using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Platform.Android;


[assembly: Xamarin.Forms.ExportRenderer(typeof(GoogleHuaweiMap.CustomHuaweiMap), typeof(GoogleHuaweiMap.Droid.HuaweiMapRenderer))]

namespace GoogleHuaweiMap.Droid
{
    public class HuaweiMapRenderer : ViewRenderer
    {
        public HuaweiMapRenderer(Context context) : base(context)
        {

        }
        public HuaweiMapView MapView;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            var useHMSSerivce = (Com.Huawei.Hms.Api.ConnectionResult.Success == Com.Huawei.Hms.Api.HuaweiApiAvailability.Instance.IsHuaweiMobileServicesAvailable(MainActivity.Instance)) && !(Android.Gms.Common.ConnectionResult.Success == Android.Gms.Common.GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(MainActivity.Instance));
            if (useHMSSerivce)
            {
                MapView = new HuaweiMapView(MainActivity.Instance);
                this.SetNativeControl(MapView);
                if (Element is CustomHuaweiMap customMap)
                {
                    customMap.AddPinEvent += OnAddPin;
                    customMap.ClearPinsEvent += CustomMap_ClearPinsEvent;
                    customMap.VisibleRegion_Center_Latitude = MapView.getVisibleRegion_Center_Latitude();
                    customMap.VisibleRegion_Center_Longitude = MapView.getVisibleRegion_Center_Longitude();
                    customMap.MoveToRegionEvent += CustomMap_MoveToRegionEvent;
                    customMap.MyLocationEnabledEvent += CustomMap_MyLocationEnabledEvent;
                    MapView.setupCustomMap(customMap);

                }
            }

        }

        private void CustomMap_MyLocationEnabledEvent(object sender, bool e)
        {
            MapView.SetLocationisEnable(e);
        }

        private void CustomMap_MoveToRegionEvent(object sender, Xamarin.Forms.GoogleMaps.MapSpan e)
        {
            MapView.MoveToRegionRequest(new MoveToRegionMessage(new MapSpan(e.Center, e.LatitudeDegrees, e.LongitudeDegrees), false));
        }

        private void CustomMap_ClearPinsEvent(object sender, EventArgs e)
        {
            MapView.ClearPins();
        }

        private void OnAddPin(object sender, Pin e)
        {
            MapView.AddPin(e);
        }


    }
}