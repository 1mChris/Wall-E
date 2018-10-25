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
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Wall_E.Comandos;
using Wall_E.Música;
using Wall_E.Bot;

namespace Wall_E
{
    public class Wall_E {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        public static IContainer Services { get; private set; }

        public static Wall_E Instance { get; private set; }

        public Config Config { get; private set; }

        public CommandsNextExtension CommandsNext { get; set; }

        public LavalinkExtension Lavalink { get; set; }

        public InteractivityExtension Interactivity { get; private set; }

        public static void Main(string[] args) {
            IntPtr ptrConsole = GetConsoleWindow();
            ShowWindow(ptrConsole, SW_HIDE);

            Process.Start("start.lnk");

            Console.Title = "Wall-E da Ética online!";

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

                DiscordChannel Secretaria = Discord.GetChannelAsync(valores.secretaria_openspades_chat).Result;
                //await Secretaria.SendMessageAsync($"<@&{valores.OpenSpades}>, alguém digita: ``/os irc`` ?\n\nObrigado :grin:");

                //DiscordChannel Secretaria = await Discord.GetChannelAsync(valores.secretaria_openspades_chat);
                //var CN = Discord.GetCommandsNext();
                //var cmd = CommandsNext.FindCommand("/ping", out var args);
                //CN.CreateFakeContext(Discord.CurrentUser, Secretaria, "/ping", Config.Prefix, cmd, null);
                //Console.WriteLine("A");

                //DateTime DT = new DateTime();
                //DiscordChannel Secretaria = Discord.GetChannelAsync(valores.secretaria_openspades_chat).Result;

                //if(DT.DayOfWeek == DayOfWeek.Friday)
                //{
                //var Semanal = System.Diagnostics.Process.Start("OpenSpadesSemanal.exe");
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine("[Wall-E] [UBGE-Semanal] AEEEEEEEEEEEEEOOOO Domingão pola! Liguei o semanal!");
                //Console.ResetColor();
                //await Secretaria.SendMessageAsync("[Wall-E] [UBGE-Semanal] Liguei o servidor Semanal! Hoje é sexta-feira calaleo, *Dia de beber (e jogar)*");
                //}
                //else if (DT.DayOfWeek == DayOfWeek.Sunday)
                //{
                //var Semanal = System.Diagnostics.Process.Start("OpenSpadesSemanal.exe");
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine("[Wall-E] [UBGE-Semanal] AEEEEEEEEEEEEEOOOO Domingão pola! Liguei o semanal!");
                //Console.ResetColor();
                //await Secretaria.SendMessageAsync("[Wall-E] [UBGE-Semanal] Liguei o servidor: ``Semanal``! Hoje é domningo calaleo, *Dia de assitir o Faustão*");
                //}
                //else if (DT.DayOfWeek == DayOfWeek.Saturday)
                //{
                //var Semanal = System.Diagnostics.Process.Start("OpenSpadesSemanal.exe");
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine("[Wall-E] [UBGE-Semanal] AEEEEEEEEEEEEEOOOO Hoje é sábado pola! Liguei o semanal!");
                //Console.ResetColor();
                //await Secretaria.SendMessageAsync("[Wall-E] [UBGE-Semanal] Liguei o servidor: ``Semanal``! Hoje é sábado calaleo, SILVIO SANTOS VEM AI, OLE OLE OLÁ :musical_note:");
                //}
                //else
                //{
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("[Wall-E] [UBGE-Semanal] Hoje não é sexta-feira :/");
                //Console.ResetColor();
                //await Log.SendMessageAsync("**[Wall-E] [UBGE-Semanal]** **|** Hoje não é sexta-feira :/");
                //}
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
            await Task.Delay(20000);
            await Discord.ConnectAsync();

            Application.EnableVisualStyles();
            Application.Run(new WinFormWall_E());
        }
    }
}