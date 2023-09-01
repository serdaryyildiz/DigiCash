using System;
using DigiCash.Models;
using DigiCash.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigiCash.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowBalanceController : Controller
    {
        private readonly BalanceServices _balanceServices;

        public ShowBalanceController(BalanceServices balanceServices)
        {
            _balanceServices = balanceServices;
        }

        [HttpGet]
        public async Task<IActionResult> ShowBalance([FromBody] RequestModel request)
        {
            double balance;
            try
            {
                if (request.WalletId != null)
                {
                    balance = await _balanceServices.GetBalanceAsync(request.WalletId);
                    return Ok(balance);
                }
                else
                {
                    return BadRequest("WalletId gönderilmedi");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "hata");
            }
        }

    }
}
