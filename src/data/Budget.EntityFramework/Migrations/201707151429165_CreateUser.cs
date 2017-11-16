namespace Budget.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserPasswords",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserLogin = c.String(nullable: false, maxLength: 64),
                        Hash = c.String(nullable: false, maxLength: 32, fixedLength: true),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Receipts", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Receipts", "UserId");
            AddForeignKey("dbo.Receipts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receipts", "UserId", "dbo.Users");
            DropIndex("dbo.Receipts", new[] { "UserId" });
            DropColumn("dbo.Receipts", "UserId");
            DropTable("dbo.UserPasswords");
            DropTable("dbo.Users");
        }
    }
}
