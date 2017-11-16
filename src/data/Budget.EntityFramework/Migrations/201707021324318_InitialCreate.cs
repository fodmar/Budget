namespace Budget.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReceiptEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiptId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Receipts", t => t.ReceiptId, cascadeDelete: true)
                .Index(t => t.ReceiptId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceiptEntries", "ReceiptId", "dbo.Receipts");
            DropIndex("dbo.ReceiptEntries", new[] { "ReceiptId" });
            DropTable("dbo.ReceiptEntries");
            DropTable("dbo.Receipts");
        }
    }
}
