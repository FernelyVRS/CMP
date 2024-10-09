using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentApi;

public class AddressConfigutation : IEntityTypeConfiguration<Address>
{
    public const string TableName = "addresses";

    public void Configure(EntityTypeBuilder<Address> builder)
    {

        builder.ToTable(TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(x => x.Country)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(x => x.StateProvince)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.City)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Street)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.PostalCode)
            .IsRequired(false)
            .HasMaxLength(10);

        builder.Property(x => x.Latitude)
            .IsRequired();

        builder.Property(x => x.Longitude)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .IsRequired(false);

        builder.HasOne(x => x.Unit)
            .WithOne(u => u.Address)
            .HasForeignKey<Address>(x => x.UnitId);

    }
}
