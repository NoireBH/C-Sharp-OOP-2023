using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirthdayCelebrations
{
    public interface IBirthdate
    {
        public string BirthDate { get;}

        public void SearchForSameBirthday(string birthdayYear)
        {
            if (BirthDate.Split('/').Last() == birthdayYear)
            {
                Console.WriteLine(BirthDate);
            }
        }
    }
}
