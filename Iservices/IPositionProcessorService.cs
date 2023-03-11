using ClosestVehiclePositionLocator.Models;

namespace ClosestVehiclePositionLocator.Iservices
{
    public interface IPositionProcessorService
    {
        List<PositionAndClosestVehicle> GetVehiclePositions(VehicleDetails[] vehicles, Position[] positions);
    }
}
