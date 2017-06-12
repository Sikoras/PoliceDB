namespace Police.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Department : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Department", c => c.String());
            AddColumn("dbo.AspNetUsers", "Rank", c => c.String());
            AddColumn("dbo.AspNetUsers", "isCommand", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "isCommand");
            DropColumn("dbo.AspNetUsers", "Rank");
            DropColumn("dbo.AspNetUsers", "Department");
        }
    }
}
