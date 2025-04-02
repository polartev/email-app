using Microsoft.Maui.ApplicationModel.Communication;

namespace Pmail.Models;

internal static class EmailDataBase
{
    public async static Task<IEnumerable<Email>> GetEmails()
    {
        string filePath = Path.Combine(FileSystem.AppDataDirectory, "data.json");

        if (!File.Exists(filePath))
            return new List<Email>();

        using FileStream stream = File.OpenRead(filePath);

        System.Text.Json.JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true,
        };

        return await System.Text.Json.JsonSerializer.DeserializeAsync<List<Email>>(stream, options) ?? new List<Email>();
    }

    public async static Task AddEmail(Email newEmail)
    {
        string filePath = Path.Combine(FileSystem.AppDataDirectory, "data.json");

        List<Email> emails = new();

        if (File.Exists(filePath))
        {
            using FileStream readStream = File.OpenRead(filePath);
            emails = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Email>>(readStream) ?? new List<Email>();
        }

        emails.Add(newEmail);

        using FileStream writeStream = File.Create(filePath);
        System.Text.Json.JsonSerializerOptions options = new() { WriteIndented = true };
        await System.Text.Json.JsonSerializer.SerializeAsync(writeStream, emails, options);
    }
}
