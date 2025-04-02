using CommunityToolkit.Mvvm.ComponentModel;

namespace Pmail.ViewModels;

public partial class EmailViewModel : ObservableObject
{
    [ObservableProperty]
    private string? subject;

    [ObservableProperty] 
    private string? body;

    [ObservableProperty] 
    private string? from;

    [ObservableProperty] 
    private string? to;

    [ObservableProperty] 
    private DateTime? date;

    public EmailViewModel(Models.Email email)
    {
        Subject = email.Subject;
        Body = email.Body;
        From = email.From;
        To = email.To;
        Date = email.Date;
    }
}
