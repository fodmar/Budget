namespace Budget.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserPasswordPrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserPasswords");
            AlterColumn("dbo.UserPasswords", "UserId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserPasswords", "UserLogin");
            CreateIndex("dbo.UserPasswords", "UserId");
            AddForeignKey("dbo.UserPasswords", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPasswords", "UserId", "dbo.Users");
            DropIndex("dbo.UserPasswords", new[] { "UserId" });
            DropPrimaryKey("dbo.UserPasswords");
            AlterColumn("dbo.UserPasswords", "UserId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserPasswords", "UserId");
        }
    }
}
