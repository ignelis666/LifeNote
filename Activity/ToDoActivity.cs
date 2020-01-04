using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using LifeNoteApp.Model;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using Firebase.Xamarin.Auth;
using Firebase.Auth;
using Android.Content;
using XamarinFirebase;

namespace LifeNoteApp
{
    [Activity(Label = "To-Do Events")]
    public class ToDoActivity : Activity
    {
       
        private ListView list_data;
        //private ProgressBar circular_progress;

        private List<ToDoItem> list_Items = new List<ToDoItem>();
        private ToDoListViewAdapter adapter;
        
        public static ToDoItem selectedToDoItem;

        string currentuser = Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid;
        private const string FirebaseURL = "https://lifenote-32743.firebaseio.com/";
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.ToDoMain);
            //View
            //circular_progress = FindViewById<ProgressBar>(Resource.Id.circularProgress);
            list_data = FindViewById<ListView>(Resource.Id.list_data);
            list_data.ItemClick += (s, e) =>
            {
                ToDoItem toDoNote = list_Items[e.Position];
                selectedToDoItem = toDoNote;
                
                Intent intent = new Intent(this, typeof(ToDoCardEdit));
                StartActivity(intent);
            };

            await LoadData();
            Button buttonAdd = FindViewById<Button>(Resource.Id.Addbtn);
            buttonAdd.Click += Addbtn_Click;

            Button buttonNext = FindViewById<Button>(Resource.Id.next);
            buttonNext.Click += Nextbtn_Click;

            Button buttonPrev = FindViewById<Button>(Resource.Id.previous);
            buttonPrev.Click += Prevbtn_Click;
        }

        private void Prevbtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CalendarActivity));
            StartActivity(intent);
        }

        private void Nextbtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(LifeNoteActivity));
            StartActivity(intent);
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(ToDoCard));
            StartActivity(intent);
        }

        private async Task LoadData()
        {
           // circular_progress.Visibility = ViewStates.Visible;
            list_data.Visibility = ViewStates.Invisible;

            var firebase = new FirebaseClient(FirebaseURL);
            var items = await firebase
                .Child(currentuser)
                .Child("ToDoNotes")
                .OnceAsync<ToDoItem>();

            list_Items.Clear();
            adapter = null;
            foreach(var item in items)
            {
                ToDoItem note = new ToDoItem();
                note.uid = item.Key;
                note.title = item.Object.title;
                note.description = item.Object.description;
                list_Items.Add(note);
                
            }
            adapter = new ToDoListViewAdapter(this, list_Items);
            adapter.NotifyDataSetChanged();
            list_data.Adapter = adapter;

            //circular_progress.Visibility = ViewStates.Invisible;
            list_data.Visibility = ViewStates.Visible;

        }


    }
}

