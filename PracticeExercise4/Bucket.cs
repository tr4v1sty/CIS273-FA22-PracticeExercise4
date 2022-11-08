using System;
namespace PracticeExercise4
{
	public enum BucketState
	{
		EmptySinceStart,
		EmptyAfterRemoval,
		Full
	}

	public class Bucket<K, V>
	{
		public K Key { get; set; }
		public V Value { get; set; }
		public BucketState State { get; set; }

		public Bucket()
		{
			State = BucketState.EmptySinceStart;
		}

		public Bucket(K key, V value)
		{
			Key = key;
			Value = value;

            State = BucketState.Full;
        }

		public void Clear()
		{
			Key = default;
			Value = default;
			State = BucketState.EmptyAfterRemoval;
		}
	}
}

