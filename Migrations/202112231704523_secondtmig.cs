namespace MVCExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondtmig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        productName = c.String(),
                        grossSalevalue = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sales");
        }
    }
}
