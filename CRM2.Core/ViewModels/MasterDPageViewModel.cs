using CRM2.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM2.ViewModels
{
	public class MasterDPageViewModel : BaseViewModel
	{
        private readonly IEventAggregator eventAggregator;

        public MasterDPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator):base(navigationService)
        {
            this.eventAggregator = eventAggregator;
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            eventAggregator.GetEvent<MasterNavigationEvent>().Subscribe(NavigateToDetailPage);
        }

        private void NavigateToDetailPage(string obj)
        {
            _navigationService.NavigateAsync(new System.Uri(obj, UriKind.Relative));
        }
    }
}
