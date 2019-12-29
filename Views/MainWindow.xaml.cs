using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using ReactiveUI_ViewModelViewHost.ViewModels;
using System.Reactive.Disposables;

namespace ReactiveUI_ViewModelViewHost.Views
{
    public class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public Button BtnShowPage1 => this.FindControl<Button>("BtnShowPage1");
        public Button BtnShowPage2 => this.FindControl<Button>("BtnShowPage2");

        public ViewModelViewHost ViewModelViewHost => this.FindControl<ViewModelViewHost>("ViewModelViewHost");


        public MainWindow()
        {
            this.WhenActivated(disposables =>
            {
                this.BindCommand(ViewModel, x => x.ShowPage1Command, x => x.BtnShowPage1).DisposeWith(disposables);
                this.BindCommand(ViewModel, x => x.ShowPage2Command, x => x.BtnShowPage2).DisposeWith(disposables);
                
                this.Bind(ViewModel, x => x.CurrentViewModel, x => x.ViewModelViewHost.ViewModel).DisposeWith(disposables);
            });

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
