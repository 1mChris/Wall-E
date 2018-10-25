using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Wall_E.Comandos.Desenvolvedor
{
    public class DesligarBOT : BaseCommandModule
    {
        [Command("desligartempo"), RequireRoles(RoleCheckMode.Any, "Administradores", "Diretores Comunitários", "Ajudantes Comunitários")]

        public async Task DesligarPorTempo(CommandContext ctx, String tempo = null) {
            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            DiscordUser self = ctx.Member;

            if (String.IsNullOrWhiteSpace(tempo)) {
                var temponull = new DiscordEmbedBuilder();
                temponull.WithColor(cor)
                    .WithAuthor("Erro!", null, "https://cdn.discordapp.com/attachments/452508980896333825/468940279068491777/Alert-icon.png")
                    .WithDescription("Diga o tempo que devo ficar em Stand By!")
                    .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);
                await ctx.RespondAsync(embed: temponull);
            }

            var desligado = new DiscordEmbedBuilder();
            var religado = new DiscordEmbedBuilder();
            int display = 0;
            int time = new Utilidades.Utilidades().getTime(tempo);
            String regex = "";

            if (tempo.Contains('s')) {
                display = time / 1000;
                regex = display == 1 ? "Segundo" : "Segundos";
            }
            else if (tempo.Contains('m')) {
                display = (time / 1000) / 60;
                regex = display == 1 ? "Minuto" : "Minutos";
            }
            else if (tempo.Contains('h')) {
                display = ((time / 60) / 60) / 1000;
                regex = display == 1 ? "Hora" : "Horas";
            }

            #region Embeds
            desligado.WithColor(cor)
                .WithAuthor("Desliguei temporariamente, voltarei daqui a pouco", null, "https://cdn.discordapp.com/attachments/438402141132947456/497254644062355466/Wall-ELogo.png")
                .WithDescription($"**Me religarei daqui à: {tempo}**")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);
            religado.WithColor(cor)
                .WithAuthor("Voltei à ativa!", null, "https://cdn.discordapp.com/attachments/438402141132947456/497254644062355466/Wall-ELogo.png")
                .WithDescription("**Estou devolta e em perfeito funcionamento, podem usar meus comandos a vontade!**")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);
            #endregion

            await ctx.RespondAsync(embed: desligado);
            await ctx.Client.DisconnectAsync();
            new Utilidades.Utilidades().Wait(time);
            await ctx.Client.ConnectAsync();
            await ctx.RespondAsync(embed: religado);
        }

        [Command("desligar"), RequireRoles(RoleCheckMode.SpecifiedOnly, "Administradores", "Diretores Comunitários", "Ajudantes Comunitários")]

        public async Task Desligar(CommandContext ctx) {
            await ctx.Client.DisconnectAsync();
        }
    }
}
