using System.Windows.Input;
using KWops.Mobile.Services;
using KWops.Mobile.Services.Identity;

namespace KWops.Mobile.ViewModels;

public class LoginViewModel : BaseViewModel
{
    public ICommand LoginCommand { private set; get; }

    public LoginViewModel(IIdentityService iis, ITokenProvider itp, INavigationService ins, IToastService its)
    {
        LoginCommand = new Command(
            execute: () =>
            {
                RefreshCanExecutes(true);
                var login = iis.LoginAsync();
                if (login.Result.IsError)
                {
                    its.DisplayToastAsync(login.Result.ErrorDescription);
                    RefreshCanExecutes(false);
                }
                else
                {
                    itp.AuthAccessToken = login.Result.AccessToken;
                    ins.NavigateAsync("TeamsPage");
                    RefreshCanExecutes(false);
                }
            },
            canExecute: () => !IsBusy);
    }

    private void RefreshCanExecutes(bool isBusy)
    {
        IsBusy = isBusy;
        ((Command)LoginCommand).ChangeCanExecute();
    }
}