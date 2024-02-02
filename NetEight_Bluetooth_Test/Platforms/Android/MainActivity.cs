using System.Collections.Generic;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Maui;

namespace NetEight_Bluetooth_Test;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    readonly List<string> AppPermissions = new List<string>()
        {
            Manifest.Permission.AccessNetworkState,
            Manifest.Permission.Internet,
            Manifest.Permission.BluetoothScan,
            Manifest.Permission.BluetoothConnect,
            Manifest.Permission.Vibrate,
            Manifest.Permission.WakeLock,
            Manifest.Permission.Camera
        };
    const int RequestAppPermissionsId = 0;
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        RequestPermissionsAsync();
    }

    void RequestPermissionsAsync()
    {
        Permissions.RequestAsync<BLEPermission>();
        //Check to see if any permission in our group is available, if one, then all are
        const string permission = Manifest.Permission.Internet;
        if (CheckSelfPermission(permission) == (int)Permission.Granted)
        {
            return;
        }
        //Finally request permissions with the list of permissions and Id
        RequestPermissions(AppPermissions.ToArray(), RequestAppPermissionsId);
    }

    // Function below is required to ask for permission to use Bluetooth
    public class BLEPermission : Permissions.BasePlatformPermission
    {
        public override (string androidPermission, bool isRuntime)[] RequiredPermissions => new List<(string androidPermission, bool isRuntime)>
            {
                (Android.Manifest.Permission.BluetoothScan, true),
                (Android.Manifest.Permission.BluetoothConnect, true)
            }.ToArray();
    }
}

