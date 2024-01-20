using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___App.Controllers
{
    [Route("api/TravelAgencies")]
    [ApiController]
    public class TravelAgencyApiController : ControllerBase
    {
        private readonly AppDbContext _travel;

        public TravelAgencyApiController(AppDbContext context)
        {
            _travel = context;
        }

        [HttpGet]
        public IActionResult GetByName(string? q)
        {
            return Ok(
                q == null ?
                _travel.TravelAgencies
                .Select(o => new { o.Id, o.Name })
                .ToList() :
                _travel.TravelAgencies
                .Where(x => x.Name.ToUpper().StartsWith(q.ToUpper()))
                .Select(o => new { o.Id, o.Name })
                .ToList()
                );
        }
    }
}
