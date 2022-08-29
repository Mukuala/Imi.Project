﻿using Android.Gms.Location;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

[assembly: Dependency(typeof(Imi.Project.Mobile.Droid.Services.DroidLocationService))]

namespace Imi.Project.Mobile.Droid.Services
{
    public class DroidLocationService : ILocationService
    {
        private readonly Geocoder geocoder = new Geocoder();
        public async Task<CurrentLocation> GetCurrentLocation()
        {
            var currentContext = Android.App.Application.Context;
            FusedLocationProviderClient fusedLocationProviderClient = LocationServices.GetFusedLocationProviderClient(currentContext);
            CurrentLocation currentLocation = new CurrentLocation();

            var location = await fusedLocationProviderClient.GetLastLocationAsync();


            Position position = new Position(location.Latitude, location.Longitude);
            IEnumerable<string> possibleAddresses = await geocoder.GetAddressesForPositionAsync(position);
            string adress = possibleAddresses.FirstOrDefault();
            currentLocation.Address = adress;

            //Geolocation testing xam essentials
            var geoLocation = await Geocoding.GetLocationsAsync(adress);
            var geoPlacemark = await Geocoding.GetPlacemarksAsync(geoLocation.FirstOrDefault());

            return await Task.FromResult<CurrentLocation>(currentLocation);
        }
    }
}