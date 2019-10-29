IMPLEMENT SERIALIZATION AND FUNCTIONALITY OF ABSTRACT DATA TYPES OF A SQLITE DATABASE ALTERNATIVE
Context: First post graduate local code weekend project

So this project is a implementation of an alternative SQLite block storage system. SQLite has issues regarding ineffiency, file size bloating
as well as problems in regards to data expiration values not existing. This can cause what is supposed to be a mini
implementation of SQL to be quite bloated and hard to traverse.

This side project is a nifty implementation of an alternate DB using block copy architechture! We use FOOCORE for the necessity of having
block storage as well as B-TREE search capabilites.

the main outer layer of files use FOOCORE in an attempt to serialize and deserialize data to be used in a useful context in regards to storable byte blocks. we serialize byte arrays into a organized stucture, store them, then when we need to see and or manipulate,
we can deserialize the data and pull out that specific byte block of data. Commenting is abound in upper layering as this was my part of the implementation. Lower levels of foocore are not commented as they mainly focus on B-Tree traversal and file storage of the specific byte blocks.


check problems with SQLite here:
https://wiki.mozilla.org/Performance/Avoid_SQLite_In_Your_Next_Firefox_Feature
