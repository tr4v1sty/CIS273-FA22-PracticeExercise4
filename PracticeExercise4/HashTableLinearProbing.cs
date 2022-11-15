﻿using System;

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

        private int count;
        private readonly double MAX_LOAD_FACTOR = 0.6;

        public int Count => count;

        public double LoadFactor => count / (double)buckets.Length;

        // O(1) - average case
        // O(n) - worst case
        public bool Add(K key, V value)
        {
            if( LoadFactor > MAX_LOAD_FACTOR)
            {
                Resize();
            }

            // find the hash
            int hash = Hash(key);

            // find the starting index
            int startingIndex = hash % buckets.Length;
            int bucketIndex = startingIndex;

            while (buckets[bucketIndex].State == BucketState.Full)
            {
                // if the key already exists, then update it.
                if(buckets[bucketIndex].Key.Equals( key ))
                {
                    buckets[bucketIndex].Value = value;
                    return true;
                }


                bucketIndex = (bucketIndex + 1) % buckets.Length;

                if( bucketIndex == startingIndex)
                {
                    throw new OutOfMemoryException();
                }
            }

            // if the key doesn't exist, then add it.
            buckets[bucketIndex].Key = key;
            buckets[bucketIndex].Value = value;
            buckets[bucketIndex].State = BucketState.Full;
            count++;
            return false;

        }

        // O(1) - average case
        // O(n) - worst case
        public bool ContainsKey(K key)
        {
            int hash = Hash(key);
            int bucketIdx = hash % buckets.Length;
            int initIdx = bucketIdx;

            while (buckets[bucketIdx].State != BucketState.EmptySinceStart)
            {
                // if bucket is full and contains the key return true
                if (buckets[bucketIdx].State == BucketState.Full && buckets[bucketIdx].Key.Equals(key))
                {
                    return true;
                }
                // ++length for buckets
                bucketIdx = (bucketIdx + 1) % buckets.Length;
                // if == init then the bucket is empty
                if(bucketIdx == initIdx)
                {
                    return false;
                }
            }
            return false;
        }

        // O(n) - average case
        // O(n) - worst case
        public bool ContainsValue(V value)
        {
            throw new NotImplementedException();
        }

        // O(1) - average case
        // O(n) - worst case
        public V Get(K key)
        {
            int hash = Hash(key);
            int bucketIdx = hash % buckets.Length;
            int initIdx = bucketIdx;
            while (buckets[bucketIdx].State != BucketState.EmptySinceStart)
            {
                if (buckets[bucketIdx].State == BucketState.Full && buckets[bucketIdx].Key.Equals(key))
                {
                    return buckets[bucketIdx].Value;
                }

                bucketIdx = (bucketIdx + 1) % buckets.Length;

                if (bucketIdx == initIdx)
                {
                    throw new KeyNotFoundException();
                }
            }
            throw new KeyNotFoundException();
        }

    

       

        // O(n) - average case
        // O(n) - worst case
        public List<K> GetKeys()
        {
            // List<K> keys = new List<K>();
            // foreach (var buckets in buckets) ;
            throw new NotImplementedException();
        }

        // O(n) - average case
        // O(n) - worst case
        public List<V> GetValues()
        {
            throw new NotImplementedException();
        }

        // O(1) - average case
        // O(n) - worst case
        public bool Remove(K key)
        {
            throw new NotImplementedException();
        }

        private void Resize()
        {
            var newBuckets = new Bucket<K, V>[2 * buckets.Length];
            var oldBuckets = buckets;

            buckets = newBuckets;
            for(int i=0; i < buckets.Length; i++)
            {
                buckets[i] = new Bucket<K, V>();
            }

            count = 0;

            // rehash all the old/existing buckets into the new array/hashtable
            foreach( var bucket in oldBuckets)
            {
                if( bucket.State == BucketState.Full)
                {
                    Add(bucket.Key, bucket.Value);
                }
            }
        }


        private int Hash(K key)
        {
            int hash = key.GetHashCode();

            return hash < 0 ? -hash : hash;
        }
    }
}

