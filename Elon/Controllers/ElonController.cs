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
            while (!Util.isReady)
            {
                Thread.Sleep(100);
            }
            var ret = Util.deck[Util.pickNumber].color.ToString();
            Util.isReady = false;
            return Ok(ret);
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
