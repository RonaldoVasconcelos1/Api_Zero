using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class CastDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Character { get; set; }

    }
}
