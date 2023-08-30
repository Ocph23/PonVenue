using PonVenueMobile.Services;

namespace PonVenueMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<JadwalService>();
            DependencyService.Register<VenueService>();

            MainPage = new AppShell();
        }
    }
}