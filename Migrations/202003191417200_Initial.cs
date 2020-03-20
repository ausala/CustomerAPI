namespace CustomerAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        sex = c.String(),
                        RepresentatId = c.Int(nullable: false),
                        Representatives_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Representatives", t => t.Representatives_Id)
                .Index(t => t.Representatives_Id);
            
            CreateTable(
                "dbo.Representatives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Representatives_Id", "dbo.Representatives");
            DropIndex("dbo.Customers", new[] { "Representatives_Id" });
            DropTable("dbo.Representatives");
            DropTable("dbo.Customers");
        }
    }
}
