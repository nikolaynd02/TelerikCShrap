using Agency.Models.Contracts;
using Agency.Models;
using System.Collections.Generic;
using System.Linq;

using Agency.Core.Contracts;
using Agency.Core;

namespace Agency.Tests.Helpers
{
    public class TestHelpers
    {
        public static List<string> GetListWithSize(int size)
        {
            return new string[size].ToList();
        }

        public static string GetStringWithSize(int size)
        {
            return new string('x', size);
        }

        public static IRepository GetTestRepository()
        {
            return new Repository();
        }

        public static IVehicle GetTestVehicle()
        {
            return new Bus(
                    id: 1,
                    passengerCapacity: BusData.ValidCapacity,
                    pricePerKilometer: BusData.ValidPricePerKilometerValue,
                    hasFreeTv: true);
        }

        public static IJourney GetTestJourney()
        {
            return new Journey(
                    id: 1,
                    from: new string('x', JourneyData.ValidStartLocationLength),
                    to: new string('x', JourneyData.ValidDestinationLength),
                    distance: JourneyData.ValidDistanceValue,
                    vehicle: GetTestVehicle());
        }
    }
}
