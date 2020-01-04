using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using LifeNoteApp.Model;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using Android.Content;
using XamarinFirebase;

namespace LifeNoteApp
{
    [Activity(Label = "Calendar Events")]
    public class CalendarActivity : Activity
    {
        private ListView list_data;

        //private ProgressBar circular_progress;

        readonly string currentuser = Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid;

        private readonly List<CalendarItem> list_Items = new List<CalendarItem>();
        private CalendarListViewAdapter adapter;
        public static CalendarItem selectedCalendarItem;
        //Firebase.Auth.FirebaseAuth auth;


        private const string FirebaseURL = "https://lifenote-32743.firebaseio.com/";
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CalendarMain);
           
            //View
           // circular_progress = FindViewById<ProgressBar>(Resource.Id.circularProgress);
            list_data = FindViewById<ListView>(Resource.Id.list_data);
            
            list_data.ItemClick += (s, e) =>
            {
                CalendarItem cNote = list_Items[e.Position];
                selectedCalendarItem = cNote;

                Intent intent = new Intent(this, typeof(CalendarCardEdit));
                StartActivity(intent);

            };
            await LoadData();
            Button buttonAdd = FindViewById<Button>(Resource.Id.Addbtn);
            buttonAdd.Click += Addbtn_Click;

            Button buttonNext = FindViewById<Button>(Resource.Id.next);
            buttonNext.Click += Nextbtn_Click;

            Button buttonPrev = FindViewById<Button>(Resource.Id.previous);
            buttonPrev.Click += Prevbtn_Click;
            ///Button buttonLogout = FindViewById<Button>(Resource.Id.btn_logout);
            //buttonLogout.Click += logout_Click;

        }

        private void logout_Click(object sender, EventArgs e)
        {
            LogoutUser();
        }
        private void LogoutUser()
        {
            //auth.SignOut();
            //if (auth.CurrentUser == null)
            //{
            //    StartActivity(new Intent(this, typeof(MainActivity)));
            //    Finish();
            //}
        }

        private void Prevbtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(LifeNoteActivity));
            StartActivity(intent);
        }

        private void Nextbtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ToDoActivity));
            StartActivity(intent);
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(CalendarCard));
            StartActivity(intent);
        }

        private async Task LoadData()
        {
           // circular_progress.Visibility = ViewStates.Visible;
            list_data.Visibility = ViewStates.Invisible;

            var firebase = new FirebaseClient(FirebaseURL);
            var items = await firebase
                .Child(currentuser)
                .Child("CalendarNotes")
                .OnceAsync<CalendarItem>();

            list_Items.Clear();
            adapter = null;
            foreach (var item in items)
            {
                CalendarItem note = new CalendarItem
                {
                    uid = item.Key,
                    title = item.Object.title,
                    description = item.Object.description,
                    date = item.Object.date,
                    time = item.Object.time
                };
                list_Items.Add(note);
                

            }
            adapter = new CalendarListViewAdapter(this, list_Items);
            adapter.NotifyDataSetChanged();
            list_data.Adapter = adapter;

            //circular_progress.Visibility = ViewStates.Invisible;
            list_data.Visibility = ViewStates.Visible;

        }
    }
}

