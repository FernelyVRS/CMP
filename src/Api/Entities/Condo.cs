namespace RentApi;

public class Condo
{
    public Ulid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Ulid ManagerId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public Address Address { get; set; }
}
