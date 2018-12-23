# Xamarin Forms Tiny Calculator
Simple Calculator written using Xamarin Forms (no XAML) in +-90 lines of code.

This project inspired by the a tweet by [Don Syme](https://twitter.com/dsyme/status/996720094683258880?lang=en) that managed to create a F# based calculator using Elmish on top of Xamarin Forms.  His solution weighed in at 95 lines of code.

Another challenger [Thomas Burkart](https://twitter.com/ThomasBurkhartB/status/997088751724761088) also accepted the challenge for a Flutter equivalent, and his solution weighed in at +-90 lines of code.

This app will run on 7 platforms:

Platform clients:

- Android
- iOS
- Mac
- UWP (Windows Universal Platform, including XBOX)
- WPF (Classic Windows Desktop)
- GTK (for Linux, Mac and Windows)
- WASM (Web Assembly, only seems to work in FireFox)

![Main File](FormsTinyCalculator/Main.cs)

## Code in action on Visual Studio for Mac
![Calculator screenshot](screenshot.png)

## Screenshots for each platform

#### Android
<img src="screenshots/droid-screenshot.png" height="400">

#### iOS
<img src="screenshots/ios-screenshot.png" height="400">

#### Mac OX
<img src="screenshots/macos-screenshot.png" height="400">

#### Windows UWP 
<img src="screenshots/windows-uwp-screenshot.png" height="400">

#### Windows WPF 
<img src="screenshots/windows-wpf-screenshot.png" height="400">

#### Windows Linux
<img src="screenshots/linux-screenshot.png" height="400">


### Notes:

 - UI ported from https://github.com/xamarin/mobile-samples/tree/master/LivePlayer/BasicCalculator
- Braces obviously add more lines of code, so I've used trailing braces for more compact code).
- With the Exception of the WASM project, no third party libraries used, just what is available in Xamarin.  WASM uses [Ooui](https://github.com/praeclarum/Ooui)





