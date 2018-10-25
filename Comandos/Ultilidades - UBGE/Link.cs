using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Link : BaseCommandModule
    {
        [Command("link")]

        public async Task LinkdeconvitedaUBGE(CommandContext ctx) {
            await ctx.RespondAsync("https://discordapp.com/invite/cPFBXDz");
        }
    }
}
