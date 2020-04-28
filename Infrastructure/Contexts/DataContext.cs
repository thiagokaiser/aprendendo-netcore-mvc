using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Infrastructure.Contexts
{    
    public class DataContext : DbContext
    {        
        public DbSet<Despesa> Despesa { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
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