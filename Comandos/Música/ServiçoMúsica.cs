using System.Collections.Concurrent;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Lavalink;
using DSharpPlus.Net.Udp;

namespace Wall_E.Música
{
	public class MusicService
	{
		private readonly ConcurrentDictionary<ulong, MusicPlayer> Players;
		private readonly LavalinkConfiguration configuration;

		public DiscordClient Discord {
            get; private set;
		}

		public LavalinkNodeConnection Node {
			get; private set;
		}

		public CSPRNG RNG {
			get; set;
		}

		public MusicService(DiscordClient discord) {
			configuration = new LavalinkConfiguration {
				Password = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzZXJ2aWNlIjoibGF2YWxpbmsifQ.RERpZ_wfrNos5eknOeeQcieaYESPUajoRn2Ts9AWeRw",
				RestEndpoint = new ConnectionEndpoint {
					Hostname = "54.207.51.138", //127.0.0.1 ou ubge.ddns.net ou 54.207.51.138
					Port = 65200
				},
				SocketEndpoint = new ConnectionEndpoint {
					Hostname = "54.207.51.138",
					Port = 65201    
				}
			};

			Players = new ConcurrentDictionary<ulong, MusicPlayer>();
			Discord = discord;
			Discord.Ready += Discord_Ready;
		}

		public Task<MusicPlayer> GetOrCreatePlayerAsync(DiscordGuild guild, DiscordChannel channel) {
			if (Players.TryGetValue(guild.Id, out var player))
				return Task.FromResult(player);

			player = new MusicPlayer(this, guild, channel);
			Players.AddOrUpdate(guild.Id, player, (key, old) => player);

			return Task.FromResult(player);
		}

		async Task Discord_Ready(ReadyEventArgs e) {
			await ConnectAsync();
		}

		public async Task ConnectAsync() {
			var ll = Discord.GetLavalink();
			Node = await ll.ConnectAsync(configuration);
		}
	}
}