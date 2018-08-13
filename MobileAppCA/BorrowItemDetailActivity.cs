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
    [Activity(Label = "BorrowItemDetailActivity")]
    public class BorrowItemDetailActivity : Activity
    {
        ImageView imgItemPhoto;
        TextView txtItemName;
        TextView txtItemDescription;
        Button btnContactLender;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BorrowItemDetail);
            // Create your application here

            imgItemPhoto = FindViewById<ImageView>(Resource.Id.imgItemPhoto);
            txtItemName = FindViewById<TextView>(Resource.Id.lblItemName);
            txtItemDescription = FindViewById<TextView>(Resource.Id.lblItemDescription);
            btnContactLender = FindViewById<Button>(Resource.Id.btnContactLender);
        }
    }
}