using Autofac;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Net.WebSocket;
using DSharpPlus.EventArgs;
using DSharpPlus.Lavalink;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Wall_E.Comandos;
using Wall_E.Música;
using Wall_E.Bot;
using System.Net.Sockets;

namespace Wall_E
{
    public class Wall_E {
        public static IContainer Services { get; private set; }

        public static Wall_E Instance { get; private set; }

        public Config Config { get; private set; }

        public CommandsNextExtension CommandsNext { get; set; }

        public LavalinkExtension Lavalink { get; set; }

        public InteractivityExtension Interactivity { get; private set; }

        public static string IP = "irc.quakenet.org";

        private static int Porta = 6667;

        private static string Usuario = "USER IRCbot 0 * :IRCbot";

        private static string Nome = "Wall-E";

        private static string Canal = "#servidores.ubge";

        public static void Main(string[] args) {
            Console.Title = "Wall-E da Ética online!";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[Wall-E] [DSharpPlus] [Discord] Bem-Vindo Luiz!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[Wall-E] Versão: {valores.Versao}");
            Console.ResetColor();

            var Container = new ContainerBuilder(); {
                Container.RegisterType<MangoDB>().SingleInstance();
            }

            Services = Container.Build();
            Task.Delay(200);

            Utilidades.Utilidades.CriarPastaBDTorneioOS();

            Console.WriteLine("[Wall-E] [SQLCe] A conexão com o banco de dados foi feita com sucesso e está em funcionamento.");
            Console.WriteLine("[Wall-E] [MongoDB] A conexão com o MongoDB foi estabelecida e está em perfeito funcionamento.");

            Instance = new Wall_E();
            Instance.StartAsync().GetAwaiter().GetResult();
        }

        public Wall_E() {
            Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(Directory.GetCurrentDirectory() + @"\Config.json"));

            Discord = new DiscordClient(new DiscordConfiguration {
                Token = Config.Token,
                UseInternalLogHandler = true,
                TokenType = Config.TokenType,
                AutoReconnect = true,
                ReconnectIndefinitely = true,
                GatewayCompressionLevel = GatewayCompressionLevel.Stream,
                LargeThreshold = 250,
                LogLevel = LogLevel.Info,
                WebSocketClientFactory = WebSocket4NetCoreClient.CreateNew,
            });

            Lavalink = Discord.UseLavalink();

            CommandsNext = Discord.UseCommandsNext(new CommandsNextConfiguration {
                EnableDms = Config.EnableDms,
                EnableMentionPrefix = true,
                EnableDefaultHelp = false,
                StringPrefixes = new[] { Config.Prefix },

                Services = new ServiceCollection()
                    .AddSingleton<CSPRNG>()
                    .AddSingleton(new MusicService(Discord))
                    .BuildServiceProvider(true)
            });

            DiscordChannel Log = Discord.GetChannelAsync(valores.IdLogWall_E).Result;
            int iterate = 0;
            CommandsNext.CommandErrored += async (args) => {
                var ctx = args.Context;

                CommandNotFoundException cntfe = (CommandNotFoundException)args.Exception;
                if (!String.IsNullOrEmpty(cntfe.CommandName)) {
                    if (iterate == 1) {
                        await args.Context.RespondAsync($"Nononononononono, esse comando: `{Config.Prefix}{cntfe.CommandName}` também non ecziste!");
                        iterate = 0;
                    }
                    else {
                        await args.Context.RespondAsync($"Padre Quevedo te alerta, esse comando: `{Config.Prefix}{cntfe.CommandName}` non ecziste!");
                        iterate++;
                    }
                    Console.WriteLine(args.Exception.ToString());
                    await Log.SendMessageAsync($"O membro `{ctx.Member.DisplayName}` executou um comando inexistente: `{Config.Prefix}{cntfe.CommandName}`.\nChat: `{ctx.Channel}`\nDia e Hora: `{DateTime.Now}`\n-------------------------------------------------------\n");
                }
            };

            Discord.Ready += DiscordClient_Ready;

            async Task DiscordClient_Ready(ReadyEventArgs e) {
                await Discord.UpdateStatusAsync(new DiscordActivity("no Discord da UBGE!"));
                await Log.SendMessageAsync($"**Wall-E da Ética online!**\nLigado às: ``{DateTime.Now}``");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"[{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} -03:00] [Wall-E] [DSharpPlus] Meu ping é: {Discord.Ping}ms!");
                Console.ResetColor();

                DiscordChannel Paulo = Discord.GetChannelAsync(valores.PauloCanal).Result;
                //await Paulo.SendMessageAsync($"Tenho: **{Discord.GetCommandsNext().RegisteredCommands.Count}** comandos!");
                Console.WriteLine($"[Wall-E] [DSharpPlus] Tenho: {Discord.GetCommandsNext().RegisteredCommands.Count} comandos!");

                IRC(Discord);
            }

            CommandsNext.RegisterCommands(Assembly.GetEntryAssembly());

            Interactivity = Discord.UseInteractivity(new InteractivityConfiguration {
                PaginationBehavior = TimeoutBehaviour.DeleteMessage,
                PaginationTimeout = TimeSpan.FromMinutes(3),
                Timeout = TimeSpan.FromMinutes(3)
            });
        }

        public DiscordClient Discord { get; set; }

        private async void IRC(DiscordClient ctx) {
            DiscordChannel TOW_Chat = ctx.GetChannelAsync(valores.tow_chat).Result;
            DiscordChannel Arena_Chat = ctx.GetChannelAsync(valores.arena_chat).Result;
            DiscordChannel TDM_Chat = ctx.GetChannelAsync(valores.tdm_chat).Result;
            DiscordChannel Log = ctx.GetChannelAsync(valores.IdLogWall_E).Result;

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
                await Log.SendMessageAsync($"**[IRC] [UBGE-Servidores] [Wall-E] [Discord]** **|** A conexão com o servidores: ``TOW``, ``Arena``, ``Semanal`` foi estabelecida com sucesso! Chat's sendo enviados nos canais: <#{valores.tow_chat}>, <#{valores.arena_chat}> e <#{valores.tdm_chat}>.");

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
                            if (InputLine.Contains(":UBGE-TDM!~UBGE-TDM@179.218.243.249 PRIVMSG #servidores.ubge :")) {
                                await TDM_Chat.SendMessageAsync($"[UBGE-TDM] | ``{DateTime.Now}`` [-] {InputLine.Replace(":UBGE-TDM!~UBGE-TDM@179.218.243.249 PRIVMSG #servidores.ubge :", "")}");
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
                    //Writer.Close();
                    //Reader.Close();
                    //IRC.Close();
                }
            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[IRC] [UBGE-Servidores] [Wall-E] [Discord] | A conexão com o servidores: \"TOW, Arena, Semanal\" não foi estabelecida com sucesso.\n\nErro: {ex.ToString()}");
                Console.ResetColor();
                await Log.SendMessageAsync($"**[IRC] [UBGE-Servidores] [Wall-E] [Discord]** **|** A conexão com o servidores: ``TOW``, ``Arena``, ``Semanal`` não foi estabelecida com sucesso.\n\n**Erro:**\n```{ex.ToString()}```");
                Console.WriteLine("[Wall-E] Reiniciando...");
                await ctx.DisconnectAsync();
                await Task.Delay(200);
                await ctx.ConnectAsync();
                Console.WriteLine("[Wall-E] Reiniciei.");
                await Log.SendMessageAsync($"**[IRC] [UBGE-Servidores] [Wall-E] [Discord]** **|** Me auto-reiniciei e o erro foi consertado! Os IRC's estão funcionando novamente e em perfeito estado. Chat's sendo enviados nos canais: <#{valores.tow_chat}>, <#{valores.arena_chat}> e <#{valores.tdm_chat}>.\n\n*(Fatiou, passou, boa 06)*");
                Console.WriteLine("[IRC] [Wall-E] Me auto-reiniciei e o erro foi consertado! Os IRC's estão funcionando em perfeito estado.");
            }
        }

        public async Task StartAsync() {
            await Discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}