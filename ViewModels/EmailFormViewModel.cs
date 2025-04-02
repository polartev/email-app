using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Pmail.ViewModels;

public partial class EmailFormViewModel : ObservableObject
{
    [ObservableProperty]
    private string? subject;

    [ObservableProperty]
    private string? body;

    [ObservableProperty]
    private string? from;

    [ObservableProperty]
    private string? to;

    [RelayCommand]
    public async Task OnSendButtonTappedAsync()
    {
        if (string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(body) || string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
        {
            return;
        }

        DateTime date = DateTime.Now;

        var email = new Models.Email(subject, body, from, to, date);

        await App.EmailListViewModel.SendEmail(email);

        Subject = string.Empty;
        Body = string.Empty;
        From = string.Empty;
        To = string.Empty;
    }
}
