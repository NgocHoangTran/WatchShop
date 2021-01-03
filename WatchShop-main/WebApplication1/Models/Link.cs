namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Link")]
    public partial class Link
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LinkID { get; set; }

        [StringLength(250)]
        public string LinkName { get; set; }

        [StringLength(250)]
        public string LinkURL { get; set; }

        [StringLength(250)]
        public string LinkDescription { get; set; }

        public int? ID { get; set; }

        public virtual Category Category { get; set; }
    }
}
