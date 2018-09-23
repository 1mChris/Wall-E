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
    public class Denúncia
    {
        [Command("Denuncia")]
        [Aliases("denuncia", "Denúncia", "denúncia")]

        public async Task DenúnciaFormulário(CommandContext ctx)
        {
            await ctx.RespondAsync("https://goo.gl/forms/zssTOBNen8X9wzk12");
        }
    }
}
