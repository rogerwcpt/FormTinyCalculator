using AppKit;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

namespace FormsTinyCalculator.Mac {
	[Register("AppDelegate")]
	public partial class AppDelegate : FormsApplicationDelegate {
		private readonly NSWindow _window;

		public AppDelegate() {
			var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

			var rect = new CoreGraphics.CGRect(500, 1000, 500, 800);
			_window = new NSWindow(rect, style, NSBackingStore.Buffered, false);
			_window.Title = "Calculator";
		}

		public override NSWindow MainWindow => _window;

		public override void DidFinishLaunching(NSNotification notification) {
			Forms.Init();
			LoadApplication(new App());
			base.DidFinishLaunching(notification);
		}
	}
}
