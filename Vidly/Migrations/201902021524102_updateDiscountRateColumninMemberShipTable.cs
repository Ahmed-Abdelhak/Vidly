namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDiscountRateColumninMemberShipTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MemberShipTypes", "DiscountRate", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MemberShipTypes", "DiscountRate", c => c.Byte(nullable: false));
        }
    }
}
