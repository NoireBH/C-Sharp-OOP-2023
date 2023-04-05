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
                foreach (var knight in knights.Where(x => x.IsAlive && x.Weapon != null))
                {
                    foreach (var barbarian in barbarians.Where(x => x.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }

                foreach (var barbarian in barbarians.Where(x => x.IsAlive && x.Weapon != null))
                {
                    foreach (var knight in knights.Where(x => x.IsAlive))
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }
                }

            }

            if (knights.All(x => x.IsAlive == false))
            {
                barbariansWin = true;
                
            }

            if (barbariansWin)
            {
                return string.Format(OutputMessages.MapFigthBarbariansWin, barbarians.Where(x => !x.IsAlive).Count());
            }

            else
            {
                return string.Format(OutputMessages.MapFightKnightsWin, knights.Where(x => !x.IsAlive).Count());
            }

        }
    }
}
