using CRUD_Xamarin.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CRUD_Xamarin.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public Task GoBasckAsync()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task NavigateToAsync<TPageModel>(object navigationData = null, bool setRoot = false) where TPageModel : PageModelBase
        {
            var page = PageModelLocator.CreatePageFor(typeof(TPageModel));

            if (setRoot)
            {
                if(page is TabbedPage tabbed)
                {
                    App.Current.MainPage = tabbed;
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
              
            }
            else
            {
                if(page is TabbedPage tabePage)
                {
                    App.Current.MainPage = tabePage;
                }
                else if (App.Current.MainPage is NavigationPage navPage)
                {
                    await navPage.PushAsync(page);
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
            }

            if(page.BindingContext is PageModelBase pmBase)
            {
                await pmBase.InitializeAsync(navigationData);
            }
           
        }
    }
}
