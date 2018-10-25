using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Denúncia : BaseCommandModule
    {
        [Command("denuncia")]
        [Aliases("denúncia")]

        public async Task DenúnciaFormulário(CommandContext ctx) {
            await ctx.RespondAsync("https://goo.gl/forms/zssTOBNen8X9wzk12");
        }
    }
}
