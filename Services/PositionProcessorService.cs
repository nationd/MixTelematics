using ClosestVehiclePositionLocator.Iservices;
using ClosestVehiclePositionLocator.Models;
using KdTree.Math;
using System.Diagnostics;


namespace ClosestVehiclePositionLocator.Services
{
    public class PositionProcessorService : IPositionProcessorService
    {
        public List<PositionAndClosestVehicle> GetVehiclePositions(VehicleDetails[] vehicles, Position[] positions)
        {
            var vehicleAndPositions = new List<PositionAndClosestVehicle>();
            Console.WriteLine("\n storing vehicles started");
            var vehicleTime = new Stopwatch();
            vehicleTime.Start();
            var vehiclesTree = StoreVehicles(vehicles);
            vehicleTime.Stop();
            var timeTakenPerVehicle = vehicleTime.Elapsed;

            Console.WriteLine("time taken to store vehicles " + timeTakenPerVehicle.ToString(@"m\:ss\.fff"));

            Console.WriteLine(" \n Closest vehicle retrieval starting");
            vehicleTime.Reset();

            vehicleTime.Start();
            Parallel.For(0, positions.Length, i =>
            {
                var closest = vehiclesTree.GetNearestNeighbours(new[] { positions[i].Latitude, positions[i].Longitude }, 1).FirstOrDefault();

                if (null != closest)
                {
                    vehicleAndPositions.Add(new PositionAndClosestVehicle { Position = positions[i], Vehicle = closest.Value });
                }

            });
            vehicleTime.Stop();
            timeTakenPerVehicle = vehicleTime.Elapsed;
            Console.WriteLine("Retrieval of closest vehicles ended " + timeTakenPerVehicle.ToString(@"m\:ss\.fff"));

            return vehicleAndPositions;
        }

        //Store vehicles in kd-tree
        public KdTree.KdTree<float, VehicleDetails> StoreVehicles(VehicleDetails[] vehicles)
        {
            var vehiclesTree = new KdTree.KdTree<float, VehicleDetails>(2, new FloatMath());

            Parallel.For(0, vehicles.Length, (i) =>
            {
                var item = vehicles[i];
                vehiclesTree.Add(item.Key, item);
            });

            return vehiclesTree;
        }
    }
}
