﻿using _15._1._2MVVM实例2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._1._2MVVM实例2.Services
{
    interface IOrderService
    {
        void PlaceOrder(List<string> dishes);
    }
}
