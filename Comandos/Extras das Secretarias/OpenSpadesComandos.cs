using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    [Group("os")]

    public class OpenSpadesComandosDiscord : BaseCommandModule
    {
        public static string IP = "irc.quakenet.org";
        private static int Porta = 6667;
        private static string Usuario = "USER IRCbot 0 * :IRCbot";
        private static string Nome = "Wall-E";
        private static string Canal = "#servidores.ubge";
        public static bool Conectado;

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

        [Command("irc"), RequireRoles(RoleCheckMode.Any, "Diretores Comunitários", "Administradores", "Ajudantes Comunitários", "Secretaria de OpenSpades")]

        public async Task IRC_dos_Servidores(CommandContext ctx) {
            DiscordChannel TOW_Chat = ctx.Guild.GetChannel(valores.tow_chat);
            DiscordChannel Arena_Chat = ctx.Guild.GetChannel(valores.arena_chat);
            DiscordChannel Semanal_Chat = ctx.Guild.GetChannel(valores.semanal_chat);
            DiscordChannel Secretaria_OpenSpades = ctx.Guild.GetChannel(valores.secretaria_openspades_chat);
            DiscordChannel Log = ctx.Guild.GetChannel(valores.IdLogWall_E);

            NetworkStream NS;
            TcpClient IRC;
            string InputLine;
            StreamReader Reader;
            StreamWriter Writer;

            try {
                Console.WriteLine("[IRC] [UBGE-Servidores] [Wall-E] Logando no IRC...");
                IRC = new TcpClient(IP, Porta);
                NS = IRC.GetStream();
                Reader = new StreamReader(NS);
                Writer = new StreamWriter(NS);
                Writer.WriteLine($"NICK {Nome}");
                Writer.Flush();
                Writer.WriteLine(Usuario);
                Console.WriteLine("[IRC] [UBGE-Servidores] [Wall-E] Logado no IRC! Conectando...");
                Writer.Flush();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[IRC] [UBGE-Servidores] [Wall-E] [Discord] | A conexão com o servidores: \"TOW, Arena, Semanal\" foi estabelecida com sucesso!");
                Console.ResetColor();
                Conectado = true;
                await Secretaria_OpenSpades.SendMessageAsync($"**[IRC] [UBGE-Servidores] [Wall-E] [Discord]** **|** A conexão com o servidores: ``TOW``, ``Arena``, ``Semanal`` foi estabelecida com sucesso! Chat's sendo enviado no: <#{valores.tow_chat}>, <#{valores.arena_chat}>, <#{valores.semanal_chat}>");

                while (true) {
                    while ((InputLine = Reader.ReadLine()) != null) {
                        if (InputLine.Contains("PING :port80a.se.quakenet.org") || InputLine.Contains("PING :port80c.se.quakenet.org") || InputLine.Contains("PING :underworld1.no.quakenet.org") || InputLine.Contains("PING :underworld2.no.quakenet.org") || InputLine.Contains("PING :cymru.us.quakenet.org") || InputLine.Contains("PING :dreamhack.se.quakenet.org")) {
                            InputLine.Replace("PING :port80a.se.quakenet.org", "");
                            InputLine.Replace("PING :port80c.se.quakenet.org", "");
                            InputLine.Replace("PING :underworld1.no.quakenet.org", "");
                            InputLine.Replace("PING :underworld2.no.quakenet.org", "");
                            InputLine.Replace("PING :cymru.us.quakenet.org", "");
                            InputLine.Replace("PING :dreamhack.se.quakenet.org", "");
                        }
                        else {
                            if (InputLine.Contains(":UBGE-ToW!~UBGE-ToW@179.218.243.249 PRIVMSG #servidores.ubge :")) {
                                await TOW_Chat.SendMessageAsync($"[UBGE-TOW] | ``{DateTime.Now}`` [-] {InputLine.Replace(":UBGE-ToW!~UBGE-ToW@179.218.243.249 PRIVMSG #servidores.ubge :", "")}");
                            }
                            if (InputLine.Contains(":UBGE-Arena!~UBGE-Aren@179.218.243.249 PRIVMSG #servidores.ubge :")) {
                                await Arena_Chat.SendMessageAsync($"[UBGE-Arena] | ``{DateTime.Now}`` [-] {InputLine.Replace(":UBGE-Arena!~UBGE-Aren@179.218.243.249 PRIVMSG #servidores.ubge :", "")}");
                            }
                            if (InputLine.Contains(":UBGE-Semanal!~UBGE-Sema@179.218.243.249 PRIVMSG #servidores.ubge :")) {
                                await Semanal_Chat.SendMessageAsync($"[UBGE-Semanal] | ``{DateTime.Now}`` [-] {InputLine.Replace(":UBGE-Semanal!~UBGE-Sema@179.218.243.249 PRIVMSG #servidores.ubge :", "")}");
                            }
                        }

                        string[] splitInput = InputLine.Split(' ');

                        if (splitInput[0] == "PING") {
                            string Resposta = splitInput[1];
                            Writer.WriteLine($"PONG {Resposta}");
                            Writer.Flush();
                        }
                        Conectado = true;
                        switch (splitInput[1]) { 
                            case "001":
                                Writer.WriteLine($"JOIN {Canal}");
                                Writer.WriteLine("auth Wall-E wall-e2018");
                                Writer.Flush();
                                break;
                            default:
                                break;
                        }
                    }
                    Writer.Close();
                    Reader.Close();
                    IRC.Close();
                }
            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[IRC] [UBGE-Servidores] [Wall-E] [Discord] | A conexão com o servidores: \"TOW, Arena, Semanal\" não foi estabelecida com sucesso.\n\nErro: {ex.ToString()}");
                Conectado = false;
                Console.ResetColor();
                await Secretaria_OpenSpades.SendMessageAsync($"**[IRC] [UBGE-Servidores] [Wall-E] [Discord]** **|** A conexão com o servidores: ``TOW``, ``Arena``, ``Semanal`` não foi estabelecida com sucesso.\n\n**Erro:**\n```{ex.ToString()}```");
                await Log.SendMessageAsync($"**[IRC] [UBGE-Servidores] [Wall-E] [Discord]** **|** A conexão com o servidores: ``TOW``, ``Arena``, ``Semanal`` não foi estabelecida com sucesso.\n\n**Erro:**\n```{ex.ToString()}```");
                Console.WriteLine("[Wall-E] Reiniciando...");
                await ctx.Client.DisconnectAsync();
                await Task.Delay(200);
                await ctx.Client.ConnectAsync();
                Console.WriteLine("[Wall-E] Reiniciei.");
                await Secretaria_OpenSpades.SendMessageAsync("[IRC] [Wall-E] Me auto-reiniciei e o erro foi consertado! Os IRC's estão funcionando novamente e em perfeito estado. *(Fatiou, passou, boa 06)*");
                Console.WriteLine("[IRC] [Wall-E] Me auto-reiniciei e o erro foi consertado! Os IRC's estão funcionando em perfeito estado.");
            }
        }
    }
}