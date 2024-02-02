using System.Diagnostics;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;

namespace NetEight_Bluetooth_Test;

public partial class MainPage : ContentPage
{
    IBluetoothLE ble;

    public MainPage()
	{
        InitializeComponent();
        ble = CrossBluetoothLE.Current;
        var adapter = ble.Adapter;
        var state = ble.State;
        //In Android and iOS phones, the state is either "On" or "Off" depending upon the device's bluetooth status. Which is as expected.
        //In Mac, it's either unavailable (when permission pop up isn't shown as in this example) or unauthorized (while using CBCentralManager's state in the real app that I am working with...the code for which is too large to create as a repro).
        ble.StateChanged += (s, e) =>
        {
            //This "StateChanged" event is called in iOS and Android when bluetooth is turned on or off manually.
            //In Mac, turning the bluetooth On/Off manually doesn't trigger the event.
            Debug.WriteLine($"The bluetooth state changed to {e.NewState}");
        };
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        var state = ble.State;
        checkStatus(state);
    }

    private void checkStatus(BluetoothState state)
    {
        switch (state)
        {
            case BluetoothState.On:
                Console.WriteLine("On");
                break;
            case BluetoothState.Unavailable:
                Console.WriteLine("Unavailable");
                break;
            case BluetoothState.Unauthorized:
                Console.WriteLine("Unauthorized");
                break;
            case BluetoothState.Off:
                Console.WriteLine("Off");
                break;
            default:
                Console.WriteLine("Unknown");
                break;
        }
    }
}


