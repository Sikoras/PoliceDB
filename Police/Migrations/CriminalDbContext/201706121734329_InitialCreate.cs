namespace Police.Migrations.CriminalDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Criminals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CriminalName = c.String(nullable: false),
                        DateOfArrest = c.DateTime(nullable: false),
                        Crimes = c.String(nullable: false),
                        Sanction = c.String(nullable: false),
                        ArrestingOfficer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Criminals");
        }
    }
}
