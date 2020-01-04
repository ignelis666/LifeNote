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
    [Activity(Label = "New Calendar Card")]
    public class CalendarCard : Activity, Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog.IOnDateSetListener, Com.Wdullaer.Materialdatetimepicker.Time.TimePickerDialog.IOnTimeSetListener
    {
        private EditText input_Title, input_Description;
        private TextView time, date;

        Button datePicker_btn, timePicker_btn;
        string currentuser = FirebaseAuth.Instance.CurrentUser.Uid;
        

        private const string FirebaseURL = "https://lifenote-32743.firebaseio.com/";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CalendarCard);

           input_Title = FindViewById<EditText>(Resource.Id.titleEditText);
            input_Description = FindViewById<EditText>(Resource.Id.desciptionEditText);
            time = FindViewById<TextView>(Resource.Id.Time);
            date = FindViewById<TextView>(Resource.Id.Date);
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

            Button button = FindViewById<Button>(Resource.Id.AddEventbtn);
            button.Click += AddEventbtn_Click;

            Button cancelbtn = FindViewById<Button>(Resource.Id.CancelEventbtn);
            cancelbtn.Click += CancelEventbtn_Click;

            CheckBox shareBtn = FindViewById<CheckBox>(Resource.Id.shareCheckBox);
        }


        //private void Share_Check(object sender, EventArgs e)
        //{

        //}

        private void AddEventbtn_Click(object sender, EventArgs e)
        {
            input_Title = FindViewById<EditText>(Resource.Id.titleEditText);
            input_Description = FindViewById<EditText>(Resource.Id.desciptionEditText);
            time = FindViewById<TextView>(Resource.Id.Time);
            date = FindViewById<TextView>(Resource.Id.Date);

            CheckBox ch = FindViewById<CheckBox>(Resource.Id.shareCheckBox);

            CreateNote();
            Finish();

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
        private async void CreateNote()
        {
            CalendarItem noteItem = new CalendarItem();
            noteItem.uid = String.Empty;
            noteItem.title = input_Title.Text;
            noteItem.description = input_Description.Text;
            noteItem.time = time.Text;
            noteItem.date = date.Text;
          // user.IsShared = ch.Checked;

            var firebaseurl = new FirebaseClient(FirebaseURL);
            string email = MainActivity.input_email.Text;
            //Console.WriteLine(MainActivity.input_email.Text);
            //Add item
           
            Console.WriteLine(currentuser.ToString());
            var item = await firebaseurl.Child(currentuser).Child("CalendarNotes").PostAsync<CalendarItem>(noteItem);

           // await LoadData();
        }

    }



}