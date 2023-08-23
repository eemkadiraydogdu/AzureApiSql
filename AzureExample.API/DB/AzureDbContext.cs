using System;
using System.Collections.Generic;
using AzureExample.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureExample.API.DB;

public partial class AzureDbContext : DbContext
{
    public AzureDbContext()
    {
    }

    public AzureDbContext(DbContextOptions<AzureDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Product { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:sqlserver-kadir-001.database.windows.net,1433;Initial Catalog=AzuraExampleDb;Persist Security Info=False;User ID=kadir;Password=Ka187155;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
