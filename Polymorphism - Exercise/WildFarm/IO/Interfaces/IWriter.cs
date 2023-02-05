﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.IO.Interfaces
{
    public interface IWriter
    {
        void Write(object value);
        void WriteLine(object value);
    }
}
