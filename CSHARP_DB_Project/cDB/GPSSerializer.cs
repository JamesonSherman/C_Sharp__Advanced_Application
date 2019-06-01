using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FooCore;

namespace c__db_system
{
    class GPSSerializer
    {
        public byte[] Serialize (Location_DataModel location)
        {
            var LocationBytes = System.Text.Encoding.UTF8.GetBytes(location.location_Name);
            var LocationData = new byte[
                16 +                    //16 bytes for guid ID
                32 +                    //lat float 32 byte
                32 +                    //long float 32 byte
                LocationBytes.Length +  //n bytes for location string
                4
                ];

            //ID Block Copy
            Buffer.BlockCopy(
                src: location.ID.ToByteArray(),
                srcOffset: 0,
                dst: LocationData,
                dstOffset: 0,
                count: 16
                );

            //naming schema
            Buffer.BlockCopy(
                src: LittleEndianByteOrder.GetBytes((int)LocationBytes.Length),
                srcOffset: 0,
                dst: LocationData,
                dstOffset: 16,
                count:4
                );

            Buffer.BlockCopy(
                src: LocationBytes,
                srcOffset: 0,
                dst: LocationData,
                dstOffset: 16 + 4,
                count: LocationBytes.Length
                );

            //LAT
            Buffer.BlockCopy(
                src: LittleEndianByteOrder.GetBytes((int)location.unique_Longitude),
                srcOffset: 0,
                dst: LocationData,
                dstOffset: 16 + 32 + LocationBytes.Length + 32 +4,
                count: 4   
                );
            //LONG
            Buffer.BlockCopy(
                src: LittleEndianByteOrder.GetBytes((int)location.unique_Latitude),
                srcOffset:0,
                dst:LocationData,
                dstOffset: 16 + 32 + LocationBytes.Length + 32 + 4,
                count: 4
                );

            return LocationData;
        }



        public Location_DataModel Deseralizer (byte[] data)
        {
            var locationDM = new Location_DataModel();
            //Read id
            locationDM.ID = BufferHelper.ReadBufferGuid(data, 0);

            //read name
            var nameLength = BufferHelper.ReadBufferInt32(data, 16);
            if (nameLength < 0 || nameLength > (16 * 1024))
            {
                throw new Exception("Invalid string length: " + nameLength);
            }
            locationDM.location_Name = System.Text.Encoding.UTF8.GetString(data, 16 + 4 , nameLength);

            //Read Lat
            locationDM.unique_Latitude = BufferHelper.ReadBufferInt32(data, 16 + 4 + nameLength + 4);

            //Read long 
            locationDM.unique_Longitude = BufferHelper.ReadBufferInt32(data, 16 + 4 + nameLength + 4);


            return locationDM;
        }
    }
}
