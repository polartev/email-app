namespace Pmail.Views;

public partial class EmailOpenedPage : ContentPage
{
	public EmailOpenedPage()
	{
        BindingContext = App.EmailListViewModel?.SelectedEmail;
        InitializeComponent();
	}
}