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
    public class ServerInfo
    {
        [Command("Serverinfo")]
        [Aliases("serverinfo", "SERVERINFO")]

        public async Task ServidorInformacoes(CommandContext ctx)
        {
            var servidor = ctx.Guild;
            var embed = new DiscordEmbedBuilder();
            DiscordColor cor;
            cor = new Utilidades.CorDiscordEmbed().randomColor();
            DiscordUser self = ctx.Member;
            embed.WithAuthor($"Informações do servidor {servidor.Name}")
                .AddField("🗺️ Região:", $"{servidor.RegionId}")
                .AddField("👑 Criador:", $"{servidor.Owner.Mention}")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}
