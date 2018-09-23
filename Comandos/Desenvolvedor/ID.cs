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
    public class ID
    {
        [Command("ID")]
        [Aliases("id")]

        public async Task IDdoWallE(CommandContext ctx)
        {
            await ctx.RespondAsync("Meu ID é: 445330394188087306");
        }
    }
}
