﻿using System.Collections.Generic;
using CarDetails.Models;

namespace CarDetails.GlobalVariables
{
    public static class GlobalVariables
    {
        public static List<Car> Cars { get; set; }
            = new List<Car>();
    }
}