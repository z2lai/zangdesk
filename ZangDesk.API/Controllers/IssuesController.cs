using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZangDesk.API.Controllers
{
    [ApiController]
    [Route("api/issues")]
    public class IssuesController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetIssues()
        {
            return new JsonResult(
                new List<object>
                {
                    new { id = 1, Name = "Issue 1" },
                    new { id = 2, Name = "Issue 2" }
                });
        }
    }
}