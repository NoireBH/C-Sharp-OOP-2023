﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Models.Interfaces
{
    public interface IHero
    {
        IWeapon Weapon { get; }
        int Xp { get; }

        void SwingAxe(Itarget target);
    }
}
