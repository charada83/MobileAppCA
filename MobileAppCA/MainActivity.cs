using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace MobileAppCA
{
    [Activity(Label = "LocalLend", MainLauncher = true)]
    public class MainActivity : Activity
    {
        TextView lblTitle;
        Button btnBorrow;
        Button btnLend;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            lblTitle = FindViewById<TextView>(Resource.Id.lblTitle);
            btnBorrow = FindViewById<Button>(Resource.Id.btnBorrow);
            btnLend = FindViewById<Button>(Resource.Id.btnLend);

            btnBorrow.Click += BtnBorrow_Click;
            btnLend.Click += BtnLend_Click;


        }

        private void BtnLend_Click(object sender, System.EventArgs e)
        {
            //Look into more
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            DialogLend lendDialog = new DialogLend();
            lendDialog.Show(transaction, "dialog fragment");
        }

        private void BtnBorrow_Click(object sender, System.EventArgs e)
        {
            Intent showBorrowList = new Intent(this, typeof(BorrowListActivity));
            StartActivity(showBorrowList);
        }
    }
}

