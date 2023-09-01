using System;
namespace DigiCash.Models
{
    public class ProcessHistory
    {
        public string WalletId { get; set; }
        public List<Process> Histories { get; set; } = new List<Process>();
        public ProcessHistory(string walletID,Process process)
        {
            Histories[0] = process;
            WalletId = walletID;
        }
    }
}

