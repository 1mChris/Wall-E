using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System.Net.Sockets;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Wall_E.Comandos.Extras_das_Secretarias
{
    public class IRC_Servidores
    {
        public static string IP = "irc.quakenet.org";
        private static int Porta = 6667;
        private static string Usuario = "USER IRCbot 0 * :IRCbot";
        private static string Nome = "Wall-E";
        private static string Canal = "#servidores.ubge";

        [Command("irc"), RequireRolesAttribute("Administradores", "Diretores Comunitários", "Ajudantes Comunitários", "Secretaria de OpenSpades")]
        [Aliases("IRC", "Irc")]

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
                IRC = new TcpClient(IP, Porta);
                NS = IRC.GetStream();
                Reader = new StreamReader(NS);
                Writer = new StreamWriter(NS);
                Writer.WriteLine($"NICK {Nome}");
                Writer.Flush();
                Writer.WriteLine(Usuario);
                Writer.Flush();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[IRC] [UBGE-Servidores] [Wall-E] [Discord] | A conexão com o servidores: \"TOW, Arena, Semanal\" foi estabelecida com sucesso!");
                Console.ResetColor();
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
                            if (InputLine.Contains(":UBGE-Arena!~UBGE-Aren@179.218.243.249 PRIVMSG #servidores.ubge :"))
                            {
                                await Arena_Chat.SendMessageAsync($"[UBGE-Arena] | ``{DateTime.Now}`` [-] {InputLine.Replace(":UBGE-Arena!~UBGE-Aren@179.218.243.249 PRIVMSG #servidores.ubge :", "")}");
                            }
                            if (InputLine.Contains(":UBGE-Semanal!~UBGE-Sema@179.218.243.249 PRIVMSG #servidores.ubge :"))
                            {
                                await Semanal_Chat.SendMessageAsync($"[UBGE-Semanal] | ``{DateTime.Now}`` [-] {InputLine.Replace(":UBGE-Semanal!~UBGE-Sema@179.218.243.249 PRIVMSG #servidores.ubge :", "")}");
                            }
                        }

                        string[] splitInput = InputLine.Split(' ');

                        if (splitInput[0] == "PING") {
                            string Resposta = splitInput[1];
                            Writer.WriteLine($"PONG {Resposta}");
                            Writer.Flush();
                        }

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
                Console.WriteLine($"[IRC] [UBGE-Servidores] [Wall-E] [Discord] | A conexão com o servidores: \"TOW, Arena, Semanal\" não foi estabelecida com sucesso.\nErro: {ex.ToString()}");
                Console.ResetColor();
                await Secretaria_OpenSpades.SendMessageAsync($"**[IRC] [UBGE-Servidores] [Wall-E] [Discord]** **|** A conexão com o servidores: ``TOW``, ``Arena``, ``Semanal`` não foi estabelecida com sucesso.\n\n**Erro:**\n```{ex.ToString()}```");
                await Log.SendMessageAsync($"**[IRC] [UBGE-Servidores] [Wall-E] [Discord]** **|** A conexão com o servidores: ``TOW``, ``Arena``, ``Semanal`` não foi estabelecida com sucesso.\n\n**Erro:**\n```{ex.ToString()}```");
                Thread.Sleep(5000);
                string[] argv = { };
            }
        }
    }
}
