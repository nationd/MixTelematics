namespace ClosestVehiclePositionLocator
{
    public class VehicleDetails
    {
        public int PositionId { get; set; }
        public string? VehicleRegistration { get; set; }
        //public Position Position { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public UInt64 RecordedTimeUTC { get; set; }
        public float[] Key
        {
            get
            {
                return new[] { Latitude, Longitude };
            }
        }
    }
}
