using Chainblock.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock
{
    public class Transaction : ITransaction
    {
        private int id;
        private TransactionStatus status;
        private string from;
        private string to;
        private double amount;
        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            Id = id;
            Status = status;
            From = from;
            To = to;
            Amount = amount;
        }
        public int Id
        {
            get => this.id;
            set => this.id = value;
        }

        public TransactionStatus Status
        {
            get => this.status;
            set => this.status = value;
        }
        public string From
        {
            get => this.from;
            set => this.from = value;
        }
        public string To
        {
            get => this.to;
            set => this.to = value;
        }
        public double Amount
        {
            get => this.amount;
            set => this.amount = value;
        }
    }
}
