namespace PartageMvc.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Containers", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Containers", new[] { "User_Id" });
            AddColumn("dbo.Containers", "DateOnline", c => c.DateTime(nullable: false));
            AddColumn("dbo.Containers", "DateExpire", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Containers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Containers", "Link", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Containers", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Containers", "User_Id");
            AddForeignKey("dbo.Containers", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Containers", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Containers", new[] { "User_Id" });
            AlterColumn("dbo.Containers", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Containers", "Link", c => c.String());
            AlterColumn("dbo.Containers", "Name", c => c.String());
            DropColumn("dbo.Containers", "DateExpire");
            DropColumn("dbo.Containers", "DateOnline");
            CreateIndex("dbo.Containers", "User_Id");
            AddForeignKey("dbo.Containers", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
