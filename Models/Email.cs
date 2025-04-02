namespace Pmail.Models;

public record Email(string Subject, string Body, string From, string To, DateTime Date);