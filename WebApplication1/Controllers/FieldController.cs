using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        // GET: api/<FieldController>
        [HttpGet]
        public ActionResult<string> Get()
        {   //headers
            string username = Request.Headers["username"];
            string token = Request.Headers["token"];

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(token)){
                return Ok(Security.GetError(SecurityError.MissingOrEmptySecurityHeaders));
            }

            if (!Security.ValidateToken(username, token)) { 
                return Ok(Security.GetError(SecurityError.InvalidSecurityToken));
            }

            FieldListViewModel vm = new FieldListViewModel();
            vm.Status = 0;
            vm.Fields = Field.GetAll();
            return Ok(vm);
        }

        // GET api/<FieldController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FieldController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FieldController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FieldController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
