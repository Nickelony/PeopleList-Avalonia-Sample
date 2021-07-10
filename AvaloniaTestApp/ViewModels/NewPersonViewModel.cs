using Avalonia.Controls;
using AvaloniaTestApp.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;
using System;
using System.Reactive;

namespace AvaloniaTestApp.ViewModels
{
	public class NewPersonViewModel : ReactiveValidationObject // Different class inheritance from the other ViewModels
															   // This class allows for easy data validation
	{
		[Reactive] public string? FirstName { get; set; }
		[Reactive] public string? LastName { get; set; }
		[Reactive] public ComboBoxItem? DepartmentItem { get; set; }
		public ReactiveCommand<Unit, Person> AddPersonCommand { get; } // Unit == nothing is passed into it (void)

		public NewPersonViewModel()
		{
			this.ValidationRule(
				viewModel => viewModel.FirstName,
				firstName => !string.IsNullOrWhiteSpace(firstName),
				"You must specify the first name.");

			this.ValidationRule(
				viewModel => viewModel.LastName,
				lastName => !string.IsNullOrWhiteSpace(lastName),
				"You must specify the last name.");

			this.ValidationRule(
				viewModel => viewModel.DepartmentItem,
				item => item != null,
				"You must specify the department.");

			AddPersonCommand = ReactiveCommand.Create(AddPerson, ValidationContext.Valid);
		}

		private Person AddPerson()
		{
			Department selectedDep = (Department)Enum.Parse(typeof(Department), DepartmentItem!.Content.ToString()!);

			var person = new Person
			{
				FirstName = this.FirstName,
				LastName = this.LastName,
				Department = selectedDep
			};

			return person;
		}
	}
}
