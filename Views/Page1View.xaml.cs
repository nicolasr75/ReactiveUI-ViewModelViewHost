using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI_ViewModelViewHost.ViewModels;

namespace ReactiveUI_ViewModelViewHost.Views
{
    public class Page1View : ReactiveUserControl<Page1ViewModel>
    {
        public Page1View()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
