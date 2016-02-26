using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Axado.Models
{
    [Table("Carrier")]
    public class Carrier
    {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage ="Description cannot be empty!")]
        public string Nome { get; set; }

    }
}