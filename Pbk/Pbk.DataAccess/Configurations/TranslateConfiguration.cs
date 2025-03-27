using Pbk.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Pbk.DataAccess.Configurations
{
    internal sealed class TranslateConfiguration : IEntityTypeConfiguration<Translate>
    {
        public void Configure(EntityTypeBuilder<Translate> builder)
        {
            builder.ToTable("Translate", "Config");
            builder.HasKey(x => x.TranslateId);
        }
    }

}
