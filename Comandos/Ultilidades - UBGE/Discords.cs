using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Discords : BaseCommandModule
    {
        [Command("discords")]

        public async Task DiscordsRelacionados(CommandContext ctx) {
            await ctx.RespondAsync("**Discords Relacionados:**\n\n**Foxhole:** https://discord.gg/foxhole\n\n**Foxhole - Eventos:** https://discord.gg/TMenESY\n\n\n**Project Reality:** https://discord.gg/xHXdNcS\n\n**Project Reality - Divsul:** https://discord.gg/wNbevyW\n\n\n**Hell Let Loose:** https://discord.gg/45F4SZT\n\n**Hell Let Loose - Brasil:** https://discord.gg/M3Sn2NR");
        }
    }
}
