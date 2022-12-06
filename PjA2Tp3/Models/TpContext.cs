using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PjA2Tp3.Models
{
    public partial class TpContext : DbContext
    {
        

        public TpContext(DbContextOptions<TpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empresa> Empresas { get; set; } 
        public virtual DbSet<Endereco> Enderecos { get; set; } 
        public virtual DbSet<Tag> Tags { get; set; } 
        public virtual DbSet<Telefone> Telefones { get; set; } 
        public virtual DbSet<Usuario> Usuarios { get; set; } 
        public virtual DbSet<Vaga> Vagas { get; set; } 
        public virtual DbSet<VagaTag> VagaTags { get; set; }  
        public virtual DbSet<TelefoneEmpresa> TelefoneEmpresas { get; set; }    
        public virtual DbSet<EnderecoEmpresa> EnderecoEmpresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VagaTag>().HasKey(st => new { st.TagId, st.VagaId });

            modelBuilder.Entity<VagaTag>()
             .HasOne<Tag>(st => st.Tag)
              .WithMany(s => s.Vagas)
              .HasForeignKey(st => st.VagaId);

            modelBuilder.Entity<VagaTag>()
             .HasOne<Vaga>(s => s.Vaga)
              .WithMany(t => t.Tags)
              .HasForeignKey(s => s.TagId);
        }

       
    }
}
