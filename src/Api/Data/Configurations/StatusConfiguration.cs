using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentApi.Entities;

namespace RentApi.Data.Configurations;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public const string TableName = "status";
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(50)
            .IsRequired(false);

        // builder.HasData(
        //     new Status { Id = 1, Name = "Active", Description = "Active state" },
        //     new Status { Id = 2, Name = "Inactive", Description = "Inactive state" },
        //     new Status { Id = 3, Name = "Pending", Description = "Pending state" }
        // );
    }
}
