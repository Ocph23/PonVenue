using CommunityToolkit.Mvvm.ComponentModel;
using PonVenueMobile.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PonVenueMobile.Pages;

public partial class JadwalPage : ContentPage
{
    public JadwalPage()
    {
        InitializeComponent();
        this.BindingContext = new JadwalPageViewModel();
    }
}

public partial class JadwalPageViewModel : BaseViewModel
{

    public ObservableCollection<Jadwal> Sources { get; set; } = new ObservableCollection<Jadwal>();

    public JadwalPageViewModel()
    {
        JadwalSelectCommand = new Command<Jadwal>((x) => DetailJadwalShow(x));
        RefreshCommand = new Command(async (x) => await RefreshAction(x));


    }

    private async Task RefreshAction(object obj)
    {
        try
        {
            IsBusy = true;
            var data = await JadwalStore.GetByDate(startDate, endDate);
            if (data != null)
            {
                Sources.Clear();
                foreach (var item in data)
                {
                    Sources.Add(item);
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

    private void DetailJadwalShow(Jadwal x)
    {
        Shell.Current.Navigation.PushAsync(new DetailJadwalPage(x));
    }

    public ICommand JadwalSelectCommand { get; set; }
    public Command RefreshCommand { get; }


    [ObservableProperty]
    private DateTime startDate = DateTime.Now;


    [ObservableProperty]
    private DateTime endDate = DateTime.Now.AddHours(1);


}