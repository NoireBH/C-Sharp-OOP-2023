﻿using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, Interfaces.ILieutenantGeneral
    {   
        private readonly ICollection<IPrivate> privates;
        public LieutenantGeneral(int id, string firstName, string lastName,
            decimal salary, ICollection<IPrivate> privates)
            : base(id, firstName, lastName, salary )
        {
            this.privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates
            => (IReadOnlyCollection<IPrivate>) privates;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (IPrivate priv in privates)
            {
                sb.AppendLine($"  {priv.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
