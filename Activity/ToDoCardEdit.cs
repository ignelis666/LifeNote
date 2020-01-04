
using Android.App;
using Android.Icu.Util;
using Android.OS;
using Android.Widget;
using Com.Wdullaer.Materialdatetimepicker.Time;
using Firebase.Auth;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinFirebase;
using LifeNoteApp.Model;

namespace LifeNoteApp
{
    [Activity(Label = "To Do Card Edit")]
    public class ToDoCardEdit : Activity
    {
        private EditText input_Title, input_Description;

        private List<ToDoItem> list_users = new List<ToDoItem>();
        private ToDoListViewAdapter adapter;
        string currentuser = FirebaseAuth.Instance.CurrentUser.Uid;
        private const string FirebaseURL = "https://lifenote-32743.firebaseio.com/";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ToDoCardEdit);

            input_Title = FindViewById<EditText>(Resource.Id.titleEditText);
            input_Title.Text = ToDoActivity.selectedToDoItem.title;

            input_Description = FindViewById<EditText>(Resource.Id.desciptionEditText);
            input_Description.Text = ToDoActivity.selectedToDoItem.description;



            Button saveButton = FindViewById<Button>(Resource.Id.SaveChangesbtn);
            saveButton.Click += SaveChangesbtn_Click;

            Button cancelbtn = FindViewById<Button>(Resource.Id.CancelEventbtn);
            cancelbtn.Click += CancelEventbtn_Click;

            Button deleteBtn = FindViewById<Button>(Resource.Id.DeleteEventbtn);
            deleteBtn.Click += Deletebtn_Click;

            CheckBox shareBtn = FindViewById<CheckBox>(Resource.Id.shareCheckBox);
        }


        private void Share_Check(object sender, EventArgs e)
        {

        }

        private void SaveChangesbtn_Click(object sender, EventArgs e)
        {

            UpdateToDoNote(ToDoActivity.selectedToDoItem.uid, input_Title.Text, input_Description.Text);
            Finish();
        }

        private async void Deletebtn_Click(object sender, EventArgs e)
        {
            DeleteUser(ToDoActivity.selectedToDoItem.uid);
            await LoadData();
            Finish();
        }
        private async void DeleteUser(string uid)
        {
            var firebase = new FirebaseClient(FirebaseURL);

            await firebase.Child(currentuser).Child("ToDoNotes").Child(uid).DeleteAsync();
            await LoadData();
        }
        private async Task LoadData()
        {

            var firebase = new FirebaseClient(FirebaseURL);
            var items = await firebase
                .Child(currentuser)
                .Child("ToDoNotes")
                .OnceAsync<ToDoItem>();

            list_users.Clear();
            adapter = null;
            foreach (var item in items)
            {
                ToDoItem note = new ToDoItem();
                note.uid = item.Key;
                note.title = item.Object.title;
                note.description = item.Object.description;

                list_users.Add(note);

            }
            adapter = new ToDoListViewAdapter(this, list_users);
            adapter.NotifyDataSetChanged();
            //  list_data.Adapter = adapter;

        }


        private void CancelEventbtn_Click(object sender, EventArgs a)
        {
            this.Finish();
        }


        private async void UpdateToDoNote(string uid, string title, string description)
        {
            var firebase = new FirebaseClient(FirebaseURL);
            await firebase.Child(currentuser).Child("ToDoNotes").Child(uid).Child("title").PutAsync(title);
            await firebase.Child(currentuser).Child("ToDoNotes").Child(uid).Child("description").PutAsync(description);
        }
    }



}