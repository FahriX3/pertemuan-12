using Microsoft.AspNetCore.Mvc;

namespace WebApplicationTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet("halo")]
        public string Index()
        {
            return "hello selamat pagi";
        }

        [HttpGet("test")]
        public string nama([FromQuery] string nama)
        {
            return "hello, " + nama ;
        }

        [HttpGet("{noRumah}")]
        public string Hallo(int noRumah)
        {   
            return "hello, " + noRumah;
        }

        [HttpGet("SimpleUser")]
        public object SimpleUser()
        {
            return new
            {
                Id = 1,
                Role = new String[] {"Admin", "Pengawas"},
                PIndex = new int [] { 1, 2, 3 }
            };
        }
    }
}
