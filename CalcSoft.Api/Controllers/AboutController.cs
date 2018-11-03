using CalcSoft.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalcSoft.Api.Controllers
{
    [Route("showmethecode")]
    public class AboutController : ControllerBase
    {
        private readonly ConfigApp _configApp;

        public AboutController(ConfigApp configApp)
        {
            _configApp = configApp;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return Ok(new
            {
                SourceCode = _configApp.GitHubUrl
            });
        }
    }
}