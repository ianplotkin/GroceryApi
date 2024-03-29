﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GroceryApi.Models;

public partial class groceryContext : DbContext
{
    public groceryContext(DbContextOptions<groceryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Grocery> Groceries { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<StoreArea> StoreAreas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07329A2949");

            entity.ToTable("Category");

            entity.Property(e => e.Icon).HasMaxLength(50);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Grocery>(entity =>
        {
            entity.ToTable("Grocery");

            entity.Property(e => e.DefaultUnit)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Groceries)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grocery_Category");

            entity.HasMany(d => d.StoreAreas).WithMany(p => p.Groceries)
                .UsingEntity<Dictionary<string, object>>(
                    "GroceryInStore",
                    r => r.HasOne<StoreArea>().WithMany()
                        .HasForeignKey("StoreAreaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_StoreAreaMember_StoreArea"),
                    l => l.HasOne<Grocery>().WithMany()
                        .HasForeignKey("GroceryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_StoreAreaMember_Grocery"),
                    j =>
                    {
                        j.HasKey("GroceryId", "StoreAreaId").HasName("PK_StoreAreaMember");
                        j.ToTable("GroceryInStore");
                    });
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.ToTable("Store");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<StoreArea>(entity =>
        {
            entity.ToTable("StoreArea");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Store).WithMany(p => p.StoreAreas)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreArea_Store");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}