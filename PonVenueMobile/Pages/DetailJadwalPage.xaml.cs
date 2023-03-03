using Android.Gms.Common.Api.Internal;
using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace PonVenueMobile.Pages;

public partial class DetailJadwalPage : ContentPage
{
	public DetailJadwalPage(Models.Jadwal x)
    {
		InitializeComponent();
        Location location = new Location(-2.535531, 140.714595);
        MapSpan mapSpan = new MapSpan(location, 0, 0);
        map = new Map(mapSpan);
		BindingContext = new DetailJadwalPageViewModel();
	}
}

internal class DetailJadwalPageViewModel
{
    public DetailJadwalPageViewModel()
    {
    }
}