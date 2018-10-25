using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Lavalink;

namespace Wall_E.Música
{
	[RequireMusicService]
	public partial class MusicModule : BaseCommandModule
	{
		private MusicService _music;

		public MusicModule(MusicService music) {
			_music = music;
		}

		public override async Task BeforeExecutionAsync(CommandContext ctx) {
			if (_music.Node == null)
				await _music.ConnectAsync();

			await _music.GetOrCreatePlayerAsync(ctx.Guild, ctx.Channel);
			await base.BeforeExecutionAsync(ctx);
		}

		[Command("play")]
        [Aliases("p"), RequireInVoiceChannel, RequireInSameVoiceChannel]

		public async Task PlayAsync(CommandContext ctx,
			[Description("Termo de pesquisa ou link para tocar.")]
			[RemainingText] string pesquisa = null)
		{
			if (pesquisa == null) {
				await ctx.RespondAsync($"{ctx.User.Mention} **|** Você precisa fornecer uma url ou termo para eu pesquisar no Youtube e depois tocar a música desejada.");
				return;
			}

			MusicPlayer player = await _music.GetOrCreatePlayerAsync(ctx.Guild, ctx.Channel);
			LavalinkLoadResult result = null;

			if (Uri.IsWellFormedUriString(pesquisa, UriKind.Absolute))
				result = await _music.Node.GetTracksAsync(new Uri(pesquisa));
			else
				result = await _music.Node.GetTracksAsync(pesquisa);

			switch (result.LoadResultType) {
				case LavalinkLoadResultType.LoadFailed:
					await ctx.RespondAsync($"{ctx.User.Mention} **|** Houve um problema ao carregar a música selecionada!");
					return;

				case LavalinkLoadResultType.NoMatches:
					await ctx.RespondAsync($"{ctx.User.Mention} **|** Nenhum resultado com a pesquisa ou link foi encontrado!");
					return;

				case LavalinkLoadResultType.PlaylistLoaded: {
					int indice = 0;

					lock (player.Queue)
						indice = player.Queue.Count;

					var str = "";
					var pages = new List<Page>();

					foreach (var track in result.Tracks) {
						if (str.Length >= 1500) {
							pages.Add(new Page {
								Content = ctx.User.Mention,
								Embed = new DiscordEmbedBuilder()
									.WithTitle($"{ctx.User.Mention} **|** Músicas adicionadas na Playlist.")
									.WithDescription(str)
									.WithFooter($"Comando requisitado pelo: " + ctx.Member.Username, iconUrl: ctx.User.AvatarUrl)
									.WithColor(DiscordColor.Orange)
							});

							str = "";
						}
						else {
							str += $"**`{string.Format("{0:00}", indice++)}`**: {Formatter.MaskedUrl(Formatter.Sanitize(track.Title), track.Uri)} (`{MusicPlayer.FormatTimespan(track.Length)}`)\n";
						}

						var qresult = player.Enqueue(new MusicItem(track, ctx.Member, ctx.Channel));
						if (qresult == MusicOperationResult.QueueFull) {
							await ctx.RespondAsync($"{ctx.User.Mention} **|** A fila encheu e nem todas as músicas foram adicionadas! :/");
							await PrepareAsync();

							player.Play();

							await ctx.Client.GetInteractivity()
								.SendPaginatedMessage(ctx.Channel, ctx.User, pages);

							return;
						}
					}

					if (!string.IsNullOrEmpty(str)) {
						pages.Add(new Page {
							Content = ctx.User.Mention,
							Embed = new DiscordEmbedBuilder()
									.WithTitle($"{ctx.User.Mention} **|** Músicas adicionadas na Playlist.")
									.WithDescription(str)
									.WithFooter($"Comando requisitado pelo: " + ctx.Member.Username, iconUrl: ctx.User.AvatarUrl)
									.WithColor(DiscordColor.Orange)
						});
					}

					await PrepareAsync();

					player.Play();

					await ctx.Client.GetInteractivity()
						.SendPaginatedMessage(ctx.Channel, ctx.User, pages);
				}
				return;

				case LavalinkLoadResultType.SearchResult:
				case LavalinkLoadResultType.TrackLoaded: {
					var track = result.Tracks
						.FirstOrDefault();

					await ctx.RespondAsync($"{ctx.User.Mention} **|** A música: **{Formatter.Sanitize(track.Title)}** " +
						$"por: **{Formatter.Sanitize(track.Author)}** foi adicionada a playlist.");

					await PrepareAsync();

					player.Enqueue(new MusicItem(track, ctx.Member, ctx.Channel));
					player.Play();
				}
				return;

			}

			async Task PrepareAsync() {
				var vs = ctx.Member.VoiceState;
				var chn = vs.Channel;
				await player.CreatePlayerAsync(chn);
			}
		}

		[Command("skip"), RequireInVoiceChannel, RequireInSameVoiceChannel]
        [Aliases("s")]

		public async Task SkipAsync(CommandContext ctx) {
			var player = await _music.GetOrCreatePlayerAsync(ctx.Guild, ctx.Channel);

			await ctx.RespondAsync($"{ctx.User.Mention} **|** A música: **{Formatter.Sanitize(player.NowPlaying.Track.Title)}** " +
				$"por: **{Formatter.Sanitize(player.NowPlaying.Track.Author)}** foi saltada.");

			var result = player.Stop();
		}

		[Command("remove")]
        [Aliases("r"), RequireInVoiceChannel, RequireInSameVoiceChannel]

		public async Task RemoverAsync(CommandContext ctx,

			[Description("Índice da música que será removido.")]
			[RemainingText]
			int index = 0)
		{
			var player = await _music.GetOrCreatePlayerAsync(ctx.Guild, ctx.Channel);
			var result = player.Remove(index, out var item);
			switch (result) {
				case MusicOperationResult.NotEnoughTrack:
					await ctx.RespondAsync($"{ctx.User.Mention} **|** Não existe nenhuma música com o índice: **`{string.Format("{0:00}", index)}`** foi encontrada!");
					return;

				case MusicOperationResult.Success:
					await ctx.RespondAsync($"{ctx.User.Mention} **|** A música: **{Formatter.Sanitize(item.Track.Title)}** por: **{Formatter.Sanitize(item.Track.Author)}** foi removida da playlist.");
					return;
			}
		}

		[Command("shuffle")]
        [Aliases("embaralhar", "e"), RequireInVoiceChannel, RequireInSameVoiceChannel]

		public async Task ShuffleAsync(CommandContext ctx) {
			var player = await _music.GetOrCreatePlayerAsync(ctx.Guild, ctx.Channel);
			var result = player.Shuffle();
			switch (result) {
				case MusicOperationResult.QueueIsEmpty:
					await ctx.RespondAsync($"{ctx.User.Mention} **|** A fila está vazia!");
					break;

				default:
					await ctx.RespondAsync($"{ctx.User.Mention} **|** A playlist foi embaralhada!");
					break;
			}
		}

		[Command("nowplaying")]
        [Aliases("np", "tocando", "t")]

		public async Task NowPlayingAsync(CommandContext ctx) {
			var player = await _music.GetOrCreatePlayerAsync(ctx.Guild, ctx.Channel);
			if(player.NowPlaying == null) {
				await ctx.RespondAsync($"{ctx.User.Mention} **|** Nenhuma música está tocando agora.");
				return;
			}
            else {
				var now = player.NowPlaying.Track;
				
				var builder = new DiscordEmbedBuilder()
					.WithTitle(":headphones: **|** Tocando agora:")
					.WithFooter($"Comando requisitado pelo: " + ctx.Member.Username, iconUrl: ctx.User.AvatarUrl)
					.WithColor(DiscordColor.Blurple)
					.WithThumbnailUrl("https://i.imgur.com/awKVGqI.png")
					.AddField("Id:", now.Identifier, true)
					.AddField("Título:", Formatter.Sanitize(now.Title), true)
					.AddField("Autor:", Formatter.Sanitize(now.Author), true)
					.AddField("Duração:", MusicPlayer.FormatTimespan(now.Length), true)
					.AddField("É Transmitido?", (now.IsStream ? "Sim" : "Não"), true)
					.AddField("É Pesquisável?", (now.IsSeekable ? "Sim" : "Não"), true)
					.AddField("Link:", now.Uri.ToString(), true);

				await ctx.RespondAsync(ctx.User.Mention, embed: builder);
			}
		}

		[Command("queue")]
        [Aliases("fila", "q", "f")]

		public async Task QueueAsync(CommandContext ctx) {
			var player = await _music.GetOrCreatePlayerAsync(ctx.Guild, ctx.Channel);

			var ity = ctx.Client.GetInteractivity();
			var pages = new List<Page>();
			var queue = player.Queue;

			var str = "";
			var indice = 1;

			lock (player.Queue) {
				foreach (var item in queue) {
					if (str.Length >= 1500) {
						pages.Add(new Page {
							Content = ctx.User.Mention,
							Embed = new DiscordEmbedBuilder()
								.WithTitle($":musical_note: | Playlist das músicas:")
								.WithDescription(str)
								.WithFooter($"Comando requisitado pelo: " + ctx.Member.Username, iconUrl: ctx.User.AvatarUrl)
								.WithColor(DiscordColor.Blurple)
						});

						str = "";
					}
                    else {
						str += $"`{string.Format("{0:00}", indice++)}`: {Formatter.MaskedUrl(Formatter.Sanitize(item.Track.Title), item.Track.Uri)} (`{MusicPlayer.FormatTimespan(item.Track.Length)}`)\n";
					}
				}

				if (!string.IsNullOrEmpty(str))
					pages.Add(new Page {
						Content = ctx.User.Mention,
						Embed = new DiscordEmbedBuilder()
							.WithTitle($":musical_note: | Playlist das músicas:")
							.WithDescription(str)
							.WithFooter($"Comando requisitado pelo: " + ctx.Member.Username, iconUrl: ctx.User.AvatarUrl)
							.WithColor(DiscordColor.Blurple)
					});
			}

			if (pages.Count > 0)
				await ity.SendPaginatedMessage(ctx.Channel, ctx.User, pages);
			else
				await ctx.RespondAsync($"{ctx.User.Mention} **|** A playlist está vazia.");
		}

        [Command("stop")]
        [Aliases("para", "pare", "parar")]

        public async Task StopAsync(CommandContext ctx) {
            var player = await _music.GetOrCreatePlayerAsync(ctx.Guild, ctx.Channel);
            player.Stop();
            await player.DestroyPlayerAsync();

            await ctx.RespondAsync($"{ctx.User.Mention} **|** A música foi parada.");
        }
        
        [Command("volume")]
        [Aliases("v")]

        public async Task VolumeAsync(CommandContext ctx, int volume)
        {
            var player = await _music.GetOrCreatePlayerAsync(ctx.Guild, ctx.Channel);
            player.SetVolume(volume);

            if (volume > 100) {
                await ctx.RespondAsync($"{ctx.User.Mention} **|** Volume da música foi definido para: ``{volume.ToString()}``.\n\n**Atenção!, cuidado ao definir um volume muito alto, poderá lhe causar problema de audição.**");
                
            }
            else {
                await ctx.RespondAsync($"{ctx.User.Mention} **|** Volume da música foi definido para: ``{volume.ToString()}``.");
            }
        }
    }
}