using System;
using System.IO;
using System.Collections.Generic;
using FooCore;

public class Location_DataModel
{
    class GPSDataBase : IDisposable
    {
        readonly Stream mainDatabaseFile;
        readonly Stream primaryIndexFile;
        readonly Stream secondaryIndexFile;

        readonly Tree<Guid, uint> primaryIndex;
        readonly Tree<Tuple<string, int>, uint> secondaryIndex;
        readonly RecordStorage GPSRecords;
        readonly 
    }
}