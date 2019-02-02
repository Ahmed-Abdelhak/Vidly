namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateTableMemberShipTypeWithName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MemberShipTypes SET Name='Free' WHERE Id=1 ");
            Sql("UPDATE MemberShipTypes SET Name='One Month' WHERE Id=2 ");
            Sql("UPDATE MemberShipTypes SET Name='Three Months' WHERE Id=3 ");
            Sql("UPDATE MemberShipTypes SET Name='Six Months' WHERE Id=4 ");
            Sql("UPDATE MemberShipTypes SET Name='Year Membership' WHERE Id=5 ");

        }
        
        public override void Down()
        {
        }
    }
}
