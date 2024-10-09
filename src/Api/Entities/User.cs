using System;

namespace RentApi.Entities;

public class User
{
    public Ulid Id { get; set; }
    public string ExternalUserApi { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phonenumber { get; set; } = string.Empty;
    public DateTime Birthdate { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}
