using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI_ViewModelViewHost.ViewModels;

namespace ReactiveUI_ViewModelViewHost.Views
{
    public class Page2View : ReactiveUserControl<Page2ViewModel>
    {
        public Page2View()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
