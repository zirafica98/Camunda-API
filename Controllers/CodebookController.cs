using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Camunda_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodebookController : ControllerBase
    {
        private readonly ILogger<CamundaController> _logger;
        private readonly IConfiguration _config;

        public CodebookController(ILogger<CamundaController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        [Route("getCodebookData/{codebookName}")]
        public Task<string> GetCodebookData([FromServices] IHttpClientFactory factory, string codebookName)
        {
            var client = factory.CreateClient("codebookRetail");

            return client.GetStringAsync(codebookName);
        }

        [HttpGet]
        [Route("getCodebookDataCorporate/{codebookName}")]
        public Task<string> GetCodebookDataCorporate([FromServices] IHttpClientFactory factory, string codebookName)
        {
            var client = factory.CreateClient("codebookCorporate");

            return client.GetStringAsync(codebookName);
        }

        [HttpGet]
        [Route("getCodebookPlaces/{placeId}")]
        public Task<string> GetCodebookPlaces([FromServices] IHttpClientFactory factory, string placeId)
        {
            var client = factory.CreateClient("codebookRetail");

            return client.GetStringAsync($"places/{placeId}");
        }

        [HttpGet]
        [Route("getCodebookPlacesCorporate/{placeId}")]
        public Task<string> GetCodebookPlacesCorporate([FromServices] IHttpClientFactory factory, string placeId)
        {
            var client = factory.CreateClient("codebookCorporate");

            return client.GetStringAsync($"places/{placeId}");
        }

        [HttpGet]
        [Route("getCodebookStreets/{placeId}/{municipalityId}")]
        public Task<string> GetCodebookStreets([FromServices] IHttpClientFactory factory, string placeId, string municipalityId)
        {
            var client = factory.CreateClient("codebookRetail");

            return client.GetStringAsync($"streets/{placeId}/{municipalityId}");
        }

        [HttpGet]
        [Route("getCodebookStreetsCorporate/{placeId}/{municipalityId}")]
        public Task<string> GetCodebookStreetsCorporate([FromServices] IHttpClientFactory factory, string placeId, string municipalityId)
        {
            var client = factory.CreateClient("codebookCorporate");

            return client.GetStringAsync($"streets/{placeId}/{municipalityId}");
        }

    }
}
