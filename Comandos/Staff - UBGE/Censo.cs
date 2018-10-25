using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Censo : BaseCommandModule
    {
        [Command("censo")]
        [Aliases("censo_comunitário")]

        public async Task CensoComunitárioUBGE(CommandContext ctx) {
            await ctx.RespondAsync("https://goo.gl/forms/3jm8kq2Im94bOXYA2");
        }
    }
}
