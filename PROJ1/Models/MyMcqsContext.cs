using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PROJ1.Models;

public partial class MyMcqsContext : DbContext
{
    public MyMcqsContext()
    {
    }

    public MyMcqsContext(DbContextOptions<MyMcqsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auth> Auths { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-3IKAFCF\\SQLEXPRESS;Database=myMCQS;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Auth__3214EC07EFBBF2E1");

            entity.ToTable("Auth");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Emailis)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Passwordis)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Usernameis)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC070123674B");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Answer)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Option1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Option2)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Option3)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Option4)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Question1)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("Question");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
