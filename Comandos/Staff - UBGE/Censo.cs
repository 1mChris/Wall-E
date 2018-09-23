using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Censo
    {
        [Command("Censo")]
        [Aliases("censo", "Censo_comunitário", "censo_comunitário")]

        public async Task CensoComunitárioUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("https://goo.gl/forms/3jm8kq2Im94bOXYA2");
        }
    }
}
