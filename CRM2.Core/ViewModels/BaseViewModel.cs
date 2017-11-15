﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM2.ViewModels
{
	public class BaseViewModel : BindableBase, INavigationAware
	{
        protected readonly INavigationService _navigationService;
        public DelegateCommand<string> NavigateCommand { get; set; }
        
        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private async void Navigate(string name) {
            await _navigationService.NavigateAsync(name);
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
         
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
         
        }
    }
}
