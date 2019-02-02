namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreatingTableGenreAndForeignKeyInMovieTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "Fk_GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "Fk_GenreId");
            AddForeignKey("dbo.Movies", "Fk_GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Fk_GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Fk_GenreId" });
            DropColumn("dbo.Movies", "Fk_GenreId");
            DropTable("dbo.Genres");
        }
    }
}
