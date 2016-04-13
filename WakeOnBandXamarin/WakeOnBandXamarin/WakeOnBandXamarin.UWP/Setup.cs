using MvvmCross.Core.ViewModels;
using MvvmCross.WindowsUWP.Platform;
using Windows.UI.Xaml.Controls;

namespace WakeOnBandXamarin.UWP
{
    public class Setup : MvxWindowsSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new WakeOnBandXamarin.App();
        }
    }
}