using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Lavalink;
using DSharpPlus.Lavalink.EventArgs;

namespace Wall_E.Música
{
	public class MusicPlayer
	{
		public MusicPlayer(MusicService service, DiscordGuild guild, DiscordChannel channel) {
			Queue = new List<MusicItem>(40);
			Service = service;
			Guild = guild;
			Channel = channel;
		}

		public DiscordChannel Channel {
			get; private set;
		}

		private MusicService Service {
			get; set;
		}

		public DiscordGuild Guild {
			get; private set;
		}

		public ulong Id {
			get; private set;
		}

		public LavalinkGuildConnection Connection {
			get; private set;
		}

		public MusicItem NowPlaying {
			get; private set;
		}

		public List<MusicItem> Queue {
			get; private set;
		}

		public int Volume {
			get; private set;
		}

        public DiscordMember UltimoMembro {
            get; private set;
        }

		public MusicOperationResult Shuffle() {
			lock (Queue) {
				if (Queue.Count == 0)
					return MusicOperationResult.QueueIsEmpty;
                else {
					Queue.Sort(new MusicItemSorter(Service.RNG));
					return MusicOperationResult.Success;
				}
			}
		}

		public async Task CreatePlayerAsync(DiscordChannel channel) {
			if (Connection != null && Connection.IsConnected)
				return;

			Connection = await Service.Node.ConnectAsync(channel);

			if (Volume <= 0)
				Volume = 100;

			else if (Volume >= 150)
				Volume = 100;

			Connection.SetVolume(Volume);
			Connection.TrackException += Connection_TrackException;
			Connection.PlaybackFinished += Connection_PlaybackFinished;
		}

		async Task Connection_TrackException(TrackExceptionEventArgs e) {
			await NowPlaying.RequestedChannel.SendMessageAsync($"Houve um problema ao tocar a música: **{Formatter.Sanitize(e.Track.Title)}** por: **{Formatter.Sanitize(e.Track.Author)}**\n\n**Erro:** ```{e.Error}```");
		}

		async Task Connection_PlaybackFinished(TrackFinishEventArgs e) {
			await Task.Delay(500).ConfigureAwait(false);
			BeginPlay();
		}

		async void BeginPlay() {
			var result = Dequeue(out var item);
			switch (result) {
				case MusicOperationResult.QueueIsEmpty:
                    if (Channel != null) {
					    await Channel.SendMessageAsync($"{UltimoMembro?.Mention} **|** Nenhuma música pra tocar na fila! Desconectando do canal.");
                        Channel = null;
                    }
                    await DestroyPlayerAsync();
                    break;

				case MusicOperationResult.Success: {
                    Channel = item.RequestedChannel;
                    UltimoMembro = item.RequestMember;
					await item.RequestedChannel.SendMessageAsync($"{UltimoMembro?.Mention} **|** Tocando agora: **{Formatter.Sanitize(item.Track.Title)}** " +
						$"por: **{Formatter.Sanitize(item.Track.Author)}**. - Duração: `{FormatTimespan(item.Track.Length)}`");
                    Channel = null;
                    UltimoMembro = null;

					NowPlaying = item;
					Connection.Play(item.Track);
				}
				break;
			}
		}

		public static string FormatTimespan(TimeSpan ts) {
			if (ts.TotalHours > 1)
				return ts.ToString(@"h\:mm\:ss");
			return ts.ToString(@"m\:ss");
		}

		public void Play() {
			if (Connection == null || !Connection.IsConnected)
				return;

			if (NowPlaying == null)
				BeginPlay();
		}

		public Task DestroyPlayerAsync() {
			if (Connection == null)
				return Task.CompletedTask;

			if (Connection.IsConnected)
				Connection.Disconnect();

			Connection = null;
			return Task.CompletedTask;
		}

		public TimeSpan GetCurrentPosition() {
			if (NowPlaying == null)
				return TimeSpan.Zero;

			if (Connection == null)
				return TimeSpan.Zero;

			return Connection.CurrentState.PlaybackPosition;
		}

		public MusicOperationResult Clear(out int count) {
			lock (Queue) {
				if (Queue.Count == 0) {
					count = 0;
					return MusicOperationResult.QueueIsEmpty;
				}
                else {
					count = Queue.Count;
					Queue.Clear();
					return MusicOperationResult.Success;
				}
			}
		}

		public MusicOperationResult Enqueue(MusicItem item) {
			lock (Queue) {
				if(Queue.Count >= Queue.Capacity)
					return MusicOperationResult.QueueFull;

                else {
					Queue.Add(item);
					return MusicOperationResult.Success;
				}
			}
		}

		public MusicOperationResult Dequeue(out MusicItem item) {
			lock (Queue) {
				if (Queue.Count == 0) {
					item = null;
					return MusicOperationResult.QueueIsEmpty;
				}

				item = Queue.ElementAt(0);
				Queue.RemoveAt(0);
				return MusicOperationResult.Success;
			}
		}

		public MusicOperationResult Remove(int index, out MusicItem item) {
			lock (Queue) {
				if (index < 0 || index >= Queue.Count) {
					item = null;
					return MusicOperationResult.NotEnoughTrack;
				}
                else {
					item = Queue [index];
					Queue.RemoveAt(index);
					return MusicOperationResult.Success;
				}
			}
		}

		public int Count() {
			lock (Queue)
				return Queue.Count;
		}

		public MusicOperationResult SetVolume(int volume) {
			if (volume <= 0)
				volume = 100;

			if (volume >= 150)
				volume = 100;

			Volume = volume;

			if (Connection == null || !Connection.IsConnected)
				return MusicOperationResult.NotConnected;

			Connection.SetVolume(Volume);
			return MusicOperationResult.Success;
		}

		public MusicOperationResult Stop() {
			if (Connection == null || !Connection.IsConnected)
				return MusicOperationResult.NotConnected;

			NowPlaying = null;
			Connection.Stop();
			return MusicOperationResult.Success;
		}

		public MusicOperationResult Pause() {
			if (Connection == null || !Connection.IsConnected)
				return MusicOperationResult.NotConnected;

			Connection.Pause();
			return MusicOperationResult.Success;
		}

		public MusicOperationResult Resume() {
			if (Connection == null || !Connection.IsConnected)
				return MusicOperationResult.NotConnected;

			Connection.Resume();
			return MusicOperationResult.Success;
		}

		public MusicOperationResult Restart() {
			if (Connection == null || !Connection.IsConnected)
				return MusicOperationResult.NotConnected;

			if (NowPlaying == null)
				return MusicOperationResult.NotEnoughTrack;

			lock (Queue) {
				Queue.Insert(0, NowPlaying);
				return MusicOperationResult.Success;
			}
		}
	}

	public enum MusicOperationResult {
		Success,
		NotConnected,
		QueueFull,
		QueueIsEmpty,
		NotEnoughTrack,
	}
}