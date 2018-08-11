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
    public class Pioneiros
    {
        [Command("Pioneiro")]
        [Aliases("pioneiro", "Pioneiros", "pioneiros")]

        public async Task PioneiroUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("Aplique-se para Pioneiro aqui: https://goo.gl/7smKqz\n\nLeia mais sobre em: <#448571287384752168>");
        }
    }
}
