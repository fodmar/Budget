namespace Budget.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueConstraintToUserPassword : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserPasswords", new[] { "UserId" });
            CreateIndex("dbo.UserPasswords", "UserId", unique: true, name: "IX_UserIdUnique");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserPasswords", "IX_UserIdUnique");
            CreateIndex("dbo.UserPasswords", "UserId");
        }
    }
}
