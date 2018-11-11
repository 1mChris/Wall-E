using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace Wall_E.Comandos.Ultilidades___UBGE
{
    public class Dominar : BaseCommandModule
    {
        [Command("dominar")]

        public async Task DominarUBGE(CommandContext ctx) {
            var embed = new DiscordEmbedBuilder();
            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            DiscordUser UBGEBot = await ctx.Client.GetUserAsync(valores.UBGEBot);

            //Turururururu

            embed.WithColor(cor)
                .WithAuthor("SPARTAAAAAAAAAAAAAAAAA!!! Como dominar o site da Loritta com o upvote de vocês!")
                .WithDescription($"Bem, o servidor da UBGE está no ranking da loritta." +
                $" Se todos nós nos unirmos e dermos um upvote, conseguiremos facilmente chegar no top 1 do server." +
                $" Não é um procedimento difícil, e para ajudar o servidor nos rankings esses são os passos que vocês podem fazer:\n\n" +
                $"``1.`` Digite **+daily** no <#{valores.Comandos_bot}> para obter a moeda da loritta.\n" +
                $"``2.`` Clique nesse link: https://goo.gl/BmnXEK e clique nesses botões:")
                .WithImageUrl("https://cdn.discordapp.com/attachments/242430061330825216/510616284350775306/Botoes.png")
                .WithFooter("Comando requisitado pelo: " + UBGEBot.Username, iconUrl: UBGEBot.AvatarUrl);

            await ctx.RespondAsync(embed: embed);
        }
    }
}