using System.ComponentModel.DataAnnotations;

namespace ProjetoDBZ.Models
{
    public class Character {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is mandatory")]
        [MaxLength(50, ErrorMessage = "The name must have a max length 50 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The  camp is mandatory")]
        [MaxLength(50, ErrorMessage = "The type must have a max length 50 characters")]
        public string? Type { get; set; }
    }
}