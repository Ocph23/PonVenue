using Android.Gms.Common.Api.Internal;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using PonVenueMobile.Models;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace PonVenueMobile.Pages;

public partial class DetailJadwalPage : ContentPage
{
    public DetailJadwalPage(Models.Jadwal x)
    {
        InitializeComponent();
        BindingContext = new DetailJadwalPageViewModel(x, map);
    }
}

internal class DetailJadwalPageViewModel
{
    public Jadwal Model { get; set; }

    private Map _map;

    public DetailJadwalPageViewModel(Models.Jadwal x, Map map)
    {
        Model = x;
        _map = map;
        _ = LoadMap();

    }

    private async Task LoadMap()
    {
        await Task.Delay(100);
        var x = Model;
        if (x != null && x.Venue != null )
        {
            double lat = Convert.ToDouble(x.Venue.Latitdue);// 36.9628066;
            double ltg = Convert.ToDouble(x.Venue.Longitude);// -122.0194722;
            Location location = new Location(lat, ltg);

            double zoomLevel = 10;
            double latlongDegrees = 360 / (Math.Pow(2, zoomLevel));
            MapSpan mapSpan = new MapSpan(location, latlongDegrees,latlongDegrees);
            _map.MoveToRegion(mapSpan);
            Pin pin = new Pin
            {
                Label = $"{x.Venue.Nama}",
                Address = $"{x.Venue.Alamat}",
                Type = PinType.Place,
                Location = new Location(lat, ltg)
            };
            _map.Pins.Add(pin);
        }
    }
}