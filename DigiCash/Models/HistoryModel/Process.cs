using System;
namespace DigiCash.Models
{
    public class Process
    {
        public string ProcessName { get; set; }
        public double ProcessBalance { get; set; }
        public double OldBalance { get; set; }
        public double NewBalance { get; set; }
        public string? TargetWalletId { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public Process(string processName, double newBalance , double oldBalance ,string? targetWalletId , double ProcessBalance)
        {
            this.ProcessName = processName;
            this.ProcessBalance = ProcessBalance;
            this.TargetWalletId = targetWalletId;
            this.OldBalance = OldBalance;
            this.NewBalance = NewBalance;
            DateTime = DateTimeOffset.UtcNow;
        }
    }
}

