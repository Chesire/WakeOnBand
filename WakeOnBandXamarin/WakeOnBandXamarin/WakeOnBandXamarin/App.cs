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
                .EndingWith("Repository")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}