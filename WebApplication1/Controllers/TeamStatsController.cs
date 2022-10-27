using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamStatsController : ControllerBase
    {
        // GET: api/<TeamStatsController>
        [HttpGet]
        public ActionResult<string> Get()
        {
            string username = Request.Headers["username"];
            string token = Request.Headers["token"];

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(token))
            {
                return Ok(Security.GetError(SecurityError.MissingOrEmptySecurityHeaders));
            }

            if (!Security.ValidateToken(username, token))
            {
                return Ok(Security.GetError(SecurityError.InvalidSecurityToken));
            }

            TeamStatViewModel vm = new TeamStatViewModel();
            vm.Status = 0;
            vm.TeamStats = TeamStat.GetAll();
            return Ok(vm);
        }

        // GET api/<TeamStatsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TeamStatsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TeamStatsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeamStatsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
