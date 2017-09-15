namespace ExemploBackEndsRobustos.Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class segundafase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lvro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 80),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LivroAutor",
                c => new
                    {
                        Autor_Id = c.Int(nullable: false),
                        Livro_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Autor_Id, t.Livro_Id })
                .ForeignKey("dbo.Autor", t => t.Autor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Lvro", t => t.Livro_Id, cascadeDelete: true)
                .Index(t => t.Autor_Id)
                .Index(t => t.Livro_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LivroAutor", "Livro_Id", "dbo.Lvro");
            DropForeignKey("dbo.LivroAutor", "Autor_Id", "dbo.Autor");
            DropForeignKey("dbo.Lvro", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.LivroAutor", new[] { "Livro_Id" });
            DropIndex("dbo.LivroAutor", new[] { "Autor_Id" });
            DropIndex("dbo.Lvro", new[] { "CategoriaId" });
            DropTable("dbo.LivroAutor");
            DropTable("dbo.Categoria");
            DropTable("dbo.Lvro");
            DropTable("dbo.Autor");
        }
    }
}
