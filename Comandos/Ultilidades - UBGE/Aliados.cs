using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Aliados : BaseCommandModule
    {
        [Command("aliados")]

        public async Task AliadosdaUBGE(CommandContext ctx) {
            await ctx.RespondAsync("Discords parceiros da UBGE:\n\n-**MundoGamer**\nhttps://discord.gg/uv3VC2U\n\n-**Legion Brazilian**\n(Robocraft)\nhttps://discord.gg/4MtMysK");
        }
    }
}
