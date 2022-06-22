using System;
using System.Collections.Generic;
using System.Linq;

namespace PR1
{
    class Queries
    {
        readonly NormalizeText _normalizeText = new NormalizeText();
        public IEnumerable<Plane> SelectAllPlanes(List<Plane> planes)
        {
            return planes.Select(x => x);
        }

        public IEnumerable<AirCompany> CompaniesFromUkraine(List<AirCompany> airCompanies)
        {
            
            var companiesFromUkraine = airCompanies.Where(x => _normalizeText.NormalizeAirCompaniesInfo( x.OfficeLocation.Country).Equals("Ukraine"));
            return companiesFromUkraine;
        }

        public IEnumerable<Helicopter> HelicoptersByDescending(List<Helicopter> helicopters)
        {
            
            var helicoptersByDescending = from x in helicopters
                                          orderby _normalizeText.NormalizeAircraftInfo(x.ModelName) descending
                                          select x;
            return helicoptersByDescending;
        }

        public IEnumerable<Plane> SelectParticularPlane(List<Plane> planes, string plane)
        {
            
            var particularPlane = planes.Where((x) => { return x.ToString().Equals(plane); });
            return particularPlane;
        }

        public Dictionary<string, List<HelicoptersWithPlanes>> SelectHeliesAndPlanesWithSameCompanyCipher(List<Helicopter> helicopters, List<Plane> planes)
        {

            var heliesAndPlanesWithSameCompanyCipher = from x in helicopters
                                          join y in planes 
                                            on _normalizeText.NormalizeAircraftInfo( x.CompanyCipher)
                                            equals _normalizeText.NormalizeAircraftInfo(y.CompanyCipher)
                                          group new HelicoptersWithPlanes { Plane = y, Helicopter = x } 
                                            by _normalizeText.NormalizeAircraftInfo(x.CompanyCipher) 
                                            into grouped
                                          select grouped;
                                          
            return heliesAndPlanesWithSameCompanyCipher.ToDictionary(x=> x.Key, x=> x.ToList());
        }


        public IEnumerable<AirCompany> SelectCompaniesWhichStartsFromLetter(List<AirCompany> airCompanies, char letter)
        {
            
            var companiesWhichStartWhithLetter = airCompanies.Where(x => _normalizeText.NormalizeAirCompaniesInfo(x.Label).StartsWith(letter));
            return companiesWhichStartWhithLetter;
        }

        public IEnumerable<Plane> SkipWhilePlaneMaxDistanceLower(List<Plane> planes, decimal lower)
        {
            
            return planes.SkipWhile(x => x.MaxDistance < lower);
        }

        public IEnumerable<Helicopter> TakeWhileLoadCapacityLower(List<Helicopter> helicopters, decimal loadCapacity)
        {
            
            return helicopters.TakeWhile(x => x.LoadCapacity < loadCapacity);
        }

        public Dictionary<string, List<Helicopter>> GroupHeliesByCompanyCipher(List<Helicopter> helicopters)
        {
            
            var groupHelicoptersByCipher = from x in helicopters
                                           group x by _normalizeText.NormalizeAircraftInfo(x.CompanyCipher) into q
                                           select q;
            return groupHelicoptersByCipher.ToDictionary(x => x.Key, x => x.ToList());
        }

        public Dictionary<string, List<Plane>> GroupPlanesByFlights(List <FligtsToPlanes> fligtsToPlanes, List<Flight> flights, List<Plane> planes)
        {
            var groupPlanesByFlights = from x in planes
                         join y in fligtsToPlanes on x.ID equals y.IDPlane
                         join z in flights on y.IDFlight equals z.ID
                         group x by z.ToString() into groupedPlanesByFlights
                         select groupedPlanesByFlights;
            return groupPlanesByFlights.ToDictionary(x=> x.Key, x=> x.ToList());
        }

        public decimal SelectAverageMaxDistanceFromAllAircrafts(List<Plane> planes, List<Helicopter> helicopters)
        {
            
            var averageMaxDistance = planes.Select(p => p.MaxDistance).Concat(helicopters.Select(h => h.MaxDistance));
            return averageMaxDistance.Average();
        }

        public IEnumerable<AirCompany> SelectAirCompaniesWithParticularCondidtion(List<Plane> planes, List<Helicopter> helicopters, List<AirCompany> airCompanies, decimal maxDistance, decimal maxHeight)
        {
           
            var airCompaniesWithParticularCondition = from q in airCompanies 
                                                   join y in planes on _normalizeText.NormalizeAircraftInfo(q.CompanyCipher) equals _normalizeText.NormalizeAircraftInfo(y.CompanyCipher)
                                                   join z in helicopters on _normalizeText.NormalizeAircraftInfo(q.CompanyCipher) equals _normalizeText.NormalizeAircraftInfo(z.CompanyCipher)
                                                   where y.MaxDistance > maxDistance && z.MaxHeight > maxHeight
                                                   orderby _normalizeText.NormalizeAircraftInfo(q.CompanyCipher) descending
                                                   select q;
            return airCompaniesWithParticularCondition;
        }

        public IEnumerable<string> SelectAllAircraftTypes(List<Plane> planes, List<Helicopter> helicopters)
        {
            
            var allAircraftTypes = planes
                .Select(p => _normalizeText.NormalizeAircraftInfo(p.ModelName))
                .Concat(helicopters
                    .Select(x => _normalizeText.NormalizeAircraftInfo(x.ModelName)));
            return allAircraftTypes;
        }


        public decimal SelectMaxHeightOfHelicopters(List<Helicopter> helicopters)
        {
           
            return helicopters.Max(p => p.MaxHeight);
        }

        public IEnumerable<bool> CheckIfThereIsCompanyWithThisLabel(List<AirCompany> airCompanies)
        {
            
            bool isCompanyExists;
            List<string> labels = new List<string> { "Super Planes", "Planes", "asdaffs", "Speedy Wings", "Low Cost Airlines", "Simple Planes" };
            foreach (var x in labels)
            {
                isCompanyExists = airCompanies.Where(p => _normalizeText.NormalizeAirCompaniesInfo(p.OfficeLocation.Country) is "Ukraine").Select(p => _normalizeText.NormalizeAirCompaniesInfo(p.Label)).Contains(x);
                yield return isCompanyExists ;
            }
        }
    }
}
