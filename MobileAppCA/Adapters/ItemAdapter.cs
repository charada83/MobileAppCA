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
    class ItemAdapter : BaseAdapter<Item>
    {

        Context context;
        public List<Item> ItemList { get; }

        public ItemAdapter(Context context, List<Item> items)
        {
            this.context = context;
            ItemList = items;
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
            //var view = convertView;
            //ItemAdapterViewHolder holder = null;

            //if (view != null)
            //    holder = view.Tag as ItemAdapterViewHolder;

            //if (holder == null)
            //{
            //    holder = new ItemAdapterViewHolder();
            //    var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
            //    //replace with your item and your holder items
            //    //comment back in
            //view = inflater.Inflate(Resource.Layout.item, parent, false);
            //holder.Title = view.FindViewById<TextView>(Resource.Id.text);
            //view.Tag = holder;
            // }


            //fill in your items
            //holder.Title.Text = "new text here";

            var itemInfoRowView = convertView;
            if (itemInfoRowView == null)
            {
                var inflator = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                itemInfoRowView = inflator.Inflate(Resource.Layout.BorrowListRow, parent, false);

                var itemImageView = itemInfoRowView.FindViewById<ImageView>(Resource.Id.imageViewBorrowItem);
                var lblItemNameView = itemInfoRowView.FindViewById<TextView>(Resource.Id.lblBorrowItemName);
                var lblItemDescription = itemInfoRowView.FindViewById<TextView>(Resource.Id.lblBorrowItemDescription);

                var itemViewHolder = new ItemAdapterViewHolder(itemImageView, lblItemNameView, lblItemDescription);
                
                itemInfoRowView.Tag = itemViewHolder;
            }

            var cachedItemAdapterViewHolder = itemInfoRowView.Tag as ItemAdapterViewHolder;
            cachedItemAdapterViewHolder.ItemImage.SetImageResource(ItemList[position].ImageDrawableID);
            cachedItemAdapterViewHolder.ItemName.Text = ItemList[position].ItemName;
            cachedItemAdapterViewHolder.ItemDescription.Text = ItemList[position].ItemDescription;

            return itemInfoRowView;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return ItemList.Count;
            }
        }

        public override Item this[int position] => ItemList[position];

    }

}