using AvaloniaTestApp.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvaloniaTestApp.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		[Reactive] public ObservableCollection<Person> People { get; set; }
		public Interaction<Unit, Person?> ShowAddNewPersonWindowInteraction { get; }
		public ICommand AddNewPersonCommand { get; }

		public MainViewModel()
		{
			People = new();
			ShowAddNewPersonWindowInteraction = new();

			AddNewPersonCommand = ReactiveCommand.CreateFromTask(AddNewPersonAsync);
		}

		private async Task AddNewPersonAsync()
		{
			Person? newPerson = await ShowAddNewPersonWindowInteraction.Handle(Unit.Default); // Unit.Default == nothing

			if (newPerson != null)
				People.Add(newPerson);
		}
	}
}
