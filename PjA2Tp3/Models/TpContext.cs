using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PjA2Tp3.Models
{
    public partial class TpContext : DbContext
    {
        public TpContext()
        {
        }

        public TpContext(DbContextOptions<TpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<Telefone> Telefones { get; set; } = null!;
        public virtual DbSet<TelefoneUsuarioEmpresa> TelefoneUsuarioEmpresas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Vaga> Vagas { get; set; } = null!;
        public virtual DbSet<VagasTag> VagasTags { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=TrabalhoTopicos;Integrated Security=True;Encrypt=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasOne(d => d.Endereco)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.EnderecoId)
                    .HasConstraintName("FK_Empresa_Endereco1");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.PessoaId)
                    .HasConstraintName("FK_Pessoa_Endereco");
            });

            modelBuilder.Entity<TelefoneUsuarioEmpresa>(entity =>
            {
                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.TelefoneUsuarioEmpresas)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK_Local_Empresa");

                entity.HasOne(d => d.Telefone)
                    .WithMany(p => p.TelefoneUsuarioEmpresas)
                    .HasForeignKey(d => d.TelefoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empresa_Telefone");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.TelefoneUsuarioEmpresas)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_Local_Usuario");
            });

            modelBuilder.Entity<Vaga>(entity =>
            {
                entity.HasOne(d => d.PessoaJuridica)
                    .WithMany(p => p.Vagas)
                    .HasForeignKey(d => d.PessoaJuridicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empresa_Endereco");
            });

            modelBuilder.Entity<VagasTag>(entity =>
            {
                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.VagasTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Local_Tag");

                entity.HasOne(d => d.Vaga)
                    .WithMany(p => p.VagasTags)
                    .HasForeignKey(d => d.VagaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Local_Vaga");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
