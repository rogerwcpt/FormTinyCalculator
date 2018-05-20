using Xamarin.Forms;
using System.Windows.Input;

namespace FormsTinyCalculator {
	public partial class App : Application {
		public App() {
			InitializeComponent();
			MainPage = new MainPage();
		}
	}

	public enum ButtonType { Digit, Operand, Cancel, Total };

	public class GridButton: Button {
		private Color[] Colors = new[] { Color.White, Color.Orange, Color.Gray, Color.Orange };
		public GridButton(string text, ButtonType buttonType, int row, int col, int colspan){
			Text = text;
			FontSize = 36;
			TextColor = Color.Black;
			BackgroundColor =  Colors[(int)buttonType];
			ButtonType = buttonType;
			this.SetValue(Grid.RowProperty, row);
			this.SetValue(Grid.ColumnProperty, col);
			this.SetValue(Grid.ColumnSpanProperty, colspan);
		}
		public ButtonType ButtonType { get;  }
	}

	public class DisplayLabel : Label {
		public DisplayLabel() {
			Text = "0";
			FontSize = 36;
			HorizontalOptions = LayoutOptions.End; VerticalOptions = LayoutOptions.Center;
			BackgroundColor = Color.Black; TextColor = Color.White;
			this.SetValue(Grid.RowProperty, 0);
			this.SetValue(Grid.ColumnProperty, 0);
			this.SetValue(Grid.ColumnSpanProperty, 4);
		}
	}

	public class MainPage : ContentPage {
		private Label _displayLabel = new DisplayLabel();

		private (string, ButtonType, int, int, int)[] _buttonStruct = new[] {
			("7", ButtonType.Digit, 1, 0, 1), ("8", ButtonType.Digit, 1, 1, 1), ("9", ButtonType.Digit, 1, 2, 1), ("/", ButtonType.Operand, 1, 3, 1),
			("4", ButtonType.Digit, 2, 0, 1), ("5", ButtonType.Digit, 2, 1, 1), ("6", ButtonType.Digit, 2, 2, 1), ("x", ButtonType.Operand, 2, 3, 1),
			("1", ButtonType.Digit, 3, 0, 1), ("2", ButtonType.Digit, 3, 1, 1), ("3", ButtonType.Digit, 3, 2, 1), ("-", ButtonType.Operand, 3, 3, 1),
			("0", ButtonType.Digit, 4, 0, 3), ("+", ButtonType.Operand, 4, 3, 1),
			("C", ButtonType.Cancel, 5, 0, 1), ("+", ButtonType.Total, 5, 1, 3)
		};

		public MainPage() {
			var grid = new Grid() { BackgroundColor = Color.Black, RowSpacing = 1, ColumnSpacing = 1 };
			grid.Children.Add(_displayLabel);
			foreach(var b in _buttonStruct) { grid.Children.Add(new GridButton(b.Item1, b.Item2, b.Item3, b.Item4, b.Item5));}
			Content = grid;
			BindingContext = this;
		}
	}

	public class MainPageViewModel
	{
		private int _digit1, _digit2;
		private string _operand;
		private bool operandSet = false;

		public MainPageViewModel() {
			DigitCommand = new Command<string>(DoDigitCommand);
			OperandCommand = new Command<string>(DoOperandCommand);
			CancelCommand = new Command(DoCancelCommand);
			TotalCommand = new Command(DoTotalCommand);
		}

		private void DoOperandCommand(string operand) {
			_operand = operand;
		}

		private void DoDigitCommand(string digit) {
			if (operandSet) {
				_digit2 = int.Parse(digit);
			} else  {
				_digit1  = int.Parse(digit);
			}
		}

		private void DoTotalCommand() {
		}

		private void DoCancelCommand() {
		}

		public ICommand DigitCommand { get; }
		public ICommand OperandCommand { get; }
		public ICommand TotalCommand { get; }
		public ICommand CancelCommand { get; }
		public string Total { get; set;}
	}
}
