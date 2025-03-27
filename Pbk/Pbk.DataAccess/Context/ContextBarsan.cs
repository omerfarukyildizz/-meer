using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.DataAccess.Context
{
    public class ContextBarsan : DbContext, IUnitOfWork
    {
        public ContextBarsan(DbContextOptions<ContextBarsan> options) : base(options)
        {
        }
        public DbSet<Gnladresbankasi> Gnladresbankasi { get; set; }
        public DbSet<YdNakMasrafHesapPlani> YdNakMasrafHesapPlani { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextBarsan).Assembly);
            modelBuilder.Entity<Gnladresbankasi>().ToTable("gnladresbankasi", "dbo");
            modelBuilder.Entity<YdNakMasrafHesapPlani>().ToTable("ydnakmasrafhesapplani", "dbo");
        }
    }
}
