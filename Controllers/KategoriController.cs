using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplicationTest.Helpers;

namespace WebApplicationTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KategoriController : ControllerBase
    {
        private readonly Koneksi _koneksi;

        public KategoriController(Koneksi koneksi)
        {
            _koneksi = koneksi;
        }

        //  GET ALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = new List<object>();

            using (SqlConnection conn = _koneksi.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, NamaKategori FROM Kategori", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new
                    {
                        Id = reader["Id"],
                        NamaKategori = reader["NamaKategori"]
                    });
                }
                reader.Close();
            }

            return Ok(list);
        }

        //  GET BY NAME — AMAN (PAKAI PARAMETER)
        [HttpGet("byname/{nama}")]
        public IActionResult GetByNama(string nama)
        {
            var list = new List<object>();

            using (SqlConnection conn = _koneksi.GetConnection())
            {
                conn.Open();

                string query = @"SELECT Id, NamaKategori 
                                 FROM Kategori 
                                 WHERE NamaKategori = @nama";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", nama);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new
                    {
                        Id = reader["Id"],
                        NamaKategori = reader["NamaKategori"]
                    });
                }

                reader.Close();
            }

            return Ok(list);
        }
    }
}
