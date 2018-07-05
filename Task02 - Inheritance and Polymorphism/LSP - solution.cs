using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp
{
    interface IPay
    {
        bool PayMoney(int ammount);
    }

    interface IBorrow
    {
        void BorrowMoney(int ammount);
    }

    public class BasicAccount : IPay
    {
        int balance;
        public BasicAccount()
        {
            balance = 0;
        }
        public bool PayMoney(int ammount)
        {
            if (balance < ammount)
                return false;
            balance -= ammount;
            return true;
        }
    }
    public class GoldAccount : IPay, IBorrow
    {
        int balance, borrowedMoney;
        public GoldAccount()
        {
            balance = 0;
            borrowedMoney = 0;
        }
        public bool PayMoney(int ammount)
        {
            if (balance < ammount)
                return false;
            balance -= ammount;
            return true;
        }
        public void BorrowMoney(int ammount)
        {
            balance += ammount;
            borrowedMoney += ammount;
        }
    }
    
}
