using System;
using System.Collections.Generic;
using System.Text;
//symbol tables are needed for fast access , insertion and retrieval
//symbol tables allow us to add a value using keys and then retrieve the data by
//keys do not have to be intgers
//consists of key/value pairs adn data types. don't have to match

    //four ways of implementation
    //3 ways of which are competitive while one is  basic and trival

    //api support should follow:
    // a default constructor and a constructor which allows a client to pass
    //custom keys comparer

    //bool TryGet(Tkey key) - returns true if a value was found otherwise false

    //void add(Tkey, Tvalue val) - inserts a key-value pair into a table

    //bool remove(Tkey) - explicitly removes a key value pair

    //bool Contains(Tkey key) - checks if a certain key is presented ina  table

    //bool isEmpty() - count returns the number of key value pairs in a table

    //int Count() - count returns the number of key value pairs in a table

    //IEnumerable<TKey> keys() - returns all the keys from a table

    //there are sorted (ordered) and unsorted(unorded) symbol tables and they are
    //different


    //ordered table ops
    //tkey Min() - least key
    //tkey Max() - greatest key

    //void RemoveMin() - remove least key
    //void RemoveMax() - remove greatest key
    //Tkey Floor(Tkey key) -get the greatest key which is less or equals the requested key
    //Tkey Ceiling(Tkey key) - gets the least key  which is greater or equals the requested key
    //int rank(Tkey key) -counts the number of keys which are less than the requested key

    //Tkey Select(int k) - searches for a key with a specific rank.
    //So, the following expresssions will be true:
    //i == Rank(Select(i)) and key == Select(Rank(key))

    //int Range(Tkeya,Tkey B) - allows to quickly get the number of keys
    //between a and b -> [a..b]




namespace SymbolTable_Implementation
{
    //generic parameters Tkey and Tvalue
    //special placeholder data type that is defiend by client later
    public class symbolTable<Tkey, TValue>
    {
        private class Node
        {
            public Tkey Key { get; }
            public TValue Value { get; set; }
            public Node Next { get; set; }

            public Node(Tkey key, TValue value, Node next)
            {
                Key = key;
                Value = value;
                Next = next;
            }
        }
        //private first node.
        private Node _first;
        //can only read the comparer value part of Ienumerable Iequalitycomparer
        // with the readoly and equalitycompaerer setup it can use generics
        private readonly EqualityComparer<Tkey> _comparer;

        //sets size and count. get can be public access. set is private
        public int Count { get; private set; }

        //specifies default comparer
        public SequentialSearchSt()
        {
            _comparer = EqualityComparer<TKey>.Default;
        }
        //overload comparison
        public SequentialSearchSt(EqualityComparer<Tkey> comparer)
        {
            //null coalescing returns left if not null else return right 
            _comparer = comparer ?? throw new ArgumentNullException();
        }

        //out keyword is a reference type modifier
        //the difference in ref and out is that ref requires the value to be initialized
        //out throws out the kitchen sink and just references whatever uninitilaized
        // generic you attach to it.
        
            //side note its similar to in but in is selfish and doesnt let
            //you change the value only "READ" it. Who needs saftey precautions
            //am i rite?

            //checks if our  key is in our dictionary
        public bool TryGet(Tkey key, out TValue val)
        {
            //node x is set to head node. as long as it isnt equal to null
            //we iterate
            for (Node x = _first; x != null; x = x.Next)
            {
                //x: y: are our comparator values. designated by the x: y:
                //here we check the given key to see if it matches any of our keys
                if(_comparer.Equals(x:key, y:x.Key))
                {
                    val = x.Value;
                    return true;
                }
            }

            val = default(Tvalue);
            return false;
        }

        //adds key
        public void Add(Tkey key, TValue val)
        {
            //if the adding key is null we throw an error
            if(key == null)
            {
                throw new ArgumentNullException(paramName: "Key cant be null");
            }
            // check and updates keys if the key is in the list
            //if we want to overwrite a key value we just add agaim
            for(Node x = _first; x!=null; x = x.Next)
            {
                //compares key and if the values are similar we update
                //the x value to meet new value
                if(_comparer.Equals(x:key, y:x.Key))
                {
                    x.Value = val;
                    return;
                }  
            }
            //Oh yeah we add the node and link the previous to the new head
            _first = new Node(key, val, _first);
            Count++;
        }
        //just checks to see if there is the specified value in the table
        public bool Contains(Tkey key)
        {  //same node loop and same comparison
            for (Node x = _first; x != null; x = x.Next)
            {
                if (_comparer.Equals(x: key, y: x.Key))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Tkey> Keys()
        {  //simple I enumerable with generic link to keys.
            //displays all keys
            for (Node x = _first; x != null; x = x.Next)
            {
                //yield returns all statements one at at a time
                //simple iterator over all of the values
                yield return x.Key;
            }
        }


        //removes a key
        public bool Remove(Tkey key)
        {
            if (key == null)
                throw new ArgumentNullException(paramName: "Key cant be null");
            //if there is a one count we remove the table to be empty
            if(Count== 1 && _comparer.Equals(x:_first.Key,y:key))
            {
                _first = null;
                Count--;
                return true;
            }
            //declares a previous and current node setup.
            //since we add at the beginning of the table we use current as first
            Node prev = null;
            Node current = _first;

            //while our value isnt null we do a couple quick comparisons and
            //edits
            while (current != null)
            {
                //if our comparsion is our head
                if (_comparer.Equals(x: current.Key, y: key))
                {
                    //if the previous node is null we just remove the whole
                    //node
                    if (prev == null)
                    {
                        _first = current.Next;
                    }
                    //else we just overwrite the node location
                    else
                    {
                        prev.Next = current.Next;
                    }
                    //decrements count returns true 
                    Count--;
                    return true;
                }

                //updates  incase what were looking for 
                //it sets the current value to previous
                //and then makes current the next value in list
                prev = current;
                current = current.Next;
            }
            return false;
        }
    }
}

