namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InsertRowDataInMemberShipTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MemberShipTypes(Id,DurationInMonths,DiscountRate,SignUpFee) VALUES (1,0,0,0)");
            Sql("INSERT INTO MemberShipTypes(Id,DurationInMonths,DiscountRate,SignUpFee) VALUES (2,1,0.10,30)");
            Sql("INSERT INTO MemberShipTypes(Id,DurationInMonths,DiscountRate,SignUpFee) VALUES (3,3,0.15,60)");
            Sql("INSERT INTO MemberShipTypes(Id,DurationInMonths,DiscountRate,SignUpFee) VALUES (4,6,0.3,150)");
            Sql("INSERT INTO MemberShipTypes(Id,DurationInMonths,DiscountRate,SignUpFee) VALUES (5,12,0.5,300)");

        }

        public override void Down()
        {
        }
    }
}
