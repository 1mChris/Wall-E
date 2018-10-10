using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class XVerYVer
    {
        [Command("XVértice")]
        [Aliases("XVÉRTICE", "xvértice", "xvertice", "XVertice", "XVERTICE", "XV", "Xv", "xv")]

        public async Task XVértice(CommandContext ctx, double b, double a) {
            double xver = (-b / 2 * a);
            await ctx.RespondAsync($"{ctx.Member.Mention} **|** **X do Vértice:** ``{xver.ToString()}``");
        }

        [Command("YVértice")]
        [Aliases("YVÉRTICE", "yvértice", "yvertice", "YVertice", "YVERTICE", "YV", "Yv", "yv")]

        public async Task YVértice(CommandContext ctx, double delta, double a) {
            double xver = (-delta / 4 * a);
            await ctx.RespondAsync($"{ctx.Member.Mention} **|** **Y do Vértice:** ``{xver.ToString()}``");
        }
    }
}