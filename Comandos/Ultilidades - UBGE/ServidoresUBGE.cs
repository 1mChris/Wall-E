using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using MongoDB.Driver;
using QuickType;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wall_E.Bot;

namespace Wall_E.Comandos.Ultilidades___UBGE
{
    public class ServidoresUBGE : BaseCommandModule
    {
        [Command("servidores")]

        public async Task ServidoresUBGEMongo(CommandContext ctx) {
            MongoClient client = new MangoDB().getMongo();
            var db = client.GetDatabase("local");
            var servers = db.GetCollection<Server>("Servers");

            var cursorOpen = await servers.FindAsync(_ => true);
            var resultadosOPen = await cursorOpen.ToListAsync();
            DiscordUser self = ctx.Member;
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();

            foreach (var open in resultadosOPen) {
                embed.AddField($"{open.Jogo}: {open.Nome}", $"**Players**: {open.Players}/{open.MaxJoin}\n**Modo de Jogo**: {open.Gamemode}\n**Versão**: {open.Version}");
            }
            embed.WithAuthor("Servidores da UBGE:");
            embed.WithColor(new DiscordColor(0x006400));
            embed.WithThumbnailUrl("https://cdn.discordapp.com/attachments/294261092836704278/408987087870754825/LOGO_UBGE_2.0b.png");
            embed.WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);

            await ctx.RespondAsync(embed: embed);
        }

        [Command("servers")]
        [Aliases("sv")]

        public async Task ServidoresJogo(CommandContext ctx, string jogo) {
            var client = new MangoDB().getMongo();
            var db = client.GetDatabase("local");
            var servers = db.GetCollection<Server>("Servers");
            var filtroOpen = Builders<Server>.Filter.Eq(x => x.Jogo, jogo);
            var filtrogeral = await servers.Find(_ => true).ToListAsync();
            var cursorOpen = await servers.FindAsync(filtroOpen);
            var resultadosOPen = await cursorOpen.ToListAsync();
            DiscordUser self = ctx.Member;
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();

            if (jogo != "list") {
                if (resultadosOPen.Count == 0) {
                    embed
                        .WithDescription($"A UBGE não possui servidores oficiais no jogo: {jogo}")
                        .WithAuthor("Jogo não encontrado!");
                }
                else {
                    foreach (var open in resultadosOPen) {
                        embed.AddField($"{open.Nome}", $"**Players**: {open.Players}/{open.MaxJoin}\n**Modo de jogo**: {open.Gamemode}\n**Versão**: {open.Version}");
                    }
                    if (jogo == "OpenSpades") {
                        embed.WithAuthor($"Servidores UBGE: {jogo}", null, "https://cdn.discordapp.com/attachments/443159405991821323/471879195685814273/images.png");
                        embed.WithColor(new DiscordColor(0x32363c));
                        embed.WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);
                        embed.WithThumbnailUrl("https://cdn.discordapp.com/attachments/294261092836704278/408987087870754825/LOGO_UBGE_2.0b.png");
                    }
                    else if (jogo == "Minecraft") {
                        embed.WithAuthor($"Servidores UBGE: {jogo}", null, null);
                        embed.WithColor(new DiscordColor(0x32363c));
                        embed.WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);
                        embed.WithThumbnailUrl("https://cdn.discordapp.com/attachments/294261092836704278/408987087870754825/LOGO_UBGE_2.0b.png");
                    }
                    else {
                        embed.WithAuthor($"Servidores UBGE: {jogo}", null, null);
                        embed.WithColor(new DiscordColor(0x32363c));
                        embed.WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);
                        embed.WithThumbnailUrl("https://cdn.discordapp.com/attachments/294261092836704278/408987087870754825/LOGO_UBGE_2.0b.png");
                    }
                }
                await ctx.RespondAsync(embed: embed);
            }
            else {
                embed.WithAuthor("A UBGE possui servidores nos seguintes jogos:");

                List<String> sbuild = new List<string>();
                string esbuild = "";

                foreach (var server in filtrogeral) {
                    if (!sbuild.Contains(server.Jogo)) {
                        sbuild.Add(server.Jogo);
                    }
                }
                foreach (string s in sbuild) {
                    esbuild += $"{s}\n";
                }

                embed.WithDescription(esbuild);
                await ctx.RespondAsync(embed: embed);
            }
        }
    }
}