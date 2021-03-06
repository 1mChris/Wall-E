﻿using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Foxhole : BaseCommandModule
    {
        [Command("foxholeajuda")]

        public async Task FoxholeUBGE(CommandContext ctx) {
            await ctx.RespondAsync("**Guia rápido do jogo em português:** https://goo.gl/jHqssj\n\nSe deseja entrar em nosso núcleo de Foxhole, leia o seguinte documento: https://docs.google.com/document/d/17rVkzWAjYJOUi0xIkZqz_Pspaa0Ol7mEcefxbeYx8VQ/edit?usp=sharing");
        }
    }
}