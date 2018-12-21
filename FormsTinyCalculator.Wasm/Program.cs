using Ooui;
using Xamarin.Forms;

namespace FormsTinyCalculator.Wasm
{
    class Program
    {
 		static void Main(string[] args) {
            Forms.Init ();

			var page = new MainPage();

			UI.Publish("/", page.GetOouiElement());
        }
    }
}
