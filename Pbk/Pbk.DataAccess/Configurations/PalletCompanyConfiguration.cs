using Pbk.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.DataAccess.Configurations
{
    
    internal sealed class PalletCompanyConfiguration : IEntityTypeConfiguration<PalletCompany>
    {
        public void Configure(EntityTypeBuilder<PalletCompany> builder)
        {
            builder.ToTable("PalletCompanies");
        }
    }

}


