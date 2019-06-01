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

            //the locaitonbytes is a utf8 byte string that allows us to get the byte value for the next byte array. 
            //since this is block storage we store each value as a unique identifier in or storage medium in a byte aray. this allows us to decipher the byte array easily
            //we can all serialize and deserialize the array using inhouse c# methods and a few librarys
            var LocationBytes = System.Text.Encoding.UTF8.GetBytes(location.location_Name);

            //location data is a byte array system that allows us to store unique identifer bytes in an array. these act as both a buffer and a reading system
            var LocationData = new byte[
                16 +                    //16 bytes for guid ID
                4 +                     //gps point
                LocationBytes.Length +  //n bytes for location string
                4 +
                4
                ];


            //all the block copy functions here allow us to create byte buffers to do block copying to our block DB. it serialzes them and stores into memory for later use as
            //loaded pointed to cells of data. we also cant repeat copy of GUIDs as to prevent harder search and sorting
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

            //point
            Buffer.BlockCopy(
                src: LittleEndianByteOrder.GetBytes((int)location.GPSPoint),
                srcOffset: 0,
                dst: LocationData,
                dstOffset: 16 + 4 + LocationBytes.Length +4,
                count: 4   
                );
            return LocationData;
        }


        //deseralizer allows us to deseralize out data back to a readable format for humans eyes..
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

            locationDM.GPSPoint = BufferHelper.ReadBufferInt32(data, 16 + 4 + nameLength + 4);

            return locationDM;
        }
    }
}
