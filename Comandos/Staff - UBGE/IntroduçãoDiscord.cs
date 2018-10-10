using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class IntroduçãoDiscord
    {
        [Command("Discord")]
        [Aliases("discord")]

        public async Task IntroDiscord(CommandContext ctx) {
            await ctx.RespondAsync("https://youtu.be/8aydobOKeA0");
        }
    }
}
