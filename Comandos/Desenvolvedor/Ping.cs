using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using System.Threading.Tasks;

namespace Wall_E.Comandos.Desenvolvedor
{
    public class Ping : BaseCommandModule
    {
        [Command("ping")]

        public async Task PingWall_EDiscord(CommandContext ctx) {
            await ctx.RespondAsync($"Meu ping é: **{ctx.Client.Ping}ms**! :ping_pong:");
        }
    }
}
