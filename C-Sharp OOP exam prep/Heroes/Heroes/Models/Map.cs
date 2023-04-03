using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = players.Where(x => x.GetType().Name == nameof(Knight)).ToList();
            List<IHero> barbarians = players.Where(x => x.GetType().Name == nameof(Barbarian)).ToList();
            bool barbariansWin = false;

            while (knights.All(x => x.IsAlive == true) && (barbarians.All(x => x.IsAlive == true)))
            {
                foreach (var knight in knights)
                {
                    foreach (var barbarian in barbarians)
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }

                if (knights.All(x => x.IsAlive == false))
                {
                    barbariansWin = true;
                    break;
                }

                else if (barbarians.All(x => x.IsAlive == false))
                {
                    break;
                }

                foreach (var barbarian in barbarians)
                {
                    foreach (var knight in knights)
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }
                }

            }

            if (barbariansWin)
            {
                return string.Format(OutputMessages.MapFigthBarbariansWin, knights.Count);
            }

            else
            {
                return string.Format(OutputMessages.MapFightKnightsWin, barbarians.Count);
            }

        }
    }
}
