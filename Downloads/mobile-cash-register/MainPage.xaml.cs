using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mobile_cash_register
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<History> historyItems;
        public ObservableCollection<Item> _items;

        public MainPage(ObservableCollection<Item> items)
        {
            InitializeComponent();

            _items = items;
            historyItems = new ObservableCollection<History> { };

            mylist.ItemsSource = _items;
        }

        void NumberClicked(System.Object sender, System.EventArgs e)
        {
            Button digit = (Button)sender;

            if (mylist.SelectedItem != null)
            {
                Quantity.Text = Quantity.Text == "Quantity" || Quantity.Text == "0" ? digit.Text : Quantity.Text + digit.Text;

                double total = Double.Parse(Quantity.Text) * Double.Parse((mylist.SelectedItem as Item).price);
                Total.Text = total.ToString();
            } 
            else
            {
                DisplayAlert("Notice", "Please select an item.", "OK");
            }
        }

        void BuyClicked(System.Object sender, System.EventArgs e)
        {
            if (mylist.SelectedItem != null)
            {
                int updatedQuantity = int.Parse((mylist.SelectedItem as Item).quantity) - int.Parse(Quantity.Text);

                // Check if the quantity of items are in stock
                if (updatedQuantity < 0)
                    DisplayAlert("Error", "The amount of items selected exceeds the amount in stock.", "OK");
                else
                {
                    (mylist.SelectedItem as Item).quantity = updatedQuantity.ToString();

                    string msg = Quantity.Text
                                    + " selection(s) of " + (mylist.SelectedItem as Item).name
                                    + " have been bought for $" + (mylist.SelectedItem as Item).price
                                    + " each for a total of $" + Total.Text + ".";

                    DisplayAlert("Item(s) Bought", msg, "OK");

                    // Make new history item
                    var tempHistoryItem = new History(Type.Text, Quantity.Text, Total.Text, DateTime.Now.ToString());
                    historyItems.Add(tempHistoryItem);

                    Type.Text = "Type";
                }

                Quantity.Text = "Quantity";
                Total.Text = "Total";
            } 
            else
            {
                DisplayAlert("Error", "No item has been selected.", "OK");
            }
        }

        void mylist_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Type.Text = (e.SelectedItem as Item).name;
        }

        async void ManagerClicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new ManagerPage(_items, historyItems));
        }
    }
}
