using System;
using DigiCash.Models;
using DigiCash.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigiCash.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionHistoryController : Controller
    {

        private readonly TransactionService _transactionService;
        public TransactionHistoryController(TransactionService transactionService) 
        {
            _transactionService = transactionService;
        }   
        [HttpGet("route/api")]
       /* public async Task<IActionResult> TransactionHistory([FromBody] RequestModel request)
        {
            try
            {
                var histories = null;//_transactionService.getHistory(request.walletId);
                return Ok(histories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return null;
        }*/

        public async Task<IActionResult> ShowTransactionHistory(RequestModel request)
        {
            try
            {
                var histories = _transactionService.GetHistory(request.WalletId);
                return Ok(histories);
            }
            catch (Exception ex)
            {
                return BadRequest("Bir hata meydana geldi \n" + ex.Message);
            }
        }
    }
}

