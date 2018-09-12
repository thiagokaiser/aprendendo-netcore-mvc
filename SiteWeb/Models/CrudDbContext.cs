using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SiteWeb.Models
{    
    public class CrudDbContext : DbContext
    {
        public DbSet<Teste> Teste { get; set; }
        public DbSet<Despesa> Despesa { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        public CrudDbContext(DbContextOptions<CrudDbContext> options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=siteweb.db");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Despesa>().HasOne(p => p.Categoria);
            base.OnModelCreating(modelBuilder);     

        }
    }
}