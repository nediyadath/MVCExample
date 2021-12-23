namespace MVCExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discountschemechange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiscountSchemes", "discountName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiscountSchemes", "discountName");
        }
    }
}
