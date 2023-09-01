using DigiCash.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Bson;
using System;
namespace DigiCash.Services.WalletServices
{
    public class TransferMoneyServices
    {
        PostgreSqlServices _postgreSqlServices;
        AmountServices _amountServices;

        public TransferMoneyServices(PostgreSqlServices postgreSqlServices , AmountServices amountServices)
        {
            _amountServices = amountServices;
            _postgreSqlServices = postgreSqlServices;
        }

        public async Task<bool> TransferMoney(string walletId , string targetWalletId , double amount)
        {
            if(await _amountServices.CheckTransferAmount(walletId,amount))
            {
                Wallet wallet = await _postgreSqlServices.GetWallet(walletId);
                wallet.Balance -= amount;
                Wallet targetWallet = await _postgreSqlServices.GetWallet(targetWalletId);
                targetWallet.Balance += amount;
                try
                {
                    _postgreSqlServices.SetBalance(wallet.Balance , walletId);
                    _postgreSqlServices.SetBalance(targetWallet.Balance , targetWalletId);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Bir hata meydana geldi\n" , ex);
                }
            }
            return false;
        }
    }
}

