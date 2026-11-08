using System;

namespace MobileAccountSystem
{
    public class LowBalance : EventArgs
    {
        public decimal CurrentBalance { get; }
        public decimal MinimumThreshold { get; }

        public LowBalance(decimal currentBalance, decimal minimumThreshold)
        {
            CurrentBalance = currentBalance;
            MinimumThreshold = minimumThreshold;
        }
    }
}