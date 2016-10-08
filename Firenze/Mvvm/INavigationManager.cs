namespace Firenze.Mvvm
{
    public interface INavigationManager
    {
        void SetRoot(ViewModel viewModel);
        void Push<TViewModel>() where TViewModel : ViewModel;
        void Push<TViewModel>(object args) where TViewModel : ViewModel;
        void Push(ViewModel viewModel);
        void Return();
    }
}