namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'42197b1a-ee52-42f5-9fd0-ff44f3002d98', N'admin@Vidly.com', 0, N'ANj18hi/NYFvfLG3yHJEAE2AW+FGeU0EZOK5QH9eMDJshZBmjNqs8Kv/qEGD/qGP3Q==', N'91b346de-264b-4809-83dd-8b116ba0acea', NULL, 0, 0, NULL, 1, 0, N'admin@Vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'686de6da-90b2-4c01-9f21-21bd2111548d', N'ahmedinho77@gmail.com', 0, N'APFO9XCXFlooi16MpOOUM7+bJKAWMofboGYNEeu1SApyxQzkIuQAT2lxvFK54Ge8cA==', N'5458367f-ecab-4d2a-9322-0782d47c060e', NULL, 0, 0, NULL, 1, 0, N'ahmedinho77@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'34fe8527-1b09-498e-9574-1e8e9a1a75a1', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'42197b1a-ee52-42f5-9fd0-ff44f3002d98', N'34fe8527-1b09-498e-9574-1e8e9a1a75a1')


");

        }

        public override void Down()
        {
        }
    }
}
