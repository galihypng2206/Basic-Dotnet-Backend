namespace KeretaApiBackend.Dtos
{
    public class TiketDto
    {
        public int Id { get; set; }
        public DateTime Jadwal { get; set; }
        public string StasiunAsal { get; set; }
        public string StasiunTujuan { get; set; }
        public int Harga { get; set; }
        public KeretaDto Kereta { get; set; }
        public UserDto User { get; set; }
    }
}
