using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight = 0;
        public int BedCapacity => bedCapacity;

        protected Room(int bedCapactity)
        {
            bedCapacity = bedCapactity;
            
        }

        public double PricePerNight
        {
            get { return pricePerNight; }

           private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PricePerNightNegative));
                }

                pricePerNight = value; 
            }
        }


        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}
