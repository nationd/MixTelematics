using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosestVehiclePositionLocator.Extensions;
using System.Diagnostics;

namespace ClosestVehiclePositionLocator.Helpers
{
    public class FileProcessor
    {
        public static List<VehicleDetails> ProcessFile(string file)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException(file);
            }

            var vehicleDetails = new VehicleDetails();
            var vehicles = new List<VehicleDetails>();  
            var vehicleAndPositions = new Dictionary<int, VehicleDetails>();           

            using (FileStream fs = new (file, FileMode.Open))
            {
                using (BinaryReader br = new(fs))
                {
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    { 
                        vehicles.Add(new VehicleDetails 
                        {
                            PositionId = br.ReadInt32(),
                            VehicleRegistration = br.ReadNullTerminatedString(),
                            Position = new Position 
                            { 
                                Latitude = br.ReadSingle(),
                                Longitude = br.ReadSingle()
                            },
                            RecordedTimeUTC = br.ReadUInt64()
                        }  );

                    }
                }
            }

            return vehicles;
        }
    }
}
