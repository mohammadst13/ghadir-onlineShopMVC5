namespace ghadir.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeAdminModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Admins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
        }
    }
}
