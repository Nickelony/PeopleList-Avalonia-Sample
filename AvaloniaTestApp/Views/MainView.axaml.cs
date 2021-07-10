using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using AvaloniaTestApp.Models;
using AvaloniaTestApp.ViewModels;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;

namespace AvaloniaTestApp.Views
{
	public partial class MainView : ReactiveUserControl<MainViewModel> // Reactive UserControl with a specified ViewModel
	{
		public MainView()
		{
			InitializeComponent();

			// Interaction handling
			this.WhenActivated(d => d(ViewModel!.ShowAddNewPersonWindowInteraction.RegisterHandler(ShowAddNewPersonWindow)));
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public async Task ShowAddNewPersonWindow(InteractionContext<Unit, Person?> interaction)
		{
			var window = new NewPersonWindow
			{
				DataContext = new NewPersonViewModel() // It is important to set the ViewModel of the window!
			};

			var result = await window.ShowDialog<Person?>(Parent as Window); // We know the Parent is the MainWindow
			interaction.SetOutput(result);
		}
	}
}
