using PonVenueMobile.Services;

namespace PonVenueMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<JadwalService>();

            MainPage = new AppShell();
        }
    }
}