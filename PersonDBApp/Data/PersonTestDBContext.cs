using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PersonDBApp.Models;

#nullable disable

namespace PersonDBApp.Data
{
    public partial class PersonTestDBContext : DbContext
    {
        public PersonTestDBContext()
        {
        }

        public PersonTestDBContext(DbContextOptions<PersonTestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Nuoremmat> Nuoremmats { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Shoe> Shoes { get; set; }
        public virtual DbSet<Yhteystiedot> Yhteystiedots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=PersonTestDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Nuoremmat>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("nuoremmat");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EyeColor)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Sex)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.HasIndex(e => e.DateOfBirth, "idx_BirthDate");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EyeColor)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Sex)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("Phone");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Personid).HasColumnName("personid");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.Test)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("test");
            });

            modelBuilder.Entity<Shoe>(entity =>
            {
                entity.ToTable("shoe");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("brand");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.Personid).HasColumnName("personid");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Shoes)
                    .HasForeignKey(d => d.Personid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__shoe__personid__4AB81AF0");
            });

            modelBuilder.Entity<Yhteystiedot>(entity =>
            {
                entity.ToTable("Yhteystiedot");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Arvo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("arvo");

                entity.Property(e => e.Personid).HasColumnName("personid");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.Tyyppi)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tyyppi");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Yhteystiedots)
                    .HasForeignKey(d => d.Personid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Yhteystie__perso__571DF1D5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
