namespace ClosestVehiclePositionLocator.Iservices
{
    public interface IPositionProcessorService
    {
        Dictionary<int, VehicleDetails> GetVehiclePositions(List<VehicleDetails> vehicles, List<Position> positions);
    }
}
