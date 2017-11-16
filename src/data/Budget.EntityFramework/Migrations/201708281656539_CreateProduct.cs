namespace Budget.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ReceiptEntries", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReceiptEntries", "ProductId");
            AddForeignKey("dbo.ReceiptEntries", "ProductId", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceiptEntries", "ProductId", "dbo.Products");
            DropIndex("dbo.ReceiptEntries", new[] { "ProductId" });
            DropColumn("dbo.ReceiptEntries", "ProductId");
            DropTable("dbo.Products");
        }
    }
}
