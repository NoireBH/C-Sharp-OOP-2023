﻿using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {   
        private List<IHero> heroes;

        public HeroRepository()
        {
            heroes = new List<IHero>(); 
        }

        public IReadOnlyCollection<IHero> Models => heroes;

        public void Add(IHero model)
        {
            heroes.Add(model);
        }

        public IHero FindByName(string name)
        {
            return heroes.FirstOrDefault(h => h.Name == name);
        }

        public bool Remove(IHero model)
        {
            if (heroes.Any(h => h == model))
            {
                heroes.Remove(model);
                return true;
            }

            return false;
        }
    }
}
