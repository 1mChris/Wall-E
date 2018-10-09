using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using System.Net;
using System.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using System.IO;
using System.Threading;

namespace Wall_E.Comandos.Extras_das_Secretarias
{
    public class IRC_TOW
    {
        public static string IP = "irc.quakenet.org";
        private static int Porta = 6667;
        private static string Usuario = "USER IRCbot 0 * :IRCbot";
        private static string Nome = "Wall-E_TOW";
        private static string Canal = "#ubge.servidor";

        [Command("towirc"), RequireRolesAttribute("Administradores", "Diretores Comunitários", "Ajudantes Comunitários")]
        [Aliases("TOWIRC", "TowIRC")]

        public async Task IRC_do_TOW(CommandContext ctx)
        {
            DiscordChannel TOW_Chat = ctx.Guild.GetChannel(valores.tow_chat);
            DiscordChannel Secretaria_OpenSpades = ctx.Guild.GetChannel(valores.secretaria_openspades_chat);
            DiscordChannel Log = ctx.Guild.GetChannel(valores.IdLogWall_E);

            NetworkStream NS;
            TcpClient IRC;
            string InputLine;
            StreamReader Reader;
            StreamWriter Writer;

            try
            {
                IRC = new TcpClient(IP, Porta);
                NS = IRC.GetStream();
                Reader = new StreamReader(NS);
                Writer = new StreamWriter(NS);
                Writer.WriteLine($"NICK {Nome}");
                Writer.Flush();
                Writer.WriteLine(Usuario);
                Writer.Flush();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[IRC] [UBGE-TOW] [Wall-E] [Discord] | A conexão com o servidor: \"TOW\" foi estabelecida com sucesso!");
                Console.ResetColor();
                await Secretaria_OpenSpades.SendMessageAsync($"**[IRC] [UBGE-TOW] [Wall-E] [Discord]** **|** A conexão com o servidor: ``TOW`` foi estabelecida com sucesso! Chat sendo enviado no: <#{valores.tow_chat}>");

                while (true)
                {
                    while ((InputLine = Reader.ReadLine()) != null)
                    {
                        if (InputLine.Contains("PING :port80a.se.quakenet.org") || InputLine.Contains("PING :port80c.se.quakenet.org") || InputLine.Contains("PING :underworld1.no.quakenet.org") || InputLine.Contains("PING :underworld2.no.quakenet.org")) {
                            InputLine.Replace("PING :port80a.se.quakenet.org", "");
                            InputLine.Replace("PING :port80c.se.quakenet.org", "");
                            InputLine.Replace("PING :underworld1.no.quakenet.org", "");
                            InputLine.Replace("PING :underworld2.no.quakenet.org", "");
                        }
                        else {
                            await TOW_Chat.SendMessageAsync($"[UBGE-TOW] | ``{DateTime.Now}`` [-] {InputLine.Replace(":UBGE-ToW!~UBGE-ToW@179.218.243.249 PRIVMSG #ubge.servidor :", "")}");
                        }
                           string[] splitInput = InputLine.Split(new Char[] {
                           ' '
                        });
                        if (splitInput[0] == "PING")
                        {
                            string Resposta = splitInput[1];
                            Writer.WriteLine($"PONG {Resposta}");
                            Writer.Flush();
                        }

                        switch (splitInput[1])
                        {
                            case "001":
                                Writer.WriteLine($"JOIN {Canal}");
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
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[IRC] [UBGE-TOW] [Wall-E] [Discord] | A conexão com o servidor: \"TOW\" não foi estabelecida com sucesso.\nErro: {ex.ToString()}");
                Console.ResetColor();
                await Secretaria_OpenSpades.SendMessageAsync($"**[IRC] [UBGE-TOW] [Wall-E] [Discord]** **|** A conexão com o servidor: ``TOW`` não foi estabelecida com sucesso.\n\n**Erro:**\n```{ex.ToString()}```");
                await Log.SendMessageAsync($"**[IRC] [UBGE-TOW] [Wall-E] [Discord]** **|** A conexão com o servidor: ``TOW`` não foi estabelecida com sucesso.\n\n**Erro:**\n```{ex.ToString()}```");
                Thread.Sleep(5000);
                string[] argv = { };
            }
        }
    }
}
