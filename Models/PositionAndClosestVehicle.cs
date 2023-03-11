using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestVehiclePositionLocator.Models
{
    public class PositionAndClosestVehicle
    {
        public Position Position { get; set; }
        public VehicleDetails Vehicle { get; set; }
    }
}
