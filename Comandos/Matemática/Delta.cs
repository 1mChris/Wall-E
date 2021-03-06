﻿using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Delta : BaseCommandModule
    {
        [Command("delta")]
        [Aliases("d")]

        public async Task DeltaMatemática(CommandContext ctx, double b, double a, double c) {
            double delta = (b * b) - (4 * a * c);
            await ctx.RespondAsync($"{ctx.Member.Mention} **|** **Delta:** ``{delta.ToString()}``");
        }
    }
}
