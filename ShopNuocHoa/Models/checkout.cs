namespace ShopNuocHoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("checkout")]
    public partial class checkout
    {
       
        [Key]
        [StringLength(10)]
        public string id_checkout { get; set; }

        [StringLength(10)]
        public string status { get; set; }

        [StringLength(10)]
        public string payment_type { get; set; }

        [StringLength(10)]
        public string payment_infor { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_checkout { get; set; }

        [Required]
        [StringLength(10)]
        public string id_account { get; set; }

        public virtual account account { get; set; }
    }
}
