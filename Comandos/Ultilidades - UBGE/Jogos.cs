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
    public class Jogos
    {
        [Command("Jogos")]
        [Aliases("jogos")]

        public async Task JogosdaUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("https://www.ubge.org/grupos\n\n<#456575674279526410>");
        }
    }
}
