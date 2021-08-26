using CRUD_Xamarin.PageModels.Base;
using CRUD_Xamarin.Services.Account;
using CRUD_Xamarin.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUD_Xamarin.PageModels
{
    public class LoginPageModel : PageModelBase
    {
        private ICommand _signCommand;

        public ICommand SignInCommand
        {
            get => _signCommand;
            set => SetProperty(ref _signCommand, value);
        }

        private string _username;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        private INavigationService _navigationService;
        private IAccountService _accountService;
        public LoginPageModel(INavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;

            SignInCommand = new Command(OnSignInAction);
        }

        private async void OnSignInAction(object obj)
        {
            var loginAttempt = await _accountService.LoginAsync(Username, Password);
            if (loginAttempt)
            {
                await _navigationService.NavigateToAsync<DashboardPageModel>();
            }
            else
            {

            }
           
        }
    }
}
