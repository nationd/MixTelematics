using ClosestVehiclePositionLocator.Helpers;
using ClosestVehiclePositionLocator.Iservices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

            // Time taken to locate closest vehicles to given positions 0:01.179
            //Parallel.For(0, positions.Count, i =>
            //{
            //     // int index = FindNearestNeighbor(vehicles, positions[i].Longitude, positions[i].Longitude);

            //});


            //Time taken to locate closest vehicles to given positions 0:01.379
            Parallel.ForEach(positions, position =>
            {
                Console.WriteLine("Distance calculations per point started");
                var vehicleTime = new Stopwatch();
                vehicleTime.Start();

                var closest = vehicles.Min(x => DistanceCalculator.Distance(position.Latitude, position.Longitude,
                    x.Position.Latitude, x.Position.Longitude));

                vehicleTime.Stop();
                var timeTakenPerVehicle = vehicleTime.Elapsed;

                Console.WriteLine("Distance calculations per point ended " + timeTakenPerVehicle.ToString(@"m\:ss\.fff"));

                var vehicleDetails = vehicles.First(x => DistanceCalculator.Distance(position.Latitude, position.Longitude,
                    x.Position.Latitude, x.Position.Longitude) == closest);

                vehicleAndPositions.Add(position.PositionId, vehicleDetails);

            });
            return vehicleAndPositions;
        }


        //Tried this options, it is not effient as the initial one
        private int FindNearestNeighbor(List<VehicleDetails> vehicles, double latitude, double longitude)
        {
            double min_dist = double.MaxValue;
            int min_index = -1;
            Parallel.For(0, vehicles.Count, i =>
            {
                double dist = DistanceCalculator.Distance(vehicles[i].Position.Latitude, vehicles[i].Position.Longitude, latitude, longitude);
                if (dist < min_dist)
                {
                    min_dist = dist;
                    min_index = i;
                }
            });
            return min_index;
        }
    }
}
