namespace AtendimentoOnline.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atendimento",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descricao = c.String(unicode: false),
                        IdPessoa = c.Int(),
                        IdEndereco = c.Int(),
                        IdTipoAtendimento = c.Int(),
                        IdStatus = c.Int(),
                        IdCategoria = c.Int(),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        DataAlteracao = c.DateTime(nullable: false, precision: 0),
                        idUsuarioCadastro = c.Int(nullable: false),
                        idUsuarioAlteracao = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categoria", t => t.IdCategoria)
                .ForeignKey("dbo.Endereco", t => t.IdEndereco)
                .ForeignKey("dbo.Pessoa", t => t.IdPessoa)
                .ForeignKey("dbo.Status", t => t.IdStatus)
                .ForeignKey("dbo.TipoAtendimento", t => t.IdTipoAtendimento)
                .Index(t => t.Codigo, unique: true)
                .Index(t => t.IdPessoa)
                .Index(t => t.IdEndereco)
                .Index(t => t.IdTipoAtendimento)
                .Index(t => t.IdStatus)
                .Index(t => t.IdCategoria);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NomeCategoria = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Descricao = c.String(maxLength: 1000, storeType: "nvarchar"),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        DataAlteracao = c.DateTime(nullable: false, precision: 0),
                        idUsuarioCadastro = c.Int(nullable: false),
                        idUsuarioAlteracao = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(nullable: false, maxLength: 300, storeType: "nvarchar"),
                        Numero = c.String(maxLength: 20, storeType: "nvarchar"),
                        Complemento = c.String(maxLength: 300, storeType: "nvarchar"),
                        CEP = c.String(nullable: false, maxLength: 8, storeType: "nvarchar"),
                        Bairro = c.String(nullable: false, maxLength: 300, storeType: "nvarchar"),
                        Cidade = c.String(nullable: false, maxLength: 300, storeType: "nvarchar"),
                        UF = c.String(nullable: false, maxLength: 300, storeType: "nvarchar"),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        DataAlteracao = c.DateTime(nullable: false, precision: 0),
                        idUsuarioCadastro = c.Int(nullable: false),
                        idUsuarioAlteracao = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Documento = c.String(maxLength: 50, storeType: "nvarchar"),
                        Telefone = c.String(maxLength: 20, storeType: "nvarchar"),
                        Celular = c.String(maxLength: 20, storeType: "nvarchar"),
                        Email = c.String(maxLength: 100, storeType: "nvarchar"),
                        Descricao = c.String(maxLength: 600, storeType: "nvarchar"),
                        IdTipoPessoa = c.Int(),
                        DataNascimento = c.DateTime(nullable: false, precision: 0),
                        IdSexo = c.Int(),
                        IdEndereco = c.Int(),
                        IdMunicipio = c.Int(),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        DataAlteracao = c.DateTime(nullable: false, precision: 0),
                        idUsuarioCadastro = c.Int(nullable: false),
                        idUsuarioAlteracao = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Endereco", t => t.IdEndereco)
                .ForeignKey("dbo.Municipio", t => t.IdMunicipio)
                .ForeignKey("dbo.Sexo", t => t.IdSexo)
                .ForeignKey("dbo.TipoPessoa", t => t.IdTipoPessoa)
                .Index(t => t.IdTipoPessoa)
                .Index(t => t.IdSexo)
                .Index(t => t.IdEndereco)
                .Index(t => t.IdMunicipio);
            
            CreateTable(
                "dbo.Municipio",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Nome = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        UF = c.String(nullable: false, maxLength: 5, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sexo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        DataAlteracao = c.DateTime(nullable: false, precision: 0),
                        idUsuarioCadastro = c.Int(nullable: false),
                        idUsuarioAlteracao = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TipoPessoa",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Codigo = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        DataAlteracao = c.DateTime(nullable: false, precision: 0),
                        idUsuarioCadastro = c.Int(nullable: false),
                        idUsuarioAlteracao = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NomeStatus = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Descricao = c.String(maxLength: 1000, storeType: "nvarchar"),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        DataAlteracao = c.DateTime(nullable: false, precision: 0),
                        idUsuarioCadastro = c.Int(nullable: false),
                        idUsuarioAlteracao = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TipoAtendimento",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NomeTipoAtendimento = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Descricao = c.String(maxLength: 1000, storeType: "nvarchar"),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        DataAlteracao = c.DateTime(nullable: false, precision: 0),
                        idUsuarioCadastro = c.Int(nullable: false),
                        idUsuarioAlteracao = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Descritivo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NomeDescritivo = c.String(unicode: false),
                        IdAtendimento = c.Int(),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        DataAlteracao = c.DateTime(nullable: false, precision: 0),
                        idUsuarioCadastro = c.Int(nullable: false),
                        idUsuarioAlteracao = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Atendimento", t => t.IdAtendimento)
                .Index(t => t.IdAtendimento);
            
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        DataAlteracao = c.DateTime(nullable: false, precision: 0),
                        idUsuarioCadastro = c.Int(nullable: false),
                        idUsuarioAlteracao = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UF",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5, storeType: "nvarchar"),
                        Descricao = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Login = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        Senha = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        IdPerfil = c.Int(),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        DataAlteracao = c.DateTime(nullable: false, precision: 0),
                        idUsuarioCadastro = c.Int(nullable: false),
                        idUsuarioAlteracao = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Perfil", t => t.IdPerfil)
                .Index(t => t.IdPerfil);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "IdPerfil", "dbo.Perfil");
            DropForeignKey("dbo.Descritivo", "IdAtendimento", "dbo.Atendimento");
            DropForeignKey("dbo.Atendimento", "IdTipoAtendimento", "dbo.TipoAtendimento");
            DropForeignKey("dbo.Atendimento", "IdStatus", "dbo.Status");
            DropForeignKey("dbo.Atendimento", "IdPessoa", "dbo.Pessoa");
            DropForeignKey("dbo.Pessoa", "IdTipoPessoa", "dbo.TipoPessoa");
            DropForeignKey("dbo.Pessoa", "IdSexo", "dbo.Sexo");
            DropForeignKey("dbo.Pessoa", "IdMunicipio", "dbo.Municipio");
            DropForeignKey("dbo.Pessoa", "IdEndereco", "dbo.Endereco");
            DropForeignKey("dbo.Atendimento", "IdEndereco", "dbo.Endereco");
            DropForeignKey("dbo.Atendimento", "IdCategoria", "dbo.Categoria");
            DropIndex("dbo.Usuario", new[] { "IdPerfil" });
            DropIndex("dbo.Descritivo", new[] { "IdAtendimento" });
            DropIndex("dbo.Pessoa", new[] { "IdMunicipio" });
            DropIndex("dbo.Pessoa", new[] { "IdEndereco" });
            DropIndex("dbo.Pessoa", new[] { "IdSexo" });
            DropIndex("dbo.Pessoa", new[] { "IdTipoPessoa" });
            DropIndex("dbo.Atendimento", new[] { "IdCategoria" });
            DropIndex("dbo.Atendimento", new[] { "IdStatus" });
            DropIndex("dbo.Atendimento", new[] { "IdTipoAtendimento" });
            DropIndex("dbo.Atendimento", new[] { "IdEndereco" });
            DropIndex("dbo.Atendimento", new[] { "IdPessoa" });
            DropIndex("dbo.Atendimento", new[] { "Codigo" });
            DropTable("dbo.Usuario");
            DropTable("dbo.UF");
            DropTable("dbo.Perfil");
            DropTable("dbo.Descritivo");
            DropTable("dbo.TipoAtendimento");
            DropTable("dbo.Status");
            DropTable("dbo.TipoPessoa");
            DropTable("dbo.Sexo");
            DropTable("dbo.Municipio");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Endereco");
            DropTable("dbo.Categoria");
            DropTable("dbo.Atendimento");
        }
    }
}
