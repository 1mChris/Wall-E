using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E.Comandos.Desenvolvedor
{
    public class Ping
    {
        [Command("Ping")]
        [Aliases("ping", "PING")]

        public async Task PingWall_EDiscord(CommandContext ctx)
        {
            await ctx.RespondAsync($"Meu ping é: **{ctx.Client.Ping}ms**! :ping_pong:");
        }
    }
}
