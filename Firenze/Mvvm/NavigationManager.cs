using System;
using System.Collections.Generic;

namespace Firenze.Mvvm
{
    public class NavigationManager : ViewModel, INavigationManager
    {
        private readonly IViewModelResolver _viewModelResolver;
        private readonly Stack<ViewModel> _navigationStack;

        public NavigationManager(IViewModelResolver viewModelResolver)
        {
            if (viewModelResolver == null)
                throw new ArgumentNullException(nameof(viewModelResolver));

            _viewModelResolver = viewModelResolver;
            _navigationStack = new Stack<ViewModel>();
        }

        public void SetRoot(ViewModel viewModel)
        {
            _navigationStack.Clear();
            Push(viewModel);
        }

        public void Push<TViewModel>() where TViewModel : ViewModel
        {
            Push<TViewModel>(null);
        }

        public void Push<TViewModel>(object args) where TViewModel : ViewModel
        {
            var viewModel = _viewModelResolver.Resolve<TViewModel>(args);
            Push(viewModel);
        }

        public void Push(ViewModel viewModel)
        {
            _navigationStack.Push(viewModel);
            RaisePropertyChanged(nameof(CurrentViewModel));
        }

        public void Return()
        {
            _navigationStack.Pop();
            RaisePropertyChanged(nameof(CurrentViewModel));
        }

        public ViewModel CurrentViewModel => _navigationStack.Peek();
    }
}