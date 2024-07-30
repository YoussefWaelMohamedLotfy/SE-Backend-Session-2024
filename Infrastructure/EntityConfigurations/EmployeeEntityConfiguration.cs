using BackendSessionDemo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

internal class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        // Makes column of type nvarchar(200) instead of nvarchar(max)
        builder.Property(x => x.FullName).HasMaxLength(200);
    }
}
