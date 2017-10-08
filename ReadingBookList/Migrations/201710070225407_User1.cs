namespace ReadingBookList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Books", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Books", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Books", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Books", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
