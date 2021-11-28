using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HouseOfShows.WebMVC.Models
{
    public partial class houseofshowsContext : DbContext
    {
        public houseofshowsContext()
        {
        }

        public houseofshowsContext(DbContextOptions<houseofshowsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Responsavei> Responsaveis { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<TipoIngresso> TipoIngressos { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=houseofshows;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PK__Clientes__C1F8973039679CD5");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CIDADE");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("DATA_NASCIMENTO");

                entity.Property(e => e.Idade).HasColumnName("IDADE");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("UF")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CpfResponsavel)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF_RESPONSAVEL");

                entity.Property(e => e.DataEvento)
                    .HasColumnType("date")
                    .HasColumnName("DATA_EVENTO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.Property(e => e.NomeStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME_STATUS");

                entity.Property(e => e.ValorInteira)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("VALOR_INTEIRA");

                entity.Property(e => e.ValorMeia)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("VALOR_MEIA");

                entity.HasOne(d => d.CpfResponsavelNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.CpfResponsavel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CPF_RESPONSAVEL");

                entity.HasOne(d => d.NomeStatusNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.NomeStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NOME_STATUS");
            });

            modelBuilder.Entity<Responsavei>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PK__Responsa__C1F897305501FC37");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CIDADE");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("DATA_NASCIMENTO");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ENDERECO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("UF")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.NomeStatus)
                    .HasName("PK__Status__968AD0C88EEF1BE8");

                entity.ToTable("Status");

                entity.Property(e => e.NomeStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME_STATUS");
            });

            modelBuilder.Entity<TipoIngresso>(entity =>
            {
                entity.HasKey(e => e.TipoIngresso1)
                    .HasName("PK__TipoIngr__F2A73A498D195797");

                entity.ToTable("TipoIngresso");

                entity.Property(e => e.TipoIngresso1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_INGRESSO");
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.HasKey(e => e.IdVenda)
                    .HasName("PK__Vendas__F3B65F88019D8403");

                entity.Property(e => e.IdVenda).HasColumnName("ID_VENDA");

                entity.Property(e => e.CpfCliente)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF_CLIENTE");

                entity.Property(e => e.IdEvento).HasColumnName("ID_EVENTO");

                entity.Property(e => e.QtdIngresso).HasColumnName("QTD_INGRESSO");

                entity.Property(e => e.TipoIngresso)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_INGRESSO");

                entity.Property(e => e.ValorTotal)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("VALOR_TOTAL");

                entity.HasOne(d => d.CpfClienteNavigation)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.CpfCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CPF_CLIENTE");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.IdEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ID_EVENTO");

                entity.HasOne(d => d.TipoIngressoNavigation)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.TipoIngresso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TIPO_INGRESSO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
