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
    internal sealed class RevenueCodeConfiguration : IEntityTypeConfiguration<RevenueCode>
    {
        public void Configure(EntityTypeBuilder<RevenueCode> builder)
        {
            builder.ToTable("RevenueCodes");

           // builder.ToTable("Role", "Auth");
        }
    }
}



