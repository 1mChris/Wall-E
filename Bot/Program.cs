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

namespace Wall_E
{
    public class Wall_E {
        public static IContainer Services { get; private set; }

        public static Wall_E Instance { get; private set; }

        public Config Config { get; private set; }

        public CommandsNextExtension CommandsNext { get; set; }

        public LavalinkExtension Lavalink { get; set; }

        public InteractivityExtension Interactivity { get; private set; }

        public static void Main(string[] args) {
            Console.Title = "Wall-E da Ética online!";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[Wall-E] [DSharpPlus] [Discord] Bem-Vindo Luiz!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Wall-E] Versão: v2.1.0");
            Console.ResetColor();

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
                LogLevel = LogLevel.Debug,
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

                DiscordChannel Secretaria = Discord.GetChannelAsync(valores.secretaria_openspades_chat).Result;
                DiscordChannel Paulo = Discord.GetChannelAsync(valores.PauloCanal).Result;
                //await Secretaria.SendMessageAsync($"<@&{valores.OpenSpades}>, alguém digita: ``/os irc`` ?\n\nObrigado :grin:");
                await Paulo.SendMessageAsync($"Tenho: **{Discord.GetCommandsNext().RegisteredCommands.Count}** comandos!");              
            }

            CommandsNext.RegisterCommands(Assembly.GetEntryAssembly());

            Interactivity = Discord.UseInteractivity(new InteractivityConfiguration {
                PaginationBehavior = TimeoutBehaviour.DeleteMessage,
                PaginationTimeout = TimeSpan.FromMinutes(3),
                Timeout = TimeSpan.FromMinutes(3)
            });
        }

        public DiscordClient Discord { get; set; }

        public async Task StartAsync() {
            await Discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}