namespace Base.Models
{
    public class AuthUser
    {
        public AuthUser(int id, string username, string email, string token)
        {
            Id = id;
            Username = username;
            Email = email;
            Token = token;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
