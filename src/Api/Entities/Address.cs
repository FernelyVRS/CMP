using System.Drawing;

namespace RentApi;

public class Address
{
    protected Address() { }
    public Address(string country, string stateProvince, string city, string street, string postalCode, double latitude, double longitude, Ulid unitId)
    {
        Id = Ulid.NewUlid();
        Country = country;
        StateProvince = stateProvince;
        City = city;
        Street = street;
        PostalCode = postalCode;
        Latitude = latitude;
        Longitude = longitude;
        CreatedAt = DateTime.UtcNow;
        UnitId = unitId;
    }

    public Ulid Id { get; private init;}
    public string Country { get; private set; }
    public string StateProvince { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public string PostalCode { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    public DateTime CreatedAt { get; private init; }
    public DateTime UpdatedAt { get; private set; }

    public Ulid UnitId { get; private set; }
    public Unit? Unit { get; private set; }

    // public Ulid CondoId { get; set; }
    // public Condo Condo { get; set; }

}
