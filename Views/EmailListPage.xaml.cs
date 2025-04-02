namespace Pmail.Views;

public partial class EmailListPage : ContentPage
{
	public EmailListPage()
	{
		InitializeComponent();
	}

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new Views.EmailOpenedPage());
    }
}