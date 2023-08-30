using AndroidX.Emoji2.Text.FlatBuffer;
using IntelliJ.Lang.Annotations;
using PonVenueMobile.Models;
using System.Collections.ObjectModel;

namespace PonVenueMobile.Pages;

public partial class VenuePage : ContentPage
{
    public VenuePage()
    {
        InitializeComponent();
        BindingContext = new VenuePageViewModel(map);
    }
}

public partial class VenuePageViewModel : BaseViewModel
{

    Microsoft.Maui.Controls.Maps.Map _map;

    public ObservableCollection<Lokasi> Locations { get; set; } = new ObservableCollection<Lokasi>();
    public VenuePageViewModel(Microsoft.Maui.Controls.Maps.Map map)
    {
        RefreshCommand = new Command(async (x) => await RefreshAction(x));
        _map = map;
        RefreshCommand.Execute(null);
    }

    public Command RefreshCommand { get; }

    private async Task RefreshAction(object obj)
    {
        try
        {
            IsBusy = true;
            var data = await VenueStore.Get();
            if (data != null)
            {
                Locations.Clear();
                foreach (var item in data)
                {
                    var d = new Lokasi
                    {
                        Position = new Location(item.Latitdue, item.Longitude),
                        Address = item.Alamat,
                        Label = item.Nama
                    };
                    Locations.Add(d);
                }
                var dd = Locations.FirstOrDefault();

                if (dd != null)
                {
                    double zoomLevel = 10;
                    double latlongDegrees = 360 / (Math.Pow(2, zoomLevel));
                    _map.MoveToRegion(new Microsoft.Maui.Maps.MapSpan(dd.Position, latlongDegrees, latlongDegrees));
                }
            }
        }
        catch (Exception ex)
        {
            await MessageShow.ErrorAsync(ex.Message);
        }
        finally
        { IsBusy = false; }
    }
}