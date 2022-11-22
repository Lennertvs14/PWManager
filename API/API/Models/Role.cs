using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string? Code { get; set; }
    }
}
