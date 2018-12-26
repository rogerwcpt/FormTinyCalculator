# Xamarin Forms Tiny Calculator
Simple Calculator written using Xamarin Forms (XAML and MVVM)in +-120 lines of code.
- View=55 lines of XML
- ViewModel=65 lines of C# code

This app will run on 7 platforms:

Platform clients:

- Android
- iOS
- Mac
- UWP (Windows Universal Platform, including XBOX)
- WPF (Classic Windows Desktop)
- GTK (for Linux, Mac and Windows)
- WASM (Web Assembly)

![Main File](FormsTinyCalculator/Main.cs)

## Code in action on Visual Studio for Mac
![Calculator screenshot](screenshot.png)

## Screenshots for each platform

#### Android
<img src="screenshots/droid-screenshot.png" height="400">

#### iOS
<img src="screenshots/ios-screenshot.png" height="400">

#### Mac OS X
<img src="screenshots/macos-screenshot.png" height="400">

#### Windows UWP 
<img src="screenshots/windows-uwp-screenshot.png" height="400">

#### Windows WPF 
<img src="screenshots/windows-wpf-screenshot.png" height="400">

#### Linux
<img src="screenshots/linux-screenshot.png" height="400">

#### Web Assembly (browser)
<img src="screenshots/wasm-screenshot.png" height="400">

### Notes:

- UI ported from https://github.com/xamarin/mobile-samples/tree/master/LivePlayer/BasicCalculator
- Braces add more lines of code, so I've used trailing braces for more compact code).
- With the Exception of the WASM project, no third party libraries used, just what is available in Xamarin.  WASM uses [Ooui](https://github.com/praeclarum/Ooui)
- To run the WASM project, build it, then open a terminal at to FormsTinyCalculator.Wasm/bin/Debug/netcoreapp2.1/dist and run `python server.py` to start a lightweight python web server in this folder.  and then open your browser at http://localhost:8000/ . If you have Firefox, you can simply open the index.html file from the same folder without having to start the python web server.





