namespace Pmail.Views
{
    public partial class EmailPage : ContentPage
    {
        public EmailPage()
        {
            BindingContext = new ViewModels.EmailFormViewModel();
            InitializeComponent();
        }
    }
}
