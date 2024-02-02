# maui-bluetooth-adapter-issue
This contains the repro code for https://github.com/dotnet/maui/issues/20297

# Steps to reproduce
1) Clone this repo.
2) Build and run it for Mac-catalyst.
3) Observe the state of BLE in Mac compared to Android and iOS (The code is hit in the constructor and also when the "Click me" button is clicked.
4) The state should return "On" or "Off" based on the device's bluetooth state, but returns "Unavailable".
   
I believe the app should also ask for bluetooth permission pop-up since "NSBluetoothAlwaysUsageDescription" and "Privacy - Bluetooth Peripheral Usage Description" are added to the info.plist... and when clicked "Allow" or "Ok", it should allow the use of bluetooth. Bit the pop-up doesn't appear. It used to appear in .net7 version of the app.
