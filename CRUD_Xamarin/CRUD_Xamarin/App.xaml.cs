using CRUD_Xamarin.PageModels;
using CRUD_Xamarin.PageModels.Base;
using CRUD_Xamarin.Services.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_Xamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
        }

        Task InitNavigation()
        {
            var navService = PageModelLocator.Resolve<INavigationService>();

            return navService.NavigateToAsync<LoginPageModel>();
        }
        protected override async void OnStart()
        {
            await InitNavigation();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
