namespace KeretaApiBackend.Dtos
{
    public class KeretaDto
    {
        public int Id { get; set; }
        public string NamaKereta { get; set; }
        public string NomorKereta { get; set; }
        public string Kelas { get; set; }
        public int Kapasitas { get; set; }
    }
}
