using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class FoxholeEsquadrõesEntrareSair
    {
        [Command("fox-entrar")]
        [Aliases("Fox-Entrar", "FOX-ENTRAR", "FOX-Esquadrão", "fox-esquadrão", "FOX-ESQUADRÃO", "FOX-ENTRA", "Fox-Entra", "fox-entra", "F-E", "f-e")]

        public async Task EntrarEsquadrãoUBGEFoxhole(CommandContext ctx, [RemainingText] string squad = "listar") {
            Dictionary<string, ulong> dicionariofoxhole = JsonConvert.DeserializeObject<Dictionary<string, ulong>>(File.ReadAllText(Directory.GetCurrentDirectory() + @"\FoxholeEsquadroes.json"));
            String TextoEsquadroes = $"";
            bool block = false;
            dicionariofoxhole.Values.Distinct().ToList().ForEach(u => {
                DiscordRole r = ctx.Guild.GetRole(u);
                TextoEsquadroes += $"/fox-entrar {dicionariofoxhole.FirstOrDefault(s => s.Value == u).Key} - {r.Mention}\n";
            });

            var EmbedListar = new DiscordEmbedBuilder();
            var EmbedEntrou = new DiscordEmbedBuilder();
            var EmbedParticipa = new DiscordEmbedBuilder();
            var EmbednotMembro = new DiscordEmbedBuilder();

            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            DiscordUser self = ctx.Member;
            DiscordRole MembroCla = ctx.Guild.GetRole(352296287493947402);

            EmbednotMembro
                .WithDescription("Você só pode entrar em um esquadrão se já for membro do clã.\n\nPara entrar é muito fácil! Veja as instruções no canal <#416041012645855262>, e caso tenha qualquer dúvida, fale com algum membro da <@&316723010818277376>.")
                .WithColor(cor)
                .WithAuthor("Erro!", null, "https://cdn.discordapp.com/attachments/452508980896333825/468940279068491777/Alert-icon.png")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            EmbedListar
                .WithDescription($"{TextoEsquadroes}")
                .WithColor(cor)
                .WithAuthor("Lista dos Esquadrões do Foxhole na UBGE")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            EmbedParticipa
                .WithAuthor("Erro!", null, "https://cdn.discordapp.com/attachments/452508980896333825/468940279068491777/Alert-icon.png")
                .WithDescription("Você ja participa de um esquadrão!")
                .WithColor(cor)
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);

            if (squad != "listar") {
                EmbedEntrou
                .WithAuthor($"Tag do esquadrão foi adicionado com sucesso!", null, "https://cdn.discordapp.com/emojis/450829956063166474.png?v=1")
                .WithDescription($"O Esquadrão `{ctx.Guild.GetRole(dicionariofoxhole[squad]).Name}` agradece a sua escolha!")
                .WithColor(cor)
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            }
            if (squad == "listar") {
                await ctx.RespondAsync(embed: EmbedListar);
            }
            else {
                if (ctx.Member.Roles.Contains(MembroCla)) {
                    ctx.Member.Roles.Distinct().ToList().ForEach(r => {
                        if (!block) {
                            if (dicionariofoxhole.Values.Contains(r.Id)) {
                                block = true;
                            }
                        }
                    });
                    if (block) {
                        await ctx.RespondAsync(embed: EmbedParticipa);
                    }
                    else {
                        if (dicionariofoxhole.Keys.Contains(squad.ToString())) {
                            await ctx.Member.GrantRoleAsync(ctx.Guild.GetRole(dicionariofoxhole[squad]));
                            await ctx.RespondAsync(embed: EmbedEntrou);
                        }
                    }
                }
                else {
                    await ctx.RespondAsync(embed: EmbednotMembro);
                }
            }
        }

        [Command("fox-sair")]
        [Aliases("FOX-SAIR", "Fox-sair", "Fox-Sair")]

        public async Task SairDoEsquadrãoFoxholeUBGE(CommandContext ctx, [RemainingText] string squad = "listar") {
            Dictionary<string, ulong> dicionariofoxhole = JsonConvert.DeserializeObject<Dictionary<string, ulong>>(File.ReadAllText(Directory.GetCurrentDirectory() + @"\FoxholeEsquadroes.json"));
            dicionariofoxhole.Values.Distinct().ToList().ForEach(u => {
                DiscordRole r = ctx.Guild.GetRole(u);
            });

            var embedesquadraosaiu = new DiscordEmbedBuilder();
            var semmembrodocla = new DiscordEmbedBuilder();
            var naotemocargo = new DiscordEmbedBuilder();
            var emojo = DiscordEmoji.FromName(ctx.Client, ":thinking:");

            var Formigas = ctx.Guild.GetRole(valores.IdFormigas);
            var Canivetes = ctx.Guild.GetRole(valores.IdCanivetes);
            var Tuiti = ctx.Guild.GetRole(valores.IdTuiti);
            var DivisaoTatica = ctx.Guild.GetRole(valores.IdDivisaoTatica);

            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            DiscordUser self = ctx.Member;
            DiscordRole MembroCla = ctx.Guild.GetRole(352296287493947402);

            embedesquadraosaiu.WithColor(cor)
                .WithAuthor($"Tag do esquadrão foi removida com sucesso.", null, "https://cdn.discordapp.com/emojis/450829956063166474.png?v=1")
                .WithDescription($"Removi a tag do esquadrão `{ctx.Guild.GetRole(dicionariofoxhole[squad]).Name}` para você, se quiser entrar em outro esquadrão, digite /fox-entrar `(squad)`.\n\n**Esquadrões:**\n/fox-entrar `Formigas`\n/fox-entrar `Canivete`\n/fox-entrar `DivisãoTática`\n/fox-entrar `Tuiti`\n/fox-entrar `BlackDragon`")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            semmembrodocla.WithColor(cor)
                .WithAuthor("Erro!", null, "https://cdn.discordapp.com/attachments/452508980896333825/468940279068491777/Alert-icon.png")
                .WithDescription($"Como isso é possível? Você não tem a tag <@&352296287493947402> e está em um esquadrão e quer sair dele... {emojo}\n\nConsiga a tag <@&352296287493947402> depois tente novamente dar o comando.")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            naotemocargo.WithColor(cor)
                .WithAuthor("Erro!", null, "https://cdn.discordapp.com/attachments/452508980896333825/468940279068491777/Alert-icon.png")
                .WithDescription("Você não tem a tag: <@&352296287493947402> ou você não está em nenhum esquadrão. Ou você tem a tag de algum esquadrão, mas não tem a tag de membro do clã.\n\nPeça para alguém da <@&316723010818277376> verificar seus cargos e ver o que está acontecendo.")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);

            if (!(ctx.Member.Roles.Contains(MembroCla))) {
                await ctx.RespondAsync(embed: naotemocargo);
            }
            else if (ctx.Member.Roles.Contains(MembroCla)) {
                await ctx.Member.RevokeRoleAsync(ctx.Guild.GetRole(dicionariofoxhole[squad]));
                await ctx.RespondAsync(embed: embedesquadraosaiu);
            }
        }
    }
}