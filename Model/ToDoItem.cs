using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LifeNoteApp.Model
{
    public class ToDoItem
    {
        public string uid { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool IsShared { get; set; }
    }
}