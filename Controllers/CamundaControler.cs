using Camunda_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Camunda_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CamundaController : ControllerBase
    {
        private readonly ILogger<CamundaController> _logger;
        private readonly IConfiguration _config;

        public CamundaController(ILogger<CamundaController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        [Route("getProcessDefinition/{processName}")]
        public Task<string> GetProcessDefinition([FromServices] IHttpClientFactory factory, string processName)
        {
            var client = factory.CreateClient("camunda");

            return client.GetStringAsync($"process-definition/key/{processName}");
        }

        [HttpGet]
        [Route("getProcessDefinitionXML/{processName}")]
        public Task<string> GetProcessDefinitionXML([FromServices] IHttpClientFactory factory, string processName)
        {
            var client = factory.CreateClient("camunda");

            return client.GetStringAsync($"process-definition/key/{processName}/xml");
        }

        [HttpPost]
        [Route("startProcessInstance/{processName}")]
        public Task<string> StartProcessInstance([FromServices] IHttpClientFactory factory, string processName)
        {          
            var client = factory.CreateClient("camunda");

            StringContent httpContent = new StringContent("", System.Text.Encoding.UTF8, "application/json");
            var result = client.PostAsync($"process-definition/key/{processName}/start", httpContent);

            return result.Result.Content.ReadAsStringAsync();
        }

        [HttpGet]
        [Route("getProcessInstance/{id}")]
        public Task<string> GetProcessInstance([FromServices] IHttpClientFactory factory, string id)
        {
            var client = factory.CreateClient("camunda");

            return client.GetStringAsync($"process-instance/{id}");
        }

        [HttpGet]
        [Route("getActiveTask/{processId}")]
        public Task<string> GetActiveTask([FromServices] IHttpClientFactory factory, string processId)
        {
            var client = factory.CreateClient("camunda");

            return client.GetStringAsync($"task?processInstanceId={processId}");
        }
    }
}