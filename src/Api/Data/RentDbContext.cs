using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentApi.Entities;

namespace RentApi.Data.Configurations;

public class RentDbContext : DbContext
{
    public RentDbContext(DbContextOptions options) : base(options) { }

    //public DbSet<User> Users { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<Ulid>()
            .HaveConversion<UlidToStringConverter>();
    }
}

public class UlidToStringConverter : ValueConverter<Ulid, string>
{
    private static readonly ConverterMappingHints defaultHints = new ConverterMappingHints(size: 26);

    public UlidToStringConverter() : this(null)
    {
    }

    public UlidToStringConverter(ConverterMappingHints mappingHints = null)
        : base(
                convertToProviderExpression: x => x.ToString(),
                convertFromProviderExpression: x => Ulid.Parse(x),
                mappingHints: defaultHints.With(mappingHints))
    {
    }
}
