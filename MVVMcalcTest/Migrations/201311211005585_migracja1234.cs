namespace StudentList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracja1234 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "IndexNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "IndexNo", c => c.String());
        }
    }
}
