﻿using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;
        private double currentBill;
        public double turnover;
        public bool isReserved;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
        }

        public int BoothId { get; private set; }

        public int Capacity
        {
            get { return capacity; }
           private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CapacityLessThanOne));
                }

                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu { get; private set; }

        public IRepository<ICocktail> CocktailMenu { get; private set; }

        public double CurrentBill { get; private set; }

        public double Turnover { get; private set; }

        public bool IsReserved { get; private set; } = false;

        public void ChangeStatus()
        {
            IsReserved = !IsReserved;
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:f2} lv");
            sb.AppendLine("-Cocktail menu:");

            foreach (var cocktail in CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail.ToString()}");
            }

            sb.AppendLine("-Delicacy menu:");

            foreach (var delicacy in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
