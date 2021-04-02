using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace GoogleHuaweiMap
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static bool UseHMS => DependencyService.Get<IHMS>().UseHMSServices() && Device.RuntimePlatform == Device.Android;

        public MainPage()
        {
            InitializeComponent();

            Task.Run(async () =>
            {
                Position location;
                if (UseHMS)
                    location = await DependencyService.Get<ILocationHelper>().GetLastLocation();
                else
                    location = new Position(31.963158, 35.930359);

                if (UseHMS)
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(1)), true);


                Xamarin.Forms.GoogleMaps.Pin pin = new Pin()
                {
                    Address = "Test Address",
                    Type = PinType.Place,
                    Position = new Position(location.Latitude, location.Longitude)
                };

                pin.Label = "Hello";
                pin.Icon = BitmapDescriptorFactory.DefaultMarker(Color.Green);
                if (UseHMS)
                    map.AddPin(pin);
                else
                    map.Pins.Add(pin);


            });

        }
        
    }
}
