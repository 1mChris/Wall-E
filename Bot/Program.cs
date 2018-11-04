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
using Wall_E.Comandos;
using Wall_E.Música;
using Wall_E.Bot;

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
                await Log.SendMessageAsync($"**Wall-E da Ética online!**\nLigado às: ``{DateTime.Now}``");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"[{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} -03:00] [Wall-E] [DSharpPlus] Meu ping é: {Discord.Ping}ms!");
                Console.ResetColor();

                DiscordChannel Secretaria = Discord.GetChannelAsync(valores.secretaria_openspades_chat).Result;
                await Secretaria.SendMessageAsync($"<@&{valores.OpenSpades}>, alguém digita: ``/os irc`` ?\n\nObrigado :grin:");

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

            Status(Discord);
        }

        public DiscordClient Discord { get; set; }

        private async Task Status(DiscordClient discord) {
            var utils = new Utilidades.Utilidades();
            var mins = utils.getTime("30s");
            var ubge = await discord.GetGuildAsync(194925640888221698);
            var qtd = await ubge.GetAllMembersAsync();

            bool minWaiter = false;

            while (!minWaiter) {
                await discord.UpdateStatusAsync(new DiscordActivity($"no Discord da UBGE! - {qtd.Count} membros!"));
                utils.Wait(mins);
                await discord.UpdateStatusAsync(new DiscordActivity($"{discord.GetCommandsNext().RegisteredCommands.Count} comandos!"));
                utils.Wait(mins);
                await discord.UpdateStatusAsync(new DiscordActivity($"Meu criador é o @[UBGE] Luiz#8721!"));
                utils.Wait(mins);
            }
        }

        public async Task StartAsync() {
            await Discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}