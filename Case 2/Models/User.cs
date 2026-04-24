namespace Case_2.Models
{//     Student, Teacher, Admin,
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
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
