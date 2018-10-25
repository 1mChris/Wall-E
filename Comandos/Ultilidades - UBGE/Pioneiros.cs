using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Pioneiros : BaseCommandModule
    {
        [Command("pioneiro")]
        [Aliases("pioneiros")]

        public async Task PioneiroUBGE(CommandContext ctx) {
            await ctx.RespondAsync("Aplique-se para Pioneiro aqui: https://goo.gl/7smKqz\n\nLeia mais sobre em: <#448571287384752168>");
        }
    }
}
