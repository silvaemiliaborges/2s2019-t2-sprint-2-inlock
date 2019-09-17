using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.InLock.WebApi.Domains
{
    public partial class InLockContext : DbContext
    {
        public InLockContext()
        {
        }

        public InLockContext(DbContextOptions<InLockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudio> Estudio { get; set; }
        public virtual DbSet<Jogo> Jogo { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-9SBL6QT ;Initial Catalog=T_INLOCK;User Id=sa;Pwd=132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudio>(entity =>
            {
                entity.HasKey(e => e.Idestudio);

                entity.ToTable("ESTUDIO");

                entity.Property(e => e.Idestudio).HasColumnName("IDESTUDIO");

                entity.Property(e => e.Datacriacao)
                    .HasColumnName("DATACRIACAO")
                    .HasColumnType("date");

                entity.Property(e => e.Estudio1)
                    .IsRequired()
                    .HasColumnName("ESTUDIO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Estudio)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK__ESTUDIO__IDUSUAR__4E88ABD4");
            });

            modelBuilder.Entity<Jogo>(entity =>
            {
                entity.HasKey(e => e.Idjogo);

                entity.ToTable("JOGO");

                entity.Property(e => e.Idjogo).HasColumnName("IDJOGO");

                entity.Property(e => e.Datalancamento)
                    .HasColumnName("DATALANCAMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Idestudio).HasColumnName("IDESTUDIO");

                entity.Property(e => e.Jogo1)
                    .IsRequired()
                    .HasColumnName("JOGO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnName("VALOR");

                entity.HasOne(d => d.IdestudioNavigation)
                    .WithMany(p => p.Jogo)
                    .HasForeignKey(d => d.Idestudio)
                    .HasConstraintName("FK__JOGO__IDESTUDIO__5165187F");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.Idperfil);

                entity.ToTable("PERFIL");

                entity.Property(e => e.Idperfil).HasColumnName("IDPERFIL");

                entity.Property(e => e.Perfil1)
                    .IsRequired()
                    .HasColumnName("PERFIL")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.ToTable("USUARIO");

                entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Idperfil).HasColumnName("IDPERFIL");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdperfilNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.Idperfil)
                    .HasConstraintName("FK__USUARIO__IDPERFI__4BAC3F29");
            });
        }
    }
}
