using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class ServerInfo
    {
        [Command("Serverinfo")]
        [Aliases("serverinfo", "SERVERINFO")]

        public async Task ServidorInformacoes(CommandContext ctx) {
            var servidor = ctx.Guild;
            var embed = new DiscordEmbedBuilder();
            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            DiscordUser self = ctx.Member;
            embed.WithAuthor($"Informações do servidor {servidor.Name}")
                .WithColor(cor)
                .WithDescription($"**Criador:** {servidor.Owner.Mention}\n**Membros:** `{servidor.MemberCount}`\n**Região do servidor:** `{servidor.RegionId}`\n**Nível de verificação:** `{servidor.VerificationLevel}`\n**Verificação multi-fator:** `{servidor.MfaLevel}`\n**Quantidade de emojis:** `{servidor.Emojis.Count}`\n**ID do servidor:** `{servidor.Id}`\n**Quantidade de cargos:** `{servidor.Roles.Count}`\n**Canal de ausentes:** `0`\n**Quantidade de canais:** `{servidor.Channels.Count}`\n**Configurações de notificações padrão:** `{servidor.DefaultMessageNotifications}`\n**Servidor grande?:** `{servidor.IsLarge}`")
                .WithThumbnailUrl(servidor.IconUrl)
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}