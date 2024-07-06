using Microsoft.AspNetCore.Mvc;

namespace Elon.Controllers
{
    [ApiController]
    [Route("player")]
    public class ElonController : ControllerBase
    {
        private ICardPickStrategy strategy;

        public ElonController(ICardPickStrategy strategy)
        {
            this.strategy = strategy;
        }

        [HttpGet("test")]
        public IActionResult test()
        {
            return Ok("success");
        }

        [HttpPost(Name = "result")]
        public IActionResult Get([FromBody] List<Card> cards)
        {
            Console.WriteLine("get request");
            return Ok(strategy.Pick(cards.ToArray()));
        }
    }
}
