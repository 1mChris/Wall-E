using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Central
    {
        [Command("Central")]
        [Aliases("central")]

        public async Task CentralFormulários(CommandContext ctx) {
            await ctx.RespondAsync("https://goo.gl/forms/zssTOBNen8X9wzk12");
        }
    }
}
