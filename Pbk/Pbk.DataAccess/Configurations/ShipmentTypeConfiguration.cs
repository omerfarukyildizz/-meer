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
    internal sealed class ShipmentTypeConfiguration : IEntityTypeConfiguration<ShipmentType>
    {
        public void Configure(EntityTypeBuilder<ShipmentType> builder)
        {
            builder.ToTable("ShipmentTypes");

           // builder.ToTable("Role", "Auth");
        }
    }
}



