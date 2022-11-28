namespace API.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; } = String.Empty;
        public ICollection<Role>? Roles { get; set; }
    }
}
