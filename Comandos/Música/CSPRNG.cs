using System;
using System.Security.Cryptography;

namespace Wall_E.Música
{
	public class CSPRNG : IDisposable
	{
		public bool IsDisposed { get; set; } = false;
		private RandomNumberGenerator RNG { get; } = RandomNumberGenerator.Create();

		public byte [] GetBytes(int count) {
			if (count <= 0)
				throw new ArgumentOutOfRangeException("Deve obter pelo menos 1 byte.", nameof(count));

			var bts = new byte [count];
			RNG.GetBytes(bts);
			return bts;
		}

		public void GetBytes(int count, out byte [] bytes) {
			if (count <= 0)
				throw new ArgumentOutOfRangeException("Deve obter pelo menos 1 byte.", nameof(count));

			bytes = new byte [count];
			RNG.GetBytes(bytes);
		}

		public byte GetU8()
			=> GetBytes(1) [0];

		public sbyte GetS8()
			=> (sbyte)GetBytes(1) [0];

		public ushort GetU16()
			=> BitConverter.ToUInt16(GetBytes(2), 0);

		public short GetS16()
			=> BitConverter.ToInt16(GetBytes(2), 0);

		public uint GetU32()
			=> BitConverter.ToUInt32(GetBytes(4), 0);

		public int GetS32()
			=> BitConverter.ToInt32(GetBytes(4), 0);

		public ulong GetU64()
			=> BitConverter.ToUInt64(GetBytes(8), 0);

		public long GetS64()
			=> BitConverter.ToInt64(GetBytes(8), 0);

		public int Next()
			=> Next(0, int.MaxValue);

		public int Next(int max)
			=> Next(0, max);

		public int Next(int min, int max) {
			if (max <= min)
				throw new ArgumentException("Máximo necessita ser maior que o mínimo.", nameof(max));

			var offset = 0;
			if (min < 0)
				offset = -min;

			min += offset;
			max += offset;

			return Math.Abs(GetS32()) % (max - min) + min - offset;
		}

		public float NextSingle() {
			var (l1, l2) = ((float)GetS32(), (float)GetS32());
			return Math.Abs(l1 / l2) % 1.0F;
		}

		public double NextDouble() {
			var (l1, l2) = ((double)GetS64(), (double)GetS64());
			return Math.Abs(l1 / l2) % 1.0;
		}

		public void Dispose() {
			if (IsDisposed)
				throw new ObjectDisposedException("Este gerador de números aleatórios já está descartado.");

			IsDisposed = true;
			RNG.Dispose();
		}
	}
}