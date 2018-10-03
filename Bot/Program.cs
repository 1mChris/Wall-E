using Autofac;
using Autofac.Core;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Net.WebSocket;
using DSharpPlus.VoiceNext;
using DSharpPlus.VoiceNext.Codec;
using DSharpPlus.EventArgs;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using Google.Apis.Upload;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Wall_E.Comandos;
using Wall_E.Utilidades;
using Wall_E.Bot;
using Wall_E;

namespace Wall_E
{
    public class Wall_E
    {
        //TOW
        public static string IP = "irc.quakenet.org";
        private static int Porta = 6667;
        private static string Usuario = "USER IRCbot 0 * :IRCbot";
        private static string Nome = "Wall-E";
        private static string Canal = "#ubge.servidor";

        //Arena
        public static string IP2 = "irc.quakenet.org";
        private static int Porta2 = 6667;
        private static string Usuario2 = "USER IRCbot 0 * :IRCbot";
        private static string Nome2 = "Wall-E";
        private static string Canal2 = "#ubge.servidor2";

        //Semanal
        public static string IP3 = "irc.quakenet.org";
        private static int Porta3 = 6667;
        private static string Usuario3 = "USER IRCbot 0 * :IRCbot";
        private static string Nome3 = "Wall-E";
        private static string Canal3 = "#ubge.servidor3";
        
        public static IContainer Services
        {
            private set;
            get;
        }

        public static Wall_E Instance { get; private set; }

        public Config Config
        {
            get; private set;
        }

        public CommandsNextModule CommandsNext
        {
            get; set;
        }

        public VoiceNextClient Voice
        {
            get; set;
        }

        public InteractivityModule Interactivity
        {
            get; private set;
        }

        public static void Main(string[] args)
        {
            Console.Title = "Wall-E da Ética online!";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[Wall-E] [DSharpPlus] [Discord] Bem-Vindo Luiz!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Wall-E] Versão: 1.6.7");
            Console.ResetColor();
            Instance = new Wall_E();
            Instance.StartAsync().GetAwaiter().GetResult();
        }

        public Wall_E()
        {
            Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(Directory.GetCurrentDirectory() + @"\Config.json"));

            Discord = new DiscordClient(new DiscordConfiguration
            {
                Token = Config.Token,
                UseInternalLogHandler = true,
                TokenType = Config.TokenType,
            });
            var vcfg = new VoiceNextConfiguration
            {
                VoiceApplication = VoiceApplication.Music
            };

            this.Voice = this.Discord.UseVoiceNext(vcfg);

            Discord.SetWebSocketClient<WebSocket4NetCoreClient>();
            CommandsNext = Discord.UseCommandsNext(new CommandsNextConfiguration
            {
                EnableDms = Config.EnableDms,
                EnableMentionPrefix = true,
                EnableDefaultHelp = false,
                StringPrefix = Config.Prefix
            });

            DiscordChannel Log = Discord.GetChannelAsync(460875622323978240).Result;
            int iterate = 0;
            CommandsNext.CommandErrored += async (args) =>
            {
                var ctx = args.Context;

                CommandNotFoundException cntfe = (CommandNotFoundException)args.Exception;
                if (!String.IsNullOrEmpty(cntfe.Command))
                {
                    if (iterate == 1)
                    {
                        await args.Context.RespondAsync($"Nononononononono, esse comando: `{Config.Prefix}{cntfe.Command}` também non ecziste!");
                        iterate = 0;
                    }
                    else
                    {
                        await args.Context.RespondAsync($"Padre Quevedo te alerta, esse comando: `{Config.Prefix}{cntfe.Command}` non ecziste!");
                        iterate++;
                    }
                    Console.WriteLine(args.Exception.ToString());
                    await Log.SendMessageAsync($"O membro `{ctx.Member.DisplayName}` executou um comando inexistente: `{Config.Prefix}{cntfe.Command}`.\nChat: `{ctx.Channel}`\nDia e Hora: `{DateTime.Now}`\n-------------------------------------------------------\n");
                }
            };

            Discord.Ready += DiscordClient_Ready;

            async Task DiscordClient_Ready(ReadyEventArgs e)
            {
                await Discord.UpdateStatusAsync(new DiscordGame("no Discord da UBGE!"));
                await Log.SendMessageAsync($"**Wall-E da Ética online!**\nLigado às: `{DateTime.Now}`");

                #region IRC do TOW -> Discord
                DiscordChannel TOW_Chat = Discord.GetChannelAsync(valores.tow_chat).Result;
                DiscordChannel Secretaria_OpenSpades = Discord.GetChannelAsync(valores.secretaria_openspades_chat).Result;

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
                    await Secretaria_OpenSpades.SendMessageAsync($"**[IRC] [UBGE-TOW] [Wall-E] [Discord]** **|** A conexão com o servidor: **\"TOW\"** foi estabelecida com sucesso! Chat sendo enviado no: <#{valores.tow_chat}>");

                    while (true)
                    {
                        while ((InputLine = Reader.ReadLine()) != null)
                        {
                            await TOW_Chat.SendMessageAsync($"**[UBGE-TOW]** **|** ``{DateTime.Now}`` >> {InputLine.Replace(":UBGE-ToW!~UBGE-ToW@179.218.243.249 PRIVMSG #ubge.servidor :", "")}");
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
                    Console.WriteLine($"[IRC] [UBGE-TOW] [Wall-E] [Discord] | A conexão com o servidor: \"TOW\" não foi estabelecida com sucesso.\n.\nErro: {ex.ToString()}");
                    Console.ResetColor();
                    await Secretaria_OpenSpades.SendMessageAsync($"**[IRC] [UBGE-TOW] [Wall-E] [Discord]** **|** A conexão com o servidor: **\"TOW\"** não foi estabelecida com sucesso. <@&{valores.OpenSpades}>, procurem o erro e tentem resolver!\n.\n**Erro:** {ex.ToString()}");
                    await Log.SendMessageAsync($"**[IRC] [UBGE-TOW] [Wall-E] [Discord]** **|** A conexão com o servidor: **\"TOW\"** não foi estabelecida com sucesso.\n.\n**Erro:** {ex.ToString()}");
                    Thread.Sleep(5000);
                    string[] argv = { };
                }
                #endregion

                #region IRC da Arena -> Discord
                DiscordChannel Arena_Chat = Discord.GetChannelAsync(valores.arena_chat).Result;
                DiscordChannel Secretaria_OpenSpades2 = Discord.GetChannelAsync(valores.secretaria_openspades_chat).Result;

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
                    Writer2.WriteLine(Usuario);
                    Writer2.Flush();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[IRC] [UBGE-Arena] [Wall-E] [Discord] | A conexão com o servidor: \"Arena\" foi estabelecida com sucesso!");
                    Console.ResetColor();
                    await Secretaria_OpenSpades.SendMessageAsync($"**[IRC] [UBGE-Arena] [Wall-E] [Discord]** **|** A conexão com o servidor: **\"Arena\"** foi estabelecida com sucesso! Chat sendo enviado no: <#{valores.arena_chat}>");

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
                    await Secretaria_OpenSpades.SendMessageAsync($"**[IRC] [UBGE-Arena] [Wall-E] [Discord]** **|** A conexão com o servidor: **\"Arena\"** não foi estabelecida com sucesso. <@&{valores.OpenSpades}>, procurem o erro e tentem resolver!\n.\n**Erro:** {ex2.ToString()}");
                    await Log.SendMessageAsync($"**[IRC] [UBGE-Arena] [Wall-E] [Discord]** **|** A conexão com o servidor: **\"Arena\"** não foi estabelecida com sucesso.\n.\n**Erro:** {ex2.ToString()}");
                    Thread.Sleep(5000);
                    string[] argv = { };
                }
                #endregion

                //Falta o Semanal
            }

            CommandsNext.RegisterCommands(Assembly.GetEntryAssembly());

            Interactivity = Discord.UseInteractivity(new InteractivityConfiguration
            {
                PaginationBehaviour = TimeoutBehaviour.Delete,
                PaginationTimeout = TimeSpan.FromMinutes(3),
                Timeout = TimeSpan.FromMinutes(3)
            });
        }

        public DiscordClient Discord
        {
            get; set;
        }

        public async Task StartAsync()
        {
            await Discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}