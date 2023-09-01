using DigiCash.Models;

namespace DigiCash.Services
{
    public class AmountServices
    {
        public readonly ConfigServices _configServices;
        public readonly BalanceServices _balanceServices;
        public readonly TransactionService _transactionServices;
        public AmountServices(ConfigServices configServices, BalanceServices balanceServices, TransactionService transactionServices)
        {
            _configServices = configServices;
            _balanceServices = balanceServices;
            _transactionServices = transactionServices;
        }
        public async Task<bool> CheckWithdrawAmount(string walletId, double amount)
        {
                if (//if yapısı kontrol bölümü kısaltma
                    amount < _configServices.getMaxWithdraw() &&
                    amount < await _balanceServices.GetBalanceAsync(walletId) &&
                    (_transactionServices.GetLast24HoursProcess(walletId) + amount) < _configServices.getMaxWithdraw())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public async Task<bool> CheckTransferAmount(string walletId, double amount)
            {
                if (
                    amount < _configServices.getMaxTransfer() &&
                    amount < await _balanceServices.GetBalanceAsync(walletId) &&
                    (_transactionServices.GetLast24HoursProcess(walletId) + amount) < _configServices.getMaxWithdraw()
                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            return false;
        }
    }
}