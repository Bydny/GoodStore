namespace GoodStore.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GoodSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GoodId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        GoodAmount = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Goods", t => t.GoodId, cascadeDelete: true)
                .Index(t => t.GoodId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Amount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IncomingDate = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 1000),
                        UserId = c.Int(nullable: false),
                        GoodTypeId = c.Int(nullable: false),
                        GoodSellerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GoodSellers", t => t.GoodSellerId, cascadeDelete: true)
                .ForeignKey("dbo.GoodTypes", t => t.GoodTypeId, cascadeDelete: true)
                .ForeignKey("dbo.StoreUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GoodTypeId)
                .Index(t => t.GoodSellerId);
            
            CreateTable(
                "dbo.GoodSellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GoodTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoreUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 20),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoodSales", "GoodId", "dbo.Goods");
            DropForeignKey("dbo.Goods", "UserId", "dbo.StoreUsers");
            DropForeignKey("dbo.Goods", "GoodTypeId", "dbo.GoodTypes");
            DropForeignKey("dbo.Goods", "GoodSellerId", "dbo.GoodSellers");
            DropForeignKey("dbo.GoodSales", "ClientId", "dbo.Clients");
            DropIndex("dbo.Goods", new[] { "GoodSellerId" });
            DropIndex("dbo.Goods", new[] { "GoodTypeId" });
            DropIndex("dbo.Goods", new[] { "UserId" });
            DropIndex("dbo.GoodSales", new[] { "ClientId" });
            DropIndex("dbo.GoodSales", new[] { "GoodId" });
            DropTable("dbo.StoreUsers");
            DropTable("dbo.GoodTypes");
            DropTable("dbo.GoodSellers");
            DropTable("dbo.Goods");
            DropTable("dbo.GoodSales");
            DropTable("dbo.Clients");
        }
    }
}
