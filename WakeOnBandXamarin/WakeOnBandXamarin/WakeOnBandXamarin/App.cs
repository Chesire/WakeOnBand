using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using WakeOnBandXamarin.Interfaces;
using WakeOnBandXamarin.Services;

namespace WakeOnBandXamarin
{
    public class App : MvxApplication
    {
        public App()
        {
            Mvx.RegisterType<IBand, BandService>();
            Mvx.RegisterType<IWol, WolService>();
        }
    }
}