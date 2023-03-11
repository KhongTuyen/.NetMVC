namespace ShopNuocHoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("blog")]
    public partial class blog
    {
        [Key]
        [StringLength(10)]
        public string id_blog { get; set; }

        [StringLength(50)]
        public string name_blog { get; set; }

        [StringLength(200)]
        public string image { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        [Required]
        [StringLength(10)]
        public string id_blogcate { get; set; }

        public virtual blog_category blog_category { get; set; }
    }
}
