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
    public partial class ManagerPage : ContentPage
    {
        private ObservableCollection<Item> _items;
        private ObservableCollection<History> _historyItems;
        public ManagerPage(ObservableCollection<Item> items, ObservableCollection<History> historyItems)
        {
            InitializeComponent();

            _items = items;
            _historyItems = historyItems;
        }

        async void HistoryClicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new HistoryPage(_historyItems));
        }

        async void RestockClicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new RestockPage(_items));
        }

        async void AddNewProductClicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new AddNewProductPage(_items));
        }
    }
}