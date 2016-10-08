using System.Collections.Generic;
using System.Linq;

using Firenze.Core;
using Firenze.Mvvm;

namespace Firenze.ViewModels
{
    [AutofacRegister]
    public class StartJob : ViewModel
    {
        private readonly INavigationManager _navigationManager;

        public StartJob(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            AvailableCharacters = GameState.Current.CharactersWithAvailability.Where(cwa => cwa.Item2).Select(c => new Selectable<Character>(c.Item1)).ToList();
        }

        public IEnumerable<Selectable<Character>> AvailableCharacters { get; }

        public MvvmCommand StartJobCommand
        {
            get
            {
                return new MvvmCommand(o =>
                {
                    var selectedCharacters = AvailableCharacters.Where(ac => ac.Selected).Select(ac => ac.Item).ToList();
                    if (selectedCharacters.Any())
                    {                        
                        var mission = new Mission(selectedCharacters);
                        GameState.Current.ActiveMissions.Add(mission);
                        _navigationManager.Return();
                    }
                });
            }
        }
    }
}
