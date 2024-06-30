namespace HashTable
{
    public class HashTable<TKey, TValue>
    {
        private const int Size = 100;
        private LinkedList<Node>[] items;

        private class Node
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }

        public HashTable()
        {
            items = new LinkedList<Node>[Size];
        }

        private int GetArrayIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % Size;
        }

        public void Add(TKey key, TValue value)
        {
            int index = GetArrayIndex(key);

            if (items[index] == null)
            {
                items[index] = new LinkedList<Node>();
            }

            items[index].AddLast(new Node { Key = key, Value = value });
        }

        public TValue Get(TKey key)
        {
            int index = GetArrayIndex(key);

            if (items[index] != null)
            {
                foreach (var node in items[index])
                {
                    if (node.Key.Equals(key))
                    {
                        return node.Value;
                    }
                }
            }

            throw new KeyNotFoundException("Key not found in hash table");
        }

        public bool ContainsKey(TKey key)
        {
            int index = GetArrayIndex(key);

            if (items[index] != null)
            {
                foreach (var node in items[index])
                {
                    if (node.Key.Equals(key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

    class Program
    {
        static void Main()
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();

            hashTable.Add("One", 1);
            hashTable.Add("Two", 2);
            hashTable.Add("Three", 3);

            Console.WriteLine(hashTable.Get("Two")); // Output: 2

            Console.WriteLine(hashTable.ContainsKey("Four")); // Output: False
        }
    }
}

