using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Huawei.Hms.Location;
using Com.Huawei.Hms.Maps.Model;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

[assembly: Dependency(typeof(GoogleHuaweiMap.Droid.HuaweiLocation))]
[assembly: Dependency(typeof(GoogleHuaweiMap.Droid.HMSServices))]

namespace GoogleHuaweiMap.Droid
{
    public class HMSServices : IHMS
    {
        public bool UseHMSServices()
        {
            return (Com.Huawei.Hms.Api.ConnectionResult.Success == Com.Huawei.Hms.Api.HuaweiApiAvailability.Instance.IsHuaweiMobileServicesAvailable(MainActivity.Instance)) && !(Android.Gms.Common.ConnectionResult.Success == Android.Gms.Common.GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(MainActivity.Instance));
        }
    }

    public class HuaweiLocation : ILocationHelper
    {
        public Task<Position> GetLastLocation()
        {
            var taskCompletionSource = new TaskCompletionSource<Position>();
            var fusedLocationClient = new FusedLocationProviderClient(MainActivity.Instance);
            fusedLocationClient.LastLocation.AddOnSuccessListener(MainActivity.Instance, new LastLocationAnimationIOnSuccessListener(taskCompletionSource));
            return taskCompletionSource.Task;
        }
    }
    public class LastLocationAnimationIOnSuccessListener : Java.Lang.Object, Com.Huawei.Hmf.Tasks.IOnSuccessListener
    {
        public TaskCompletionSource<Position> TaskCompletionSource;
        public LastLocationAnimationIOnSuccessListener(TaskCompletionSource<Position> taskCompletionSource)
        {
            TaskCompletionSource = taskCompletionSource;
        }
        public void OnSuccess(Java.Lang.Object location)
        {
            if (location == null)
            {

            }
            else if (location is Location ll)
            {
                LatLng latLng = new LatLng(ll.Latitude, ll.Longitude);
                TaskCompletionSource.SetResult(new Position(ll.Latitude, ll.Longitude));
            }
        }
    }
}