using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Privilege
    {
        [Key]
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public int Role { get; set; }

    }
}
