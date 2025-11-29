using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplicationTest.Helpers;

namespace WebApplicationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorinewController : ControllerBase
    {
        private readonly Koneksi _koneksi;

        public KategorinewController(Koneksi koneksi)
        {
            _koneksi = koneksi;
        }

        [HttpGet("{id}")]
        public object Getkategori(int id)
        {
            var result = new
            {
                Status = 200,
                Data = new
                {
                    id = 0,
                    Nama = ""
                }
            };

            SqlConnection conn = _koneksi.GetConnection();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Kategori WHERE id = " + id, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    result = new
                    {
                        Status = 200,
                        Data = new
                        {
                            id = Convert.ToInt32(reader["id"]),
                            Nama = reader["NamaKategori"].ToString()
                        }
                    };
                }

                return result;
            }
            catch (Exception e)
            {
                result = new
                {
                    Status = 200,
                    Data = new
                    {
                        id = 0,
                        Nama = ""
                    }
                };
            }

            return result;
            
        }


    }
}

