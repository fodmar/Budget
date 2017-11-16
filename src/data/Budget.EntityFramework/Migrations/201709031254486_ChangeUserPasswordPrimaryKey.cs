namespace Budget.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserPasswordPrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UserPasswords");

            CreateTable(
                "dbo.UserPasswords",
                c => new
                {
                    UserLogin = c.String(nullable: false, maxLength: 64),
                    UserId = c.Int(nullable: false),
                    Hash = c.String(nullable: false, maxLength: 32, fixedLength: true),
                })
                .PrimaryKey(t => t.UserLogin);

            AddForeignKey("dbo.UserPasswords", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            CreateIndex("dbo.UserPasswords", "UserId");
        }
        
        public override void Down()
        {
            DropTable("dbo.UserPasswords");

            CreateTable(
                "dbo.UserPasswords",
                c => new
                {
                    UserId = c.Int(nullable: false, identity: true),
                    UserLogin = c.String(nullable: false, maxLength: 64),
                    Hash = c.String(nullable: false, maxLength: 32, fixedLength: true),
                })
                .PrimaryKey(t => t.UserId);
        }
    }
}
