using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using static Com.Huawei.Hms.Maps.HuaweiMap;
using Com.Huawei.Hms.Location;
using Com.Huawei.Hms.Maps;
using Com.Huawei.Hms.Maps.Model;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Locations;
using Android.Util;
using Android.Content.PM;

namespace GoogleHuaweiMap.Droid
{
    public class HuaweiMapView : LinearLayout, IOnMapReadyCallback, IOnCameraMoveStartedListener, IOnCameraMoveListener, IOnCameraIdleListener,
   IOnMyLocationButtonClickListener
    {
        private static string TAG = "MapViewDemoActivity";
        private HuaweiMap hMap;
        private MapView mMapView;
        private FusedLocationProviderClient fusedLocationClient;
        private static long UPDATE_INTERVAL = 5000, FASTEST_INTERVAL = 5000;
        public static int REQUEST_CODE = 0X01;
        private LocationRequest locationRequestH;
        private SettingsClient settingsClientH;
        private Marker mMarker;
        private static string MAPVIEW_BUNDLE_KEY = "MapViewBundleKey";

        internal double getVisibleRegion_Center_Latitude()
        {
            return hMap?.Projection?.VisibleRegion?.LatLngBounds?.Center?.Latitude ?? 0;
        }
        internal double getVisibleRegion_Center_Longitude()
        {
            return hMap?.Projection?.VisibleRegion?.LatLngBounds?.Center?.Longitude ?? 0;
        }
        public CustomHuaweiMap customMap;
        internal void setupCustomMap(CustomHuaweiMap custMap)
        {
            customMap = custMap;
        }

        internal void MoveToRegionRequest(MoveToRegionMessage m)
        {
            if (hMap == null)
                return;
            var span = m.Span;
            var animate = false;

            span = span.ClampLatitude(85, -85);
            var ne = new LatLng(span.Center.Latitude + span.LatitudeDegrees / 2, span.Center.Longitude + span.LongitudeDegrees / 2);
            var sw = new LatLng(span.Center.Latitude - span.LatitudeDegrees / 2, span.Center.Longitude - span.LongitudeDegrees / 2);
            var update = Com.Huawei.Hms.Maps.CameraUpdateFactory.NewLatLngBounds(new LatLngBounds(sw, ne), 0);

            try
            {
                if (animate)
                    hMap.AnimateCamera(update);
                else
                    hMap.MoveCamera(update);
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("MoveToRegion exception: " + exc);
            }
        }

        internal void SetLocationisEnable(bool e)
        {
            if (hMap?.UiSettings != null)
                hMap.UiSettings.MyLocationButtonEnabled = e;
        }

        internal void ClearPins()
        {
            hMap?.Clear();
        }

        //mLocationCallbackHclass mLocationCallbackH;
        public Context Context;
        mLocationCallbackHclass mLocationCallbackH;

        internal void AddPin(Pin pin)
        {
            hMap?.AddMarker(new MarkerOptions().InvokePosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude))
                .InvokeTitle(pin.Label)
                .Anchor(Convert.ToSingle(pin.Anchor.X), Convert.ToSingle(pin.Anchor.Y))
                .Draggable(pin.IsDraggable).InvokeIcon(Com.Huawei.Hms.Maps.Model.BitmapDescriptorFactory.DefaultMarker((float)pin.Icon.Color.Hue)));
        }

        public HuaweiMapView(Context context) : base(context)
        {
            Context = context;
        }
        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            OnCreate();
        }
        protected void OnCreate()
        {
            checkPermission(new string[] {
                Android.Manifest.Permission.WriteExternalStorage,
                Android.Manifest.Permission.ReadExternalStorage,
                Android.Manifest.Permission.AccessCoarseLocation,
                Android.Manifest.Permission.AccessFineLocation,
                Android.Manifest.Permission.Internet }, 100);
            var paramss = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

            this.LayoutParameters = paramss;
            fusedLocationClient = new FusedLocationProviderClient(MainActivity.Instance);
            Bundle mapViewBundle = null;
            Orientation = Orientation.Vertical;
            LayoutInflater inflater = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);
            var view = inflater.Inflate(Resource.Layout.MapView, null);
            mMapView = view.FindViewById<MapView>(Resource.Id.mapview);
            mMapView.OnCreate(null);
            mMapView.GetMapAsync(this);
            mMapView.OnStart();
            mMapView.LayoutParameters = paramss;
            this.AddView(view);

        }

        public void checkPermission(string[] permissions, int requestCode)
        {
            foreach (string permission in permissions)
            {
                if (Android.Support.V4.Content.ContextCompat.CheckSelfPermission(MainActivity.Instance, permission) == Permission.Denied)
                {
                    Android.Support.V4.App.ActivityCompat.RequestPermissions(MainActivity.Instance, permissions, requestCode);
                }
            }

        }
        public void OnCameraIdle()
        {
        }

        public void OnCameraMove()
        {
            if (customMap != null)
            {
                customMap.VisibleRegion_Center_Latitude = getVisibleRegion_Center_Latitude();
                customMap.VisibleRegion_Center_Longitude = getVisibleRegion_Center_Longitude();
            }

        }

        public void OnCameraMoveStarted(int p0)
        {
        }
        private bool isGPSOpen(Context context)
        {
            LocationManager locationManager = (LocationManager)context.GetSystemService(Context.LocationService);
            bool gps = locationManager.IsProviderEnabled(LocationManager.GpsProvider);
            bool network = locationManager.IsProviderEnabled(LocationManager.NetworkProvider);
            if (gps || network)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void OnMapReady(HuaweiMap map)
        {
            hMap = map;

            if (isGPSOpen(MainActivity.Instance))
            {
                hMap.MyLocationEnabled = (true);
                hMap.UiSettings.MyLocationButtonEnabled = (true);
                getMyLastLocationAnimation();
            }
            else
            {
                hMap.MyLocationEnabled = (false);
                hMap.UiSettings.MyLocationButtonEnabled = (false);
                handleLocation();
            }
            hMap.SetOnCameraMoveStartedListener(this);
            hMap.SetOnCameraIdleListener(this);
            hMap.SetOnCameraMoveListener(this);

        }
        public void getMyLastLocationAnimation()
        {
            var task = fusedLocationClient.LastLocation.AddOnSuccessListener(MainActivity.Instance, new LastLocationAnimationIOnSuccessListener(this));

        }
        public void handleLocation()
        {
            settingsClientH = LocationServices.GetSettingsClient(MainActivity.Instance);

            locationRequestH = new LocationRequest();
            locationRequestH.SetPriority(LocationRequest.PriorityHighAccuracy);
            locationRequestH.SetInterval(UPDATE_INTERVAL);
            locationRequestH.SetFastestInterval(FASTEST_INTERVAL);

            if (mLocationCallbackH == null)
            {
                mLocationCallbackH = new mLocationCallbackHclass(this);

            }
            updateLocation();
            fusedLocationClient.RequestLocationUpdates(locationRequestH, mLocationCallbackH, Looper.MainLooper);
        }

        public bool OnMyLocationButtonClick()
        {
            return false;
        }

        public class mLocationCallbackHclass : LocationCallback
        {
            HuaweiMapView mainActivity;
            public mLocationCallbackHclass(HuaweiMapView context)
            {
                mainActivity = context;
            }
            public override void OnLocationResult(LocationResult locationResult)
            {
                base.OnLocationResult(locationResult);
                if (locationResult != null)
                {
                    System.Collections.Generic.IList<Location> locations = locationResult.Locations;
                    if (locations.Count != 0)
                    {
                        mainActivity.hMap.MyLocationEnabled = (true);
                        mainActivity.hMap.UiSettings.MyLocationButtonEnabled = (true);
                        foreach (Location location in locations)
                        {
                            Log.Info(TAG, "onLocationResult location[Longitude,Latitude,Accuracy]:" + location.Longitude + "," + location.Latitude + "," + location.Accuracy);
                        }
                    }
                }
            }
            public override void OnLocationAvailability(LocationAvailability locationAvailability)
            {
                base.OnLocationAvailability(locationAvailability);
                if (locationAvailability != null)
                {
                    var flag = locationAvailability.IsLocationAvailable;
                    Log.Info(TAG, "onLocationAvailability isLocationAvailable:" + flag);
                }
            }
        }
        public class updateLocationIOnSuccessListener : Java.Lang.Object, Com.Huawei.Hmf.Tasks.IOnSuccessListener
        {
            HuaweiMapView mainActivity;
            public updateLocationIOnSuccessListener(HuaweiMapView context)
            {
                mainActivity = context;
            }
            public void OnSuccess(Java.Lang.Object location)
            {
                Log.Info(TAG, "check location settings success");
                mainActivity.getMyLastLocationAnimation();
            }
        }
        public class updateLocationIOnFailureListener : Java.Lang.Object, Com.Huawei.Hmf.Tasks.IOnFailureListener
        {
            HuaweiMapView mainActivity;
            public updateLocationIOnFailureListener(HuaweiMapView context)
            {
                mainActivity = context;
            }

            public void OnFailure(Java.Lang.Exception e)
            {
                Log.Error(TAG, "checkLocationSetting onFailure:" + e.Message);
                int statusCode = ((Com.Huawei.Hms.Common.ApiException)e).StatusCode;
                switch (statusCode)
                {
                    case LocationSettingsStatusCodes.ResolutionRequired:
                        try
                        {
                            var rae = (Com.Huawei.Hms.Common.ResolvableApiException)e;
                            rae.StartResolutionForResult(MainActivity.Instance, 0);
                        }
                        catch (IntentSender.SendIntentException sie)
                        {
                            //sie.printStackTrace();
                        }
                        break;
                }
            }
        }
        public void updateLocation()
        {
            try
            {
                LocationSettingsRequest.Builder builder = new LocationSettingsRequest.Builder();
                builder.AddLocationRequest(locationRequestH);
                LocationSettingsRequest locationSettingsRequest = builder.Build();
                settingsClientH.CheckLocationSettings(locationSettingsRequest).AddOnSuccessListener(new updateLocationIOnSuccessListener(this)).AddOnFailureListener(new updateLocationIOnFailureListener(this));


            }
            catch (System.Exception)
            {

                throw;
            }
        }


        public class LastLocationAnimationIOnSuccessListener : Java.Lang.Object, Com.Huawei.Hmf.Tasks.IOnSuccessListener
        {
            HuaweiMapView mainActivity;

            public LastLocationAnimationIOnSuccessListener(HuaweiMapView context)
            {
                mainActivity = context;

            }
            public void OnSuccess(Java.Lang.Object location)
            {
                if (location == null)
                {
                    // Logic to handle location object
                    Log.Info(TAG, "location is null");
                    //request location updates
                    mainActivity.handleLocation();
                }
                else if (location is Location ll)
                {
                    Log.Info(TAG, "location found");
                    LatLng latLng = new LatLng(ll.Latitude, ll.Longitude);
                    mainActivity.hMap.MoveCamera(Com.Huawei.Hms.Maps.CameraUpdateFactory.NewLatLng(latLng));
                    mainActivity.hMap.AnimateCamera(Com.Huawei.Hms.Maps.CameraUpdateFactory.ZoomTo(18), 2000, null);
                }
            }
        }


    }
    public class MapSpan
    {
        const double EarthRadiusKm = 6371;
        const double EarthCircumferenceKm = EarthRadiusKm * 2 * Math.PI;
        const double MinimumRangeDegrees = 0.001 / EarthCircumferenceKm * 360; // 1 meter

        public MapSpan(Position center, double latitudeDegrees, double longitudeDegrees)
        {
            Center = center;
            LatitudeDegrees = Math.Min(Math.Max(latitudeDegrees, MinimumRangeDegrees), 90.0);
            LongitudeDegrees = Math.Min(Math.Max(longitudeDegrees, MinimumRangeDegrees), 180.0);
        }

        public Position Center { get; }

        public double LatitudeDegrees { get; }

        public double LongitudeDegrees { get; }

        public Distance Radius
        {
            get
            {
                double latKm = LatitudeDegreesToKm(LatitudeDegrees);
                double longKm = LongitudeDegreesToKm(Center, LongitudeDegrees);
                return new Distance(1000 * Math.Min(latKm, longKm) / 2);
            }
        }

        public MapSpan ClampLatitude(double north, double south)
        {
            north = Math.Min(Math.Max(north, 0), 90);
            south = Math.Max(Math.Min(south, 0), -90);
            double lat = Math.Max(Math.Min(Center.Latitude, north), south);
            double maxDLat = Math.Min(north - lat, -south + lat) * 2;
            return new MapSpan(new Position(lat, Center.Longitude), Math.Min(LatitudeDegrees, maxDLat), LongitudeDegrees);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj is MapSpan && Equals((MapSpan)obj);
        }

        public static MapSpan FromCenterAndRadius(Position center, Distance radius)
        {
            return new MapSpan(center, 2 * DistanceToLatitudeDegrees(radius), 2 * DistanceToLongitudeDegrees(center, radius));
        }

        public static MapSpan FromPositions(IEnumerable<Position> positions)
        {
            double minLat = double.MaxValue;
            double minLon = double.MaxValue;
            double maxLat = double.MinValue;
            double maxLon = double.MinValue;

            foreach (var p in positions)
            {
                minLat = Math.Min(minLat, p.Latitude);
                minLon = Math.Min(minLon, p.Longitude);
                maxLat = Math.Max(maxLat, p.Latitude);
                maxLon = Math.Max(maxLon, p.Longitude);
            }

            return new MapSpan(new Position((minLat + maxLat) / 2d, (minLon + maxLon) / 2d), maxLat - minLat, maxLon - minLon);
        }

        public static MapSpan FromBounds(Bounds bounds)
        {
            return new MapSpan(bounds.Center, bounds.HeightDegrees, bounds.WidthDegrees);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Center.GetHashCode();
                hashCode = (hashCode * 397) ^ LongitudeDegrees.GetHashCode();
                hashCode = (hashCode * 397) ^ LatitudeDegrees.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(MapSpan left, MapSpan right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MapSpan left, MapSpan right)
        {
            return !Equals(left, right);
        }

        public MapSpan WithZoom(double zoomFactor)
        {
            double maxDLat = Math.Min(90 - Center.Latitude, 90 + Center.Latitude) * 2;
            return new MapSpan(Center, Math.Min(LatitudeDegrees / zoomFactor, maxDLat), LongitudeDegrees / zoomFactor);
        }

        static double DistanceToLatitudeDegrees(Distance distance)
        {
            return distance.Kilometers / EarthCircumferenceKm * 360;
        }

        static double DistanceToLongitudeDegrees(Position position, Distance distance)
        {
            double latCircumference = LatitudeCircumferenceKm(position);
            return distance.Kilometers / latCircumference * 360;
        }

        bool Equals(MapSpan other)
        {
            return Center.Equals(other.Center) && LongitudeDegrees.Equals(other.LongitudeDegrees) && LatitudeDegrees.Equals(other.LatitudeDegrees);
        }

        static double LatitudeCircumferenceKm(Position position)
        {
            return EarthCircumferenceKm * Math.Cos(position.Latitude * Math.PI / 180.0);
        }

        static double LatitudeDegreesToKm(double latitudeDegrees)
        {
            return EarthCircumferenceKm * latitudeDegrees / 360;
        }

        static double LongitudeDegreesToKm(Position position, double longitudeDegrees)
        {
            double latCircumference = LatitudeCircumferenceKm(position);
            return latCircumference * longitudeDegrees / 360;
        }
    }
    public class MoveToRegionMessage
    {
        public MapSpan Span { get; private set; }
        public bool Animate { get; private set; }

        public MoveToRegionMessage(MapSpan mapSpan, bool animate = true)
        {
            this.Span = mapSpan;
            this.Animate = animate;
        }
    }
}