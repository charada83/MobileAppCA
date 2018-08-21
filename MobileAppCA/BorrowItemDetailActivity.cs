using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;

namespace MobileAppCA
{
    [Activity(Label = "BorrowItemDetailActivity")]
    public class BorrowItemDetailActivity : Activity
    {
        ImageView imgItemPhoto;
        TextView lblItemName;
        TextView lblItemDescription;
        Button btnContactLender;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BorrowItemDetail);
            // Create your application here

            imgItemPhoto = FindViewById<ImageView>(Resource.Id.imgItemPhoto);
            lblItemName = FindViewById<TextView>(Resource.Id.lblItemName);
            lblItemDescription = FindViewById<TextView>(Resource.Id.lblItemDescription);
            btnContactLender = FindViewById<Button>(Resource.Id.btnContactLender);

            string itemName = Intent.GetStringExtra("itemName");
            string itemDesc = Intent.GetStringExtra("itemDescription");
            int itemImage = Intent.GetIntExtra("itemImage", 0);

            lblItemName.Text = itemName.ToString();
            lblItemDescription.Text = itemDesc.ToString();
            imgItemPhoto.SetImageResource(itemImage);

            btnContactLender.Click += BtnContactLender_Click;
        }

        private void BtnContactLender_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}