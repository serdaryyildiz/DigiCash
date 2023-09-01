namespace DigiCash.Models
{
    
    public class RequestModel
    {
        public string? UserId { get; set; }
        public string? WalletId { get; set; }
        public string? TargetWalletId { get; set; }
        public double? Amount { get; set; }
    }
}
