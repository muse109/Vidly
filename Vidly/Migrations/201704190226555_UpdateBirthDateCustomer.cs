namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthDateCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE  Customers SET Birthdate='19900101' ");
        }
        
        public override void Down()
        {
        }
    }
}
