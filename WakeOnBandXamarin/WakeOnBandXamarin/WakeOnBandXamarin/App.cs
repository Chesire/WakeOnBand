using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using WakeOnBandXamarin.Core.ViewModels;

namespace WakeOnBandXamarin.Core
{
    public class App : MvxApplication
    {
        public App()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            CreatableTypes()
                .EndingWith("ViewModel")
                .AsTypes()
                .RegisterAsLazySingleton();

            /* ViewModels */
            //Mvx.RegisterType<WolTargetsViewModel, WolTargetsViewModel>();
            //Mvx.RegisterType<BandTargetsViewModel, BandTargetsViewModel>();

            RegisterAppStart<FirstViewModel>();
        }
    }
}