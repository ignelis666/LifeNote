using Android.App;
using Android.Icu.Util;
using Android.OS;
using Android.Widget;
using Com.Wdullaer.Materialdatetimepicker.Time;
using Firebase.Auth;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using System;
using XamarinFirebase;
using LifeNoteApp.Model;

namespace LifeNoteApp
{
    [Activity(Label = "New To Do Card")]
    public class ToDoCard : Activity
    {
        private EditText input_Title, input_Description;
       

        string currentuser = FirebaseAuth.Instance.CurrentUser.Uid;

        //private CalendarItem selectedItem;

        private const string FirebaseURL = "https://lifenote-32743.firebaseio.com/";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ToDoCard);

            input_Title = FindViewById<EditText>(Resource.Id.titleEditText);
            input_Description = FindViewById<EditText>(Resource.Id.desciptionEditText);

            Button button = FindViewById<Button>(Resource.Id.AddEventbtn);
            button.Click += AddEventbtn_Click;

            Button cancelbtn = FindViewById<Button>(Resource.Id.CancelEventbtn);
            cancelbtn.Click += CancelEventbtn_Click;

            CheckBox shareBtn = FindViewById<CheckBox>(Resource.Id.shareCheckBox);
        }


        private void Share_Check(object sender, EventArgs e)
        {

        }

        private void AddEventbtn_Click(object sender, EventArgs e)
        {
            input_Title = FindViewById<EditText>(Resource.Id.titleEditText);
            input_Description = FindViewById<EditText>(Resource.Id.desciptionEditText);

            CheckBox ch = FindViewById<CheckBox>(Resource.Id.shareCheckBox);

            CreateTodo();
            Finish();

        }


        private void CancelEventbtn_Click(object sender, EventArgs a)
        {
            this.Finish();
        }

        private async void CreateTodo()
        {
            ToDoItem user = new ToDoItem();
            user.uid = String.Empty;
            user.title = input_Title.Text;
            user.description = input_Description.Text;

            // user.IsShared = ch.Checked;

            var firebase = new FirebaseClient(FirebaseURL);

            //Add item
            var item = await firebase.Child(currentuser).Child("ToDoNotes").PostAsync<ToDoItem>(user);

            // await LoadData();
        }

    }



}