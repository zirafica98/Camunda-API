using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Camunda_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CamundaController : ControllerBase
    {
        private readonly ILogger<CamundaController> _logger;

        public CamundaController(ILogger<CamundaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("getCodeBook")]
        /*[SwaggerOperation(Summary = "Dohvati CodeBook", Description = "Dohvati podatke iz CodeBook servisa.")]
        [SwaggerResponse(200, "Success", typeof(string))]*/
        public async Task<IActionResult> GetCodeBook() // Uklonjen 'static' atribut
        {
            string apiUrl = "https://jsonplaceholder.typicode.com/todos/1";
            /*string apiUrl = "https://rbrsdp01test.rbj.co.yu:8444/ol/v1/codebook/SC3TUGPR";*/

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    return Ok(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    return StatusCode((int)response.StatusCode, $"HTTP greška: {response.StatusCode}");
                }
            }
        }
    }
}