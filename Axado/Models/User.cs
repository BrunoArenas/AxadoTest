using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Axado.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Field Name cannot be empty!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field Password cannot be empty!")]
        public string Password { get; set; }
    }
}