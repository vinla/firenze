using System;

using Autofac;

using Firenze.Mvvm;
using Firenze.ViewModels.Characters;

namespace Firenze.ViewModels
{
    [AutofacRegister]
    public class HomePage : ViewModel
    {
        private readonly INavigationManager _navigationManager;

        public HomePage(INavigationManager navigationManager)
        {
            if(navigationManager == null)            
                throw new ArgumentNullException(nameof(navigationManager));

            _navigationManager = navigationManager;            
        }

        public MvvmCommand ShowRoster
        {
            get
            {
                return new MvvmCommand(o =>
                {
                    _navigationManager.Push<Roster>();
                });
            }
        }

        public MvvmCommand ShowJobs
        {
            get
            {
                return new MvvmCommand(o =>
                {
                    _navigationManager.Push<StartJob>();
                });
            }
        }

        public MvvmCommand ShowActiveMissions
        {
            get
            {
                return new MvvmCommand(o =>
                {
                    _navigationManager.Push<ActiveMissionsViewModel>();
                });
            }
        }
    }

    public interface IAutofacRegisterationClass
    {
        void Register(ContainerBuilder builder);
    }

    public class AutofacRegisterAttribute : Attribute
    {
        public Type CustomRegistrationType { get; set; }
    }
}
