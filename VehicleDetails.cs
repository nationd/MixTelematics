namespace ClosestVehiclePositionLocator
{
    public class VehicleDetails
    {
        public int PositionId { get; set; }
        public string? VehicleRegistration { get; set; }
        public Position Position { get; set; }
        public UInt64 RecordedTimeUTC { get; set; }
        public double Distance { get; set; }
    }
}
