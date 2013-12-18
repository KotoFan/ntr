namespace StudentList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropStudentIndex : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "IndexNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "IndexNo", c => c.Int(nullable: false));
        }
    }
}
