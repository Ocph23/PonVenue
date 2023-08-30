using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using PonVenueMobile.Models;
using System.Collections.ObjectModel;
using static Android.Provider.CallLog;

namespace PonVenueMobile.Pages;

public partial class ListVenuePage : ContentPage
{
	public ListVenuePage()
	{
		InitializeComponent();
        BindingContext = new ListVenuePageViewModel(map);

    }


    public partial class ListVenuePageViewModel : BaseViewModel
    {

        public ObservableCollection<Venue> Venues { get; set; } = new ObservableCollection<Venue>();


        private Venue model;

        public Venue Model
        {
            get { return model; }
            set { SetProperty(ref model , value);
                if(value!=null)
                {
                    _=LoadMap(value);
                }
            
            }
        }


        private Microsoft.Maui.Controls.Maps.Map _map;

        

        public ListVenuePageViewModel(Microsoft.Maui.Controls.Maps.Map map)
        {
            _map = map;
            _ = Load();
        }

        private async Task Load()
        {
            await Task.Delay(100);
            try
            {
                IsBusy = true;
                var data = await VenueStore.Get();
                if (data != null)
                {
                    Venues.Clear();
                    foreach (var item in data)
                    {
                        Venues.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                await MessageShow.ErrorAsync(ex.Message);
            }
            finally
            { IsBusy = false; }








            //var x = Model;
            //if (x != null && x.Venue != null)
            //{
            //    double lat = Convert.ToDouble(x.Venue.Latitdue);// 36.9628066;
            //    double ltg = Convert.ToDouble(x.Venue.Longitude);// -122.0194722;
            //    Location location = new Location(lat, ltg);

            //    double zoomLevel = 10;
            //    double latlongDegrees = 360 / (Math.Pow(2, zoomLevel));
            //    MapSpan mapSpan = new MapSpan(location, latlongDegrees, latlongDegrees);
            //    _map.MoveToRegion(mapSpan);
            //    Pin pin = new Pin
            //    {
            //        Label = $"{x.Venue.Nama}",
            //        Address = $"{x.Venue.Alamat}",
            //        Type = PinType.Place,
            //        Location = new Location(lat, ltg)
            //    };
            //    _map.Pins.Add(pin);
            //}
        }

        private async Task LoadMap(Venue model)
        {
            _map.Pins.Clear();
            if (model != null )
            {
                double lat = Convert.ToDouble(model.Latitdue);// 36.9628066;
                double ltg = Convert.ToDouble(model.Longitude);// -122.0194722;
                Location location = new Location(lat, ltg);

                double zoomLevel = 10;
                double latlongDegrees = 360 / (Math.Pow(2, zoomLevel));
                MapSpan mapSpan = new MapSpan(location, latlongDegrees, latlongDegrees);
                _map.MoveToRegion(mapSpan);
                Pin pin = new Pin
                {
                    Label = $"{model.Nama}",
                    Address = $"{model.Alamat}",
                    Type = PinType.Place,
                    Location = new Location(lat, ltg)
                };
                _map.Pins.Add(pin);
            }
        }
    }
}