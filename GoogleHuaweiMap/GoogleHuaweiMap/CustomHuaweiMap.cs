using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.GoogleMaps;

namespace GoogleHuaweiMap
{
    public class CustomHuaweiMap : Xamarin.Forms.GoogleMaps.Map
    {
        public double VisibleRegion_Center_Longitude { set; get; }
        public double VisibleRegion_Center_Latitude { set; get; }
        public event EventHandler<Xamarin.Forms.GoogleMaps.Pin> AddPinEvent;
        public event EventHandler<EventArgs> ClearPinsEvent;
        public event EventHandler<MapSpan> MoveToRegionEvent;
        public event EventHandler<bool> MyLocationEnabledEvent;

        public List<Pin> HMSPins { get; } = new List<Pin>();
        public Pin HMSSelectedPin { get; internal set; }

        public void AddPin(Xamarin.Forms.GoogleMaps.Pin pin)
        {
            HMSPins.Add(pin);
            this.AddPinEvent?.Invoke(this, pin);
        }
        public void ClearPins()
        {
            HMSPins.Clear();
            this.ClearPinsEvent?.Invoke(this, new EventArgs());
        }

        internal void MoveToRegion(MapSpan span, bool anim = false)
        {
            MoveToRegionEvent?.Invoke(this, span);
        }
        internal void HMSMyLocationEnabled(bool isEnable)
        {
            MyLocationEnabledEvent?.Invoke(this, isEnable);
        }
    }
}
