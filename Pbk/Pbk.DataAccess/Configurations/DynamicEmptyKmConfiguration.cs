using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pbk.Entities.Models;

namespace Pbk.DataAccess.Configurations
{

    internal sealed class DynamicEmptyKmConfiguration : IEntityTypeConfiguration<DynamicEmptyKm>
    {
        public void Configure(EntityTypeBuilder<DynamicEmptyKm> builder)
        {
            builder.ToTable("DynamicEmptyKm");
        }
    }
}
