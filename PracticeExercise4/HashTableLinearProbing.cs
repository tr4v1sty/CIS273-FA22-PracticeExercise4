using System;

namespace PracticeExercise4
{
	public class HashTableLinearProbing<K,V>: IHashTable<K,V>
	{

        private Bucket<K, V>[] buckets;
        private int initialCapacity = 16;


		public HashTableLinearProbing()
		{
            buckets = new Bucket<K, V>[initialCapacity];

            for(int i= 0; i < buckets.Length; i++)
            {
                buckets[i] = new Bucket<K, V>();
            }

		}

        public int Count => throw new NotImplementedException();

        public double LoadFactor => throw new NotImplementedException();

        public bool Add(K key, V value)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(K key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsValue(V value)
        {
            throw new NotImplementedException();
        }

        public V Get(K key)
        {
            throw new NotImplementedException();
        }

        public List<K> GetKeys()
        {
            throw new NotImplementedException();
        }

        public List<V> GetValues()
        {
            throw new NotImplementedException();
        }

        public bool Remove(K key)
        {
            throw new NotImplementedException();
        }
    }
}

