namespace PROEkT2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                        DishesTypeId = c.Int(nullable: false),
                        Dishes_Types_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dishes_Type", t => t.Dishes_Types_Id)
                .Index(t => t.Dishes_Types_Id);
            
            CreateTable(
                "dbo.Dishes_Type",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dishes", "Dishes_Types_Id", "dbo.Dishes_Type");
            DropIndex("dbo.Dishes", new[] { "Dishes_Types_Id" });
            DropTable("dbo.Dishes_Type");
            DropTable("dbo.Dishes");
        }
    }
}
