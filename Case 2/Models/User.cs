namespace Case_2.Models
{
    public class User
    {
        public int userId { get; set; }

        public string name { get; set; }

        public string email { get; set; }
        public string password { get; set; }

        public User(int userId, string name, string email, string password)
        {
            this.userId = userId;
            this.name = name;
            this.email = email;
            this.password = password;
        }
        public User()
        {
        }
    }
}
