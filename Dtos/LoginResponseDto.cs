namespace KeretaApiBackend.Dtos
{
    public class LoginResponseDto
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
