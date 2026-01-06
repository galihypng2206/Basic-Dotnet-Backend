using KeretaApiBackend.Dtos;
using Microsoft.AspNetCore.Mvc;
using KeretaApiBackend.Models;
using KeretaApiBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;



namespace KeretaApiBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TiketController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TiketController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/tiket
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiketDto>>> GetAllTiket()
        {
            var tikets = await _context.Tikets
                .Include(t => t.Kereta)
                .Include(t => t.User)
                .ToListAsync();

            var tiketDtos = tikets.Select(t => new TiketDto
            {
                Id = t.Id,
                Jadwal = t.Jadwal,
                StasiunAsal = t.StasiunAsal,
                StasiunTujuan = t.StasiunTujuan,
                Harga = (int)t.Harga,
                Kereta = new KeretaDto
                {
                    Id = t.Kereta.Id,
                    NamaKereta = t.Kereta.NamaKereta,
                    Kelas = t.Kereta.Kelas,
                    Kapasitas = t.Kereta.Kapasitas
                },
                User = new UserDto
                {
                    Id = t.User.Id,
                    Nama = t.User.Nama,
                    Email = t.User.Email,
                    Role = t.User.Role
                }
            }).ToList();

            return tiketDtos;
        }

        // GET: api/tiket/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiketDto>> GetTiket(int id)
        {
            var tiket = await _context.Tikets
                .Include(t => t.Kereta)
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tiket == null)
                return NotFound();

            var tiketDto = new TiketDto
            {
                Id = tiket.Id,
                Jadwal = tiket.Jadwal,
                StasiunAsal = tiket.StasiunAsal,
                StasiunTujuan = tiket.StasiunTujuan,
                Harga = (int)tiket.Harga,
                Kereta = new KeretaDto
                {
                    Id = tiket.Kereta.Id,
                    NamaKereta = tiket.Kereta.NamaKereta,
                    Kelas = tiket.Kereta.Kelas,
                    Kapasitas = tiket.Kereta.Kapasitas
                },
                User = new UserDto
                {
                    Id = tiket.User.Id,
                    Nama = tiket.User.Nama,
                    Email = tiket.User.Email,
                    Role = tiket.User.Role
                }
            };

        return tiketDto;
    }


        // POST: api/tiket
        [HttpPost]
        public async Task<ActionResult<TiketDto>> CreateTiket(CreateTiketDto dto)
        {
            var tiket = new Tiket
            {
                Jadwal = dto.Jadwal,
                StasiunAsal = dto.StasiunAsal,
                StasiunTujuan = dto.StasiunTujuan,
                Harga = dto.Harga,
                KeretaId = dto.KeretaId,
                UserId = dto.UserId
            };

            _context.Tikets.Add(tiket);
            await _context.SaveChangesAsync();

            // Fetch kembali tiket dengan relasi, lalu mapping ke DTO untuk respons
            var created = await _context.Tikets
                .Include(t => t.Kereta)
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == tiket.Id);

            var tiketDto = new TiketDto
            {
                Id = created.Id,
                Jadwal = created.Jadwal,
                StasiunAsal = created.StasiunAsal,
                StasiunTujuan = created.StasiunTujuan,
                Harga = (int)created.Harga,
                Kereta = new KeretaDto
                {
                    Id = created.Kereta.Id,
                    NamaKereta = created.Kereta.NamaKereta,
                    Kelas = created.Kereta.Kelas,
                    Kapasitas = created.Kereta.Kapasitas
                },
                User = new UserDto
                {
                    Id = created.User.Id,
                    Nama = created.User.Nama,
                    Email = created.User.Email,
                    Role = created.User.Role
                }
            };

            return CreatedAtAction(nameof(GetTiket), new { id = tiketDto.Id }, tiketDto);
        }

        // PUT: api/tiket/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTiket(int id, CreateTiketDto dto)
        {
            var tiket = await _context.Tikets.FindAsync(id);
            if (tiket == null)
                return NotFound();

            // Update properti
            tiket.Jadwal = dto.Jadwal;
            tiket.StasiunAsal = dto.StasiunAsal;
            tiket.StasiunTujuan = dto.StasiunTujuan;
            tiket.Harga = dto.Harga;
            tiket.KeretaId = dto.KeretaId;
            tiket.UserId = dto.UserId;

            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
