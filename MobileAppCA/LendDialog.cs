using System;
using System.Collections.Generic;
using System.IO;
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
    class LendDialog : DialogFragment
    {
        private EditText txtEditItemName;
        private EditText txtEditItemDescription;
        private ImageButton imgUpload;
        private Button btnAddItem;
        private Button btnCancel;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var lendView = inflater.Inflate(Resource.Layout.LendDialog, container, false);

            txtEditItemName = lendView.FindViewById<EditText>(Resource.Id.txtEditItemName);
            txtEditItemDescription = lendView.FindViewById<EditText>(Resource.Id.txtEditItemDescription);
            imgUpload = lendView.FindViewById<ImageButton>(Resource.Id.imgUpload);
            btnAddItem = lendView.FindViewById<Button>(Resource.Id.btnAddItem);
            btnCancel = lendView.FindViewById<Button>(Resource.Id.btnCancel);

            btnAddItem.Click += BtnAddItem_Click;
            btnCancel.Click += BtnCancel_Click;
            imgUpload.Click += ImgUpload_Click;
            return lendView;
        }

        private void ImgUpload_Click(object sender, EventArgs e)
        {
            Intent uploadImageIntent = new Intent(Intent.ActionPick, Android.Provider.MediaStore.Images.Media.ExternalContentUri);
            StartActivityForResult(uploadImageIntent, 200);
            
        }

        public override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if ((requestCode == 200) && (resultCode == Result.Ok))
            {
                Android.Net.Uri selectedImage = data.Data;
                imgUpload.SetImageURI(selectedImage);
            }  
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Dismiss();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            //Intent addToBorrowList = new Intent(this, typeof(BorrowListActivity));
            //addToBorrowList.PutExtra("txtName", txtEditItemName.Text);
            //StartActivityForResult(addToBorrowList, 100);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            
        }
    }
}