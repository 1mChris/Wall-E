using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Arma3 : BaseCommandModule
    {
        [Command("arma")]

        public async Task Arma3UBGE(CommandContext ctx) {
            await ctx.RespondAsync("https://units.arma3.com/unit/ubge");
        }
    }
}
