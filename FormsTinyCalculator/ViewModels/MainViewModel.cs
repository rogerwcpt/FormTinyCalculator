using System;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsTinyCalculator.ViewModels {

	public class MainViewModel : INotifyPropertyChanged {
		private string _display;
		private string _expression;
		private string _digits;

		public MainViewModel() {
			CancelCommand = new Command(DoCancelCommand);
			TotalCommand = new Command(DoTotalCommand);
			OperandCommand = new Command(DoOperandCommand);
			DigitCommand = new Command(DoDigitCommand);

			Display = "0";
		}

		public string Display { 
			get => _display;
			set {
				_display = value;
				OnPropertyChanged();
			}
		}

		public ICommand CancelCommand { get; }
		public ICommand TotalCommand { get; }
		public ICommand OperandCommand { get; }
		public ICommand DigitCommand { get; }

		public event PropertyChangedEventHandler PropertyChanged;

		private void DoDigitCommand(object obj) {
			_expression += obj.ToString();
			_digits += obj.ToString();
			Display = _digits;
		}

		private void DoOperandCommand(object obj) {
			_expression += obj.ToString();
			_digits = null;
		}

		private void DoTotalCommand(object obj) {
			_expression = Convert.ToDouble(new DataTable().Compute(_expression, null)).ToString();
			Display = _expression;
			_digits = null;
		}

		private void DoCancelCommand(object obj) {
			Display = "0";
			_expression = _digits = null;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
