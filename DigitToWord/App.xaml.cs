using System;
using DigitToWord.PageModels;
using FreshMvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitToWord
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // The root page of your application  
            var mainPage = FreshPageModelResolver.ResolvePageModel<MainPageModel>();
            MainPage = new FreshNavigationContainer(mainPage);
           // MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
