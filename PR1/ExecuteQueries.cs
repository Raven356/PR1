using System;


namespace PR1
{
    class ExecuteQueries
    {

        public void Execute()
        {
            ConsoleColors consoleColors = new ConsoleColors();

            WriteOnScreen writeOnScreen = new WriteOnScreen();

            Queries queries = new Queries();

            Lists lists = new Lists();

            consoleColors.InitiateColors("1. Select all planes:");
            writeOnScreen.WriteAnswerOnScreen(queries.SelectAllPlanes(lists.Planes));

            consoleColors.InitiateColors("\n2. Select all companies from Ukraine:");
            writeOnScreen.WriteAnswerOnScreen(queries.CompaniesFromUkraine(lists.AirCompanies));

            consoleColors.InitiateColors("\n3. Sort helicopter's types by descending:");
            writeOnScreen.WriteAnswerOnScreen(queries.HelicoptersByDescending(lists.Helicopters));

            consoleColors.InitiateColors("\n4. Select object from planes:");
            writeOnScreen.WriteAnswerOnScreen(queries.SelectParticularPlane(lists.Planes, "ID: 3, Model name: Typolev49, LoadCapacity: 20000, MaxDistance: 10000, CompanyCipher: TY09547, WingSpan: 150, TakeofLenght: 10"));

            consoleColors.InitiateColors("\n5. Select helicopters and planes with same company cipher:");
            writeOnScreen.WriteAnswerOnScreen(queries.SelectHeliesAndPlanesWithSameCompanyCipher(lists.Helicopters, lists.Planes));

            consoleColors.InitiateColors($"\n6. Select all companies that label starts with 'S':");
            writeOnScreen.WriteAnswerOnScreen(queries.SelectCompaniesWhichStartsFromLetter(lists.AirCompanies, 'S'));

            consoleColors.InitiateColors($"\n7. Skip while planes max distance < 2000:");
            writeOnScreen.WriteAnswerOnScreen(queries.SkipWhilePlaneMaxDistanceLower(lists.Planes, 2000));

            consoleColors.InitiateColors($"\n8. Take while helicopter load capacity < 3000:");
            writeOnScreen.WriteAnswerOnScreen(queries.TakeWhileLoadCapacityLower(lists.Helicopters, 3000m));

            consoleColors.InitiateColors("\n9. Group helicopters by company cipher:");
            writeOnScreen.WriteAnswerOnScreen(queries.GroupHeliesByCompanyCipher(lists.Helicopters));

            consoleColors.InitiateColors("\n10. Group planes by flights:");
            writeOnScreen.WriteAnswerOnScreen(queries.GroupPlanesByFlights(lists.FligtsToPlanesConnections, lists.Flights, lists.Planes));

            consoleColors.InitiateColors($"\n11. Select air companies where planes max distance > 500 and helicopters max height > 1000, order by company cipher in descending order:");
            writeOnScreen.WriteAnswerOnScreen(queries.SelectAirCompaniesWithParticularCondidtion(lists.Planes, lists.Helicopters, lists.AirCompanies, 500m, 1000m));

            consoleColors.InitiateColors("\n12. Select all aircraft types:");
            writeOnScreen.WriteAnswerOnScreen(queries.SelectAllAircraftTypes(lists.Planes, lists.Helicopters));

            consoleColors.InitiateColors("\n13. Select average max distance from all aircrafts:");
            writeOnScreen.WriteAnswerOnScreen(queries.SelectAverageMaxDistanceFromAllAircrafts(lists.Planes, lists.Helicopters));

            consoleColors.InitiateColors("\n14. Select max height of helicopter:");
            writeOnScreen.WriteAnswerOnScreen(queries.SelectMaxHeightOfHelicopters(lists.Helicopters));

            consoleColors.InitiateColors($"\n15. Check if there is an air company from Ukraine with this label:");
            writeOnScreen.WriteAnswerOnScreen(queries.CheckIfThereIsCompanyWithThisLabel(lists.AirCompanies));
        }
    }
}
