﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_simulator
{
    public class InvalidPinException : Exception
    {
        public InvalidPinException(string message) : base(message)
        {
        }
    }
}
