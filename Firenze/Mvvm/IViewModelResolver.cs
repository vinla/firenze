using System;

namespace Firenze.Mvvm
{
    public interface IViewModelResolver
    {
        TViewModel Resolve<TViewModel>(Object knownParameters);
    }
}