namespace ShopNuocHoa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.account",
                c => new
                    {
                        id_account = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        username = c.String(maxLength: 20, fixedLength: true),
                        passwords = c.String(maxLength: 20, fixedLength: true),
                        name = c.String(maxLength: 20, fixedLength: true),
                        email = c.String(maxLength: 20, fixedLength: true),
                        date = c.DateTime(storeType: "date"),
                        gender = c.String(maxLength: 10, fixedLength: true),
                        address = c.String(maxLength: 100),
                        rol = c.Boolean(),
                        image = c.String(maxLength: 20, fixedLength: true),
                        date_create = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.id_account);
            
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        id_cart = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        quantity = c.Int(),
                        id_product = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        id_category = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        id_account = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        total = c.Double(),
                    })
                .PrimaryKey(t => t.id_cart)
                .ForeignKey("dbo.account", t => t.id_account)
                .Index(t => t.id_account);
            
            CreateTable(
                "dbo.checkout",
                c => new
                    {
                        id_checkout = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        status = c.String(maxLength: 10, fixedLength: true),
                        payment_type = c.String(maxLength: 10, fixedLength: true),
                        payment_infor = c.String(maxLength: 10, fixedLength: true),
                        date_checkout = c.DateTime(storeType: "date"),
                        id_account = c.String(nullable: false, maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.id_checkout)
                .ForeignKey("dbo.account", t => t.id_account)
                .Index(t => t.id_account);
            
            CreateTable(
                "dbo.blog_category",
                c => new
                    {
                        id_blogcate = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        name_blogcate = c.String(maxLength: 50, fixedLength: true),
                    })
                .PrimaryKey(t => t.id_blogcate);
            
            CreateTable(
                "dbo.blog",
                c => new
                    {
                        id_blog = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        name_blog = c.String(maxLength: 50),
                        image = c.String(maxLength: 200, fixedLength: true),
                        Title = c.String(maxLength: 500),
                        id_blogcate = c.String(nullable: false, maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.id_blog)
                .ForeignKey("dbo.blog_category", t => t.id_blogcate)
                .Index(t => t.id_blogcate);
            
            CreateTable(
                "dbo.category",
                c => new
                    {
                        id_category = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        name_category = c.String(maxLength: 50, fixedLength: true),
                    })
                .PrimaryKey(t => t.id_category);
            
            CreateTable(
                "dbo.product",
                c => new
                    {
                        id_product = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        name_product = c.String(maxLength: 50, fixedLength: true),
                        image = c.String(maxLength: 50, fixedLength: true),
                        old_price = c.Double(),
                        new_price = c.Double(),
                        quantity = c.Int(),
                        Description = c.String(maxLength: 200),
                        id_category = c.String(nullable: false, maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.id_product)
                .ForeignKey("dbo.category", t => t.id_category)
                .Index(t => t.id_category);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.product", "id_category", "dbo.category");
            DropForeignKey("dbo.blog", "id_blogcate", "dbo.blog_category");
            DropForeignKey("dbo.checkout", "id_account", "dbo.account");
            DropForeignKey("dbo.Cart", "id_account", "dbo.account");
            DropIndex("dbo.product", new[] { "id_category" });
            DropIndex("dbo.blog", new[] { "id_blogcate" });
            DropIndex("dbo.checkout", new[] { "id_account" });
            DropIndex("dbo.Cart", new[] { "id_account" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.product");
            DropTable("dbo.category");
            DropTable("dbo.blog");
            DropTable("dbo.blog_category");
            DropTable("dbo.checkout");
            DropTable("dbo.Cart");
            DropTable("dbo.account");
        }
    }
}
