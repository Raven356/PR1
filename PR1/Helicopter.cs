﻿
namespace PR1
{
    class Helicopter : Aircraft
    {
        public decimal MaxHeight { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"MaxHeight: {MaxHeight}";
        }
    }
}
