using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Pmail.ViewModels
{
    public partial class EmailListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<EmailViewModel>? emails;

        [ObservableProperty]
        private EmailViewModel? selectedEmail;
        
        public EmailListViewModel()
        {
            Emails = [];
        }

        public async Task RefreshEmails()
        {
            Emails = [];

            IEnumerable<Models.Email> emailsData = await Models.EmailDataBase.GetEmails();
            
            foreach (Models.Email email in emailsData.OrderByDescending(e => e.Date))
            {
                Emails.Add(new EmailViewModel(email));
            }
        }

        public async Task SendEmail(Models.Email email) 
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (Email.Default.IsComposeSupported)
            {
                string subject = email.Subject;
                string body = email.Body;
                string[] recipients = new[] { email.To };

                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    BodyFormat = EmailBodyFormat.PlainText,
                    To = new List<string>(recipients)
                };

                await Email.Default.ComposeAsync(message);

                await Models.EmailDataBase.AddEmail(email);
                await RefreshEmails();
            }
        }
    }
}
