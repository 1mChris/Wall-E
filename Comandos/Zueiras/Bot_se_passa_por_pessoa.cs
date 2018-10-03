using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Bot_se_passa_por_pessoa
    {
        [Command("Say")]
        [Aliases("Talk", "Fale", "SAY", "say", "talk", "TALK", "FALE", "fale")]

        public async Task FalaPessoaTexto(CommandContext ctx, DiscordChannel canal = null, [RemainingText] string textopessoa = null)
        {
            await canal.SendMessageAsync(textopessoa);
        }

        [Command("Embed")]
        [Aliases("EMBED", "embed")]

        public async Task FalaEmbedPessoa(CommandContext ctx, [RemainingText] string textopessoaembed = null)
        {
            var embed = new DiscordEmbedBuilder();
            DiscordColor cor;
            cor = new Utilidades.CorDiscordEmbed().randomColor();
            embed.WithColor(cor)
                .WithDescription(textopessoaembed);
            await ctx.RespondAsync(embed: embed);
        }
    }
}
