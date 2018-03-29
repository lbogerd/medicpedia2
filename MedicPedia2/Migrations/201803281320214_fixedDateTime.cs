namespace MedicPedia2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "LastChangedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "LastChangedOn", c => c.DateTime(nullable: false));
        }
    }
}
