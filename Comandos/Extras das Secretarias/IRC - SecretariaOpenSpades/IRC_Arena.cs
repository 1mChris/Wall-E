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

namespace Wall_E.Comandos.Extras_das_Secretarias.IRC___SecretariaOpenSpades
{
    public class IRC_Arena
    {
        public static string IP2 = "irc.quakenet.org";
        private static int Porta2 = 6667;
        private static string Usuario2 = "USER IRCbot 0 * :IRCbot";
        private static string Nome2 = "Wall-E";
        private static string Canal2 = "#ubge.servidor2";

        [Command("arenairc")]
        [Aliases("ARENAIRC", "ArenaIRC")]

        public async Task IRC_da_Arena(CommandContext ctx)
        {
            DiscordChannel Arena_Chat = ctx.Guild.GetChannel(valores.arena_chat);
            DiscordChannel Secretaria_OpenSpades2 = ctx.Guild.GetChannel(valores.secretaria_openspades_chat);
            DiscordChannel Log = ctx.Guild.GetChannel(460875622323978240);

            NetworkStream NS2;
            TcpClient IRC2;
            string InputLine2;
            StreamReader Reader2;
            StreamWriter Writer2;

            try
            {
                IRC2 = new TcpClient(IP2, Porta2);
                NS2 = IRC2.GetStream();
                Reader2 = new StreamReader(NS2);
                Writer2 = new StreamWriter(NS2);
                Writer2.WriteLine($"NICK {Nome2}");
                Writer2.Flush();
                Writer2.WriteLine(Usuario2);
                Writer2.Flush();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[IRC] [UBGE-Arena] [Wall-E] [Discord] | A conexão com o servidor: \"Arena\" foi estabelecida com sucesso!");
                Console.ResetColor();
                await Secretaria_OpenSpades2.SendMessageAsync($"**[IRC] [UBGE-Arena] [Wall-E] [Discord]** **|** A conexão com o servidor: **\"Arena\"** foi estabelecida com sucesso! Chat sendo enviado no: <#{valores.arena_chat}>");

                while (true)
                {
                    while ((InputLine2 = Reader2.ReadLine()) != null)
                    {
                        await Arena_Chat.SendMessageAsync($"**[UBGE-Arena]** **|** ``{DateTime.Now}`` >> {InputLine2.Replace(":UBGE-Arena!~UBGE-Arena@179.218.243.249 PRIVMSG #ubge.servidor :", "")}");
                        string[] splitInput2 = InputLine2.Split(new Char[] {
                            ' '
                        });
                        if (splitInput2[0] == "PING")
                        {
                            string Resposta2 = splitInput2[1];
                            Writer2.WriteLine($"PONG {Resposta2}");
                            Writer2.Flush();
                        }

                        switch (splitInput2[1])
                        {
                            case "001":
                                Writer2.WriteLine($"JOIN {Canal2}");
                                Writer2.Flush();
                                break;
                            default:
                                break;
                        }
                    }
                    Writer2.Close();
                    Reader2.Close();
                    IRC2.Close();
                }
            }
            catch (Exception ex2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[IRC] [UBGE-Arena] [Wall-E] [Discord] | A conexão com o servidor: \"Arena\" não foi estabelecida com sucesso.\n.\nErro: {ex2.ToString()}");
                Console.ResetColor();
                await Secretaria_OpenSpades2.SendMessageAsync($"**[IRC] [UBGE-Arena] [Wall-E] [Discord]** **|** A conexão com o servidor: **\"Arena\"** não foi estabelecida com sucesso. <@&{valores.OpenSpades}>, procurem o erro e tentem resolver!\n.\n**Erro:** {ex2.ToString()}");
                await Log.SendMessageAsync($"**[IRC] [UBGE-Arena] [Wall-E] [Discord]** **|** A conexão com o servidor: **\"Arena\"** não foi estabelecida com sucesso.\n.\n**Erro:** {ex2.ToString()}");
                Thread.Sleep(5000);
                string[] argv = { };
            }
        }
    }
}
