using System;
using DigiCash.Models;
using DigiCash.Services.WalletServices;
using Microsoft.AspNetCore.Mvc;

namespace DigiCash.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoneyTransferController : Controller
    {
        TransferMoneyServices _transferMoney;
        public MoneyTransferController(TransferMoneyServices transferMoney) {
            _transferMoney = transferMoney;
        }

        [HttpPost]
        public async Task<IActionResult> MoneyTransfer([FromBody] RequestModel request)
        {
            try 
            {
                bool response;
                if (request.Amount != null && request.WalletId != null&& request.TargetWalletId != null)
                {
                    response = await _transferMoney.TransferMoney(request.WalletId,request.TargetWalletId,request.Amount ?? 0);
                }
                else
                {
                    return BadRequest("You didn't send an ID, TargetID or an Amount value");
                }
                return Ok(true);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something Went Wrong.");
            }
        }
    }
}

