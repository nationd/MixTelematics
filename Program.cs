// See https://aka.ms/new-console-template for more information
using ClosestVehiclePositionLocator;
using ClosestVehiclePositionLocator.Helpers;
using ClosestVehiclePositionLocator.Iservices;
using ClosestVehiclePositionLocator.Services;
using System.Diagnostics;



GivenPositions givenPositions = new GivenPositions();
List<VehicleDetails> vehicleDetails = new List<VehicleDetails>();

Console.WriteLine("Processing file started");
var timer = new Stopwatch();
timer.Start();

var vehicles = FileProcessor.ProcessFile(@"..\..\..\DataFile\VehiclePositions.dat");
timer.Stop();
TimeSpan timeTaken = timer.Elapsed;
Console.WriteLine("Processing file ended");
Console.WriteLine("Time taken to Process a file " + timeTaken.ToString(@"m\:ss\.fff"));

IPositionProcessorService positionProcessorService = new PositionProcessorService();

Console.WriteLine("Locating closest vehicles started");
timer.Reset();
timer.Start();
var processedPositions = positionProcessorService.GetVehiclePositions(vehicles, givenPositions.positions);
timer.Stop();
timeTaken = timer.Elapsed;

Console.WriteLine("Locating closest vehicles ended");
Console.WriteLine("Time taken to locate closest vehicles to given positions " + timeTaken.ToString(@"m\:ss\.fff"));

Console.WriteLine();
Console.WriteLine("Positions and Respective closest Vehicle Details");
Console.WriteLine();

processedPositions.ForEach(p =>
{
    Console.WriteLine($"Position Details, Latitude: {p.Position.Latitude} Longitude: {p.Position.Longitude}");
    Console.WriteLine($"Vehicle Details,Latitude: {p.Vehicle.Latitude} Longitude: {p.Vehicle.Longitude}, Registration {p.Vehicle.VehicleRegistration}");
    Console.WriteLine();

});