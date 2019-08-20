using System;
using System.Collections.Generic;
using System.Text;
/*
 * good hash code distribution is the requirement for good performant hash algorithms
 * number of keys in each chain is valued at N/M
 * where n is number of keys and M is total number of chain
 * 
 * search and inserting works at N/M. if we keep memory large enough then M can
 * equal to constant
 *  
 *  works in poly time computation not necessarily 1
 *  
 *  Collisions are very likely even if we have big table to store keys.
 *  An important observation is Birthday Paradox. 
 *  With only 23 persons, the probability that two people have the same birthday is 50%.
 * */
namespace hashing
{
    class Seperate_Chaining
    {
        public class ChainHashSet<Tkey, TValue>
        {

            //implement our symbol table sequential search generic variable
            //also implement default cap and count and cap
            private SymbolTable_Implementation.SequentialSearchSt<Tkey, TValue>[] _chains;
            private const int DefaultCapacity = 10;
            public int Count { get; private set; }
            public int Capacity { get; private set; }


            //constructor for our generic in the implementation
            public ChainHashSet(int capacity)
            {
                Capacity = capacity;//set our cap to our declared cap
                //set chains size to the capacity
                _chains = new SymbolTable_Implementation.SequentialSearchSt<Tkey, TValue>[Capacity];

                for (int i =0; i < capacity; i++)
                {
                    //setsa value equal to cap - 1 full of our generics
                    _chains[i] = new SymbolTable_Implementation.SequentialSearchSt<Tkey, TValue>();
                }
            }
            private int Hash(Tkey key)
            {
                //giant decimal number that refers to value 2147483647
                //logical and operator bit masks the value 
                //binary spit out; 1111111111111111111111111111111

                //afterwards we apply modular hashing by modulo of capacity
                return (key.GetHashCode() & 0x7fffffff) % Capacity;
            }

            public TValue Get(Tkey key)
            {
                //guard for key if null
                if (key == null)
                    throw new ArgumentNullException(paramName: "key is not allow to be null");

                //we grab our keys bitmasked hash code
                int index = Hash(key);
                //for the given index we try our keys and output the value
                
                if(_chains[index].TryGet(key, out TValue val))
                {
                    return val;
                }
                //else if our key wasnt found we say so
                throw new ArgumentException(message: "Key was not found");
            }

            public bool contains(Tkey key)
            {
                //safeguard
                if (key == null)
                    throw new ArgumentNullException(paramName: "key is not allow to be null");
                //set our index equal to bitmasked key hash
                int index = Hash(key);
                //we spoof the return because we dont need the value just the return of boolean val
                return _chains[index].TryGet(key, out TValue _);
            }

            public bool Remove(Tkey key)
            {
                //safeguard
                if (key == null)
                    throw new ArgumentNullException(paramName: "key is not allow to be null");

                int index = Hash(key);
                //we check if our chains generic table has the key
                if (_chains[index].Contains(key))
                {
                    //if so we just remove the big boy via symbol table remove (see symbol table entry)
                    Count--;
                    _chains[index].Remove(key);
                    return true;
                }
                //else we cant remove returns false
                return false;
            }

            public void Add(Tkey key, TValue val)
            { 
                //safeguard
                if (key == null)
                    throw new ArgumentNullException(paramName: "key is not allow to be null");
                //if our value was null we just remove the key and return. cant add somethign that doesnt exist
                if (val == null)
                {
                    Remove(key);
                    return;
                }
                //if our count is greater or equal to ten * capacity
                //we resize 2 * the cap. this makes room for more storage
                if (Count >= 10 * Capacity) Resize(2 * Capacity);

                int i = Hash(key);
                if(! _chains[i].Contains(key)) //check if contains so we account for the duplicate in the chain
                {
                    Count++;
                }
                _chains[i].Add(key, val); //we add from our symbol table library
            }

            //the fun one
            private void Resize (int chains)
            {
                //we take and set temp equal to a new chainset of our original chains
                var temp = new ChainHashSet<Tkey, TValue>(chains);
                //from here we iterate. for each key in chains this is valued in the current spec at 2 * cap
                //we then check what keys are where and if there are actually keys there. if so we add it!
                for(int i = 0; i < Capacity; i++)
                {
                    foreach( Tkey key in _chains[i].Keys())
                    {
                        if(_chains[i].TryGet(key, out TValue val))
                        {
                            temp.Add(key, val);
                        }
                    }
                }
                //afterwards we update count capacity and chains to the new values
                Capacity = temp.Capacity;
                Count = temp.Count;
                _chains = temp._chains;
            }

            //simple enumerable to specify the amount of keys we have. stored in a linked list queue for *flair*
            public IEnumerable<Tkey> Keys()
            {
                var queue = new Queues.LinkedQueue<Tkey>();
                for(int i = 0; i < Capacity; i++)
                {
                    foreach(Tkey key in _chains[i].Keys())
                    {
                        queue.Enqueue(key);
                    }
                }
                return queue;
            }
        }
    }
}
