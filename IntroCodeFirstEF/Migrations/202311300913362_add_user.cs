namespace IntroCodeFirstEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_user : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Username);
            
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.String());
            DropTable("dbo.Users");
        }
    }
}
