using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FormsTinyCalculator.ViewModels;

namespace FormsTinyCalculator.Views {
	public partial class MainView : ContentPage {
		public MainView() {
			InitializeComponent();

			BindingContext = new MainViewModel();
		}
	}
}
