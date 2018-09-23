using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Angelo
    {
        [Command("Angelo")]
        [Aliases("angelo")]

        public async Task AngeloUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("Águia da Ética :eagle:");
        }
    }

    public class Léo
    {
        [Command("Léo")]
        [Aliases("léo", "Leo", "leo")]

        public async Task LéoDono(CommandContext ctx)
        {
            await ctx.RespondAsync("Deus da Ética\n\nhttps://www.youtube.com/user/LeoFreitas021?feature=mhee");
        }
    }

    public class LuizFeliciano
    {
        [Command("Luiz")]
        [Aliases("luiz")]

        public async Task LuizFelicianoUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("Orador da Ética");
        }
    }

    public class Nicolas
    {
        [Command("Nicolas")]
        [Aliases("nicolas")]

        public async Task NicolasUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("Revolucionário da Ética");
        }
    }

    public class Paulo
    {
        [Command("Paulo")]
        [Aliases("paulo", "somai", "C#")]

        public async Task PauloUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("Programador da Ética, C# da Ética, Somai da Ética");
        }
    }

    public class Wysel
    {
        [Command("Wysel")]
        [Aliases("wysel")]

        public async Task WyselUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("Aviãozinho da Ética :airplane_small:");
        }
    }

    public class LuizWall_E
    {
        [Command("LuizW")]
        [Aliases("luizw", "luizão", "luizao")]

        public async Task LuizdoWallE(CommandContext ctx)
        {
            await ctx.RespondAsync("Compartilhador da Ética");
        }
    }

    public class ThomasdaUBGE
    {
        [Command("Thomas")]
        [Aliases("thomas", "THOMAS")]

        public async Task ThomasUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("Cachorro do Photoshop");
        }
    }
}