using ClosestVehiclePositionLocator.Helpers;
using ClosestVehiclePositionLocator.Iservices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestVehiclePositionLocator.Services
{
    public class PositionProcessorService : IPositionProcessorService
    {
        public PositionProcessorService() { }

        public Dictionary<int, VehicleDetails> GetVehiclePositions(List<VehicleDetails> vehicles, List<Position> positions)
        {
            var vehicleAndPositions = new Dictionary<int, VehicleDetails>();

            Parallel.ForEach(positions, position =>
            {
                Console.WriteLine("Distance calculations started");
                var timer = new Stopwatch();
                timer.Start();

                var closest = vehicles.Min(x => DistanceCalculator.Distance(position.Latitude, position.Longitude,
                    x.Position.Latitude, x.Position.Longitude));

                timer.Stop();
               var timeTaken = timer.Elapsed;

                Console.WriteLine("Distance calculations ended " + timeTaken.ToString(@"m\:ss\.fff"));
               // var closest = vehicles.Aggregate((result, item) => result.Position.Latitude);

                var vehicleDetails = vehicles.First(x => DistanceCalculator.Distance(position.Latitude, position.Longitude,
                    x.Position.Latitude, x.Position.Longitude) == closest);

                vehicleAndPositions.Add(position.PositionId, vehicleDetails);

            });
            return vehicleAndPositions;
        }
    }
}
