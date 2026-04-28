using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Case_2.Models
{//     Student, Teacher, Admin,
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = "";
        [Required]
        [EmailAddress]

        public string Email { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        [Required]
        public Role Role { get; set; } 

        public User(int userId, string name, string email, string password, Role role)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }
        public User()
        {
          
        
        }
    }
}
