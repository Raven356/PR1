using System;

namespace PR1
{
    class AirCompany
    {
        public int ID { get; set; }
        public string Label { get; set; }
        public Location OfficeLocation { get; set; }
        public DateTime CreationDate { get; set; }
        public string CompanyCipher { get; set; }

        public override string ToString()
        {
            NormalizeText normalizeText = new NormalizeText();
            return $"ID: {ID}, Label: {normalizeText.NormalizeAirCompaniesInfo(Label)}, Office Location: {normalizeText.NormalizeAirCompaniesInfo(OfficeLocation.ToString())}, CreationDate: {CreationDate}, CompanyCipher: {normalizeText.NormalizeAircraftInfo(CompanyCipher)}";
        }

    }
}
