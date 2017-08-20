namespace Budget.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateIndexOnReceiptUserIdAndDate : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Receipts", new[] { "UserId" });
            CreateIndex("dbo.Receipts", new[] { "UserId", "Date" }, name: "IX_UserIdDate");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Receipts", "IX_UserIdDate");
            CreateIndex("dbo.Receipts", "UserId");
        }
    }
}
