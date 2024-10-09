namespace RentApi;

public class ServiceSubscription
{
    public Ulid Id { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public int Status { get; set; }

    public int UnitId { get; set; }
    public int ServiceId { get; set; }
}
