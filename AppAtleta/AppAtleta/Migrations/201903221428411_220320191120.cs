namespace AppAtleta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _220320191120 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Uniformes",
                c => new
                    {
                        UniformeId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Cor = c.String(),
                        Tamanho = c.Int(nullable: false),
                        AtletaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UniformeId)
                .ForeignKey("dbo.Atletas", t => t.AtletaId, cascadeDelete: true)
                .Index(t => t.AtletaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Uniformes", "AtletaId", "dbo.Atletas");
            DropIndex("dbo.Uniformes", new[] { "AtletaId" });
            DropTable("dbo.Uniformes");
        }
    }
}
