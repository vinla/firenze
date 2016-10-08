using System;
using System.Collections.Generic;
using System.Linq;

using Firenze.Core;
using Firenze.Mvvm;

namespace Firenze.ViewModels.Characters
{
    [AutofacRegister]
    public class Roster : ViewModel
    {
        private readonly INavigationManager _navigationManager;
        
        public Roster(INavigationManager navigationManager)
        {
            if(navigationManager == null)
                throw new ArgumentNullException(nameof(navigationManager));
            
            _navigationManager = navigationManager;
        }

        public IEnumerable<Character> Characters => GameState.Current.CharactersWithAvailability.Where(cwa => cwa.Item2).Select(cwa => cwa.Item1);
    }
}
