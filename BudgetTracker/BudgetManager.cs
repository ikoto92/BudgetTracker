using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker
{
 
    class BudgetManager
    {
        private List<Transaction> transactions;
        private double balance;
        private const string filePath = "transactions.csv";

        public BudgetManager()
        {
            transactions = new List<Transaction>();
            balance = 0;
            LoadTransactions();
        }

        public void AddTransaction(string type, double amount, string category)
        {
            Transaction transaction = new Transaction(type, amount, category);
            transactions.Add(transaction);

            if (type.ToLower() == "revenu")
                balance += amount;
            else
                balance -= amount;

            SaveTransactions();
            Console.WriteLine("Transaction ajoutée avec succès !");
        }

        public void ShowBalance()
        {
            Console.WriteLine($"\nVotre solde actuel : {balance} €\n");
        }

        public void ShowTransactions()
        {
            Console.WriteLine("\nHistorique des transactions :");
            foreach (var t in transactions)
            {
                Console.WriteLine($"[{t.Date}] {t.Type}: {t.Amount} € - {t.Category}");
            }
        }

        private void SaveTransactions()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var t in transactions)
                {
                    writer.WriteLine($"{t.Type},{t.Amount},{t.Category},{t.Date}");
                }
            }
        }

        private void LoadTransactions()
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 4)
                        {
                            string type = parts[0];
                            double amount = double.Parse(parts[1]);
                            string category = parts[2];
                            DateTime date = DateTime.Parse(parts[3]);

                            transactions.Add(new Transaction(type, amount, category));
                            if (type.ToLower() == "revenu")
                                balance += amount;
                            else
                                balance -= amount;
                        }
                    }
                }
            }
        }
    }

}
