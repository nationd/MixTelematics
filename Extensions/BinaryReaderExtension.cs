using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestVehiclePositionLocator.Extensions
{
    public static class BinaryReaderExtension
    {
        /// <summary>
        /// Reads a C style null terminated ASCII string
        /// </summary>
        /// <param name="reader">The binary reader</param>
        /// <returns>A string as read from the stream</returns>
        public static string ReadNullTerminatedString(this BinaryReader reader)
        {
            var result = new StringBuilder();
            while (true)
            {
                byte b = reader.ReadByte();
                if (0 == b)
                    break;
                result.Append((char)b);
            }
            return result.ToString();
        }
    }
}
