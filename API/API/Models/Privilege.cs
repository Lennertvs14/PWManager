namespace API.Models
{
    public class Privilege
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; } = String.Empty;
        public string? Description { get; set; }
        public int Role { get; set; }
        public ICollection<Privilege>? Privileges { get; set; }

        public Privilege Get(object obj)
        {
            return (Privilege)obj;
        }
    }
}
