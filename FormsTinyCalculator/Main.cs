using Xamarin.Forms;
using System;
using System.Linq;
using System.Data;

namespace FormsTinyCalculator {
	
	public partial class App : Application {
		public App() { MainPage = new MainPage();}
	}

	public enum ButtonType { Digit, Operand, Cancel, Total};

	public class GridButton: Button {
		private Color[] Colors = new[] { Color.White, Color.Orange, Color.Gray, Color.Orange };
		public GridButton(string text, ButtonType buttonType, int row, int col, int colspan){
			Text = text;
			FontSize = 36;
			TextColor = Color.Black;
			BackgroundColor =  Colors[(int)buttonType];
			ButtonType = buttonType;
			SetValue(Grid.RowProperty, row);
			SetValue(Grid.ColumnProperty, col);
			SetValue(Grid.ColumnSpanProperty, colspan);
		}
		public ButtonType ButtonType { get;  }
	}

	public class DisplayLabel : Label {
		public DisplayLabel() {
			Text = "0";
			FontSize = 36;
			HorizontalOptions = LayoutOptions.End; 
			VerticalOptions = LayoutOptions.Center;
			BackgroundColor = Color.Black; TextColor = Color.White;
			SetValue(Grid.ColumnSpanProperty, 4);
		}
	}

	public class MainPage : ContentPage {
		private Label _displayLabel = new DisplayLabel();
		private string _expression, _digits;
		private (string FirstName, ButtonType ButtonType, int Row, int Col, int Span)[] _buttonStruct = new[] {
			("7", ButtonType.Digit, 1, 0, 1), ("8", ButtonType.Digit, 1, 1, 1), ("9", ButtonType.Digit, 1, 2, 1), ("/", ButtonType.Operand, 1, 3, 1),
			("4", ButtonType.Digit, 2, 0, 1), ("5", ButtonType.Digit, 2, 1, 1), ("6", ButtonType.Digit, 2, 2, 1), ("*", ButtonType.Operand, 2, 3, 1),
			("1", ButtonType.Digit, 3, 0, 1), ("2", ButtonType.Digit, 3, 1, 1), ("3", ButtonType.Digit, 3, 2, 1), ("-", ButtonType.Operand, 3, 3, 1),
			("0", ButtonType.Digit, 4, 0, 3), ("+", ButtonType.Operand, 4, 3, 1),
			("C", ButtonType.Cancel, 5, 0, 1), ("=", ButtonType.Total, 5, 1, 3)
		};

		public MainPage() {
			var grid = new Grid() { BackgroundColor = Color.Black, RowSpacing = 1, ColumnSpacing = 1 };
			grid.Children.Add(_displayLabel);
			foreach(var b in _buttonStruct) { grid.Children.Add(new GridButton(b.FirstName, b.ButtonType, b.Row, b.Col, b.Span));}
			Content = grid;

			foreach(GridButton gridButton in grid.Children.Where(x => x is GridButton)) {
				switch (gridButton.ButtonType){
					case ButtonType.Digit: gridButton.Clicked += DigitClicked; break;
					case ButtonType.Operand: gridButton.Clicked += OperandClicked; break;
					case ButtonType.Cancel: gridButton.Clicked += CancelClicked; break;
					case ButtonType.Total : gridButton.Clicked += TotalClicked; break;
				}
			}
		}

		private void CancelClicked(object sender, EventArgs e) {
			_displayLabel.Text = "0";
			_expression = _digits = null;
		}

		private void TotalClicked(object sender, EventArgs e) {
			_expression = Convert.ToDouble(new DataTable().Compute(_expression, null)).ToString();
			_displayLabel.Text = _expression;
			_digits = null;
		}

		private void OperandClicked(object sender, EventArgs e) {
			_expression += (sender as Button)?.Text;
			_digits = null;
		}

		private void DigitClicked(object sender, EventArgs e) {
			_expression += (sender as Button)?.Text;
			_digits += (sender as Button)?.Text;
			_displayLabel.Text = _digits;
		}
	}
}
