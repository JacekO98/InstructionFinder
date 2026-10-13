using System.Text.Encodings.Web;
using IF.Plugins.EFCoreSqlServer;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Instruction_finder.Components.Account;

internal sealed class SmtpIdentityEmailSender(
    IConfiguration configuration) : IEmailSender<ApplicationUser>
{
    public Task SendConfirmationLinkAsync(
        ApplicationUser user, string email, string confirmationLink)
    {
        var link = HtmlEncoder.Default.Encode(confirmationLink);

        return SendAsync(
            email,
            "Potwierdź swój adres e-mail",
            $"<p>Aby potwierdzić konto, kliknij link:</p><p><a href=\"{link}\">Potwierdź adres e-mail</a></p>");
    }

    public Task SendPasswordResetLinkAsync(
        ApplicationUser user, string email, string resetLink)
    {
        var link = HtmlEncoder.Default.Encode(resetLink);

        return SendAsync(
            email,
            "Zresetuj hasło",
            $"<p>Aby zresetować hasło, kliknij link:</p><p><a href=\"{link}\">Zresetuj hasło</a></p>");
    }

    public Task SendPasswordResetCodeAsync(
        ApplicationUser user, string email, string resetCode)
    {
        var code = HtmlEncoder.Default.Encode(resetCode);

        return SendAsync(
            email,
            "Kod resetowania hasła",
            $"<p>Twój kod resetowania hasła: <strong>{code}</strong></p>");
    }

    private async Task SendAsync(string recipient, string subject, string htmlBody)
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress(
            configuration["Email:FromName"]!,
            configuration["Email:FromAddress"]!));

        message.To.Add(MailboxAddress.Parse(recipient));
        message.Subject = subject;
        message.Body = new BodyBuilder { HtmlBody = htmlBody }.ToMessageBody();

        using var client = new SmtpClient();

        await client.ConnectAsync(
            configuration["Email:SmtpServer"],
            configuration.GetValue<int>("Email:SmtpPort"),
            SecureSocketOptions.StartTls);

        await client.AuthenticateAsync(
            configuration["Email:Username"],
            configuration["Email:AppPassword"]);

        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}