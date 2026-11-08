using System;

namespace MobileAccountSystem
{
    public class MobileAccount
    {
        private decimal _balance;
        private readonly decimal _minBalanceThreshold;

        public string PhoneNumber { get; }

        public event EventHandler<LowBalance>? LowBalanceReached;

        public MobileAccount(string phoneNumber, decimal initialBalance, decimal minBalanceThreshold = 10.0m)
        {
            PhoneNumber = phoneNumber;
            _balance = initialBalance;
            _minBalanceThreshold = minBalanceThreshold;
        }

        public void TopUp(decimal amount)
        {
            if (amount <= 0) return;
            _balance += amount;
            Console.WriteLine($"[{PhoneNumber}] Поповнено на {amount:F2} грн. Баланс: {_balance:F2} грн.");
        }

        public void MakeCall(int durationSeconds, decimal costPerSecond)
        {
            decimal totalCost = durationSeconds * costPerSecond;
            Console.WriteLine($"[{PhoneNumber}] Тривалість дзвінка: {durationSeconds} сек. Вартість: {totalCost:F2} грн.");

            _balance -= totalCost;
            Console.WriteLine($"[{PhoneNumber}] Залишок на рахунку: {_balance:F2} грн.");

            if (_balance <= _minBalanceThreshold)
            {
                OnLowBalanceReached(new LowBalance(_balance, _minBalanceThreshold));
            }
        }

        protected virtual void OnLowBalanceReached(LowBalance e)
        {
            LowBalanceReached?.Invoke(this, e);
        }
    }
}