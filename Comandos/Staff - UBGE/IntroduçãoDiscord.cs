using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class IntroduçãoDiscord : BaseCommandModule
    {
        [Command("discord")]

        public async Task IntroDiscord(CommandContext ctx) {
            await ctx.RespondAsync("https://youtu.be/8aydobOKeA0");
        }
    }
}
