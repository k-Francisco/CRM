using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM2.Models
{
    public class MasterPageMenuItemModel : BindableBase
    {
        public string menuIcon { get; set; }
        public string menuName { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }

    }
}
