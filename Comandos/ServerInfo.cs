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
                .AddField("👫 Membros:", $"{servidor.MemberCount}")
                .AddField("🌎 Região do servidor:", $"{servidor.RegionId}")
                .AddField("🔒 Nível de verificação:", $"{servidor.VerificationLevel}")
                .AddField("🔧 Verificação multi-fator:", $"{servidor.MfaLevel}")
                .AddField("🔝 Quantidade de emojis:", $"{servidor.Emojis.Count}")
                .AddField("🔑 ID do servidor:", $"{servidor.Id}")
                .AddField("📡 Quantidade de cargos:", $"{servidor.Roles.Count}")
                .AddField("📴 Canal de ausentes:", $"{servidor.AfkChannel}")
                .AddField("🔊 Quantidade de canais: `De texto`", $"{servidor.Channels.Count}")
                .AddField("📳 Configurações de notificações padrão:", $"{servidor.DefaultMessageNotifications}")
                .WithThumbnailUrl(servidor.IconUrl)
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}
