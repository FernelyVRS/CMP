using RentApi.Entities;

namespace RentApi;

public class Unit
{
    protected Unit() { }
    public Unit(string suite, string building, int bedrooms, int bathrooms, int kitchens, decimal squareFootage, bool isCondo)
    {
        Id = Ulid.NewUlid();
        Suite = suite;
        Building = building;
        Bedrooms = bedrooms;
        Bathrooms = bathrooms;
        Kitchens = kitchens;
        SquareFootage = squareFootage;
        IsCondo = isCondo;
        CreatedAt = DateTime.UtcNow;
        StatusId = 1;
    }

    public Ulid Id { get; private init; }
    public int UnitType { get; set; }
    public string Suite { get; private set; }
    public string Building { get; private set; }
    public int Bedrooms { get; private set; }
    public int Bathrooms { get; private set; }
    public int Kitchens { get; private set; }
    public decimal SquareFootage { get; private set; }
    public bool IsCondo { get; private set; }
    public DateTime CreatedAt { get; private init; }
    public DateTime UpdatedAt { get; private set; }

    public Status? Status { get; private set; }
    public int StatusId { get; private set; }

    public Address? Address { get; private set; }
    // public Ulid  AddressId { get; private set; }
    // public Condo Condo { get; set; }
    // public int CondoId { get; set; }
    // public User User { get; set; }
    // public int Owner_Id { get; set; }
}
