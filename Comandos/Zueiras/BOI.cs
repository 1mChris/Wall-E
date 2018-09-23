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
    public class BOI
    {
        [Command("Boi")]
        [Aliases("boi", "BOI")]

        public async Task YeahBoi(CommandContext ctx)
        {
            await ctx.RespondWithFileAsync(new FileStream("C:\\Users\\Luiz\\Desktop\\Wall-E\\Wall-E\\Imagens Jogos\\maxresdefault.jpg", FileMode.Open, FileAccess.Read));
        }
    }
}
