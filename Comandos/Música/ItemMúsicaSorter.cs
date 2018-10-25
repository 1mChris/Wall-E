using System.Collections.Generic;

namespace Wall_E.Música
{
	public class MusicItemSorter : IComparer<MusicItem>
	{
		private readonly CSPRNG rng;

		public MusicItemSorter(CSPRNG rng) {
			this.rng = new CSPRNG();
		}

		public int Compare(MusicItem x, MusicItem y) {
			int n1 = rng.Next(),
				n2 = rng.Next();

			if (n1 > n2)
				return 1;

			else if (n1 < n2)
				return -1;

			return 0;
		}
	}
}