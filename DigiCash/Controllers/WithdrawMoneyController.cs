using DigiCash.Models;
using DigiCash.Services.WalletServices;
using Microsoft.AspNetCore.Mvc;

namespace DigiCash.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WithdrawMoneyController : Controller
    {
        WithdrawServices _withdrawServices;
        public WithdrawMoneyController(WithdrawServices withdrawServices)
        {
            _withdrawServices = withdrawServices;
        }

        [HttpPut]
        public async Task<IActionResult> WithdrawMoney([FromBody] RequestModel request)
        {
            try
            {
                bool response;
                if (request.Amount != null && request.WalletId != null)
                {
                    response = await _withdrawServices.Withdraw(request.WalletId, request.Amount ?? 0);
                }
                else
                {
                    return BadRequest("You didn't send an ID or an Amount value");
                }
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something Went Wrong.");
            }
            return null;
        }
    }
}
