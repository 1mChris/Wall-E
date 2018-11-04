using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using System;
using System.Threading.Tasks;

namespace Wall_E.Comandos.Desenvolvedor
{
    public class Ping : BaseCommandModule
    {
        [Command("ping")]

        public async Task PingWall_EDiscord(CommandContext ctx) {
            await ctx.RespondAsync($"Meu ping é: **{ctx.Client.Ping}ms**! :ping_pong:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} -03:00] [Wall-E] [DSharpPlus] Meu ping é: {ctx.Client.Ping}ms!");
            Console.ResetColor();
        }
    }
}
