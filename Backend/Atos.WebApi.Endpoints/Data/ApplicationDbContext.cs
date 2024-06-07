using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Atos.WebApi.Endpoints.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public virtual DbSet<LimitesTerminal> LimitesTerminais { get; set; }

    public virtual DbSet<MovimentacaoPA> MovimentacoesPAs { get; set; }

    public virtual DbSet<Terminal> Terminais { get; set; }

    public virtual DbSet<TiposOperacao> TiposOperacoes { get; set; }

    public virtual DbSet<TipoTerminal> TipoTerminais { get; set; }

    public virtual DbSet<TransacoesInterbancario> TransacoesInterbancarios { get; set; }

    public virtual DbSet<Transportadora> Transportadoras { get; set; }

    public virtual DbSet<TransportadorasPA> TransportadorasPAs { get; set; }

    public virtual DbSet<UnidadeInstituicao> UnidadeInstituicoes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<LimitesTerminal>(entity =>
        {
            entity.HasKey(e => new { e.IdPontoAtendimento, e.CodigoTipoTerminal })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("limitesterminal");

            entity.HasIndex(e => e.CodigoTipoTerminal, "CODIGOTIPOTERMINAL");

            entity.Property(e => e.IdPontoAtendimento).HasColumnName("IDPONTOATENDIMENTO");
            entity.Property(e => e.CodigoTipoTerminal).HasColumnName("CODIGOTIPOTERMINAL");
            entity.Property(e => e.LimInferior).HasColumnName("LIM_INFERIOR");
            entity.Property(e => e.LimSuperior).HasColumnName("LIM_SUPERIOR");

            entity.HasOne(d => d.TipoTerminal).WithMany(p => p.LimitesTerminais)
                .HasForeignKey(d => d.CodigoTipoTerminal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("limitesterminal_ibfk_2");

            entity.HasOne(d => d.UnidadeInstituicao).WithMany(p => p.LimitesTerminais)
                .HasForeignKey(d => d.IdPontoAtendimento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("limitesterminal_ibfk_1");
        });

        modelBuilder.Entity<MovimentacaoPA>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("movimentacaopa");

            entity.HasIndex(e => new { e.CNPJTransportadora, e.IdPontoAtendimento }, "CNPJTRANSPORTADORA");

            entity.HasIndex(e => new { e.IdGrupoOpCaixa, e.IdOperacaoCaixa, e.Historico }, "IDGRUPOOPCAIXA");

            entity.HasIndex(e => e.IdTipoTerminal, "IDTIPOTERMINAL");

            entity.Property(e => e.CNPJTransportadora)
                .HasMaxLength(14)
                .HasColumnName("CNPJTRANSPORTADORA");
            entity.Property(e => e.DataLancamento)
                .HasColumnType("datetime")
                .HasColumnName("DATALANCAMENTO");
            entity.Property(e => e.Historico).HasColumnName("HISTORICO");
            entity.Property(e => e.IdGrupoOpCaixa).HasColumnName("IDGRUPOOPCAIXA");
            entity.Property(e => e.IdOperacaoCaixa).HasColumnName("IDOPERACAOCAIXA");
            entity.Property(e => e.IdPontoAtendimento).HasColumnName("IDPONTOATENDIMENTO");
            entity.Property(e => e.IdTipoTerminal).HasColumnName("IDTIPOTERMINAL");
            entity.Property(e => e.Valor)
                .HasPrecision(15, 2)
                .HasColumnName("VALOR");

            entity.HasOne(d => d.TipoTerminal).WithMany()
                .HasForeignKey(d => d.IdTipoTerminal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movimentacaopa_ibfk_2");

            entity.HasOne(d => d.TransportadorasPA).WithMany()
                .HasForeignKey(d => new { d.CNPJTransportadora, d.IdPontoAtendimento })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movimentacaopa_ibfk_1");

            entity.HasOne(d => d.TiposOperacao).WithMany()
                .HasForeignKey(d => new { d.IdGrupoOpCaixa, d.IdOperacaoCaixa, d.Historico })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movimentacaopa_ibfk_3");
        });

        modelBuilder.Entity<Terminal>(entity =>
        {
            entity.HasKey(e => new { e.IdUnidadeiIst, e.NumTerminal })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("terminal");

            entity.HasIndex(e => e.IdTipoTerminal, "IDTIPOTERMINAL");

            entity.HasIndex(e => e.Idusuario, "IDUSUARIO");

            entity.Property(e => e.IdUnidadeiIst).HasColumnName("IDUNIDADEINST");
            entity.Property(e => e.NumTerminal).HasColumnName("NUMTERMINAL");
            entity.Property(e => e.IdTipoTerminal).HasColumnName("IDTIPOTERMINAL");
            entity.Property(e => e.Idusuario)
                .HasMaxLength(30)
                .HasColumnName("IDUSUARIO");

            entity.HasOne(d => d.TipoTerminal).WithMany(p => p.Terminais)
                .HasForeignKey(d => d.IdTipoTerminal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("terminal_ibfk_2");

            entity.HasOne(d => d.UnidadeInstituicao).WithMany(p => p.Terminais)
                .HasForeignKey(d => d.IdUnidadeiIst)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("terminal_ibfk_1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Terminals)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("terminal_ibfk_3");
        });

        modelBuilder.Entity<TiposOperacao>(entity =>
        {
            entity.HasKey(e => new { e.IdGrupoOpCaixa, e.IdOperacaoCaixa, e.Historico })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("tiposoperacao");

            entity.Property(e => e.IdGrupoOpCaixa).HasColumnName("IDGRUPOOPCAIXA");
            entity.Property(e => e.IdOperacaoCaixa).HasColumnName("IDOPERACAOCAIXA");
            entity.Property(e => e.Historico).HasColumnName("HISTORICO");
            entity.Property(e => e.DescricaoHistorico)
                .HasMaxLength(100)
                .HasColumnName("DESCRICAOHISTORICO");
            entity.Property(e => e.DescricaoOperacao)
                .HasMaxLength(100)
                .HasColumnName("DESCRICAOOPERACAO");
            entity.Property(e => e.Sensibilizacao).HasColumnName("SENSIBILIZACAO");
        });

        modelBuilder.Entity<TipoTerminal>(entity =>
        {
            entity.HasKey(e => e.IdTipoTerminal).HasName("PRIMARY");

            entity.ToTable("tipoterminal");

            entity.Property(e => e.IdTipoTerminal)
                .ValueGeneratedNever()
                .HasColumnName("IDTIPOTERMINAL");
            entity.Property(e => e.DescTerminal)
                .HasMaxLength(30)
                .HasColumnName("DESCTERMINAL");
        });

        modelBuilder.Entity<TransacoesInterbancario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("transacoesinterbancario");

            entity.Property(e => e.Agencia).HasColumnName("AGENCIA");
            entity.Property(e => e.Banco).HasColumnName("BANCO");
            entity.Property(e => e.DataMovimento)
                .HasColumnType("datetime")
                .HasColumnName("DATAMOVIMENTO");
            entity.Property(e => e.Operacao)
                .HasMaxLength(6)
                .HasColumnName("OPERACAO");
            entity.Property(e => e.Situacao)
                .HasMaxLength(20)
                .HasColumnName("SITUACAO");
            entity.Property(e => e.Valor)
                .HasPrecision(15, 2)
                .HasColumnName("VALOR");
        });

        modelBuilder.Entity<Transportadora>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("transportadoras");

            entity.Property(e => e.CNPJTransportadora)
                .HasMaxLength(14)
                .HasColumnName("CNPJTRANSPORTADORA");
            entity.Property(e => e.DescTransportadora)
                .HasMaxLength(100)
                .HasColumnName("DESCTRANSPORTADORA");
        });

        modelBuilder.Entity<TransportadorasPA>(entity =>
        {
            entity.HasKey(e => new { e.CNPJTransportadora, e.IdPontoAtendimento })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("transportadoraspa");

            entity.HasIndex(e => e.IdPontoAtendimento, "IDPONTOATENDIMENTO");

            entity.Property(e => e.CNPJTransportadora)
                .HasMaxLength(14)
                .HasColumnName("CNPJTRANSPORTADORA");
            entity.Property(e => e.IdPontoAtendimento).HasColumnName("IDPONTOATENDIMENTO");

            entity.HasOne(d => d.UnidadeInstituicao).WithMany(p => p.TransportadorasPAs)
                .HasForeignKey(d => d.IdPontoAtendimento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transportadoraspa_ibfk_1");
        });

        modelBuilder.Entity<UnidadeInstituicao>(entity =>
        {
            entity.HasKey(e => e.IdUnidadeInst).HasName("PRIMARY");

            entity.ToTable("unidadeinstituicao");

            entity.Property(e => e.IdUnidadeInst)
                .ValueGeneratedNever()
                .HasColumnName("IDUNIDADEINST");
            entity.Property(e => e.CodTipoUnidade).HasColumnName("CODTIPOUNIDADE");
            entity.Property(e => e.NomeUnidade)
                .HasMaxLength(100)
                .HasColumnName("NOMEUNIDADE");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Idunidadeinstusuario, "IDUNIDADEINSTUSUARIO");

            entity.Property(e => e.Idusuario)
                .HasMaxLength(30)
                .HasColumnName("IDUSUARIO");
            entity.Property(e => e.Descnomeusuario)
                .HasMaxLength(100)
                .HasColumnName("DESCNOMEUSUARIO");
            entity.Property(e => e.Idunidadeinstusuario).HasColumnName("IDUNIDADEINSTUSUARIO");

            entity.HasOne(d => d.UnidadeInstituicao).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idunidadeinstusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuario_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
