using System;
using System.Net;
using DigiCash.Models;
using DigiCash.Services;
using DigiCash.Services.WalletServices;
using Microsoft.AspNetCore.Mvc;

namespace DigiCash.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepositMoneyController : Controller
    {
        DepositServices _depositServices;
        MongoDbServices _mongoDbServices;

        public DepositMoneyController(DepositServices DepositServices, MongoDbServices mongoDbServices) {
            _depositServices = DepositServices;
            _mongoDbServices = mongoDbServices;
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> DepositMoney([FromBody] RequestModel request) {
            bool Response;
            try
            {
                if (request.Amount!=null && request.WalletId!=null)
                {
                    Response = await _depositServices.Deposit(request.WalletId, request.Amount??0);
                }
                else
                {
                    return BadRequest("You didn't send an ID or an Amount value");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            if (request.Amount == null || request.WalletId == null) { return BadRequest("You didn't send an ID or an Amount value");}

            Response = await _depositServices.Deposit(request.WalletId, request.Amount ?? 0);
            return Ok();
        }
    }
}

