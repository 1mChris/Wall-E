﻿using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Doar : BaseCommandModule
    {
        [Command("doar")]

        public async Task DoarUBGE(CommandContext ctx) {
            await ctx.RespondAsync("**BANCO DO BRASIL:**\nBanco: 001\nConta poupança: 44313-1\nVariação: 51\nAgência: 0598-3\nTitular: Léo Schaeffer Rodrigues de Freitas\nCPF: 184.608.867/43\n\n**PAYPAL:**\nhttps://goo.gl/kx1yu8\n\n**https://www.ubge.org/contato**");
        }
    }
}
