So this project is a implementation of an alternative SQLite block storage system. SQLite has issues regarding ineffiency, file size bloating
as well as myriads of problemsin regards to data expiration values not existing. This can cause what is supposed to be a mini
implementation of SQL to be quite bloated and hard to traverse

this side project is a nifty implementation of an alternate DB using block copy! We use FOOCORE for the necessity of having
block implementaitno as well as B-TREE search capabilites.

the main outer layer of files use FOOCORE in an attempt to serialize and deserialize data to be used in a useful context in regads to block
storage. we serialize byte arrays of specifc class values into a organized stucture, store them, then when we need to see and or manipulate
we can deserialize the data and pull out that specific byte block of data. commenting is abound in outer layering but I couldnt
be bothered to handle implentation of FOOCORE commenting.


check problems with SQLite here:
https://wiki.mozilla.org/Performance/Avoid_SQLite_In_Your_Next_Firefox_Feature

check the system walk along here:
https://www.codeproject.com/Articles/1029838/Build-Your-Own-Database
