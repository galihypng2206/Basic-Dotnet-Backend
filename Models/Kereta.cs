namespace KeretaApiBackend.Models
{
    public class Kereta
    {
        public int Id { get; set; }
        public string NamaKereta { get; set; } = string.Empty;
        public string NomorKereta { get; set; } = string.Empty;
        public string Kelas { get; set; } = string.Empty; // ekonomi, bisnis, eksekutif
        public int Kapasitas { get; set; }

        public ICollection<Tiket>? Tikets { get; set; }
    }
}
