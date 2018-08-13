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

namespace MobileAppCA
{
    class Item
    {
        public string ItemName { get; }
        public string ItemDescription { get; }
        public int ImageDrawableID { get; }

        public Item(string itemName, string itemDescription, int imageID)
        {
            ItemName = itemName;
            ItemDescription = itemDescription;
            ImageDrawableID = imageID;
        }
    }
}