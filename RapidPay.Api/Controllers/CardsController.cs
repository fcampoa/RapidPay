using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Domain.Models;
using RapidPay.Services.Services;

namespace RapidPay.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Card card)
        {
            try
            {
                return Ok(_cardService.Create(card));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("Pay")]
        public IActionResult Pay([FromBody] Card card, decimal amount)
        {
            try
            {
                return Ok(_cardService.Pay(card, amount));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Balance")]
        public IActionResult Balance([FromBody] Card card)
        {
            try
            {
                return Ok(_cardService.GetCardBalance(card));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
