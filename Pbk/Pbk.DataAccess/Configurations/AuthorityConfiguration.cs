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
 

    internal sealed class AuthorityConfiguration : IEntityTypeConfiguration<Authority>
    {
        public void Configure(EntityTypeBuilder<Authority> builder)
        {
            builder.ToTable("Authority");
        }
    }
}
