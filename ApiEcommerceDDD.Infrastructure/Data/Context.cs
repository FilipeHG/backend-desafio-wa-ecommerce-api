using Microsoft.EntityFrameworkCore;
using ApiEcommerceDDD.Domain.Entitys;
using System;
using System.Linq;

namespace ApiEcommerceDDD.Infrastructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new Mappings.TokenMapping());

        //    base.OnModelCreating(modelBuilder);
        //}

        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property("DataCriacao").CurrentValue = DateTime.Now;
        //        }
        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Property("DataCriacao").IsModified = false;
        //        }
        //    }
        //    return base.SaveChanges();
        //}

        public virtual DbSet<Frota> Frota { get; set; }

        public virtual DbSet<Pedido> Pedido { get; set; }

        public virtual DbSet<Endereco> Endereco { get; set; }

        public virtual DbSet<Produto> Produto { get; set; }
    }
}