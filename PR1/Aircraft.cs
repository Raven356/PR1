using System;
using System.Collections.Generic;
using System.Text;

namespace PR1
{
    class Aircraft
    {
        public int ID { get; set; }
        public string ModelName { get; set; }
        public decimal LoadCapacity { get; set; }
        public decimal MaxDistance { get; set; }
        public string CompanyCipher { get; set; }

        public override string ToString()
        {
            NormalizeText normalizeText = new NormalizeText();
            return $"ID: {ID}, Model name: {normalizeText.NormalizeAircraftInfo(ModelName)}, LoadCapacity: {LoadCapacity}, MaxDistance: {MaxDistance}, CompanyCipher: {normalizeText.NormalizeAircraftInfo(CompanyCipher)}, ";
        }

    }
}
