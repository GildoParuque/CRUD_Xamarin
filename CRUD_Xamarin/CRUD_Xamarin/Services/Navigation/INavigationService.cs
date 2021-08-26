using CRUD_Xamarin.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Xamarin.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateToAsync<TPageModel>(object navigationData = null, bool setRoot = false)
            where TPageModel : PageModelBase;

        Task GoBasckAsync();
    }
}
