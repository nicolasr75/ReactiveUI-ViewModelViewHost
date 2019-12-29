using ReactiveUI;
using Splat;
using System.Reactive;
using System.Reactive.Disposables;

namespace ReactiveUI_ViewModelViewHost.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IActivatableViewModel
    {
        object currentViewModel;

        public object CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                this.RaiseAndSetIfChanged(ref currentViewModel, value);
            }
        }

        public ViewModelActivator Activator { get; }

        public ReactiveCommand<Unit, Unit> ShowPage1Command { get; }

        public ReactiveCommand<Unit, Unit> ShowPage2Command { get; }


        public MainWindowViewModel()
        {
            Activator = new ViewModelActivator();

            ShowPage1Command = ReactiveCommand.Create(() => ShowPage(1));
            ShowPage2Command = ReactiveCommand.Create(() => ShowPage(2));

            this.WhenActivated(Activated);
        }


        void Activated(CompositeDisposable disposables)
        {
            CurrentViewModel = new Page1ViewModel();
        }


        void ShowPage(int pageNumber)
        {
            switch(pageNumber)
            {
                case 1:
                    CurrentViewModel = Locator.Current.GetService<Page1ViewModel>();
                    break;
                case 2:
                    CurrentViewModel = Locator.Current.GetService<Page2ViewModel>();
                    break;
            }
        }
    }
}
