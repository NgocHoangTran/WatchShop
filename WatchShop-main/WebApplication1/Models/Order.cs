namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_user { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_product { get; set; }

        public int? id_stt { get; set; }

        public int? quantity { get; set; }

        public decimal? total { get; set; }

        [StringLength(100)]
        public string addressTo { get; set; }

        public int? id_deli { get; set; }

        [Column(TypeName = "date")]
        public DateTime? createDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? requireDate { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Delivery Delivery { get; set; }

        public virtual Product Product { get; set; }

        public virtual Status Status { get; set; }
    }
}
