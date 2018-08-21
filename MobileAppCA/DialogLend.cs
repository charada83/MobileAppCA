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
    class DialogLend : DialogFragment
    {
        private EditText txtEditItemName;
        private EditText txtEditItemDescription;
        private Button btnAddItem;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var lendView = inflater.Inflate(Resource.Layout.LendDialog, container, false);

            txtEditItemName = lendView.FindViewById<EditText>(Resource.Id.txtEditItemName);
            txtEditItemDescription = lendView.FindViewById<EditText>(Resource.Id.txtEditItemDescription);
            btnAddItem = lendView.FindViewById<Button>(Resource.Id.btnAddItem);

            btnAddItem.Click += BtnAddItem_Click;
            return lendView;
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