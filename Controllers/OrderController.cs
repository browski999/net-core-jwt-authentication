using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureWebApiJWT.Interfaces;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SecureWebApiJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet()]
        [Authorize(Policy = "OnlyNonBlockedCustomer")]
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;

            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
            {
                return Unauthorized("Invalid customer");
            }

            var orders = await _orderService.GetOrdersByCustomerId(int.Parse(claim.Value));

            if (orders == null || !orders.Any())
            {
                return BadRequest($"No order was found");
            }

            return Ok(orders);
        }
    }
}
