using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
        public class ATMSystem
        {
            static Dictionary<int, int> denominations = new Dictionary<int, int>()
            {
                { 2000, 10 },
                { 500, 20 },
                { 200, 30 },
                { 100, 50 }
            };

            // Calculate Total ATM Balance
            public static int GetTotalBalance()
            {
                int totalAmount = 0;

                foreach (KeyValuePair<int, int> kvp in denominations)
                {
                    totalAmount += kvp.Key * kvp.Value;
                }

                return totalAmount;
            }

            // Display ATM Status
            public static void DisplayATMStatus()
            {
                Console.WriteLine("\nCurrent ATM Status");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Denomination\tCount");

                foreach (KeyValuePair<int, int> note in denominations)
                {
                    Console.WriteLine(note.Key + "\t\t" + note.Value);
                }

                Console.WriteLine("\nTotal ATM Balance : " + GetTotalBalance());
            }

            // Withdraw Amount
            public static void Withdraw()
            {
                Console.Write("Enter withdrawal amount: ");

                int amount;

                while (!int.TryParse(Console.ReadLine(), out amount))
                {
                    Console.WriteLine("Enter valid amount.");
                }

                // Validation
                if (amount <= 0 || amount % 100 != 0)
                {
                    Console.WriteLine("ERROR: Amount must be a multiple of 100");
                    return;
                }

                if (amount > GetTotalBalance())
                {
                    Console.WriteLine("ERROR: Insufficient ATM balance");
                    return;
                }

                int remainingAmount = amount;

                Dictionary<int, int> dispensedNotes = new Dictionary<int, int>();

                // Dispense Highest Denomination First
                foreach (KeyValuePair<int, int> note in denominations)
                {
                    int denomination = note.Key;
                    int availableNotes = note.Value;

                    int requiredNotes = remainingAmount / denomination;

                    int notesToDispense = Math.Min(requiredNotes, availableNotes);

                    dispensedNotes.Add(denomination, notesToDispense);

                    remainingAmount -= denomination * notesToDispense;
                }

                // Exact amount not possible
                if (remainingAmount != 0)
                {
                    Console.WriteLine("ERROR: Cannot dispense the exact amount with available notes");
                    return;
                }

                // Update ATM Notes
                foreach (KeyValuePair<int, int> item in dispensedNotes)
                {
                    denominations[item.Key] -= item.Value;
                }

                // Success Output
                Console.WriteLine("\nSUCCESS");

                Console.WriteLine("\nDispensed Notes:");
                foreach (KeyValuePair<int, int> item in dispensedNotes)
                {
                    Console.WriteLine(item.Key + " x " + item.Value);
                }

                Console.WriteLine("\nRemaining Notes in ATM:");
                foreach (KeyValuePair<int, int> note in denominations)
                {
                    Console.WriteLine(note.Key + " : " + note.Value);
                }

                Console.WriteLine("\nRemaining ATM Balance : " + GetTotalBalance());
            }

            public static void Main()
            {
                int choice;
                char ch;

                while (true)
                {
                    Console.WriteLine("\n===== ATM MENU =====");
                    Console.WriteLine("1. Withdraw Cash");
                    Console.WriteLine("2. ATM Status");
                    Console.WriteLine("3. Get Balance");
                    Console.Write("Enter Choice: ");

                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Enter valid choice.");
                    }

                    switch (choice)
                    {
                        case 1:
                            Withdraw();
                            break;

                        case 2:
                            DisplayATMStatus();
                            break;
                        case 3:
                            int totalAmount = GetTotalBalance();
                            foreach (KeyValuePair<int, int> kvp in denominations)
                            {
                                Console.WriteLine(kvp.Key + "*" + kvp.Value + "=" + kvp.Key * kvp.Value);
                            }
                            Console.WriteLine("Total Amount" + totalAmount);
                            break;

                        default:
                            Console.WriteLine("Invalid Choice.");
                            break;
                    }

                    Console.Write("\nAre you sure you want to exit? (Y/N): ");

                    while (!char.TryParse(Console.ReadLine(), out ch))
                    {
                        Console.Write("Enter Y or N: ");
                    }

                    if (ch == 'Y' || ch == 'y')
                    {
                        Console.WriteLine("Thank You!");
                        break;
                    }
                }
            }
        }
    }
