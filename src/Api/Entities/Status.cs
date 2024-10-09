using System;

namespace RentApi.Entities;

public class Status
{
    public int Id { get; set;}
    public string Name { get; set;} = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<Unit> Units { get; set; }
}
