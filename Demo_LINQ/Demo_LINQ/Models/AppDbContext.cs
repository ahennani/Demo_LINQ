using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Demo_LINQ.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employe> Employes { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<Fourniture> Fournitures { get; set; }
        public virtual DbSet<Participer> Participers { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Projet> Projets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Demo_LINQ;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.NumDepartment)
                    .HasName("PK__Departme__2F3606BCA41F1BA0");

                entity.ToTable("Department");

                entity.Property(e => e.NumDepartment)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Num_Department");

                entity.Property(e => e.Lieu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Department");
            });

            modelBuilder.Entity<Employe>(entity =>
            {
                entity.HasKey(e => e.Matricule)
                    .HasName("PK__Employe__0FB9FB42F29433F5");

                entity.ToTable("Employe");

                entity.Property(e => e.Matricule)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdSup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID_Sup");

                entity.Property(e => e.NameEmploye)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Employe");

                entity.Property(e => e.NumDepartment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Num_Department");

                entity.Property(e => e.Poste)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salaire).HasColumnType("money");

                entity.HasOne(d => d.IdSupNavigation)
                    .WithMany(p => p.InverseIdSupNavigation)
                    .HasForeignKey(d => d.IdSup)
                    .HasConstraintName("FK__Employe__ID_Sup__38996AB5");

                entity.HasOne(d => d.NumDepartmentNavigation)
                    .WithMany(p => p.Employes)
                    .HasForeignKey(d => d.NumDepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employe__Num_Dep__398D8EEE");
            });

            modelBuilder.Entity<Fournisseur>(entity =>
            {
                entity.HasKey(e => e.NumFourniture)
                    .HasName("PK__Fourniss__C10ED305FC51716E");

                entity.ToTable("Fournisseur");

                entity.Property(e => e.NumFourniture)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Num_Fourniture");

                entity.Property(e => e.NameFournisseur)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Fournisseur");

                entity.Property(e => e.Ville)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fourniture>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Fourniture");

                entity.Property(e => e.CodeProduit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Code_Produit");

                entity.Property(e => e.NumFourniture)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Num_Fourniture");

                entity.HasOne(d => d.CodeProduitNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodeProduit)
                    .HasConstraintName("FK__Fournitur__Code___45F365D3");

                entity.HasOne(d => d.NumFournitureNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.NumFourniture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fournitur__Num_F__44FF419A");
            });

            modelBuilder.Entity<Participer>(entity =>
            {
                entity.HasKey(e => new { e.Matricule, e.CodeProjet })
                    .HasName("PK__Particip__D4B452D79391D420");

                entity.ToTable("Participer");

                entity.Property(e => e.Matricule)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodeProjet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Code_Projet");

                entity.HasOne(d => d.CodeProjetNavigation)
                    .WithMany(p => p.Participers)
                    .HasForeignKey(d => d.CodeProjet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Participe__Code___3F466844");

                entity.HasOne(d => d.MatriculeNavigation)
                    .WithMany(p => p.Participers)
                    .HasForeignKey(d => d.Matricule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Participe__Matri__3E52440B");
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(e => e.CodeProduit)
                    .HasName("PK__Produit__1706ED70D67EE8A2");

                entity.ToTable("Produit");

                entity.Property(e => e.CodeProduit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Code_Produit");

                entity.Property(e => e.Couleur)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Origine)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Projet>(entity =>
            {
                entity.HasKey(e => e.CodeProjet)
                    .HasName("PK__Projet__B0DA995C0ACED830");

                entity.ToTable("Projet");

                entity.Property(e => e.CodeProjet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Code_Projet");

                entity.Property(e => e.NameProjet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Projet");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
