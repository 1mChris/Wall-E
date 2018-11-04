using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Angelo : BaseCommandModule
    {
        [Command("angelo")]

        public async Task AngeloUBGE(CommandContext ctx) {
            await ctx.RespondAsync("Águia da Ética :eagle:");
        }
    }

    public class Léo : BaseCommandModule
    {
        [Command("léo")]
        [Aliases("leo")]

        public async Task LéoDono(CommandContext ctx) {
            await ctx.RespondAsync("Deus da Ética\n\nhttps://www.youtube.com/user/LeoFreitas021?feature=mhee");
        }
    }

    public class LuizFeliciano : BaseCommandModule
    {
        [Command("luiz")]

        public async Task LuizFelicianoUBGE(CommandContext ctx) {
            await ctx.RespondAsync("Orador da Ética");
        }
    }

    public class Nicolas : BaseCommandModule
    {
        [Command("nicolas")]

        public async Task NicolasUBGE(CommandContext ctx) {
            await ctx.RespondAsync("Revolucionário da Ética");
        }
    }

    public class Paulo : BaseCommandModule
    {
        [Command("paulo")]
        [Aliases("somai", "c#")]

        public async Task PauloUBGE(CommandContext ctx) {
            await ctx.RespondAsync("Programador da Ética, C# da Ética, Somai da Ética\n\n~~E corno~~");
        }
    }

    public class Wysel : BaseCommandModule
    {
        [Command("wysel")]

        public async Task WyselUBGE(CommandContext ctx) {
            await ctx.RespondAsync("Aviãozinho da Ética :airplane_small:");
        }
    }

    public class LuizWall_E : BaseCommandModule
    {
        [Command("luizw")]
        [Aliases( "luizão", "luizao")]

        public async Task LuizdoWallE(CommandContext ctx) {
            await ctx.RespondAsync("Compartilhador da Ética");
        }
    }

    public class ThomasdaUBGE : BaseCommandModule
    {
        [Command("thomas")]

        public async Task ThomasUBGE(CommandContext ctx) {
            await ctx.RespondAsync("Cachorro do Photoshop");
        }
    }
}