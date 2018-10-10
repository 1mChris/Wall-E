using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class ID
    {
        [Command("ID")]
        [Aliases("id")]

        public async Task IDdoWallE(CommandContext ctx) {
            await ctx.RespondAsync("Meu ID é: 445330394188087306");
        }
    }
}
