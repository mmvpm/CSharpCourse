using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTable
{
    public class HashTable<TK, TV>
    {
        private List<List<KeyValuePair<TK, TV>>> Storage { get; }

        public HashTable(int size = 16)
        {
            Storage = Enumerable.Repeat(0, size).Select(_ => new List<KeyValuePair<TK, TV>>()).ToList();
        }

        public void Add(TK key, TV value)
        {
            var index = GetKeyIndex(key);
            Storage[index].Add(new KeyValuePair<TK, TV>(key, value));
        }

        public void Remove(TK key)
        {
            var index = GetKeyIndex(key);
            Storage[index].RemoveAll(pair => pair.Key.Equals(key));
        }
        
        public bool Contains(TK key)
        {
            return FindPair(key).Key != null;
        }

        public TV Find(TK key)
        {
            return FindPair(key).Value;
        }

        public override string ToString()
        {
            var pairs = Storage
                .SelectMany(x => x)
                .Select(pair => pair.Key + " -> " + pair.Value);
            return "{" + string.Join(", ", pairs) + "}";
        }

        private int GetKeyIndex(TK key)
        {
            return key.GetHashCode() % Storage.Count;
        }

        private KeyValuePair<TK, TV> FindPair(TK key)
        {
            var index = GetKeyIndex(key);
            var neededPair = Storage[index].Find(pair => pair.Key.Equals(key));
            return neededPair;
        }
    }
}