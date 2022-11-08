using System;
namespace PracticeExercise4
{
	public interface IHashTable<K, V>
	{
		// Add/Update the key, value pair
		// Return true if the key already exists
		bool Add(K key, V value);

		// Return true if the key already exists
		// return false if key doesn't exist
		bool Remove(K key);

		// Lookup value for given key
		V Get(K key);


		bool ContainsKey(K key);

		bool ContainsValue(V value);

		int Count { get; }

		List<K> GetKeys();

		List<V> GetValues();

		double LoadFactor { get; }
	}
}

