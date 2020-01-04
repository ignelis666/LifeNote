using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;
using XamarinFirebase;
using LifeNoteApp.Model;

namespace LifeNoteApp
{
    class LifeNoteListViewAdapter : BaseAdapter
    {
        Activity activity;
        List<LifeNoteItem> lstAccounts;
        LayoutInflater inflater;


        public LifeNoteListViewAdapter(Activity activity, List<LifeNoteItem> lstAccounts)
        {
            this.activity = activity;
            this.lstAccounts = lstAccounts;
        }

        public override int Count
        {
            get
            {
                return lstAccounts.Count;
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
            View itemView = inflater.Inflate(Resource.Layout.LifeNoteList_Item, null);


            TextView txtTitle = itemView.FindViewById<TextView>(Resource.Id.list_name);
            TextView txtDescription = itemView.FindViewById<TextView>(Resource.Id.list_email);
            TextView txtDate = itemView.FindViewById<TextView>(Resource.Id.Date);
            TextView txtTime = itemView.FindViewById<TextView>(Resource.Id.Time);

            ImageView image = itemView.FindViewById<ImageView>(Resource.Id.Image);

            if (lstAccounts.Count > 0)
            {
                //txtUser.Text = lstAccounts[position].name;
                //txtEmail.Text = lstAccounts[position].email;
                txtTitle.Text = lstAccounts[position].title;
                txtDescription.Text = lstAccounts[position].description;
                txtDate.Text = lstAccounts[position].date;
                txtTime.Text = lstAccounts[position].time;
                image = lstAccounts[position].image;

            }
            return itemView;
        }
    }
}