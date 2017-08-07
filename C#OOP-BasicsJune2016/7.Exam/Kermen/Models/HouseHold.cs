using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public abstract class HouseHold
    {
        private int numberOfRooms;
        private decimal roomElectricity;
        private readonly decimal income;
        private decimal moneyWallet;

        protected HouseHold(decimal income, int numberOfRooms, decimal roomElectricity)
        {
            this.income = income;
            this.numberOfRooms = numberOfRooms;
            this.roomElectricity = roomElectricity;
        }

        public HouseHold(int numberOfRooms, decimal roomElectricity)
        {
            this.numberOfRooms = numberOfRooms;
            this.roomElectricity = roomElectricity;
        }

        public virtual int Population
        {
            get { return 1;}
        }

        public virtual decimal Consumption
        {
            get { return this.roomElectricity * this.numberOfRooms; }
        }

        public void GetIncome()
        {
            this.moneyWallet += this.income;
        }

        public void PayBills()
        {
            this.moneyWallet -= this.Consumption;
        }

        public bool CanPayBills()
        {
            return this.moneyWallet >= this.Consumption;
        }
    }
}