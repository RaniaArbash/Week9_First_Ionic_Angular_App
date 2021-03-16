using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile_cash_register
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class HistoryDetailsPage : ContentPage
    {
            History _historyItem;
        public HistoryDetailsPage(History historyItem)
        {
            InitializeComponent();

            _historyItem = historyItem;

            Type.Text = historyItem.name;
            Quantity.Text = historyItem.quantity;
            PurchaseDate.Text = historyItem.purchaseDate;
            TotalPrice.Text = historyItem.totalPrice;
        }
    }
}