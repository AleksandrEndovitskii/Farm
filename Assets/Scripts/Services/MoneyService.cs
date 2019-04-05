using System;
using Utils;

namespace Services
{
    public class MoneyService : IInitializable
    {
        public Action<int> MoneyAmountChanged = delegate {  };

        private int _moneyAmount;
        public int MoneyAmount
        {
            get
            {
                return _moneyAmount;
            }
            set
            {
                if (_moneyAmount == value)
                {
                    return;
                }

                _moneyAmount = value;

                MoneyAmountChanged.Invoke(_moneyAmount);
            }
        }

        public void Initialize()
        {
            MoneyAmount = 100;
        }
    }
}
