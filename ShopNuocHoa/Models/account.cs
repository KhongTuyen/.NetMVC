namespace ShopNuocHoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account")]
    public partial class account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public account()
        {
            Carts = new HashSet<Cart>();
            checkouts = new HashSet<checkout>();
        }

        [Key]
        [StringLength(10)]
        public string id_account { get; set; }

        [StringLength(20)]
        public string username { get; set; }

        [StringLength(20)]
        public string passwords { get; set; }

        [StringLength(20)]
        public string name { get; set; }

        [StringLength(20)]
        public string email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [StringLength(10)]
        public string gender { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        public bool? rol { get; set; }

        [StringLength(20)]
        public string image { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_create { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<checkout> checkouts { get; set; }
    }
}
