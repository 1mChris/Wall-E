using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Wall_E.Comandos
{
    public class Extras
    {
        public YoutubeAPI YoutubeApi { get; } = new YoutubeAPI("AIzaSyCFUVnPDH9uL5Z59lcr6MVOgOqA_JfbHP4", 10);

        [Command("Pesquisa")]
        [Aliases("pesquisa", "Pesquisar", "pesquisar", "PESQUISA", "PESQUISAR")]

        public async Task Pesquisa(CommandContext ctx, [RemainingText] string pesquisa = null)
        {
            var embed = new DiscordEmbedBuilder();
            DiscordUser self = ctx.Member;
            DiscordColor cor;
            cor = new Utilidades.CorDiscordEmbed().randomColor();

            if (string.IsNullOrEmpty(pesquisa))
            {
                await ctx.RespondAsync($"{ctx.Member.Mention} infelizmente sua pesquisa foi inválida. Tente novamente quando quiser.");
                return;
            }

            var resultados = (await YoutubeApi.SearchAsync(pesquisa)).ToArray();
            var mensagem = "";

            for (int i = 0; i <= 9; i++)
            {
                mensagem += $"`{i+1}.` - {resultados[i].Title} - Enviado por: **{resultados[i].Author}**\n";
            }
            embed.WithColor(cor)
                .WithDescription(mensagem)
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(mensagem);
        }
    }
}
