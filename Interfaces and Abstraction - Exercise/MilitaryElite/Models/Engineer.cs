using MilitaryElite.Enums;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly ICollection<IRepair> repairs;
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IRepair> repairs) : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs
            =>  (IReadOnlyCollection<IRepair>)repairs;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine("Repairs:");

            foreach (IRepair repair in Repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().TrimEnd();   
        }
    }
}
