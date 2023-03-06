namespace ClosestVehiclePositionLocator
{
    public class Point
    {
        private double latitude;
        private double longitude;
        public Point(double longitude, double latitude)
        {
            this.longitude = longitude;
            this.latitude = latitude;
        }
        public int PositionId { get; set; }


        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }
    }
}
