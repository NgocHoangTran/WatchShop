namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string productName { get; set; }

        [Column(TypeName = "text")]
        public string productDescription { get; set; }

        public decimal? Price { get; set; }

        public decimal? promotionPrice { get; set; }

        [StringLength(150)]
        public string productPicture { get; set; }

        public int? categoryID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? createDate { get; set; }

        public int? viewCount { get; set; }

        public bool? productStatus { get; set; }

        public int? BrandID { get; set; }

        public int? sold { get; set; }

        public decimal? turnover { get; set; }

        public virtual Brand Brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
