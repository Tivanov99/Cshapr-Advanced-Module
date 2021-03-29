using Chainblock.Contracts;

namespace Chainblock
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            IChainblock transactions = new Chainblock();
            transactions.Add(new Transaction(-1, TransactionStatus.Aborted, "to", "from", 100));
        }
    }
}
