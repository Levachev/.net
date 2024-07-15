using Microsoft.AspNetCore.Mvc;

namespace Mark.Controllers
{
    [ApiController]
    [Route("player")]
    public class MarkController : ControllerBase
    {

        private ICardPickStrategy strategy;

        public MarkController(ICardPickStrategy strategy)
        {
            this.strategy = strategy;
        }

        [HttpGet("color")]
        public IActionResult getColor()
        {
            return Ok(Util.deck[Util.pickNumber].color.ToString());
        }

        [HttpPost("result")]
        public IActionResult Get([FromBody] List<Card> cards)
        {
            System.Diagnostics.Debug.WriteLine("get request");

            return Ok(strategy.Pick(cards.ToArray()));
        }
    }
}
