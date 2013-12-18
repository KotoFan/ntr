namespace StudentList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStudentIndex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "StudentId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Students");
            AddPrimaryKey("dbo.Students", "StudentId");
            DropColumn("dbo.Students", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ID", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Students");
            AddPrimaryKey("dbo.Students", "ID");
            DropColumn("dbo.Students", "StudentId");
        }
    }
}
