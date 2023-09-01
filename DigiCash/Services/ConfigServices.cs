using System;
using DigiCash.Models;

namespace DigiCash.Services
{
    public class ConfigServices
    {
        private int MAX_WITHDRAW_VALUE;
        private int MAX_TRANSFER_VALUE;

        public ConfigServices(ConfigSettings configSettings)
        {
            MAX_TRANSFER_VALUE = configSettings.MAX_TRANSFER_VALUE;
            MAX_WITHDRAW_VALUE = configSettings.MAX_WITHDRAW_VALUE;
        }
        //public (int,int) getMaxLimits() =>(MAX_TRANSFER_VALUE, MAX_WITHDRAW_VALUE); //iki değeri birden çağırır

        public int getMaxTransfer() => MAX_TRANSFER_VALUE;
        public int getMaxWithdraw() => MAX_WITHDRAW_VALUE;
    }
}

