using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using AtendimentoOnline.Entidade;
using MySql.Data.Entity;

namespace AtendimentoOnline.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Context : DbContext
        {
            public Context(): base("Conn")
            {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
            }

            public DbSet<Categoria> Categorias { get; set; }
            public DbSet<Atendimento> Atendimentos { get; set; }
            public DbSet<Endereco> Enderecos { get; set; }
            public DbSet<Perfil> Perfils { get; set; }
            public DbSet<Pessoa> Pessoas { get; set; }
            public DbSet<Sexo> Sexos { get; set; }
            public DbSet<Status> Statuss { get; set; }
            public DbSet<TipoAtendimento> TipoAtendimentos { get; set; }
            public DbSet<TipoPessoa> TipoPessoas { get; set; }
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Descritivo> Descritivos { get; set; }
            public DbSet<UF> UFs { get; set; }
            public DbSet<Municipio> Municipios { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.ManyToManyCascadeDeleteConvention>();
        }

    }
}
