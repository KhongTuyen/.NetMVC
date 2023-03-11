namespace ShopNuocHoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Cart")]
    public partial class Cart
    {
        [Key]
        [StringLength(10)]
        public string id_cart { get; set; }

        public int? quantity { get; set; }

        [Required]
        [StringLength(10)]
        public string id_product { get; set; }

        [Required]
        [StringLength(10)]
        public string id_category { get; set; }

        [Required]
        [StringLength(10)]
        public string id_account { get; set; }

        public double? total { get; set; }

        public virtual account account { get; set; }

        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
            
        }
        public void Add(product pro, int quantity = 1)
        {
            var item = items.FirstOrDefault(s => s._product.id_product == pro.id_product);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    _product = pro,
                    _quantity = quantity
                });
            }
            else
            {
                item._quantity += quantity;
               
            }
            
        }
        public void Update_Quantity(string id , int quantity)
        {
            var item = items.Find(s => s._product.id_product == id);
            if(item != null)
            {
                item._quantity = quantity;
            }
        }
        public double Total()
        {
            var total = items.Sum(s => s._product.new_price.Value * s._quantity);
            return total;
        }
        public void Remove(string id)
        {
            items.RemoveAll(s => s._product.id_product == id);
        }
        public int total_quantity()
        {
            return items.Sum(s=>s._quantity);
        }
        public void Clear()
        {
            items.Clear();
        }
        
    }
    public class CartItem
    {
        public product _product { get; set; }
        public int _quantity { get; set; }
    }
    //giohang
   
}
