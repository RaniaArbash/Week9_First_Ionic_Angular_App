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
    public partial class RestockPage : ContentPage
    {
        public RestockPage(ObservableCollection<Item> items)
        {
            InitializeComponent();

            restockList.ItemsSource = items;
        }

        void RestockClicked(System.Object sender, System.EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(Entry.Text) && !String.IsNullOrEmpty(Entry.Text) && restockList.SelectedItem != null)
            {
                (restockList.SelectedItem as Item).quantity = Entry.Text.ToString();
            } else if (String.IsNullOrEmpty(Entry.Text) && restockList.SelectedItem != null)
            {
                DisplayAlert("Error", "No quantity has been entered.", "OK");
            } else
            {
                DisplayAlert("Error", "No item has been selected.", "OK");
            }
        }

        void CancelClicked(System.Object sender, System.EventArgs e)
        {
            Entry.Text = "";
        }
    }
}