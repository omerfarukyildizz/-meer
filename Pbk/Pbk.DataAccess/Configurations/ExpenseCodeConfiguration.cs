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
    internal sealed class ExpenseCodeConfiguration : IEntityTypeConfiguration<ExpenseCode>
    {
        public void Configure(EntityTypeBuilder<ExpenseCode> builder)
        {
            builder.ToTable("ExpenseCodes");

           // builder.ToTable("Role", "Auth");
        }
    }
}



