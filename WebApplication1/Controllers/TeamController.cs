using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        // GET: api/<TeamController>
        [HttpGet]
        public ActionResult<string> Get()
        { 
            //headers
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

            TeamListViewModel vm = new TeamListViewModel();
            vm.Status = 0;
            vm.Teams = Team.GetAll();
            return Ok(vm);
        }

        // GET api/<TeamController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TeamController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TeamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
