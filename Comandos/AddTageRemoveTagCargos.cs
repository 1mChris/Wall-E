using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class AddTageRemoveTagCargos
    {
        [Command("addtag")]
        [Aliases("ADDTAG", "ADICIONARTAG", "Addtag", "Adicionartag")]

        public async Task AddTagCargosUBGE(CommandContext ctx, String jogo)
        {
            Dictionary<string, ulong> dicionario = JsonConvert.DeserializeObject<Dictionary<string, ulong>>(File.ReadAllText(Directory.GetCurrentDirectory() + @"\Cargos.json"));
            var guild = await ctx.Client.GetGuildAsync(460875483442184212);
            var log = guild.GetChannel(valores.IdLogWall_E);
            DiscordColor cor;
            cor = new Utilidades.CorDiscordEmbed().randomColor();
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.WithColor(cor)
                .WithAuthor("Tag Adicionada!", null, "https://cdn.discordapp.com/attachments/443159405991821323/468136624736174080/Logo_UBGE_2.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/emojis/387000033100300299.png?v=1")
                .AddField($"A tag do {jogo} foi adicionada com sucesso!", $"Parabéns pela tag {ctx.Member.Mention}, mas **atenção!**: Não faça spam nem flood com essa tag, pois acarretará punições para você.");
            if (dicionario.Keys.Contains(jogo.ToLower()))
            {
                DiscordMember m = ctx.Member;
                DiscordRole r = ctx.Guild.GetRole(dicionario[jogo]);
                if (m.Roles.Contains(r))
                {
                    var embed2 = new DiscordEmbedBuilder();
                    embed2.WithColor(cor)
                        .WithAuthor("Erro!", null, "https://cdn.discordapp.com/attachments/452508980896333825/468940279068491777/Alert-icon.png")
                        .WithDescription("Você já tem esse cargo!");
                    await ctx.RespondAsync(embed: embed2);
                }
                else
                {
                    await ctx.Guild.GrantRoleAsync(m, r, null);
                    await ctx.RespondAsync(embed: embed);
                    await log.SendMessageAsync($"O membro `{ctx.Member.DisplayName}` pegou a tag `{jogo}`.\nCanal: `{ctx.Channel}`.");
                }
            }
            else
            {
                var embed3 = new DiscordEmbedBuilder();
                embed3.WithColor(cor)
                        .WithAuthor("Erro!", null, "https://cdn.discordapp.com/attachments/452508980896333825/468940279068491777/Alert-icon.png")
                        .WithDescription("Desculpe, esse jogo não tem ou não existe um cargo.");
                await ctx.RespondAsync(embed: embed3);
            }
        }

        [Command("removetag")]
        [Aliases("REMOVETAG", "REMOVERTAG", "Removetag", "Removertag")]

        public async Task RemoveTagCargosUBGE(CommandContext ctx, String jogo)
        {
            Dictionary<string, ulong> dicionario = JsonConvert.DeserializeObject<Dictionary<string, ulong>>(File.ReadAllText(Directory.GetCurrentDirectory() + @"\Cargos.json"));
            var guild = await ctx.Client.GetGuildAsync(460875483442184212);
            var log = guild.GetChannel(valores.IdLogWall_E);
            DiscordColor cor;
            cor = new Utilidades.CorDiscordEmbed().randomColor();
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.WithColor(cor)
                .WithAuthor("Tag Removida.", null, "https://cdn.discordapp.com/attachments/443159405991821323/468136624736174080/Logo_UBGE_2.png")
                .WithThumbnailUrl("https://cdn.shopify.com/s/files/1/1061/1924/products/Confused_Face_Emoji_large.png?v=1480481051")
                .AddField($"A tag do {jogo} foi removida com sucesso :/", $"{ctx.Member.Mention}, uma pena que você removeu a tag, espero que futuramente você queira adicionar denovo.");
            if (dicionario.Keys.Contains(jogo.ToLower()))
            {
                DiscordMember m = ctx.Member;
                DiscordRole r = ctx.Guild.GetRole(dicionario[jogo]);
                if (!(m.Roles.Contains(r)))
                {
                    var embed2 = new DiscordEmbedBuilder();
                    embed2.WithColor(cor)
                        .WithAuthor("Erro!", null, "https://cdn.discordapp.com/attachments/452508980896333825/468940279068491777/Alert-icon.png")
                        .WithDescription("Seu cargo já foi removido há muito tempo! Não tenho nada pra remover.");
                    await ctx.RespondAsync(embed: embed2);
                }
                else
                {
                    await ctx.Guild.RevokeRoleAsync(m, r, null);
                    await ctx.RespondAsync(embed: embed);
                    await log.SendMessageAsync($"O membro `{ctx.Member.DisplayName}` removeu a tag `{jogo}`.\nCanal: `{ctx.Channel}`.");
                }
            }
            else
            {
                var embed3 = new DiscordEmbedBuilder();
                embed3.WithColor(cor)
                        .WithAuthor("Erro!", null, "https://cdn.discordapp.com/attachments/452508980896333825/468940279068491777/Alert-icon.png")
                        .WithDescription("Desculpe, seu cargo pode ter sido removido há muito tempo ou você digitou o comando errado... Ou esse cargo não existe.");
                await ctx.RespondAsync(embed: embed3);
            }
        }
    }
}