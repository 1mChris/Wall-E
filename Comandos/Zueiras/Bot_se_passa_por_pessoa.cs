using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Bot_se_passa_por_pessoa : BaseCommandModule
    {
        [Command("say")]
        [Aliases("talk", "fale")]

        public async Task FalaPessoaTexto(CommandContext ctx, DiscordChannel canal = null, [RemainingText] string textopessoa = null) {
            await canal.SendMessageAsync(textopessoa);
        }

        [Command("embed")]

        public async Task FalaEmbedPessoa(CommandContext ctx, [RemainingText] string textopessoaembed = null) {
            var embed = new DiscordEmbedBuilder();
            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            embed.WithColor(cor)
                .WithDescription(textopessoaembed);
            await ctx.RespondAsync(embed: embed);
        }
    }
}
