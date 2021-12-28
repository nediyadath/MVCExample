namespace MVCExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseaddition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        check = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Courses");
        }
    }
}
