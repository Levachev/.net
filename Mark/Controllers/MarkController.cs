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

        [HttpGet("test")]
        public IActionResult test()
        {
            return Ok("success");
        }

        [HttpPost(Name = "result")]
        public IActionResult Get([FromBody] List<Card> cards)
        {
            return Ok(strategy.Pick(cards.ToArray()));
        }
    }
}
