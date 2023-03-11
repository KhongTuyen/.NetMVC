namespace ShopNuocHoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [Key]
        [StringLength(10)]
        public string id_product { get; set; }

        [StringLength(50)]
        public string name_product { get; set; }

        [StringLength(50)]
        public string image { get; set; }

        public double? old_price { get; set; }

        public double? new_price { get; set; }

        public int? quantity { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [StringLength(10)]
        public string id_category { get; set; }

        public virtual category category { get; set; }
    }
}
