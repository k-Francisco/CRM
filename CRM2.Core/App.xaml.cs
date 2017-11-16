using CRM2.Helpers;
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
            if(Settings.FedAuthToken != string.Empty && Settings.rtFaToken != string.Empty)
            {
                await NavigationService.NavigateAsync(new System.Uri("/MasterDPage/BaseNavigationPage/ActivitiesPage", System.UriKind.Absolute));
            }
            else
            {
                if (Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet)
                {
                    await NavigationService.NavigateAsync("LoginPage");
                }
                else
                {
                    await NavigationService.NavigateAsync("LoginPage");
                }
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
            Container.RegisterTypeForNavigation<LoginPage>();
        }
    }
}
