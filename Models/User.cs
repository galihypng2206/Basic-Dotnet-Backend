namespace KeretaApiBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nama { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // nanti kita hash
        public string Role { get; set; } = "penumpang"; // atau "admin"
    }
}
