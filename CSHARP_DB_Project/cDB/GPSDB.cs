using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using FooCore;


namespace c__db_system
{
        class GPSDataBase : IDisposable
        {
            readonly Stream mainDatabaseFile;
            readonly Stream primaryIndexFile;
            readonly Stream secondaryIndexFile;

            readonly Tree<Guid, uint> primaryIndex;
            readonly Tree<Tuple<string, int>, uint> secondaryIndex;
            readonly RecordStorage GPSRecords;
            readonly GPSSerializer gPSSerializer = new GPSSerializer();

            public GPSDataBase (string pathtoDB)
            {
                if(pathtoDB == null)
                {
                throw new ArgumentNullException("path to DB null");
                }

                this.mainDatabaseFile = new FileStream(pathtoDB, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 4096);
                this.primaryIndexFile = new FileStream(pathtoDB + ".pidx", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 4096);
                this.secondaryIndexFile = new FileStream(pathtoDB + ".sidx", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 4096);

                this.GPSRecords = new RecordStorage(new BlockStorage(this.mainDatabaseFile, 4096, 48));

                this.primaryIndex = new Tree<Guid, uint>(
                    new TreeDiskNodeManager<Guid, uint>(
                        new GuidSerializer(),
                        new TreeUIntSerializer(),
                        new RecordStorage(new BlockStorage(this.primaryIndexFile, 4096))

                    ),
                    false
                );

                 this.secondaryIndex = new Tree<Tuple<string, int>, uint>(
                     new TreeDiskNodeManager<Tuple<string, int>, uint>(
                         new StringIntSerializer(),
                         new TreeUIntSerializer(),
                         new RecordStorage(new BlockStorage(this.secondaryIndexFile, 4096))
                    ),
                    true
                );
            }

            public void Update (Location_DataModel location_DataModel)
            {
                 if (disposed)
                 {
                    throw new ObjectDisposedException("GPS DB");
                    
                 }
            }

            public void Insert (Location_DataModel location_DataModel)
            {
                if(disposed)
                {
                throw new ObjectDisposedException("GPSDB");
                }

            //serialize the location datamodel point and insert it
                var recordId = this.GPSRecords.Create(this.gPSSerializer.Serialize(location_DataModel));
                this.primaryIndex.Insert(location_DataModel.ID, recordId);
                this.secondaryIndex.Insert(new Tuple<string, int>(location_DataModel.location_Name, location_DataModel.GPSPoint), recordId);
            }
                

            public Location_DataModel Find (Guid id)
             {
                if(disposed)
                {
                    throw new ObjectDisposedException("GPS DB");
                }

            //Look in the primary index for this point
                 var entry = this.primaryIndex.Get(id);
                  if(entry == null)
                    {
                        return null;
                    }
                return this.gPSSerializer.Deseralizer(this.GPSRecords.Find(entry.Item2));
             }


        public IEnumerable<Location_DataModel> FindBy(string location_Name, int GPSPoint)
        {
            var comparer = Comparer<Tuple<string, int>>.Default;
            var searchkey = new Tuple<string, int>(location_Name, GPSPoint);
                foreach(var entry in this.secondaryIndex.LargerThanOrEqualTo(searchkey))
            {
                if (comparer.Compare(entry.Item1,searchkey) > 0)
                {
                    break;
                }

                yield return this.gPSSerializer.Deseralizer(this.GPSRecords.Find (entry.Item2));
            }
        }

            public void Delete (Location_DataModel location_DataModel)
            {
                throw new NotImplementedException();
            }


            #region Dispose
            public void Dispose ()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            bool disposed = false;

            protected virtual void Dispose(bool disposing)
             {
                if (disposing && !disposed)
                {
                this.mainDatabaseFile.Dispose();
                this.secondaryIndexFile.Dispose();
                this.primaryIndexFile.Dispose();
                this.disposed = true;
                 }
              }

            ~GPSDataBase()
            {
            Dispose(false);
            }
            #endregion
    }
}