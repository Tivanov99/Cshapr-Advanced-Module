using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private List<ITransaction> transactions;
        private int count;
        public Chainblock()
        {
            transactions = new List<ITransaction>();
        }
        public int Count => this.count;

        public void Add(ITransaction tx)
        {
            if (Contains(tx))
            {
                throw new InvalidOperationException($"Transaction with ID {tx.Id} already exist");
            }
            transactions.Add(tx);
            this.count++;
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (id <= 0)
            {
                throw new ArgumentException("No transactions with neggative id!");
            }
            int result = ChekForTransactionID(id);
            if (this.count == 0)
            {
                throw new ArgumentException($"No transaction Available");
            }
            else if (result == -1)
            {
                throw new ArgumentException($"No find transaction with ID{id}");

            }
            else if (transactions[result].Status != newStatus)
            {
                transactions[result].Status = newStatus;
            }
            else
            {
                throw new ArgumentException($"Transaction with Id {id}, already Have {newStatus}");
            }
        }

        public bool Contains(ITransaction tx)
        {
            int result = ChekForTransaction(tx);
            if (result != -1)
            {
                return true;
            }
            return false;
        }

        public bool Contains(int id)
        {
            if (transactions.Any(t => t.Id == id))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public ITransaction GetById(int id)
        {
            if(this.count==0)
            {
                throw new InvalidOperationException($"No transaction Available");
            }
            else if(id<=0)
            {
                throw new InvalidOperationException($"No transaction with negative Id!");
            }
            int result = ChekForTransactionID(id);
            if(result==-1)
            {
                throw new InvalidOperationException($"No transaction with ID {id}");
            }
            return transactions[result];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            List<ITransaction> result = new List<ITransaction>();
            foreach (ITransaction item in transactions)
            {
                if(item.Status == status)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            return GetEnumerator();
        }

        public void RemoveTransactionById(int id)
        {
            if(id<=0)
            {
                throw new ArgumentException("No transaction with neggative ID!");
            }
            int result = ChekForTransactionID(id);
            if(this.count==0)
            {
                throw new InvalidOperationException($"No transaction Available");
            }
           else if (result==-1)
            {
                throw new InvalidOperationException($"No transaction with Id{id}");
            }
            transactions.RemoveAt(result);
            this.count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (ITransaction item in transactions)
            {
                yield return item;
            }
        }
        private int ChekForTransaction(ITransaction tx)
        {
            int index = 0;
            foreach (ITransaction item in transactions)
            {
                if (item == tx)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }
        private int ChekForTransactionID(int id)
        {
            int index = 0;
            foreach (ITransaction item in transactions)
            {
                if (item.Id == id)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }
    }
}
