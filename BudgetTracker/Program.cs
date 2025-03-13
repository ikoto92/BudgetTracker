using BudgetTracker;

class Program
{
    static void Main(string[] args)
    {
        BudgetManager manager = new BudgetManager();

        while (true)
        {
            Console.WriteLine("\n===============================");
            Console.WriteLine("  BudgetTracker - Console App  ");
            Console.WriteLine("===============================");
            Console.WriteLine("1. Ajouter un revenu");
            Console.WriteLine("2. Ajouter une dépense");
            Console.WriteLine("3. Afficher le solde");
            Console.WriteLine("4. Voir les transactions");
            Console.WriteLine("5. Quitter");
            Console.Write("Choisissez une option : ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Entrez le montant : ");
                    double incomeAmount = double.Parse(Console.ReadLine());
                    Console.Write("Entrez la catégorie : ");
                    string incomeCategory = Console.ReadLine();
                    manager.AddTransaction("revenu", incomeAmount, incomeCategory);
                    break;
                case "2":
                    Console.Write("Entrez le montant : ");
                    double expenseAmount = double.Parse(Console.ReadLine());
                    Console.Write("Entrez la catégorie : ");
                    string expenseCategory = Console.ReadLine();
                    manager.AddTransaction("dépense", expenseAmount, expenseCategory);
                    break;
                case "3":
                    manager.ShowBalance();
                    break;
                case "4":
                    manager.ShowTransactions();
                    break;
                case "5":
                    Console.WriteLine("Merci d'avoir utilisé BudgetTracker. À bientôt !");
                    return;
                default:
                    Console.WriteLine("Option invalide, veuillez réessayer.");
                    break;
            }
        }
    }
}

