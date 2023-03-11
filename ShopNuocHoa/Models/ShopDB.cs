using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShopNuocHoa.Models
{
    public partial class ShopDB : DbContext
    {
        public ShopDB()
            : base("name=ShopDB")
        {
        }

        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<blog> blogs { get; set; }
        public virtual DbSet<blog_category> blog_category { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<checkout> checkouts { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.id_account)
                .IsFixedLength();

            modelBuilder.Entity<account>()
                .Property(e => e.username)
                .IsFixedLength();

            modelBuilder.Entity<account>()
                .Property(e => e.passwords)
                .IsFixedLength();

            modelBuilder.Entity<account>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<account>()
                .Property(e => e.email)
                .IsFixedLength();

            modelBuilder.Entity<account>()
                .Property(e => e.gender)
                .IsFixedLength();

            modelBuilder.Entity<account>()
                .Property(e => e.image)
                .IsFixedLength();

            modelBuilder.Entity<account>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<account>()
                .HasMany(e => e.checkouts)
                .WithRequired(e => e.account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<blog>()
                .Property(e => e.id_blog)
                .IsFixedLength();

            modelBuilder.Entity<blog>()
                .Property(e => e.image)
                .IsFixedLength();

            modelBuilder.Entity<blog>()
                .Property(e => e.id_blogcate)
                .IsFixedLength();

            modelBuilder.Entity<blog_category>()
                .Property(e => e.id_blogcate)
                .IsFixedLength();

            modelBuilder.Entity<blog_category>()
                .Property(e => e.name_blogcate)
                .IsFixedLength();

            modelBuilder.Entity<blog_category>()
                .HasMany(e => e.blogs)
                .WithRequired(e => e.blog_category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.id_cart)
                .IsFixedLength();

            modelBuilder.Entity<Cart>()
                .Property(e => e.id_product)
                .IsFixedLength();

            modelBuilder.Entity<Cart>()
                .Property(e => e.id_category)
                .IsFixedLength();

            modelBuilder.Entity<Cart>()
                .Property(e => e.id_account)
                .IsFixedLength();

            modelBuilder.Entity<category>()
                .Property(e => e.id_category)
                .IsFixedLength();

            modelBuilder.Entity<category>()
                .Property(e => e.name_category)
                .IsFixedLength();

            modelBuilder.Entity<category>()
                .HasMany(e => e.products)
                .WithRequired(e => e.category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<checkout>()
                .Property(e => e.id_checkout)
                .IsFixedLength();

            modelBuilder.Entity<checkout>()
                .Property(e => e.status)
                .IsFixedLength();

            modelBuilder.Entity<checkout>()
                .Property(e => e.payment_type)
                .IsFixedLength();

            modelBuilder.Entity<checkout>()
                .Property(e => e.payment_infor)
                .IsFixedLength();

            modelBuilder.Entity<checkout>()
                .Property(e => e.id_account)
                .IsFixedLength();

            modelBuilder.Entity<product>()
                .Property(e => e.id_product)
                .IsFixedLength();

            modelBuilder.Entity<product>()
                .Property(e => e.name_product)
                .IsFixedLength();

            modelBuilder.Entity<product>()
                .Property(e => e.image)
                .IsFixedLength();

            modelBuilder.Entity<product>()
                .Property(e => e.id_category)
                .IsFixedLength();
        }
    }
}
