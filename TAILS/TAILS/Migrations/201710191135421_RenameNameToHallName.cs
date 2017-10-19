namespace TAILS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameNameToHallName : DbMigration
    {
        public override void Up()
        {
            RenameColumn("[Halls]", "Name", "HallName");
        }
        
        public override void Down()
        {
            RenameColumn("[Halls]", "HallName", "Name");
        }
    }
}
