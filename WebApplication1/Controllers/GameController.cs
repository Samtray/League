using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // GET: api/<GameController>
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

            GameListViewModel vm = new GameListViewModel();
            vm.Status = 0;
            vm.Games = Game.GetAll();
            return Ok(vm);
        }

        [HttpPost]
        [Route("[action]/")]
        public ActionResult Finish([FromForm] PostFinishGame p)
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

            FinishGameViewModel vm = new FinishGameViewModel();

            if (!string.IsNullOrEmpty(p.idgame.ToString()) &&
                !string.IsNullOrEmpty(p.scorevisitor.ToString()) &&
                !string.IsNullOrEmpty(p.scorehome.ToString())) {
                vm.Status = Game.Finish(p.idgame, p.scorevisitor, p.scorehome);
                vm.Message = Enum.GetName(typeof(FinishGameEnum), vm.Status);
            }

            return Ok(vm);

        }

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GameController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GameController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
