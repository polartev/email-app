namespace Pmail
{
    public partial class App : Application
    {
        public static ViewModels.EmailListViewModel? EmailListViewModel { get; private set; }

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            EmailListViewModel = new();
            EmailListViewModel.RefreshEmails().ContinueWith((e) => { });

            return new Window(new AppShell());
        }
    }
}