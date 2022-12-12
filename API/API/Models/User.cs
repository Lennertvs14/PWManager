namespace API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; } = String.Empty;
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public int Role { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}