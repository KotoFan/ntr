namespace StudentList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modyfikacja : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Group_GroupId", "dbo.Groups");
            DropIndex("dbo.Students", new[] { "Group_GroupId" });
            AddColumn("dbo.Students", "IndexNo", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Imie", c => c.String(maxLength: 32));
            AlterColumn("dbo.Students", "Group_GroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "Group_GroupId");
            AddForeignKey("dbo.Students", "Group_GroupId", "dbo.Groups", "GroupId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Group_GroupId", "dbo.Groups");
            DropIndex("dbo.Students", new[] { "Group_GroupId" });
            AlterColumn("dbo.Students", "Group_GroupId", c => c.Int());
            AlterColumn("dbo.Students", "Imie", c => c.String());
            DropColumn("dbo.Students", "IndexNo");
            CreateIndex("dbo.Students", "Group_GroupId");
            AddForeignKey("dbo.Students", "Group_GroupId", "dbo.Groups", "GroupId");
        }
    }
}
