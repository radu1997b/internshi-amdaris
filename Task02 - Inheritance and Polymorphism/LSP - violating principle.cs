using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp
{
    public abstract class Account
    {
        protected int balance;
        public abstract bool PayMoney(int ammount);
        public abstract void BorrowMoney(int ammount);
    }

    public class BasicAccount : Account
    {
        public BasicAccount()
        {
            balance = 0;
        }
        public override bool PayMoney(int ammount)
        {
            if (balance - amount < 0)
                return false;
            balance -= ammount
            return true;
        }
        public override void BorrowMoney(int ammount)
        {
            throw new NotImplementedException();
        }
    }

    public class GoldAccount : Account
    {
        int borrowedAmmount;
        public GoldAccount()
        {
            borrowedAmmount = 0;
            balance = 0;
        }
        public override bool PayMoney(int ammount)
        {
            if (balance - ammount < 0)
                return false;
            balance -= ammount
            return true;
        }

        public override void BorrowMoney(int ammount)
        {
            balance += ammount;
        }
    }
}
