using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class XVerYVer : BaseCommandModule
    {
        [Command("xvértice")]
        [Aliases("xvertice", "xv")]

        public async Task XVértice(CommandContext ctx, double b, double a) {
            double xver = (-b / 2 * a);
            await ctx.RespondAsync($"{ctx.Member.Mention} **|** **X do Vértice:** ``{xver.ToString()}``");
        }

        [Command("yvértice")]
        [Aliases("yvertice", "yv")]

        public async Task YVértice(CommandContext ctx, double delta, double a) {
            double xver = (-delta / 4 * a);
            await ctx.RespondAsync($"{ctx.Member.Mention} **|** **Y do Vértice:** ``{xver.ToString()}``");
        }
    }
}