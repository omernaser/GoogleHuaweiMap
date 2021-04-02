using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Huawei.Agconnect.Config;

namespace GoogleHuaweiMap.Droid
{
    [Activity(Label = "GoogleHuaweiMap", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

       

            Instance = this;
            var useHMSSerivce = (Com.Huawei.Hms.Api.ConnectionResult.Success == Com.Huawei.Hms.Api.HuaweiApiAvailability.Instance.IsHuaweiMobileServicesAvailable(MainActivity.Instance)) && !(Android.Gms.Common.ConnectionResult.Success == Android.Gms.Common.GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(MainActivity.Instance));

            if (useHMSSerivce)
            {
                //Setup Huawei config
                AGConnectServicesConfig config = AGConnectServicesConfig.FromContext(ApplicationContext);
                config.OverlayWith(new HmsLazyInputStream(this));
                Com.Huawei.Agconnect.AGConnectInstance.Initialize(this);
                //
            }
            else {
               

                Xamarin.FormsGoogleMaps.Init(this, savedInstanceState, new Xamarin.Forms.GoogleMaps.Android.PlatformConfig()); // initialize for Xamarin.Forms.GoogleMaps
            }
            LoadApplication(new App());
      
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}