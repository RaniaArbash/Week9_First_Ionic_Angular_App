using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GOTapp
{
    public partial class DetailPage : ContentPage
    {
        CharacterClass character;
        public DetailPage(CharacterClass selectedActor)
        {
            // update this constructor to get the selected character
            // make the selected character as binding context for this page
            InitializeComponent();
            BindingContext = selectedActor;
            character = selectedActor;
        }

        // add click listener to save the rating
        private void Button_Clicked(object sender, EventArgs e)
        {
            int charRating = (int)Math.Round(ratingSlider.Value);
            character.rating = charRating; 
        }
    }
}
