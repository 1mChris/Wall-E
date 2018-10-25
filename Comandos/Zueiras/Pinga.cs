using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Pinga : BaseCommandModule
    {
        [Command("pinga")]
        [Aliases("cachaça", "51")]

        public async Task CachaçadoLéo(CommandContext ctx) {
            await ctx.RespondAsync("<:51:431184475326775296>");
        }
    }
}
