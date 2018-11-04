using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class BOI : BaseCommandModule
    {
        [Command("boi")]

        public async Task YeahBoi(CommandContext ctx) {
            var embed = new DiscordEmbedBuilder();
            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            DiscordUser self = ctx.Member;

            embed.WithColor(cor)
                .WithImageUrl("https://i.ytimg.com/vi/ezShTla3Qts/maxresdefault.jpg")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}
