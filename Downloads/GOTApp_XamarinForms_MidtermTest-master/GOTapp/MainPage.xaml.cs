﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GOTapp
{
    public partial class MainPage : ContentPage
    {

        CharactersManager manager = new CharactersManager();
        ObservableCollection<CharacterClass> downloadedList =
            new ObservableCollection<CharacterClass>();

        public MainPage()
        {
            InitializeComponent();
            actorlist.RowHeight = 50;

        }

        protected async override void OnAppearing()
        {
            if (downloadedList.Count == 0)
            {
                actorlist.ItemsSource = null;
                // call downloadData function from here.
                var list = await manager.downloadData();
                downloadedList = new ObservableCollection<CharacterClass>(list);
                actorlist.ItemsSource = downloadedList;
            }
            base.OnAppearing();
        }

        async void actorlist_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            // navigate to Detail Page and passing the selected character to detail page.
            var selectedActor = e.SelectedItem as CharacterClass;
            await Navigation.PushAsync(new DetailPage(selectedActor));
        }
    }
}
