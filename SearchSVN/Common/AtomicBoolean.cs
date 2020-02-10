using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace SVNHistorySearcher.Common
{
	public class AtomicBoolean
	{
		private const int True = 1;
		private const int False = 0;
		private int _value;

		public AtomicBoolean(bool initialValue)
		{
			Interlocked.Exchange(ref _value, initialValue ? True : False);
		}

		/// <summary>
		/// Atomically set the value to the given updated value if the current value equals the expected value.
		/// </summary>
		/// <param name="expectedValue">The comparand (expected value).</param>
		/// <param name="newValue">The new value.</param>
		/// <returns>True in case the expected value was equal to the actual value at the time of the comparison.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool CompareAndSet(bool expectedValue, bool newValue)
		{
			var newValueInt = ToInt(newValue);
			var comparandInt = ToInt(expectedValue);

			return Interlocked.CompareExchange(ref _value, newValueInt, comparandInt) == comparandInt;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get()
		{
			return ToBool(Volatile.Read(ref _value));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(bool value)
		{
			Volatile.Write(ref this._value, ToInt(value));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator bool(AtomicBoolean value)
		{
			return value.Get();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool ToBool(int value)
		{
			if (value != False && value != True)
			{
				throw new ArgumentOutOfRangeException(value.ToString());
				// originally: throw new ArgumentOutOfRangeException(nameof(value));
			}
			return value == True;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int ToInt(bool value)
		{
			return value ? True : False;
		}
	}
}
