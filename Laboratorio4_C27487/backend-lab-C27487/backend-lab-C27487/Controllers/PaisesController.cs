using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_lab_C27487.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hola Mundo";
        }

    }
}
