using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using WakeOnBandXamarin.Core.Interfaces;
using WakeOnBandXamarin.Core.Services;
using WakeOnBandXamarin.Core.ViewModels;

namespace WakeOnBandXamarin.Core
{
    public class App : MvxApplication
    {
        public App()
        {
            Mvx.RegisterType<IBand, BandService>();
            Mvx.RegisterType<IWol, WolService>();
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<FirstViewModel>();
        }
    }
}