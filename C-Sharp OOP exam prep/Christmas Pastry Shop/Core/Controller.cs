using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            Booth booth = new Booth(boothId, capacity);
            booths.AddModel(booth);
            return $"Added booth number {booth.BoothId} with capacity {capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != nameof(Hibernation) && cocktailTypeName != nameof(MulledWine))
            {
                return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            else if (size != "Small" && size != "Middle" && size != "Large")
            {
                return String.Format(OutputMessages.InvalidCocktailSize, size);
            }

            else if (booths.Models.Any(b => b.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size)))
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded);
            }

            else
            {
                ICocktail cocktail = null;

                if (cocktailTypeName == nameof(Hibernation))
                {
                    cocktail = new Hibernation(cocktailName, size);
                }

                else if (cocktailTypeName == nameof(MulledWine))
                {
                    cocktail = new MulledWine(cocktailName, size);
                }

                IBooth boothToAddCocktail = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
                boothToAddCocktail.CocktailMenu.AddModel(cocktail);

                return String.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
            }
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            var booth = booths.Models.First(b => b.BoothId == boothId);

            if (delicacyTypeName != "Gingerbread" && delicacyTypeName != "Stolen")
            {
                return String.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            else if (booths.Models.Any(d => d.DelicacyMenu.Models.Any(d => d.Name == delicacyName)))
            {
                return String.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            else
            {
                IDelicacy delicacy = null;

                if (delicacyTypeName == nameof(Gingerbread))
                {
                    delicacy = new Gingerbread(delicacyName);
                }

                else if (delicacyTypeName == nameof(Stolen))
                {
                    delicacy = new Stolen(delicacyName);
                }

                IBooth boothToAddDelicacy = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
                boothToAddDelicacy.DelicacyMenu.AddModel(delicacy);

                return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
            }
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");

            booth.Charge();
            booth.ChangeStatus();

            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            var booth = booths.Models
                 .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                 .OrderBy(b => b.Capacity)
                 .ThenByDescending(b => b.BoothId)
                 .FirstOrDefault();

            if (booth == null)
            {
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            else
            {
                booth.ChangeStatus();
                return String.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId ,countOfPeople);
            }
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            string[] orderedItem = order.Split("/");
            string itemTypeName = orderedItem[0];
            string itemName = orderedItem[1];
            int count = int.Parse(orderedItem[2]);

            if (itemTypeName != nameof(MulledWine) &&
                itemTypeName != nameof(Hibernation) &&
                itemTypeName != nameof(Gingerbread) &&
                itemTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            else if ((!booth.CocktailMenu.Models.Any(m => m.Name == itemName) &&
                !booth.DelicacyMenu.Models.Any(m => m.Name == itemName)))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            bool isDelicacy = true;

            if (itemTypeName == nameof(Hibernation) || itemTypeName == nameof(MulledWine))
            {
                isDelicacy = false;
            }

            if (isDelicacy)
            {
                IDelicacy delicacy = booth.DelicacyMenu.Models
                    .FirstOrDefault(d => d.Name == itemName && d.GetType().Name == itemTypeName);

                if (delicacy == null)
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemName);
                }

                booth.UpdateCurrentBill(delicacy.Price * count);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
            }

            else
            {
                string size = orderedItem[3];

                ICocktail cocktail = booth.CocktailMenu.Models
                    .FirstOrDefault(d => d.Name == itemName && d.GetType().Name == itemTypeName && d.Size == size);

                if (cocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                booth.UpdateCurrentBill(cocktail.Price * count);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
            }
        }
    }
}
