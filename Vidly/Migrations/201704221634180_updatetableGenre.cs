namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetableGenre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropPrimaryKey("dbo.Genres");
            AddColumn("dbo.Movies", "Genre_Id", c => c.Byte(nullable: false));
            AddColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Genres", "GenreName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "GenreName", c => c.String());
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Genres", "Name");
            DropColumn("dbo.Movies", "Genre_Id");
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
