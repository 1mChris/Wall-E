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
    public class AddTageRemoveTagCargos : BaseCommandModule
    {
        [Command("addtag")]
        [Aliases("adicionartag")]

        public async Task AddTagCargosUBGE(CommandContext ctx, String jogo, DiscordMember Membro) {
            if (Membro == null) {
                Membro = ctx.Member;
            }

            Dictionary<string, ulong> dicionario = JsonConvert.DeserializeObject<Dictionary<string, ulong>>(File.ReadAllText(Directory.GetCurrentDirectory() + @"\Cargos.json"));
            var guild = await ctx.Client.GetGuildAsync(460875483442184212);
            var log = guild.GetChannel(valores.IdLogWall_E);
            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            DiscordUser self = ctx.Member;
            embed.WithColor(cor)
                .WithAuthor("Tag Adicionada!", null, "https://cdn.discordapp.com/attachments/443159405991821323/468136624736174080/Logo_UBGE_2.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/387000033100300299.png?v=1")
                .AddField($"A tag do {jogo} foi adicionada com sucesso!", $"Parabéns pela tag {ctx.Member.Mention}, mas **atenção!**: Não faça spam nem flood com essa tag, pois acarretará punições para você.")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);
            if (dicionario.Keys.Contains(jogo.ToLower())) {
                DiscordRole r = ctx.Guild.GetRole(dicionario[jogo]);
                if (Membro.Roles.Contains(r)) {
                    var embed2 = new DiscordEmbedBuilder();
                    embed2.WithColor(cor)
                        .WithAuthor("Erro!", null, "https://cdn.discordapp.com/attachments/452508980896333825/468940279068491777/Alert-icon.png")
                        .WithDescription("Você já tem esse cargo!")
                        .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);
                    await ctx.RespondAsync(embed: embed2);
                }
                else {
                    await Membro.GrantRoleAsync(r, null);
                    await ctx.RespondAsync(embed: embed);
                    await log.SendMessageAsync($"O membro `{ctx.Member.DisplayName}` pegou a tag `{jogo}`.\nCanal: `{ctx.Channel}`.");
                }
            }
            else {
                var embed3 = new DiscordEmbedBuilder();
                embed3.WithColor(cor)
                        .WithAuthor("Erro!", null, "https://cdn.discordapp.com/attachments/452508980896333825/468940279068491777/Alert-icon.png")
                        .WithDescription("Desculpe, esse jogo não tem ou não existe um cargo.")
                        .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);
                await ctx.RespondAsync(embed: embed3);
            }
        }

        [Command("removetag")]
        [Aliases("removertag")]

        public async Task RemoveTagCargosUBGE(CommandContext ctx, String jogo, DiscordMember Membro) {
            if (Membro == null) {
                Membro = ctx.Member;
            }

            Dictionary<string, ulong> dicionario = JsonConvert.DeserializeObject<Dictionary<string, ulong>>(File.ReadAllText(Directory.GetCurrentDirectory() + @"\Cargos.json"));
            var guild = await ctx.Client.GetGuildAsync(460875483442184212);
            var log = guild.GetChannel(valores.IdLogWall_E);
            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            DiscordUser self = ctx.Member;
            embed.WithColor(cor)
                .WithAuthor("Tag Removida.", null, "https://cdn.discordapp.com/attachments/443159405991821323/468136624736174080/Logo_UBGE_2.png")
                .WithThumbnailUrl("https://cdn.shopify.com/s/files/1/1061/1924/products/Confused_Face_Emoji_large.png?v=1480481051")
                .AddField($"A tag do {jogo} foi removida com sucesso :/", $"{ctx.Member.Mention}, uma pena que você removeu a tag, espero que futuramente você queira adicionar denovo.")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);
            if (dicionario.Keys.Contains(jogo.ToLower())) {
                DiscordRole r = ctx.Guild.GetRole(dicionario[jogo]);
                if (!(Membro.Roles.Contains(r))) {
                    var embed2 = new DiscordEmbedBuilder();
                    embed2.WithColor(cor)
                        .WithAuthor("Erro!", null, "https://cdn.discordapp.com/attachments/452508980896333825/468940279068491777/Alert-icon.png")
                        .WithDescription("Seu cargo já foi removido há muito tempo! Não tenho nada pra remover.")
                        .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);
                    await ctx.RespondAsync(embed: embed2);
                }
                else {
                    await Membro.RevokeRoleAsync(r, null);
                    await ctx.RespondAsync(embed: embed);
                    await log.SendMessageAsync($"O membro `{ctx.Member.DisplayName}` removeu a tag `{jogo}`.\nCanal: `{ctx.Channel}`.");
                }
            }
            else {
                var embed3 = new DiscordEmbedBuilder();
                embed3.WithColor(cor)
                        .WithAuthor("Erro!", null, "https://cdn.discordapp.com/attachments/452508980896333825/468940279068491777/Alert-icon.png")
                        .WithDescription("Desculpe, seu cargo pode ter sido removido há muito tempo ou você digitou o comando errado... Ou esse cargo não existe.")
                        .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);
                await ctx.RespondAsync(embed: embed3);
            }
        }

        [Command("vertag")]
        [Aliases("olhartag", "listartag", "listartags")]

        public async Task VerTag(CommandContext ctx) {
            Dictionary<string, ulong> dicionario = JsonConvert.DeserializeObject<Dictionary<string, ulong>>(File.ReadAllText(Directory.GetCurrentDirectory() + @"\Cargos.json"));
            String Texto = $"";
            var embed = new DiscordEmbedBuilder();
            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            DiscordGuild UBGE = ctx.Member.Guild;
            DiscordUser self = ctx.Member;

            dicionario.Values.Distinct().ToList().ForEach(d => {
                DiscordRole R = ctx.Guild.GetRole(d);
                Texto += $"**/addtag** {dicionario.FirstOrDefault(f => f.Value == d).Key} - {R.Mention}\n";
            });

            embed.WithColor(cor)
                .WithAuthor($"Tags disponíveis para adicionar no servidor: {UBGE.Name}", null, UBGE.IconUrl)
                .WithDescription(Texto)
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}