namespace Police.Migrations.WarrantsDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Warrants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CriminalName = c.String(nullable: false),
                        Crimes = c.String(nullable: false),
                        FilingOfficer = c.String(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Warrants");
        }
    }
}
