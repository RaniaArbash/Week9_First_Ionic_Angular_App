using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile_cash_register
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewProductPage : ContentPage
    {
        private ObservableCollection<Item> _items;
        public AddNewProductPage(ObservableCollection<Item> items)
        {
            InitializeComponent();

            _items = items;
        }

        async void SaveClicked(System.Object sender, System.EventArgs e)
        {
            string name = Name.Text;
            string price = Price.Text;
            string quantity = Quantity.Text;

            _items.Add(new Item(name, price, quantity));

            await Navigation.PushModalAsync(new MainPage(_items));
        }
    }
}