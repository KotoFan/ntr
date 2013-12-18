namespace StudentList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Imie = c.String(maxLength: 32),
                        Nazwisko = c.String(),
                        IndexNo = c.Int(nullable: false),
                        Group_GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Groups", t => t.Group_GroupId, cascadeDelete: true)
                .Index(t => t.Group_GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Group_GroupId", "dbo.Groups");
            DropIndex("dbo.Students", new[] { "Group_GroupId" });
            DropTable("dbo.Students");
            DropTable("dbo.Groups");
        }
    }
}
