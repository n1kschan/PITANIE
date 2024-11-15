namespace Питание.Contracts.User
{
    public class CreateUserRequest
    {
        public string Username { get; set; } = null!;
        public string Paswordhash { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Createdat { get; set; }
    }
}
