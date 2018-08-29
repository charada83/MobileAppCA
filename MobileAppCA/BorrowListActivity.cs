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
    [Activity(Label = "Borrow")]
    public class BorrowListActivity : Activity
    {
        private ItemAdapter itemAdapter;
        EditText txtSearch;
        ListView lvItems;
        List<Item> itemList = new List<Item>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BorrowList);
            // Create your application here

            txtSearch = FindViewById<EditText>(Resource.Id.txtSearch);
            lvItems = FindViewById<ListView>(Resource.Id.lvViewItems);

            LoadItemsFromDataStore();

            txtSearch.TextChanged += TxtSearch_TextChanged;

            itemAdapter = new ItemAdapter(this, itemList);
            lvItems.Adapter = itemAdapter;

            lvItems.ItemClick += LvItems_ItemClick;
        }

        private void LvItems_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var itemClickPosition = e.Position;
            var item = itemList[itemClickPosition] as Item;
            Intent getItem = new Intent(this, typeof(BorrowItemDetailActivity));
            getItem.PutExtra("itemName", item.ItemName.ToString());
            getItem.PutExtra("itemDescription", item.ItemDescription.ToString());
            getItem.PutExtra("itemImage", item.ImageDrawableID);

            StartActivity(getItem);
        }

        private void TxtSearch_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            var itemToLower = txtSearch.Text.ToLower();
            List<Item> searchedItems = (from item in itemList
                                        where item.ItemName.ToLower().Contains(itemToLower)
                                        select item).ToList<Item>();

            itemAdapter = new ItemAdapter(this, searchedItems);
            lvItems.Adapter = itemAdapter;

        }

        private void LoadItemsFromDataStore()
        {
            itemList.Add(new Item("Power Drill", "Powerful Tool", Resource.Drawable.powerdrill));
            itemList.Add(new Item("Wheelbarrow", "Good condition, can lend for up to 3 days", Resource.Drawable.wheelbarrow));
        }
    }
}