using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM2.ViewModels
{
	public class BaseNavigationPageViewModel : BaseViewModel
	{
        public BaseNavigationPageViewModel(INavigationService navigationService):base(navigationService)
        {

        }
	}
}
