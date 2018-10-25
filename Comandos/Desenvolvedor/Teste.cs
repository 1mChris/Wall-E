using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;

namespace Wall_E.Comandos.Desenvolvedor
{
    public class Teste : BaseCommandModule
    {
        [Command("teste")]

        public async Task Legal(CommandContext ctx) {
            var NucleoProcessador = Environment.ProcessorCount;
            var VersaoOS = Environment.OSVersion;
            var NomedoPC = Environment.MachineName;

            await ctx.RespondAsync($"{NomedoPC}\n{VersaoOS}\n{NucleoProcessador}");
        }
    }
}
