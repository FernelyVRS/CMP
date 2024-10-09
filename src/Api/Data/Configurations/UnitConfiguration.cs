using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RentApi.Data.Configurations;

public class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
    public const string TableName = "units";
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(x => x.Suite)
            .HasMaxLength(5)
            .IsRequired();

        builder.Property(x => x.Building)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Bathrooms)
            .IsRequired();

        builder.Property(x => x.Bedrooms)
            .IsRequired();

        builder.Property(x => x.Kitchens)
            .IsRequired();

        builder
            .Property(x => x.CreatedAt)
            .IsRequired();

        builder
            .Property(x => x.UpdatedAt)
            .IsRequired(false);

        builder.HasOne(x => x.Status)
            .WithMany(s => s.Units)
            .HasForeignKey(x => x.StatusId)
            .IsRequired();


        // public Condo Condo { get; set; }
        // public int CondoId { get; set; }
        // public User User { get; set; }
        // public int Owner_Id { get; set; }
    }
}
