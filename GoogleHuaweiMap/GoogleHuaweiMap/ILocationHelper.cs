using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps;

namespace GoogleHuaweiMap
{
    public interface ILocationHelper
    {
        Task<Position> GetLastLocation();
    }
    public interface IHMS
    {
        bool UseHMSServices();
    }
}
