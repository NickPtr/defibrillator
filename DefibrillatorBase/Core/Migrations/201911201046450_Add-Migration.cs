namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Defibrillators",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Posx = c.String(),
                        Posy = c.String(),
                        PhotoLink = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mail = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Defibrillators");
        }
    }
}
