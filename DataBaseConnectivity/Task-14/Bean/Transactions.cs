

namespace Task_14.Bean
{
    internal class Transactions
    {
        public int transaction_id { get; set; }

        public int account_id { get; set; }

        public string transaction_type { get; set; }

        public int amount { get; set; }

        public DateTime transaction_date { get; set; }

        internal static void ViewTransactions(List<Transactions> transactions)
        {
           foreach (Transactions trans in transactions)
            {
                Console.WriteLine($"Transaction Id :: {trans.transaction_id} \t " +
                    $"Transaction Type :: {trans.transaction_type} \t " +
                    $"Amount :: {trans.amount} \t " +
                    $"Transaction Date :: {trans.transaction_date}");
            }
        }
    }
}
