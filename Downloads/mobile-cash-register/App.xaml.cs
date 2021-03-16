using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace mobile_cash_register
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ObservableCollection<Item> items = new ObservableCollection<Item>
            {
                new Item(){name = "Pants", quantity ="20", price ="50.7"},
                new Item(){name = "Shoes", quantity="50", price ="90"},
                new Item(){name = "Hats", quantity="10", price ="20.5"},
                new Item(){name = "Tshirts", quantity="10", price ="10"},
                new Item(){name = "Dresses", quantity="24", price ="10"},
            };

            MainPage = new MainPage(items);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
