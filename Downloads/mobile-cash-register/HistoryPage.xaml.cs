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
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage(ObservableCollection<History> historyItems)
        {
            InitializeComponent();

            historyList.ItemsSource = historyItems;
        }
        async void historyList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new HistoryDetailsPage(e.SelectedItem as History));
        }
    }
}