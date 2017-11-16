using CRM2.Dependency;
using CRM2.Helpers;
using CRM2.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CRM2.ViewModels
{
	public class LoginPageViewModel : BindableBase
	{
        private List<string> tokens;

        private DelegateCommand _getTokenCommand;
        private readonly ITokenAuthentication tokenAuthentication;
        private readonly INavigationService navigationService;

        public DelegateCommand GetTokenCommand =>
            _getTokenCommand ?? (_getTokenCommand = new DelegateCommand(ExecuteGetTokenCommand));

        private async void ExecuteGetTokenCommand()
        {
            tokens = tokenAuthentication.GetTokens();
            if (tokens.Any())
            {
                Settings.rtFaToken = tokens[0];
                Settings.FedAuthToken = tokens[1];
                var digest = JsonConvert.DeserializeObject<FormDigestModel>(await Singleton.Instance.webServices.GetFormDigest());
                Settings.FormDigestValue = digest.D.GetContextWebInformation.FormDigestValue;
                await navigationService.NavigateAsync(new System.Uri("/MasterDPage/BaseNavigationPage/ActivitiesPage", System.UriKind.Absolute));
            }
        }

        public LoginPageViewModel(ITokenAuthentication tokenAuthentication, INavigationService navigationService)
        {
            this.tokenAuthentication = tokenAuthentication;
            this.navigationService = navigationService;
        }
	}
}
