namespace MVCExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discountscheme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiscountSchemes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        prodID = c.Int(nullable: false),
                        discount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.prodID, cascadeDelete: true)
                .Index(t => t.prodID);
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiscountSchemes", "prodID", "dbo.Products");
            DropIndex("dbo.DiscountSchemes", new[] { "prodID" });
            DropTable("dbo.Products");
            DropTable("dbo.DiscountSchemes");
        }
    }
}
