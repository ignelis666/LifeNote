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
using LifeNoteApp.Model;

namespace LifeNoteApp
{
    [Activity(Label = "Life Notes Card Edit")]
    public class LifeNotesCardEdit : Activity, Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog.IOnDateSetListener, Com.Wdullaer.Materialdatetimepicker.Time.TimePickerDialog.IOnTimeSetListener
    {
        private EditText input_Title, input_Description;
        private TextView time, date;

        Button datePicker_btn, timePicker_btn;
        
        string currentuser = FirebaseAuth.Instance.CurrentUser.Uid;
        private List<LifeNoteItem> list_users = new List<LifeNoteItem>();
        private LifeNoteListViewAdapter adapter;

        private const string FirebaseURL = "https://lifenote-32743.firebaseio.com/";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LifeNoteCardEdit);

            input_Title = FindViewById<EditText>(Resource.Id.titleEditText);
            input_Title.Text = LifeNoteActivity.selectedLifeNoteItem.title;

            input_Description = FindViewById<EditText>(Resource.Id.desciptionEditText);
            input_Description.Text = LifeNoteActivity.selectedLifeNoteItem.description;

            time = FindViewById<TextView>(Resource.Id.Time);
            time.Text = LifeNoteActivity.selectedLifeNoteItem.time;

            date = FindViewById<TextView>(Resource.Id.Date);
            date.Text = LifeNoteActivity.selectedLifeNoteItem.date;

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


        private void Share_Check(object sender, EventArgs e)
        {

        }

        private void SaveChangesbtn_Click(object sender, EventArgs e)
        {

            UpdateLifeNoteItem(LifeNoteActivity.selectedLifeNoteItem.uid, input_Title.Text, input_Description.Text, time.Text, date.Text);
            Finish();
        }

        private async void Deletebtn_Click(object sender, EventArgs e)
        {
            DeleteUser(LifeNoteActivity.selectedLifeNoteItem.uid);
            await LoadData();
            Finish();
        }
        private async void DeleteUser(string uid)
        {
            var firebase = new FirebaseClient(FirebaseURL);

            await firebase.Child(currentuser).Child("LifeNotes").Child(uid).DeleteAsync();
            await LoadData();
        }
        private async Task LoadData()
        {

            var firebase = new FirebaseClient(FirebaseURL);
            var items = await firebase
                .Child(currentuser)
                .Child("LifeNotes")
                .OnceAsync<LifeNoteItem>();

            list_users.Clear();
            adapter = null;
            foreach (var item in items)
            {
                LifeNoteItem note = new LifeNoteItem();
                note.uid = item.Key;
                note.title = item.Object.title;
                note.description = item.Object.description;
                note.date = item.Object.date;
                note.time = item.Object.time;
                list_users.Add(note);

            }
            adapter = new LifeNoteListViewAdapter(this, list_users);
            adapter.NotifyDataSetChanged();
            //  list_data.Adapter = adapter;

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

        private async void UpdateLifeNoteItem(string uid, string title, string description, string date, string time)
        {
            var firebase = new FirebaseClient(FirebaseURL);
            await firebase.Child(currentuser).Child("LifeNotes").Child(uid).Child("title").PutAsync(title);
            await firebase.Child(currentuser).Child("LifeNotes").Child(uid).Child("description").PutAsync(description);
            await firebase.Child(currentuser).Child("LifeNotes").Child(uid).Child("date").PutAsync(date);
            await firebase.Child(currentuser).Child("LifeNotes").Child(uid).Child("time").PutAsync(time);
        }
    }



}