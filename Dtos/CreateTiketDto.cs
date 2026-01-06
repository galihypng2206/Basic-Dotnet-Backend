using System.ComponentModel.DataAnnotations;

namespace KeretaApiBackend.Dtos
{
    public class CreateTiketDto
    {
        [Required]
        [FutureDate(ErrorMessage = "Jadwal harus di masa depan")]
        public DateTime Jadwal { get; set; }

        [Required]
        public string StasiunAsal { get; set; } = string.Empty;

        [Required]
        public string StasiunTujuan { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Harga harus lebih dari 0")]
        public int Harga { get; set; }

        [Required]
        public int KeretaId { get; set; }

        [Required]
        public int UserId { get; set; }
    }

    // Custom validation attribute untuk memastikan tanggal di masa depan
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime > DateTime.Now;
            }
            return false;
        }
    }
}
