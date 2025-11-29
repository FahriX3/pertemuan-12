using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplicationTest.Helpers;

namespace WebApplicationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        private readonly Koneksi _koneksi;

        public ConnectionController(Koneksi koneksi)
        {
            _koneksi = koneksi;
        }

        [HttpGet("test")]
        public object test()
        {
            var result = new
            {
                Status = 200,
                Message = "Koneksi Berhasil"
            };

            try
            {
                SqlConnection connection = _koneksi.GetConnection();
                connection.Open();
                connection.Close();

                return result;
            }
            catch (Exception e)
            {
                result = new
                {
                    Status = 500,
                    Message = "Koneksi Gagal" + e.Message
                };
            }

            return result;
        }
    }
}
