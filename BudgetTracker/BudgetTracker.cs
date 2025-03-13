using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker
{
    class Transaction
    {
        public string Type { get; set; } // Revenu ou Dépense
        public double Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public Transaction(string type, double amount, string category)
        {
            Type = type;
            Amount = amount;
            Category = category;
            Date = DateTime.Now;
        }
    }
}
