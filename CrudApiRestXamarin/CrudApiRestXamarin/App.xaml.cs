using CrudApiRestXamarin.Data;
using CrudApiRestXamarin.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudApiRestXamarin
{
    public partial class App : Application
    {
        public static PersonManager PersonManager { get; private set; }
        public App()
        {
            InitializeComponent();

            PersonManager = new PersonManager(new RestService());
            MainPage = new NavigationPage(new PersonListPage());
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
