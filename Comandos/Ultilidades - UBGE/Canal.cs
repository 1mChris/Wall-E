using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Canal : BaseCommandModule
    {
        [Command("canal")]

        public async Task CanaldoLéo(CommandContext ctx) {
            await ctx.RespondAsync("https://www.youtube.com/user/LeoFreitas021?feature=mhee");
        }
    }
}
