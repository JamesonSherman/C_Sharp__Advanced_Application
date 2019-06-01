using System;
using System.Collections.Generic;
using System.Text;
using FooCore;

namespace c__db_system
{
    class StringIntSerializer : ISerializer<Tuple<string,int>>
    {
        //the string searializer is a special serialization function that allows for 
        //string up and down serialization and only for string related contexts of our values

            //we mimic the earilier byte value cerailzer and have a 8byte + n array
            //for storing string values.


        public byte[] Serialize (Tuple<string,int> value)
        {
            var stringBytes = System.Text.Encoding.UTF8.GetBytes(value.Item1);
            var data = new byte[
                4 +
                stringBytes.Length +
                4
                ];

            //we create some nice buffers and block copy over the string with offsets for storage
            BufferHelper.WriteBuffer((int)stringBytes.Length, data, 0);
            Buffer.BlockCopy(src: stringBytes, srcOffset: 0, dst: data, dstOffset: 4, count: stringBytes.Length);
            BufferHelper.WriteBuffer((int)value.Item2, data, 4 + stringBytes.Length);
            return data;

        }


        //deserialize does the same thing but it brings our data back and allows us to use it
        public Tuple<string, int> Deserialize(byte[] buffer, int offset, int length)
        {
            var stringLength = BufferHelper.ReadBufferInt32(buffer, offset);
            if (stringLength < 0 || stringLength > (16 * 1024))
            {
                throw new Exception("Invalid string length: " + stringLength);
            }
            var stringValue = System.Text.Encoding.UTF8.GetString(buffer, offset + 4, stringLength);
            var integerValue = BufferHelper.ReadBufferInt32(buffer, offset + 4 + stringLength);
            return new Tuple<string, int>(stringValue, integerValue);
        }


        //we can also check string byte array size by invoking the fixed size check
        //because well its dynamic because of the 8 byte + n value
        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }


        //we also have a length property retruning byte size as n amount.
        public int Length
        {
            get
            {
                throw new InvalidOperationException();
            }
        }
    }
}
