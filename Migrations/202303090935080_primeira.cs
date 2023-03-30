namespace ServicosEPedidos_Mod_17E.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primeira : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.Utilizadors",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nome = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    Morada = c.String(nullable: false),
                    Password = c.String(),
                    Perfil = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);


            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        IdPed = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        DataPed = c.DateTime(nullable: false),
                        Tipo = c.String(nullable: false, maxLength: 20),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdPed)
                .ForeignKey("dbo.Utilizadors", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);

            CreateTable(
            "dbo.PedidoAceites",
                c => new
                {
                    IdPedAc = c.Int(nullable: false, identity: true),
                    PrestadorId = c.Int(nullable: false),
                    DataPedAc = c.DateTime(nullable: false),
                    PedidoId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.IdPedAc)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Utilizadors", t => t.PrestadorId, cascadeDelete: false)
                .Index(t => t.PrestadorId)
                .Index(t => t.PedidoId);



            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoAceites", "PrestadorId", "dbo.Utilizadors");
            DropForeignKey("dbo.PedidoAceites", "PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedidoes", "ClienteId", "dbo.Utilizadors");
            DropIndex("dbo.Pedidoes", new[] { "ClienteId" });
            DropIndex("dbo.PedidoAceites", new[] { "PedidoId" });
            DropIndex("dbo.PedidoAceites", new[] { "PrestadorId" });
            DropTable("dbo.Utilizadors");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.PedidoAceites");
        }
    }
}
