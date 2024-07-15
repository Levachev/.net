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

        [HttpGet("color")]
        public IActionResult getColor()
        {
            return Ok(Util.deck[Util.pickNumber].color.ToString());
        }

        [HttpPost("result")]
        public IActionResult Get([FromBody] Card[] cards)
        {
            System.Diagnostics.Debug.WriteLine("get request");
            Console.WriteLine("get request");
            return Ok(1);
            //return Ok(strategy.Pick(cards.ToArray()));
        }
    }
}
