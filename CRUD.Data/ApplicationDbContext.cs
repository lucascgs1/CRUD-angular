using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CRUD.Model;

namespace CRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(
                entity =>
                {
                    entity.HasMany(s => s.Enderecos);
                });
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
    }
}
