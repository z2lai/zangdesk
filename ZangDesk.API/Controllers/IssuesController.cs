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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = issue.Id }, issue); // https://ochzhen.com/blog/created-createdataction-createdatroute-methods-explained-aspnet-core#createdataction-explained
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Issue issue)
        {
            if (id != issue.Id) return BadRequest();

            _context.Entry(issue).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}