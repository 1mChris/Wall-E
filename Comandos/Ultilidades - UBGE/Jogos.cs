using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Jogos : BaseCommandModule
    {
        [Command("jogos")]

        public async Task JogosdaUBGE(CommandContext ctx) {
            await ctx.RespondAsync("https://www.ubge.org/grupos\n\n<#456575674279526410>");
        }
    }
}
