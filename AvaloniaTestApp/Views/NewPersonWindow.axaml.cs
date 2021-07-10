using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using AvaloniaTestApp.ViewModels;
using ReactiveUI;
using System;
using System.Reactive.Linq;

namespace AvaloniaTestApp.Views
{
	public partial class NewPersonWindow : ReactiveWindow<NewPersonViewModel> // Reactive Window with a specified ViewModel
	{
		public NewPersonWindow()
		{
			InitializeComponent();
#if DEBUG
			this.AttachDevTools();
#endif
			// Return result from AddPersonCommand and Close()
			this.WhenActivated(d => d(ViewModel!.AddPersonCommand.Subscribe(Close)));
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
