using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplicationTest.Helpers;

namespace WebApplicationTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class jsontestController : ControllerBase
    {

        private readonly Koneksi _koneksi;

        public jsontestController(Koneksi koneksi)
        {
            _koneksi = koneksi;
        }

        [HttpGet("produk-summary")]
        public object SimpleUser()
        {
            return new
            {
                JumlahProduk = 25,
                RataRataHarga = 15400,
                ProdukTertinggi = new   
                {
                    id = 8,
                    nama = "Kabel HDMI",
                    harga = 75000
                },
                ProdukTerendah = new
                {
                    id = 1,
                    nama = "Penghapus",
                    harga = 1500
                }
            };
        }

        [HttpGet("produk-grouped")]
        public object ProdukGrouped()
        {
            return new
            {
                Elektronik = new[]
                {
                    new 
                    {
                        Id = 1,
                        Nama = "Keyboard"
                    },
                    new 
                    {
                        Id = 2,
                        Nama = "Mouse"
                    }
                },
                ATK = new[]
                {
                    new 
                    {
                        Id = 3,
                        Nama = "Keyboard"
                    },
                    new
                    {
                        Id = 4,
                        Nama = "Mouse"
                    }
                },

            };
        }

        [HttpGet("summary")]
        public object Summary()
        {
            return new
            {
                TotalProduk = 12,
                ProdukTermahal = new
                {
                    Id = 4,
                    Nama = "Laptop",
                    Harga = 8000000
                },
                ProdukTermurah = new
                {
                    Id = 1,
                    Nama = "Pensil",
                    Harga = 2000
                },
                DaftarProduk = new[]
                {
                    new
                    {
                        Id = 1,
                        Nama = "Pensil"
                    },
                    new
                    {
                        Id = 2,
                        Nama = "Buku"
                    }

                }
                
            };
        }
        [HttpGet("test-connection")]
        public IActionResult TestConnection()
        {
            try
            {
                using var conn = _koneksi.GetConnection();
                conn.Open();
                return Ok(new { connected = true });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    connected = false,
                    error = ex.Message
                });
            }
        }

    }
}
