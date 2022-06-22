using System;
using System.Collections.Generic;
using System.Text;

namespace PR1
{
    class HelicoptersWithPlanes
    {
        public Plane Plane { get; set; }
        public Helicopter Helicopter { get; set; }

        public override string ToString()
        {
            return $"Plane = {Plane}\n Helicopter = {Helicopter}";
        }
    }
}
