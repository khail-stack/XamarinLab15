using CrudApiRestXamarin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudApiRestXamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonListPage : ContentPage
    {
        public PersonListPage()
        {
            InitializeComponent();
            //GetProducts();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listViewPersons.ItemsSource = await App.PersonManager.GetTasksAsync();
        }


        async void OnAddItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonPage(true)
            {
                BindingContext = new PersonModel
                {
                    _id = Guid.NewGuid().ToString()
                }
            });
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new PersonPage
            {
                BindingContext = e.SelectedItem as PersonModel
            });
        }
    }
}