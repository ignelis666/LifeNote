using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using XamarinFirebase;
using LifeNoteApp.Model;

namespace LifeNoteApp
{
    class CalendarListViewAdapter : BaseAdapter
    {
        Activity activity;

        List<CalendarItem> lstCalNotes;
        LayoutInflater inflater;


        public CalendarListViewAdapter(Activity activity, List<CalendarItem> lstAccounts)
        {
            this.activity = activity;
            this.lstCalNotes = lstAccounts;
        }

        public override int Count
        {
            get
            {
                return lstCalNotes.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            inflater = (LayoutInflater)activity.BaseContext.GetSystemService(Context.LayoutInflaterService);
            View itemView = inflater.Inflate(Resource.Layout.CalendarList_Item, null);
            TextView txtTitle = itemView.FindViewById<TextView>(Resource.Id.list_name);
            TextView txtDescription = itemView.FindViewById<TextView>(Resource.Id.list_email);
            TextView txtDate = itemView.FindViewById<TextView>(Resource.Id.Date);
            TextView txtTime = itemView.FindViewById<TextView>(Resource.Id.Time);

            if (lstCalNotes.Count > 0)
            {
                txtTitle.Text = lstCalNotes[position].title;
                txtDescription.Text = lstCalNotes[position].description;
                txtDate.Text = lstCalNotes[position].date;
                txtTime.Text = lstCalNotes[position].time;

            }
            return itemView;
        }
    }
}