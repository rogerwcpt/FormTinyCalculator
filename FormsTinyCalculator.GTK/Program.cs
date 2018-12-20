using System;
using Xamarin.Forms.Platform.GTK;

namespace FormsTinyCalculator.GTK {
	class MainClass {

		[STAThread]
		public static void Main(string[] args) {

			Gtk.Application.Init();
			Xamarin.Forms.Forms.Init();

			var app = new FormsTinyCalculator.App();

			var window = new FormsWindow {
				DefaultHeight = 600,
				DefaultWidth = 400
			};

			window.LoadApplication(app);
			window.SetApplicationTitle("Calculator");
			window.Show();

			Gtk.Application.Run();
		}
	}
}
