using CRM2.Events;
using CRM2.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace CRM2.ViewModels
{
	public class MasterPageViewModel : BaseViewModel
	{

        private ObservableCollection<MasterPageMenuItemModel> _menuItems = new ObservableCollection<MasterPageMenuItemModel>() {
                new MasterPageMenuItemModel(){ menuIcon = "ic_activities.png", menuName = "Activities", IsSelected = true},
                new MasterPageMenuItemModel(){ menuIcon = "ic_mytasks.png", menuName = "My Tasks", IsSelected = false},
                new MasterPageMenuItemModel(){ menuIcon = "ic_backlogs.png", menuName = "Backlogs", IsSelected = false},
                new MasterPageMenuItemModel(){ menuIcon = "ic_pending.png", menuName = "Pending", IsSelected = false},
                new MasterPageMenuItemModel(){ menuIcon = "ic_inprogress.png", menuName = "In Progress", IsSelected = false},
                new MasterPageMenuItemModel(){ menuIcon = "ic_completed.png", menuName = "Completed", IsSelected = false},
                new MasterPageMenuItemModel(){ menuIcon = "ic_expenses.png", menuName = "Expenses", IsSelected = false},
                new MasterPageMenuItemModel(){ menuIcon = "ic_calendar.png", menuName = "Calendar", IsSelected = false}
        };
        public ObservableCollection<MasterPageMenuItemModel> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }

        private MasterPageMenuItemModel _selectedIndex;
        public MasterPageMenuItemModel SelectedIndex
        {
            get { return _selectedIndex; }
            set { SetProperty(ref _selectedIndex, value); }
        }

        private DelegateCommand<MasterPageMenuItemModel> _itemSelected;
        public DelegateCommand<MasterPageMenuItemModel> ItemSelectedCommand =>
            _itemSelected ?? (_itemSelected = new DelegateCommand<MasterPageMenuItemModel>(ExecuteItemSelectedCommand));

        private MasterPageMenuItemModel oldMenuItem;
        private readonly IEventAggregator eventAggregator;

        void ExecuteItemSelectedCommand(MasterPageMenuItemModel parameter)
        {
            oldMenuItem.IsSelected = false;
            oldMenuItem = parameter;
            oldMenuItem.IsSelected = true;

            var path = "";
            if (parameter.menuName.Equals("Activities"))
            {
                path = "BaseNavigationPage/ActivitiesPage";
            }
            else if(parameter.menuName.Equals("My Tasks"))
            {
                path = "BaseNavigationPage/MyTasksPage";
            }
            else if (parameter.menuName.Equals("Backlogs"))
            {
                path = "BaseNavigationPage/BacklogsPage";
            }
            else if (parameter.menuName.Equals("Pending"))
            {
                path = "BaseNavigationPage/PendingPage";
            }
            else if(parameter.menuName.Equals("In Progress"))
            {
                path = "BaseNavigationPage/InProgressPage";
            }
            else if (parameter.menuName.Equals("Completed"))
            {
                path = "BaseNavigationPage/CompletedPage";
            }
            else if (parameter.menuName.Equals("Expenses"))
            {
                path = "BaseNavigationPage/ExpensesPage";
            }
            else if (parameter.menuName.Equals("Calendar"))
            {
                path = "BaseNavigationPage/CalendarPage";
            }

            eventAggregator.GetEvent<MasterNavigationEvent>().Publish(path);
        }

        public MasterPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator):base(navigationService)
        {
            SelectedIndex = oldMenuItem = MenuItems.FirstOrDefault();
            this.eventAggregator = eventAggregator;
        }

    }
}
