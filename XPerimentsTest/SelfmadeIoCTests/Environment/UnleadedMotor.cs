﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPerimentsTest.SelfmadeIoCTests.Environment
{
    public class UnleadedMotor : IMotor
    {

        public string Smell()
        {
            return "smells normal";
        }
    }
}