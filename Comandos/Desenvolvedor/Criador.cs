using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Criador
    {
        [Command("Criador")]
        [Aliases("criador", "progenitor", "Progenitor", "Desenvolvedor", "desenvolvedor", "CRIADOR")]

        public async Task Umavidaagradável(CommandContext ctx) {
            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            var embed = new DiscordEmbedBuilder();
            embed.WithColor(cor)
                .WithDescription($"Meu criador não é o Niko Bellic (kkkkkk), o nome dele é Luiz Fernando, __*Perfil*__: <@{valores.Luiz_Criador_ID}>, a foto dele no discord é essa que está ao lado, ele faz parte da secretaria de OpenSpades, não sei se perceberam mas o Luiz fez uma referência ao filme 'Wall-E', por isso meu nome é esse.\n\nAh e outra coisa, fui feito primeiramente em python com a ajuda do <@218752828372549633>, depois me refizeram em C# com a ajuda do <@155774074885242880> ;)")
                .WithAuthor("Luiz Fernando")
                .WithThumbnailUrl("https://cdn.discordapp.com/attachments/446443297972682763/449391138005188609/NikoBellic-GTAIV.jpg");
            await ctx.RespondAsync(embed: embed);
        }
    }
}
