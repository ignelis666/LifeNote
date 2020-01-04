using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Icu.Util;
using Android.Gms.Tasks;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Widget;
using Com.Wdullaer.Materialdatetimepicker.Time;
using Firebase;
using Firebase.Storage;
using Firebase.Xamarin.Database;
using Java.IO;
using System;
using XamarinFirebase;
using LifeNoteApp.Model;
using Firebase.Xamarin.Database.Query;
using Firebase.Auth;

namespace LifeNoteApp
{
    [Activity(Label = "New Life Note Card")]
    public class LifeNoteCard : Activity, Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog.IOnDateSetListener, Com.Wdullaer.Materialdatetimepicker.Time.TimePickerDialog.IOnTimeSetListener, IOnProgressListener, IOnSuccessListener, IOnFailureListener
    {
        private EditText input_Title, input_Description;
        private TextView time, date;
        private ImageView image;
        private int PICK_IMAGE_REQUEST = 71;
        private Android.Net.Uri filePath;

        Button datePicker_btn, timePicker_btn,imagePicker_btn;
        //private CalendarItem selectedItem;
        FirebaseStorage storage;
        StorageReference storageRef;
        //ProgressDialog progressDialog;
        string currentuser = FirebaseAuth.Instance.CurrentUser.Uid;
        private const string FirebaseURL = "https://lifenote-32743.firebaseio.com/";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LifeNoteCard);
            
            FirebaseApp.InitializeApp(this);
            storage = FirebaseStorage.Instance;
            storageRef = storage.GetReferenceFromUrl("gs://lifenote-32743.appspot.com/");
           
            
            input_Title = FindViewById<EditText>(Resource.Id.titleEditText);
            input_Description = FindViewById<EditText>(Resource.Id.desciptionEditText);
            time = FindViewById<TextView>(Resource.Id.Time);
            date = FindViewById<TextView>(Resource.Id.Date);
            datePicker_btn = FindViewById<Button>(Resource.Id.btnDatePicker);
            timePicker_btn = FindViewById<Button>(Resource.Id.btnTimePicker);
            imagePicker_btn = FindViewById<Button>(Resource.Id.pickImageBtn);
            image = FindViewById<ImageView>(Resource.Id.pickedImage);

            imagePicker_btn.Click += delegate {
                ChooseImage();
            };

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

        private void ChooseImage()
        {
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(intent,"Select picture"),PICK_IMAGE_REQUEST);
                
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if(requestCode == PICK_IMAGE_REQUEST && resultCode == Result.Ok && data != null && data.Data != null)
            {
                filePath = data.Data;
                try
                {
                    Bitmap bitmap = MediaStore.Images.Media.GetBitmap(ContentResolver, filePath);
                    image.SetImageBitmap(bitmap);
                }
                catch(IOException ex)
                {
                    ex.PrintStackTrace();
                }

            }
        }

        private void Share_Check(object sender, EventArgs e)
        {

        }

        private void AddEventbtn_Click(object sender, EventArgs e)
        {
            input_Title = FindViewById<EditText>(Resource.Id.titleEditText);
            input_Description = FindViewById<EditText>(Resource.Id.desciptionEditText);
            time = FindViewById<TextView>(Resource.Id.Time);
            date = FindViewById<TextView>(Resource.Id.Date);

            CheckBox ch = FindViewById<CheckBox>(Resource.Id.shareCheckBox);

            CreateUser();
            UploadImage();
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
            //Console.WriteLine(fuldate);
        }

        public void OnTimeSet(RadialPickerLayout p0, int hour, int minute, int second)
        {

            string fultime = hour.ToString() + ":" + minute.ToString();
            time.Text = fultime;

        }
        private async void CreateUser()
        {
            LifeNoteItem user = new LifeNoteItem();
            user.uid = string.Empty;
            user.title = input_Title.Text;
            user.description = input_Description.Text;
            user.time = time.Text;
            user.date = date.Text;
            // user.IsShared = ch.Checked;
            //UploadImage();
            var firebase = new FirebaseClient(FirebaseURL);

            //Add item
            var item = await firebase.Child(currentuser).Child("LifeNotes").PostAsync<LifeNoteItem>(user);

            // await LoadData();
        }

        private void UploadImage()
        {
            if(filePath != null)
            {
               // progressDialog = new ProgressDialog(this);
               // progressDialog.SetTitle("Uploading...");
               //// progressDialog.Window.SetType(Android.Views.WindowManagerTypes.SystemAlert);
               // progressDialog.Show();

                var images = storageRef.Child("images/"+Guid.NewGuid().ToString());
                images.PutFile(filePath)
                .AddOnProgressListener(this)
                .AddOnSuccessListener(this)
                .AddOnFailureListener(this);

            }
        }

        //public void OnProgress(Java.Lang.Object snapshot)
        //{
           
        //}
        public void OnSuccess(Java.Lang.Object result)
        {
           // progressDialog.Dismiss();
            Toast.MakeText(this, "Uploaded Successful", ToastLength.Short).Show();
        }
        public void OnFailure(Java.Lang.Exception e)
        {
            //progressDialog.Dismiss();
            Toast.MakeText(this, "" + e.Message, ToastLength.Short).Show();
        }

        public void snapshot(Java.Lang.Object snapshot)
        {
            var taskSnapShot = (UploadTask.TaskSnapshot)snapshot;
            double progress = (100.0 * taskSnapShot.BytesTransferred / taskSnapShot.TotalByteCount);
           // progressDialog.SetMessage("Uploaded " + (int)progress + " %");
        }
    }


}