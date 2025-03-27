using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
 using Pbk.Entities.Models;


namespace Pbk.DataAccess.Configurations
{
    internal sealed class EntryTypeConfiguration : IEntityTypeConfiguration<EntryType>
    {
        public void Configure(EntityTypeBuilder<EntryType> builder)
        {
            builder.ToTable("EntryType", "Auth");
        }
    }
}



