namespace ServicosEPedidos_Mod_17E.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class descricaopedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "Descricao", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidoes", "Descricao");
        }
    }
}
