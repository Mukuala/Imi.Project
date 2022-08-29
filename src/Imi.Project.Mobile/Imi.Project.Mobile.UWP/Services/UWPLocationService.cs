using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Windows.Devices.Geolocation;
using Xamarin.Essentials;
using Windows.Services.Maps;

[assembly: Dependency(typeof(Imi.Project.Mobile.UWP.Services.UWPLocationService))]

namespace Imi.Project.Mobile.UWP.Services
{
    public class UWPLocationService : ILocationService
    {
        public async Task<CurrentLocation> GetCurrentLocation()
        {
            //Civil address is unsopported and always returns null -> had to use xamarin essentials to get the addresses
            Geolocator geolocator = new Geolocator { DesiredAccuracy = PositionAccuracy.High };
            MapService.ServiceToken = "lFluilKLwjhPYI4VnH6s~YFvwk5bzGlH2DRJzhsF-MA~AnSp-6kOulwVGclkKO3hW8yfZHqC95P-cxox4zl_bMGEwc-hJMi5mygk9Ico-FHb";

            var accessStatus = await Geolocator.RequestAccessAsync();
            if (accessStatus == GeolocationAccessStatus.Allowed)
            {
                var position = await geolocator.GetGeopositionAsync();
                var coordinates = position.Coordinate;
                //Xamarin essentials 
                Location location = new Location { Latitude = coordinates.Point.Position.Latitude, Longitude = coordinates.Point.Position.Longitude };
                var placemarks = await Geocoding.GetPlacemarksAsync(location);
                var placemark = placemarks.FirstOrDefault();

                CurrentLocation currentLocation = new CurrentLocation
                {
                    Address = placemark.FeatureName
                };
                return currentLocation;
            }
            else
            {
                CurrentLocation currentLocation = new CurrentLocation
                {
                    Address = "Allow access to location or enable location to know current location"
                };
                return currentLocation;
            }
        }
    }
}
