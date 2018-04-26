namespace LoginService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRegistations", "language", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRegistations", "language");
        }
    }
}
