using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Delta
    {
        [Command("Delta")]
        [Aliases("delta", "DELTA", "D", "d")]

        public async Task DeltaMatemática(CommandContext ctx, double b, double a, double c)
        {
            double delta = (b * b) - (4 * a * c);
            await ctx.RespondAsync($"{ctx.Member.Mention} **|** **Delta:** ``{delta.ToString()}``");
        }
    }
}
