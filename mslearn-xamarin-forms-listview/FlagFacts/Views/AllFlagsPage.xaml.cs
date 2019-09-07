using System;
using System.Collections.Generic;
using FlagData;
using Xamarin.Forms;

namespace FlagFacts.Views
{
    public partial class AllFlagsPage : ContentPage
    {
        public AllFlagsPage()
        {
            InitializeComponent();

            BindingContext = DependencyService.Resolve<FlagDetailsViewModel>();
        }


        //eventos
        async void OnItemTapped(object sender, ElementEventArgs args)
        {
            await this.Navigation.PushAsync(new FlagDetailsPage());
        }
    }
}
