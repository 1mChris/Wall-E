using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Conselho : BaseCommandModule
    {
        [Command("conselho")]
        [Aliases("conselho_comunitário")]

        public async Task ConselhoComunitárioUBGE(CommandContext ctx) {
            await ctx.RespondAsync("https://goo.gl/forms/OeCCPuIXBvj7BBFD2");
        }
    }
}
