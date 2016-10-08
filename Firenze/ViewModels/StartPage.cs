using System;

using Firenze.Mvvm;

namespace Firenze.ViewModels
{
    [AutofacRegister]
    public class StartPage : ViewModel
    {
        private readonly INavigationManager _navigationManager;

        public StartPage(INavigationManager navigationManager)
        {
            if(navigationManager == null)
                throw new ArgumentNullException(nameof(navigationManager));

            _navigationManager = navigationManager;
        }
                    
        public MvvmCommand StartGame
        {
            get
            {
                return new MvvmCommand(o =>
                {
                    _navigationManager.Push<HomePage>();
                });
            }
        }        
    }
}
