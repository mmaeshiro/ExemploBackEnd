namespace ExemploBackEndsRobustos.Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Terceirasubida : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Lvro", newName: "Livro");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Livro", newName: "Lvro");
        }
    }
}
