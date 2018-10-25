using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Wall_E.Música
{
	public class RequireInVoiceChannelAttribute : CheckBaseAttribute
	{
		public override async Task<bool> ExecuteCheckAsync(CommandContext ctx, bool help) {
			var vs = ctx.Member.VoiceState;

			if (vs == null) {
				await ctx.RespondAsync($"{ctx.Member.Mention} **|** Você precisa estar conectado em um canal de voz!");
				return false;
			}

			var chn = vs.Channel;

			if (chn == null) {
				await ctx.RespondAsync($"{ctx.Member.Mention} **|** Você precisa estar conectado em um canal de voz!");
				return false;
			}

			return true;
		}
	}

	public class RequireInSameVoiceChannelAttribute : CheckBaseAttribute
	{
		public override async Task<bool> ExecuteCheckAsync(CommandContext ctx, bool help) {
			var vs = ctx.Member.VoiceState;
			var chn = vs.Channel;

			var mbr = ctx.Guild.CurrentMember?.VoiceState?.Channel;
			if (mbr != null && chn != mbr) {
				await ctx.RespondAsync($"{ctx.Member.Mention} **|** Você precisa estar conectado no mesmo canal de voz!");
				return false;
			}

			return true;
		}
	}

	public class RequireMusicServiceAttribute : CheckBaseAttribute
	{
		public override async Task<bool> ExecuteCheckAsync(CommandContext ctx, bool help) {
			var service = ctx.Services.GetService<MusicService>();
			if(service == null) {
				await ctx.RespondAsync($"{ctx.User.Mention} **|** O Serviço de música não está instalado!");
				return false;
			}

			var node = service.Node;
			if(node == null) {
				await ctx.RespondAsync($"{ctx.User.Mention} **|** O Nodo de música não está configurado!");
				return false;
			}

            if (!node.IsConnected) { 
				await ctx.RespondAsync($"{ctx.User.Mention} **|** O Nodo de música não está conectado!");
				return false;
			}
			return true;
		}
	}
}