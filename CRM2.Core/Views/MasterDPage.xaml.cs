using Prism.Navigation;
using Xamarin.Forms;

namespace CRM2.Views
{
    public partial class MasterDPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public MasterDPage()
        {
            InitializeComponent();
        }

        public bool IsPresentedAfterNavigation { get { return false; } }
    }
}