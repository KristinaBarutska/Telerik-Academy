﻿using System;

namespace TradeAndTravel
{
    internal class Merchant : Shopkeeper, ITraveller
    {
        public Merchant(string name, Location location)
            : base(name, location)
        {
        }

        public void TravelTo(Location location)
        {
            this.Location = location;
        }
    }
}