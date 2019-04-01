namespace AppAtleta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atletas",
                c => new
                    {
                        AtletaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Idade = c.Int(nullable: false),
                        Classificacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AtletaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Atletas");
        }
    }
}
