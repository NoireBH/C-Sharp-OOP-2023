using System;
using Telephony.Models;
using Telephony.Interfaces;


namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] webSites = Console.ReadLine().Split();
            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();


            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(number));
                    }

                    else if (number.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(number));
                    }

                    else
                    {
                        Console.WriteLine("Invalid number!");
                    }
                }
                catch (InvalidOperationException e)
                {

                    Console.WriteLine(e.Message);
                }


            }

            foreach (var site in webSites)
            {
                try
                {
                    Console.WriteLine(smartphone.BrowseSite(site));
                }
                catch (InvalidOperationException e)
                {

                    Console.WriteLine(e.Message);
                }

            }









        }
    }
}
