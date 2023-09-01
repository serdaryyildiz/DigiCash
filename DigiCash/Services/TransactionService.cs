using DigiCash.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace DigiCash.Services
{
    public class TransactionService
    {
        private readonly MongoDbServices _mongoDbServices;
        private Wallet _wallet;

        public TransactionService(MongoDbServices mongoDbServices)
        {
            _mongoDbServices = mongoDbServices;
        }

        /*  private async Task<ProcessHistory> CheckHistory(string walletId)
          {
              try
              {
                  return new ProcessHistory(walletId,await _mongoDbServices.GetValue(walletId));

              }
              catch (Exception)
              {
                  throw new Exception("Bir hata meydana geldi.");
              }
              return null;
          }*/

        private async Task<ProcessHistory> CheckHistory(string walletId)
        {
            try
            {
                var historyObject = await _mongoDbServices.GetValue(walletId);
                if (historyObject is ProcessHistory processHistory)
                {
                    return processHistory;
                }
                throw new Exception("Cüzdana ait bir gecmis kaydi bulunamadi."); // Eğer historyObject ProcessHistory türünde değilse
            }
            catch (Exception)
            {
                throw new Exception("Bir hata meydana geldi"); // Hata durumunda
            }
        }


        public async void AddHistory(string walletId, Process process)
        {
            _mongoDbServices.AddValue(new ProcessHistory(walletId, process));
        }


        public ProcessHistory GetHistory(String walletId)
        {
            //ProcessHistory history = _mongoDbServices.GetValue(walletId);
            //return new ProcessHistory(wallet);
            var filter = Builders<ProcessHistory>.Filter.Eq("WalletId", walletId);
            ProcessHistory transactions = (ProcessHistory)_mongoDbServices.GetCollection().Find(filter);
            return transactions;
        }

        public List<Process> GetLast24Hours(String walletId)
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);
            var filter = Builders<ProcessHistory>.Filter.Eq("WalletId", walletId);
            ProcessHistory transaction = (ProcessHistory)_mongoDbServices.GetCollection().Find(filter);
            List<Process> Last24Hours = new List<Process>();
            foreach(Process history in transaction.Histories)
            {
                if(history.DateTime > yesterday && history.DateTime <= DateTime.Now)
                {
                    Last24Hours.Add(history);
                }
                break;
            }
            return Last24Hours;

        }
        public double GetLast24HoursProcess(String walletId)
        {
            double Last24Hours = 0;
            foreach(Process processes in GetLast24Hours(walletId))
            {
                Last24Hours += processes.ProcessBalance;
            }
            return Last24Hours;
        }
    }
}

