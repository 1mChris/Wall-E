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
    public class Aliados
    {
        [Command("Aliados")]
        [Aliases("aliados")]

        public async Task AliadosdaUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("Discords parceiros da UBGE:\n\n-**MundoGamer**\nhttps://discord.gg/uv3VC2U\n\n-**Legion Brazilian**\n(Robocraft)\nhttps://discord.gg/4MtMysK");
        }
    }
}
