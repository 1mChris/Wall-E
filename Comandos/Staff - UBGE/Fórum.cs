using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Fórum : BaseCommandModule
    {
        [Command("forum")]
        [Aliases("fórum")]

        public async Task FórumUBGE(CommandContext ctx) {
            await ctx.RespondAsync("https://www.ubge.org/forum/");
        }
    }
}
