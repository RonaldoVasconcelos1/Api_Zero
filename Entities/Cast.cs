using System.ComponentModel.DataAnnotations;

namespace api.Entities
{
    public class Cast
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Character { get; set; }
    }
}
