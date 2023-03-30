namespace ServicosEPedidos_Mod_17E.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estadopedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "Estado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidoes", "Estado");
        }
    }
}
