namespace ShopNuocHoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class blog_category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public blog_category()
        {
            blogs = new HashSet<blog>();
        }

        [Key]
        [StringLength(10)]
        public string id_blogcate { get; set; }

        [StringLength(50)]
        public string name_blogcate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<blog> blogs { get; set; }
    }
}
