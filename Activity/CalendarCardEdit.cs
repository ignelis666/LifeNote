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
    [Activity(Label = "Calendar Card Edit")]
    public class CalendarCardEdit : Activity, Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog.IOnDateSetListener, Com.Wdullaer.Materialdatetimepicker.Time.TimePickerDialog.IOnTimeSetListener
    {
        private EditText input_Title, input_Description;
        private TextView time, date;

        Button datePicker_btn, timePicker_btn;

        string currentuser = FirebaseAuth.Instance.CurrentUser.Uid;
        private List<CalendarItem> list_items = new List<CalendarItem>();
        private CalendarListViewAdapter adapter;

        private const string FirebaseURL = "https://lifenote-32743.firebaseio.com/";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CalendarCardEdit);

            input_Title = FindViewById<EditText>(Resource.Id.titleEditText);
            input_Title.Text = CalendarActivity.selectedCalendarItem.title;

            input_Description = FindViewById<EditText>(Resource.Id.desciptionEditText);
            input_Description.Text = CalendarActivity.selectedCalendarItem.description;

            time = FindViewById<TextView>(Resource.Id.Time);
            time.Text = CalendarActivity.selectedCalendarItem.time;

            date = FindViewById<TextView>(Resource.Id.Date);
            date.Text = CalendarActivity.selectedCalendarItem.date;

            datePicker_btn = FindViewById<Button>(Resource.Id.btnDatePicker);
            timePicker_btn = FindViewById<Button>(Resource.Id.btnTimePicker);

            datePicker_btn.Click += delegate
            {
                Calendar now = Calendar.Instance;
                Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog datePicker = Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog.NewInstance(
                    this,
                    now.Get(CalendarField.Year),
                    now.Get(CalendarField.Month),
                    now.Get(CalendarField.DayOfMonth));
                datePicker.SetTitle("Date Time");
                datePicker.Show(FragmentManager, "DatePicker");

            };
            timePicker_btn.Click += delegate
            {
                Calendar now = Calendar.Instance;
                Com.Wdullaer.Materialdatetimepicker.Time.TimePickerDialog timePicker = Com.Wdullaer.Materialdatetimepicker.Time.TimePickerDialog.NewInstance(
                  this,
                  now.Get(CalendarField.HourOfDay),
                  now.Get(CalendarField.Minute), true);


                timePicker.Title = "Time";
                timePicker.Show(FragmentManager, "timePicker");
            };

            Button saveButton = FindViewById<Button>(Resource.Id.SaveChangesbtn);
            saveButton.Click += SaveChangesbtn_Click;

            Button cancelbtn = FindViewById<Button>(Resource.Id.CancelEventbtn);
            cancelbtn.Click += CancelEventbtn_Click;

            Button deleteBtn = FindViewById<Button>(Resource.Id.DeleteEventbtn);
            deleteBtn.Click += Deletebtn_Click;

            CheckBox shareBtn = FindViewById<CheckBox>(Resource.Id.shareCheckBox);
        }


        //private void Share_Check(object sender, EventArgs e)
        //{

        //}

        private void SaveChangesbtn_Click(object sender, EventArgs e)
        {

            UpdateCalendarNote(CalendarActivity.selectedCalendarItem.uid, input_Title.Text, input_Description.Text, time.Text, date.Text);
            Finish();
        }

        private async void Deletebtn_Click(object sender, EventArgs e)
        {
            DeleteUser(CalendarActivity.selectedCalendarItem.uid);
            await LoadData();
            Finish();
        }
        private async void DeleteUser(string uid)
        {
            var firebase = new FirebaseClient(FirebaseURL);

            await firebase.Child(currentuser).Child("CalendarNotes").Child(uid).DeleteAsync();
            await LoadData();
        }
        private async Task LoadData()
        {

            var firebase = new FirebaseClient(FirebaseURL);
            var items = await firebase
                .Child(currentuser)
                .Child("CalendarNotes")
                .OnceAsync<CalendarItem>();

            list_items.Clear();
            adapter = null;
            foreach (var item in items)
            {
                CalendarItem note = new CalendarItem();
                note.uid = item.Key;
                note.title = item.Object.title;
                note.description = item.Object.description;
                note.date = item.Object.date;
                note.time = item.Object.time;
                list_items.Add(note);

            }
            adapter = new CalendarListViewAdapter(this, list_items);
            adapter.NotifyDataSetChanged();

        }


        private void CancelEventbtn_Click(object sender, EventArgs a)
        {
            this.Finish();
        }

        public void OnDateSet(Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog p0, int year, int month, int day)
        {
            string fuldate = year.ToString() + "/" + (month + 1).ToString()
                            + "/" + day.ToString();

            date.Text = fuldate;
            Console.WriteLine(fuldate);
        }

        public void OnTimeSet(RadialPickerLayout p0, int hour, int minute, int second)
        {

            string fultime = hour.ToString() + ":" + minute.ToString();
            time.Text = fultime;

        }

        private async void UpdateCalendarNote(string uid, string title, string description, string date, string time)
        {
            var firebase = new FirebaseClient(FirebaseURL);
            await firebase.Child(currentuser).Child("CalendarNotes").Child(uid).Child("title").PutAsync(title);
            await firebase.Child(currentuser).Child("CalendarNotes").Child(uid).Child("description").PutAsync(description);
            await firebase.Child(currentuser).Child("CalendarNotes").Child(uid).Child("date").PutAsync(date);
            await firebase.Child(currentuser).Child("CalendarNotes").Child(uid).Child("time").PutAsync(time);

        }
    }



}