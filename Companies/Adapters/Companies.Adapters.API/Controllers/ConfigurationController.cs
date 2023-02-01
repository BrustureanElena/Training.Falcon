using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Fabric;

namespace Companies.Adapters.API.Controllers
{
    /// <summary>
    /// Configurations Controller
    /// </summary>
    [ApiController]
    [Route("configurations")]
    public class ConfigurationController : ControllerBase
    {
        private readonly StatelessServiceContext statelessServiceContext;

        /// <summary>
        /// ConfigurationController constructor
        /// </summary>
        /// <param name="statelessServiceContext">An instance of StatelessServiceContext.</param>
        public ConfigurationController(StatelessServiceContext statelessServiceContext)
        {
            this.statelessServiceContext = statelessServiceContext;
        }

        /// <summary>
        /// Retrieves the test parameter.
        /// </summary>
        /// <returns>Test parameter</returns>
        [HttpGet]
        [Route("parameter", Name = "GetTestParameter")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetParameter()
        {
            var configurationPackage = statelessServiceContext.CodePackageActivationContext.GetConfigurationPackageObject("Config");
            var connectionStringParameter = configurationPackage.Settings.Sections["ConfigSection"].Parameters["TestParameter"];

            return Ok(connectionStringParameter.Value);
        }
    }
}
