namespace KeretaApiBackend.Models
{
    public class Tiket
    {
        public int Id { get; set; }
        public DateTime Jadwal { get; set; }
        public string StasiunAsal { get; set; } = string.Empty;
        public string StasiunTujuan { get; set; } = string.Empty;
        public decimal Harga { get; set; }

        // Relasi ke Kereta
        public int KeretaId { get; set; }
        public Kereta? Kereta { get; set; }

        // Relasi ke User (jika sudah dibeli)
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
