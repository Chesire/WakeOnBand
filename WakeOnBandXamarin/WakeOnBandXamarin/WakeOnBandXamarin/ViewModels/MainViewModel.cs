using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using WakeOnBandXamarin.Core.Models;

namespace WakeOnBandXamarin.Core.ViewModels
{
    /// <summary>
    /// The first part of the application, contains the NavigationDrawer
    /// </summary>
    public class MainViewModel : MvxViewModel
    {
        #region Fields

        private MvxCommand<MenuItem> _itemSelectedCommand;

        #endregion Fields

        #region Constructor

        public MainViewModel()
        {
            MenuItems = new ObservableCollection<MenuItem>();

            MenuItems.Add(new MenuItem() { Title = "WoL Devices", ViewModelType = typeof(Test1ViewModel), ImageName = "ic_wifi_black_24dp" });
            MenuItems.Add(new MenuItem() { Title = "Band Devices", ViewModelType = typeof(Test2ViewModel), ImageName = "ic_watch_black_24dp" });
        }

        #endregion Constructor

        #region Properties

        public ObservableCollection<MenuItem> MenuItems { get; private set; }

        public IMvxCommand ItemSelectedCommand
        {
            get
            {
                _itemSelectedCommand = _itemSelectedCommand ?? new MvxCommand<MenuItem>(MenuAction);
                return _itemSelectedCommand;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Shows the first view that should be displayed
        /// </summary>
        public void ShowDefaultMenuItem()
        {
            ShowViewModel(MenuItems.FirstOrDefault().ViewModelType);
        }

        private void MenuAction(MenuItem item)
        {
            ShowViewModel(item.ViewModelType);
        }

        #endregion Methods
    }
}