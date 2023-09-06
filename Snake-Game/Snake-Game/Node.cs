﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(int value) => Value = value;
    }
}
