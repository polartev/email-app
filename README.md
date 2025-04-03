# Email Sender Application

A cross-platform email sending application built using **.NET MAUI** and designed with the **MVVM** pattern. The app allows users to compose and send emails using built-in .NET email functionality. Additionally, it provides a history of sent emails and allows users to view their details.

---

## Features

- **Compose Emails**: Easily write and send emails.
- **Sent Emails History**: View a list of previously sent emails.
- **View Email Details**: Open and review individual emails from history.
- **MVVM Architecture**: The app follows the Model-View-ViewModel pattern for better maintainability and scalability.

---

## Screenshots

_Writing an email_
![image](https://github.com/user-attachments/assets/5cb7c9a4-2bd2-4b31-99da-0379f68451c9)

_List of all sent emails_
![image](https://github.com/user-attachments/assets/cf37d2cc-2dc8-4b68-b8f4-81d2a95adbbb)

_Opened email from the list_
![image](https://github.com/user-attachments/assets/0ac22311-8acd-44bf-8079-8d9aaf8a7457)

---

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/your-repo/email-app.git
   cd email-app
   ```
2. Open the project in **Visual Studio**.
3. Restore dependencies:
   ```sh
   dotnet restore
   ```
4. Run the application:
   ```sh
   dotnet build
   dotnet run
   ```

---

## Example Code

### Sending an Email
```csharp
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
```

---

## Technologies Used

- **C# .NET MAUI**
- **MVVM Architecture**
- **.NET Built-in Email Support**

---

## Contributing

Feel free to fork the repository, make changes, and submit a pull request.

---

## Contact

For any questions or suggestions, contact me at **polartev@gmail.com**.

