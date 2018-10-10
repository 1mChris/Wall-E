using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Facebook
    {
        [Command("Facebook")]
        [Aliases("facebook", "feicebuqi", "feicesbruqi", "Feicebuqi", "Feicesbruqi")]

        public async Task FacebookdaUBGE(CommandContext ctx) {
            await ctx.RespondAsync("**Página:** **https://www.facebook.com/ComunidadeUBGE/**\n\n**Grupo:** **https://www.facebook.com/groups/ComunidadeUBGE/**");
        }
    }
}
