using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace API.Models
{
    public class User
    {
        [Key]
        private int Id { get; set; }
        private string FullName { get; set; } = String.Empty;
        private string? UserName { get; set; }
        private string? Password { get; set; }
        private int Role { get; set; }
    }
}