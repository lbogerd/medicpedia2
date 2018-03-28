namespace MedicPedia2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        PublishedOn = c.DateTime(nullable: false),
                        LastChangedOn = c.DateTime(nullable: false),
                        Version = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        Author_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        SortOrder = c.Int(nullable: false),
                        SortIndex = c.Int(nullable: false),
                        ParentCategory_Id = c.Guid(),
                        Article_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentCategory_Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .Index(t => t.ParentCategory_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Article_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .Index(t => t.Article_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.Categories", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.Categories", "ParentCategory_Id", "dbo.Categories");
            DropForeignKey("dbo.Articles", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Tags", new[] { "Article_Id" });
            DropIndex("dbo.Categories", new[] { "Article_Id" });
            DropIndex("dbo.Categories", new[] { "ParentCategory_Id" });
            DropIndex("dbo.Articles", new[] { "Author_Id" });
            DropTable("dbo.Tags");
            DropTable("dbo.Categories");
            DropTable("dbo.Authors");
            DropTable("dbo.Articles");
        }
    }
}
