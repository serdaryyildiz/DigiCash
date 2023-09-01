using DigiCash.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DigiCash.Services.WalletServices
{
    public class WithdrawServices
    {
        private readonly AmountServices _amountServices;
        private readonly PostgreSqlServices _postgreSqlServices;
        private readonly TransactionService _transactionService;    
        public WithdrawServices(AmountServices amountServices, PostgreSqlServices postgreSqlServices, TransactionService transactionService)
        {
            _amountServices = amountServices;
            _postgreSqlServices = postgreSqlServices;
            _transactionService = transactionService;
        }

        public async Task<bool> Withdraw(string walletId, double amount)
        {
            bool withdrawAmountIsOkey = await _amountServices.CheckWithdrawAmount(walletId, amount);
            if (!withdrawAmountIsOkey) { return false; }
            try
            {
                Wallet wallet = await _postgreSqlServices.GetWallet(walletId);
                double _balance = (double)wallet.Balance;
                if (wallet != null)
                {
                    _balance -= amount;
                    wallet.Balance = _balance;
                    _postgreSqlServices.SetBalance(_balance,walletId);
                    _transactionService.AddHistory(walletId, new Process("Withdraw", _balance + amount, _balance, null , amount));
                    return true;
                }
                else
                {
                    return false; // Cüzdan bulunamadı
                }
            }
            catch (Exception)
            {
                return false; // Hata durumunda false döndür
            }
        
        // Çekim miktarı uygun değil
    }
    }
}
