using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Página : BaseCommandModule
    {
        [Command("página")]
        [Aliases("pagina")]

        public async Task PáginaUBGE(CommandContext ctx) {
            await ctx.RespondAsync("**Página:** https://www.facebook.com/ComunidadeUBGE/\n**SITE:** https://www.ubge.org/\n**Grupo Facebook:** https://www.facebook.com/groups/ComunidadeUBGE\n**Steam:** http://steamcommunity.com/groups/UBGEsteam\n\nhttps://www.ubge.org/grupos");
        }
    }
}
