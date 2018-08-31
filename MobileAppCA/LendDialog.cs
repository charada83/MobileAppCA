using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MobileAppCA.DataAccess;

namespace MobileAppCA
{
    public class LendDialog : DialogFragment
    {
        DBStore database = new DBStore();

        private EditText txtEditItemName;
        private EditText txtEditItemDescription;
        private ImageView imgUpload;
        private Button btnAddImage;
        private Button btnAddItem;
        private Button btnCancel;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            base. OnCreateView(inflater, container, savedInstanceState);

            var lendView = inflater.Inflate(Resource.Layout.LendDialog, container, false);

            txtEditItemName = lendView.FindViewById<EditText>(Resource.Id.txtEditItemName);
            txtEditItemDescription = lendView.FindViewById<EditText>(Resource.Id.txtEditItemDescription);
            imgUpload = lendView.FindViewById<ImageView>(Resource.Id.imgUpload);
            btnAddImage = lendView.FindViewById<Button>(Resource.Id.btnAddImage);
            btnAddItem = lendView.FindViewById<Button>(Resource.Id.btnAddItem);
            btnCancel = lendView.FindViewById<Button>(Resource.Id.btnCancel);

            btnAddItem.Click += BtnAddItem_Click;

            return lendView;

        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            Item item = new Item()
            {
                ItemName = txtEditItemName.Text,
                ItemDescription = txtEditItemDescription.Text          
            };

            database.InsertIntoTableItem(item);
            //Toast.MakeText(Activity, "You item has been added", ToastLength.Long).Show();
        }
    }
}