using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Money_Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bankAccounts = new Dictionary<int, double>();

            string[] accountsInfo = Console.ReadLine().Split(",");

            for (int i = 0; i < accountsInfo.Length; i++)
            {
                int accountNumber = int.Parse(accountsInfo[i].Split("-").First());
                double accountSum = double.Parse(accountsInfo[i].Split("-").Last());
                bankAccounts.Add(accountNumber, accountSum);
            }
            

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmd = input.Split();
                string command = cmd[0];
                int accNumber = int.Parse(cmd[1]);
                double sum = double.Parse(cmd[2]);
                try
                {
                    CheckIfAccountExists(accNumber, bankAccounts);

                    if (command == "Deposit")
                    {
                        bankAccounts[accNumber] += sum;
                        Console.WriteLine
                            ($"Account {accNumber} has new balance: {bankAccounts[accNumber]:f2}");
                    }

                    else if (command == "Withdraw")
                    {
                        if (sum > bankAccounts[accNumber])
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }

                        else
                        {
                            bankAccounts[accNumber] -= sum;
                            Console.WriteLine
                                ($"Account {accNumber} has new balance: {bankAccounts[accNumber]:f2}");
                        }
                    }

                    else
                    {
                        throw new FormatException("Invalid command!");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
               
            }
        }

        private static void CheckIfAccountExists(int accNumber, Dictionary<int,double> bankAccounts)
        {
            if (!bankAccounts.ContainsKey(accNumber))
            {
                throw new ArgumentException("Invalid account!");
            }
        }
    }
}
