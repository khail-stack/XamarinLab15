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
    public partial class PersonPage : ContentPage
    {

        bool isNewPerson;
        public PersonPage(bool isNew = false)
        {
            InitializeComponent();
            isNewPerson = isNew;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var todoItem = (PersonModel)BindingContext;
            await App.PersonManager.SaveTaskAsync(todoItem, isNewPerson);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var todoItem = (PersonModel)BindingContext;
            await App.PersonManager.DeleteTaskAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}