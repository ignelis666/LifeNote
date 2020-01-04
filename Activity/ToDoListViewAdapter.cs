using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using XamarinFirebase;
using LifeNoteApp.Model;

namespace LifeNoteApp
{
    class ToDoListViewAdapter : BaseAdapter
    {
        Activity activity;
        List<ToDoItem> lstItems;
        LayoutInflater inflater;
       

        public ToDoListViewAdapter(Activity activity, List<ToDoItem> lstItems)
        {
            this.activity = activity;
            this.lstItems = lstItems;
        }

        public override int Count
        {
            get
            {
                return lstItems.Count;
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
            View itemView = inflater.Inflate(Resource.Layout.ToDoList_Item, null);

            TextView txtTitle = itemView.FindViewById<TextView>(Resource.Id.list_name);
            TextView txtDescription = itemView.FindViewById<TextView>(Resource.Id.list_email);


            if (lstItems.Count > 0)
            {
                txtTitle.Text = lstItems[position].title;
                txtDescription.Text = lstItems[position].description;

            }
            return itemView;
        }
    }
}