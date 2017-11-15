using CRM2.Views;
using DLToolkit.Forms.Controls;
using Prism.Unity;
using Xamarin.Forms;

namespace CRM2
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected async override void OnInitialized()
        {
            InitializeComponent();
            FlowListView.Init();
            if (Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet)
            {
                await NavigationService.NavigateAsync("MasterDPage/BaseNavigationPage/ActivitiesPage");
            }
            else {
                await NavigationService.NavigateAsync(new System.Uri("/MasterDPage/BaseNavigationPage/ActivitiesPage", System.UriKind.Absolute));
            }
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MasterPage>();
            Container.RegisterTypeForNavigation<BaseNavigationPage>();
            Container.RegisterTypeForNavigation<MasterDPage>();
            Container.RegisterTypeForNavigation<ActivitiesPage>();
            Container.RegisterTypeForNavigation<MyTasksPage>();
            Container.RegisterTypeForNavigation<BacklogsPage>();
            Container.RegisterTypeForNavigation<PendingPage>();
            Container.RegisterTypeForNavigation<InProgressPage>();
            Container.RegisterTypeForNavigation<CompletedPage>();
            Container.RegisterTypeForNavigation<ExpensesPage>();
            Container.RegisterTypeForNavigation<CalendarPage>();
        }
    }
}
