using MvvmCross.Core.ViewModels;
using MvvmCross.Localization;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Plugins.ResxLocalization;
using WakeOnBandXamarin.Core.ViewModels;
using WakeOnBandXamarin.Localization;

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

            Mvx.RegisterSingleton<IMvxTextProvider>(new MvxResxTextProvider(Strings.ResourceManager));

            RegisterAppStart<MainViewModel>();
        }
    }
}