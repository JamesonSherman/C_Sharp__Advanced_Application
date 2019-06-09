using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace flightApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private bool hasLocationPermission = false;
        public MapPage()
        {
            InitializeComponent();
            GetPermissions();
        }

        private async void GetPermissions()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.LocationWhenInUse);
                if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Need your location", "We need to access your location", "Ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Plugin.Permissions.Abstractions.Permission.LocationWhenInUse);
                    if (results.ContainsKey(Plugin.Permissions.Abstractions.Permission.LocationWhenInUse))
                    {
                        status = results[Plugin.Permissions.Abstractions.Permission.LocationWhenInUse];
                    }
                }
                if (status == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    hasLocationPermission = true;
                    locationsMap.IsShowingUser = true;
                    GetLocation();
                }
                else
                {
                    await DisplayAlert("Location Denied", "You did not hand us a location", "OK");
                }
            }
            catch(Exception ex)
            {
               await DisplayAlert("ERROR", ex.Message, "OK");
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                locator.PositionChanged += Locator_PositionChanged;
               await locator.StartListeningAsync(TimeSpan.Zero,100);
            }
                GetLocation();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }

        void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        private async void GetLocation()
        {
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                MoveMap(position);
            }
        }

        private void MoveMap(Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
            locationsMap.MoveToRegion(span);
        }
    }
}