using Autofac;

namespace Firenze.Mvvm
{
    public static class AutoFacRegisty
    {
        public static NavigationManager CreateNavigationManager()
        {
            var containerBuilder = new ContainerBuilder();
            var vmr = new ViewModelResolver(containerBuilder);
            var navigationManager = new NavigationManager(vmr);
            containerBuilder.Register(b => navigationManager).As<INavigationManager>();
            vmr.RegisterViewModels();
            return navigationManager;
        }
    }
}