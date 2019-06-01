using System;
using System.Collections.Generic;
using System.Text;
using FooCore;

namespace c__db_system
{
    class GuidSerializer: ISerializer<Guid>
    {
        //the guidSerializer class is just a more verbose serialization method specifically for the 92ea75d6-f102-40d7-9fac-4b0446d929b9 style values.
        //due to the 16 bit complexity of these numbers we need to make sure we have a fixed size, length, and correct buffers and offsets.
        public byte[] Serialize (Guid value)
        {
            return value.ToByteArray();
        }

        public Guid Deserialize(byte[] buffer, int offset, int length)
        {
            if(length != 16)
            {
                throw new ArgumentException("length");
            }
            return BufferHelper.ReadBufferGuid(buffer, offset);
        }

        public bool IsFixedSize
        {
            get
            {
                return true;
            }
        }

        public int Length
        {
            get
            {
                return 16;
            }
        }
    }
}
