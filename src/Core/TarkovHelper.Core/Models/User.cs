using System.Net.Mail;
using System.Text.RegularExpressions;
using TarkovHelper.Core.Domain;

namespace TarkovHelper.Core.Models;

public partial class User
{
    protected User()
    {
    }

    public User(int Id, string username, string email)
    {
        SetUsername(username);
        SetEmail(email);
    }

    public int Id { get; protected set; }

    public string Username { get; protected set; }

    public string Password { get; protected set; }

    public string Email { get; protected set; }

    public string Salt { get; protected set; }

    public string Role { get; protected set; }

    public DateTime CreateAt { protected get; set; }

    public DateTime UpdatedAt { protected get; set; }

    [GeneratedRegex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$")]
    private static partial Regex UserNameRegex();

    private void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException(ErrorCodes.InvalidEmail,
                "Email can not be empty.");

        try
        {
            MailAddress address = new(email);
        }
        catch (FormatException)
        {
            throw new DomainException(ErrorCodes.InvalidEmail,
                "Email is invalid.");
        }

        if (Email == email) return;

        Email = email.ToLowerInvariant();
        UpdatedAt = DateTime.UtcNow;
    }

    private void SetUsername(string username)
    {
        if (!UserNameRegex().IsMatch(username))
            throw new DomainException(ErrorCodes.InvalidUsername,
                "Username is invalid.");

        if (string.IsNullOrEmpty(username))
            throw new DomainException(ErrorCodes.InvalidUsername,
                "Username is invalid.");

        Username = username;
        UpdatedAt = DateTime.UtcNow;
    }

    private void SetRole(string role)
    {
        if (string.IsNullOrWhiteSpace(role))
            throw new DomainException(ErrorCodes.InvalidRole,
                "Role can not be empty.");
        if (Role == role) return;
        Role = role;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetPassword(string password, string salt)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new DomainException(ErrorCodes.InvalidPassword,
                "Password can not be empty.");
        if (string.IsNullOrWhiteSpace(salt))
            throw new DomainException(ErrorCodes.InvalidPassword,
                "Salt can not be empty.");
        switch (password.Length)
        {
            case < 4:
                throw new DomainException(ErrorCodes.InvalidPassword,
                    "Password must contain at least 4 characters.");
            case > 100:
                throw new DomainException(ErrorCodes.InvalidPassword,
                    "Password can not contain more than 100 characters.");
        }

        if (Password == password) return;
        Password = password;
        Salt = salt;
        UpdatedAt = DateTime.UtcNow;
    }
}