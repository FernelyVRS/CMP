namespace RentApi;

public class Rent
{
    public Ulid Id { get; set; }
    public decimal MonthlyRent { get; set; }
    public DateTimeOffset RentStart { get; set; }
    public DateTimeOffset RentEnd { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public int Status { get; set; }

    public int UnitId { get; set; }
    public int RenterId { get; set; }
}
