using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using static Wall_E.Utilidades.Utilidades;

namespace Wall_E.Comandos
{
    [Group("os")]

    public class OpenSpadesComandosDiscord : BaseCommandModule
    {
        [Command("desban")]

        public async Task DesbanOP(CommandContext ctx) {
            await ctx.RespondAsync("Você foi banido dos servidores da UBGE e quer um possível desban? A secretaria fez um formulário para você preencher para possivelmente você ser desbanido.\n(A secretaria só irá dar 1 chance, se você for banido novamente e estiver usando hack, você não terá outra chance.)\n\nLink: https://docs.google.com/forms/d/e/1FAIpQLSe4IMX-pIUHpnm_VZdrUabI6NNz58gLHUomHV5bifMR2ejshQ/viewform");
        }

        [Command("guard")]

        public async Task GuardOP(CommandContext ctx) {
            await ctx.RespondAsync("Você quer se tornar um guarda nos servidores da UBGE? Faça esse formulário e a secretaria irá discutir seu caso.\n\nLink: https://docs.google.com/forms/d/e/1FAIpQLSc4MPkVKPB3LyGad0CLw9OHPH_oPkcKaBF8XjkgjQj_fv4UTQ/viewform");
        }

        [Command("betterspades")]
        [Aliases("bs")]

        public async Task BetterSpadesOS(CommandContext ctx) {
            await ctx.RespondAsync("O BetterSpades é um launcher leve como o Ace of Spades, mas é um pouco mais bonito e agradável que o mesmo.\n\nTrailer do BetterSpades: https://youtu.be/0DxoJFF6EPE\n\nDownload do mesmo: https://github.com/xtreme8000/BetterSpades/release\n\n*Versão: 0.1.3*");
        }

        [Command("votação")]
        [Aliases("v")]

        public async Task VotacaoOS(CommandContext ctx, [RemainingText] string texto = null) {
            var emojo = DiscordEmoji.FromName(ctx.Client, ":white_check_mark:");
            var emojo2 = DiscordEmoji.FromName(ctx.Client, ":x:");
            DiscordUser self = ctx.Member;
            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            var embed = new DiscordEmbedBuilder();

            embed.WithColor(cor)
                .WithAuthor("Votação:", null, "https://cdn.discordapp.com/attachments/443159405991821323/471879195685814273/images.png")
                .WithDescription(texto)
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);
            await ctx.RespondAsync($"<@&{valores.OpenSpades}>, votação abaixo :point_down:");

            var msgembed = await ctx.RespondAsync(embed: embed);
            await msgembed.CreateReactionAsync(emojo);
            await msgembed.CreateReactionAsync(emojo2);
        }

        [Command("cadastrartime")]
        [Aliases("cadastrartimes", "ct")]

        public async Task CadastrarTimeTorneio(CommandContext ctx, string NomeDoTime, [RemainingText] string Jogadores) {
            if (NomeDoTime == null || Jogadores == null) {
                await ctx.RespondAsync($"{ctx.Member.Mention} **|** Preencha todos os campos!\n\nExemplo: ``/os ct NomeDoTime Jogador1. Jogador2, Jogador3``");
                return;
            }

            int ID_Time = -1;
            bool editar;
            string query;

            editar = ID_Time == -1 ? false : true;

            //Conexão com a base de dados
            SqlCeConnection Conexao = new SqlCeConnection($"Data Source = {Utilidades.Utilidades.DB}");
            Conexao.Open();

            query = "SELECT MAX(ID_Time) AS maxid FROM TabelaTorneio";

            if (!editar) {
                SqlCeDataAdapter Adaptador = new SqlCeDataAdapter(query, Conexao);
                DataTable Tabela = new DataTable();
                Adaptador.Fill(Tabela);

                //Converte a adiciona +1
                if (DBNull.Value.Equals(Tabela.Rows[0][0])) {
                    ID_Time = 0;
                }
                else {
                    ID_Time = Convert.ToInt16(Tabela.Rows[0][0]) + 1;
                }

                SqlCeCommand Comando = new SqlCeCommand();
                Comando.Connection = Conexao;
                
                //Preenche os campos na DB com os parâmetros que o usuário digitou
                Comando.Parameters.AddWithValue("@ID_Time", ID_Time);
                Comando.Parameters.AddWithValue("@NomeDoTime", NomeDoTime);
                Comando.Parameters.AddWithValue("@Jogadores", Jogadores);
                Comando.Parameters.AddWithValue("@Hora_Dia", DateTime.Now);

                Console.WriteLine($"[Wall-E] [SQLCe] Cadastrando o time: \"{NomeDoTime}\"...");

                Comando.CommandText = "INSERT INTO TabelaTorneio VALUES(@ID_Time, @NomeDoTime, @Jogadores, @Hora_Dia)";
                Comando.ExecuteNonQuery();

                Comando.Dispose();
                Conexao.Dispose();

                //Comando.CommandText = "INSERT INTO TabelaTornio VALUES(" +
                //    $"'{ID_Time}', " +
                //    $"'{NomeDoTime}', " +
                //    $"'{Jogadores}', " +
                //    $"'{DateTime.Now}')";

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[Wall-E] [SQLCe] O time: \"{NomeDoTime}\" foi cadastrado com sucesso no banco de dados.");
                Console.ResetColor();

                //Embed
                var embed = new DiscordEmbedBuilder();
                DiscordUser self = ctx.Member;

                embed.WithColor(new DiscordColor(0x32363c))
                    .WithAuthor($"O cadastramento foi realizado com sucesso! Reveja os dados cadastrados:", null, "https://cdn.discordapp.com/attachments/443159405991821323/471879195685814273/images.png")
                    .WithDescription($"**ID do Time:** {ID_Time.ToString()}\n**Time:** {NomeDoTime}\n**Jogadores:** {Jogadores}")
                    .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);

                await ctx.RespondAsync(embed: embed);
            }
        }

        [Command("vertime")]
        [Aliases("vertimes", "vt")]

        public async Task VerTimesTorneio(CommandContext ctx) {
            SqlCeConnection Conexao = new SqlCeConnection($"Data Source = {Utilidades.Utilidades.DB}");
            Conexao.Open();

            Console.WriteLine($"[Wall-E] [SQLCe] Pegando informações do banco de dados...");

            string query = "SELECT * FROM TabelaTorneio";

            SqlCeDataAdapter Adaptador = new SqlCeDataAdapter(query, Conexao);
            DataTable Tabela = new DataTable();
            Adaptador.Fill(Tabela);

            Console.WriteLine($"[Wall-E] [SQLCe] Dados recolhidos com sucesso. Enviando para o Discord...");

            Conexao.Dispose();
            Adaptador.Dispose();

            var embed = new DiscordEmbedBuilder();

            foreach (DataRow dados in Tabela.Rows) {
                embed.WithColor(new DiscordColor(0x32363c))
                    .WithAuthor($"Time: {dados["NomeDoTime"].ToString()}", null, "https://cdn.discordapp.com/attachments/443159405991821323/471879195685814273/images.png")
                    .WithDescription($"**Jogadores:** {dados["Jogadores"].ToString()}");

                await ctx.RespondAsync(embed: embed);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[Wall-E] [SQLCe] Dados recolhidos com sucesso e foram enviados para o Discord!");
            Console.ResetColor();
        }

        [Command("apagartime"), RequireRoles(RoleCheckMode.Any, "Secretaria de OpenSpades")]
        [Aliases("apagartimes", "at")]

        public async Task ApagarTimes(CommandContext ctx) {
            SqlCeConnection Conexao = new SqlCeConnection($"Data Source = {Utilidades.Utilidades.DB}");
            Conexao.Open();

            Console.WriteLine($"[Wall-E] [SQLCe] Apagando todos os dados no banco de dados...");

            string query = "DELETE FROM TabelaTorneio";

            SqlCeCommand Comandos = new SqlCeCommand(query, Conexao);
            Comandos.ExecuteNonQuery();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[Wall-E] [SQLCe] Dados apagados com sucesso.");
            Console.ResetColor();

            var embed = new DiscordEmbedBuilder();

            embed.WithColor(new DiscordColor(0x32363c))
                   .WithAuthor($"Os dados do banco de dados foram apagados com sucesso.", null, "https://cdn.discordapp.com/attachments/443159405991821323/471879195685814273/images.png");

            await ctx.RespondAsync(embed: embed);

            Conexao.Dispose();
            Comandos.Dispose();
        }

        [Command("rank")]

        public async Task RankUBGEServidores(CommandContext ctx) {
            await ctx.TriggerTypingAsync();

            string EndPoint = "https://aoslogin.herokuapp.com/api/v1/ranking/players";

            var RequisicaoWeb = WebRequest.CreateHttp(EndPoint);
            var Embed = new DiscordEmbedBuilder();

            //Como conecta
            RequisicaoWeb.Method = "GET";
            RequisicaoWeb.ContentType = "application/json";
            RequisicaoWeb.Headers.Add("api_key", valores.KeyAPIRankAoS);
            RequisicaoWeb.Accept = "application/json";

            //Foreach servidores
            using (Stream S = RequisicaoWeb.GetResponse().GetResponseStream()) {
                using (StreamReader SR = new StreamReader(S)) {
                    var Resposta = SR.ReadToEnd();
                    DiscordUser self = ctx.Member;
                    int x = 0;

                    //API como um todo
                    List<Membro> API = JsonConvert.DeserializeObject<List<Membro>>(Resposta);

                    string Builder = "\n";

                    //Foreach jogadores
                    Embed.WithColor(0x32363c);
                    foreach (var CARALHO in API) {
                        double RatioFinal = Math.Round((double)CARALHO.TotalKills / (double)(CARALHO.TotalDeaths == 0 ? 1 : CARALHO.TotalDeaths), 2);
                        Builder += $"**{++x}º**: {CARALHO.Name.ToString()} ou <@{Convert.ToInt64(CARALHO.DiscordId)}>\n- Kills: {CARALHO.TotalKills.ToString()} | Deaths: {CARALHO.TotalDeaths.ToString()} | Ratio: {RatioFinal.ToString()}\n\n";
                    }
                    Embed.WithDescription(Builder);
                    Embed.WithAuthor("Rank nos servidores de OpenSpades na UBGE:", null, "https://cdn.discordapp.com/attachments/443159405991821323/471879195685814273/images.png");
                    Embed.WithFooter("Comando requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);

                    await ctx.RespondAsync(embed: Embed);
                }
            }
        }
    }
}           