using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace c__db_system
{
    //number of bytes of custom data per block that this storage can handle.
    public interface IBlockStorage
    {
       int blockContentSize
       {
        get;
       } 

       int blockHeaderSize
       {
           get;
       }

       int blockSize
       {
           get;
       }

       //Find Block by its id
       IBlock Find (uint blockID);

       //allocates a new block and extends length of underlying storage
       IBlock CreateNew ();
    }

    public interface IBlock : IDisposable
    {
        uint Id
        {
            get;
        }

        //A block may contain one or more header metadata
        long GetHeader (int field);

        void setHeader (int field, long value);

        void Read(byte dst, int dstOffset, int srcOffset, int count);

        void Write (byte[] src, int srcOffset, int dstOffset, int count);
    }
    
}