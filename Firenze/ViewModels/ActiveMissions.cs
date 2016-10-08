using System.Collections.Generic;

using Firenze.Core;
using Firenze.Mvvm;

namespace Firenze.ViewModels
{
    public class ActiveMissionsViewModel : ViewModel
    {
        public IEnumerable<Mission> ActiveMissions => GameState.Current.ActiveMissions;
    }
}
