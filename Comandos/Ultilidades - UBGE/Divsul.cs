using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Divsul : BaseCommandModule
    {
        [Command("divsul")]

        public async Task DivsulUBGE(CommandContext ctx) {
            await ctx.RespondAsync("https://discord.gg/Amet8Yc");
        }
    }
}
