using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Axado.Models
{
    [Table("Rating")]
    public class Rating
    {
        [Key]
        public int ID { get; set; }

        public DateTime IncludeDate { get; set; }
        public int UserId { get; set; }
        public int CarrierId { get; set; }

        [ForeignKey("UserId")]
        public virtual IQueryable<User> Users { get; set; }
        [ForeignKey("CarrierId")]
        public virtual IQueryable<Carrier> Carriers { get; set; }
    }
}
