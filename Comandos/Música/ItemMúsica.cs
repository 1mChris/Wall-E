using DSharpPlus.Entities;
using DSharpPlus.Lavalink;

namespace Wall_E.Música
{
	public class MusicItem
	{
		public LavalinkTrack Track {
			get; private set;
		}

		public DiscordMember RequestMember {
			get; private set;
		}

		public DiscordChannel RequestedChannel {
			get; private set;
		}

		public MusicItem(LavalinkTrack track, DiscordMember member, DiscordChannel channel) {
			Track = track;
			RequestMember = member;
			RequestedChannel = channel;
		}
	}
}