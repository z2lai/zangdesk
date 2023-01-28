using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZangDesk.API.Data;
using ZangDesk.API.Model;

namespace ZangDesk.API.Controllers
{
    [ApiController] // Attribute from MVC, applies automatic model validation, binding request data to model
    [Route("api/issues")]
    public class IssuesController : ControllerBase
    {
        private readonly IssueDbContext _context;

        public IssuesController(IssueDbContext context)
        {
            _context = context;
        }

        [HttpGet] // Action method that responds to an HTTP request
        public async Task<IEnumerable<Issue>> Get() 
            => await _context.Issues.ToListAsync();

        //public JsonResult GetIssues()
        //{
        //    return new JsonResult(
        //        new List<object>
        //        {
        //            new { id = 1, Name = "Issue 1" },
        //            new { id = 2, Name = "Issue 2" }
        //        });
        //}
    }
}