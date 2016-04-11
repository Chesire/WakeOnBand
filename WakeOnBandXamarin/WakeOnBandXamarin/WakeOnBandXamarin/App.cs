using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using WakeOnBandXamarin.Interfaces;
using WakeOnBandXamarin.Services;
using WakeOnBandXamarin.ViewModels;

namespace WakeOnBandXamarin
{
    public class App : MvxApplication
    {
        public App()
        {
            Mvx.RegisterType<IBand, BandService>();
            Mvx.RegisterType<IWol, WolService>();
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<MainViewModel>());
        }
    }
}