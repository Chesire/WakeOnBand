using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using WakeOnBandXamarin.Core.ViewModels;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace WakeOnBandXamarin.Droid.Views
{
    [Activity()]
    public class MainActivity : MvxCachingFragmentCompatActivity<MainViewModel>
    {
        #region Fields

        private MvxActionBarDrawerToggle _drawerToggle;
        private DrawerLayout _drawerLayout;

        #endregion Fields

        #region Methods

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (_drawerToggle.OnOptionsItemSelected(item))
                return true;

            return base.OnOptionsItemSelected(item);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MainView);

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);

                _drawerToggle = new MvxActionBarDrawerToggle(
                    this,                  /* host Activity */
                    _drawerLayout,         /* DrawerLayout object */
                    toolbar,  /* nav drawer icon to replace 'Up' caret */
                    Resource.String.OpenDrawerString,  /* "open drawer" description */
                    Resource.String.CloseDrawerString  /* "close drawer" description */
                );

                _drawerLayout.SetDrawerListener(_drawerToggle);
            }

            ViewModel.ShowDefaultMenuItem();
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            _drawerToggle.SyncState();

            base.OnPostCreate(savedInstanceState);
        }

        #endregion Methods
    }
}