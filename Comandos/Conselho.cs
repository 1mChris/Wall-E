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
    public class Conselho
    {
        [Command("Conselho")]
        [Aliases("conselho", "Conselho_Comunitário", "conselho_comunitário")]

        public async Task ConselhoComunitárioUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("https://goo.gl/forms/OeCCPuIXBvj7BBFD2");
        }
    }
}
