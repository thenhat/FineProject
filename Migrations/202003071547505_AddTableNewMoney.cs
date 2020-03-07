namespace MoneyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableNewMoney : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Moneys", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Moneys", "Date");
        }
    }
}
