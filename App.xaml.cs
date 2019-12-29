using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using ReactiveUI_ViewModelViewHost.ViewModels;
using ReactiveUI_ViewModelViewHost.Views;
using Splat;

namespace ReactiveUI_ViewModelViewHost
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                Locator.CurrentMutable.Register(() => new Page1View(), typeof(IViewFor<Page1ViewModel>));
                Locator.CurrentMutable.Register(() => new Page2View(), typeof(IViewFor<Page2ViewModel>));

                var vm = new MainWindowViewModel();

                desktop.MainWindow = new MainWindow
                {
                    ViewModel = vm
                };

                Locator.CurrentMutable.Register(() => new Page1ViewModel());
                Locator.CurrentMutable.Register(() => new Page2ViewModel());
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
