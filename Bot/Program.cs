using Autofac;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Net.WebSocket;
using DSharpPlus.VoiceNext;
using DSharpPlus.VoiceNext.Codec;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Wall_E.Comandos;
using Wall_E.Utilidades;
using Wall_E.Bot;
using Wall_E;

namespace Wall_E
{
    public class Wall_E {
        public static IContainer Services {
            get; private set;
        }

        public static Wall_E Instance {
            get; private set; 
        }

        public Config Config {
            get; private set;
        }

        public CommandsNextModule CommandsNext {
            get; set;
        }

        public VoiceNextClient Voice {
            get; set;
        }

        public InteractivityModule Interactivity {
            get; private set;
        }

        public static void Main(string[] args) {
            Console.Title = "Wall-E da Ética online!";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[Wall-E] [DSharpPlus] [Discord] Bem-Vindo Luiz!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Wall-E] Versão: 1.8.9");
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
            });

            var vcfg = new VoiceNextConfiguration {
                VoiceApplication = VoiceApplication.Music
            };

            this.Voice = this.Discord.UseVoiceNext(vcfg);

            Discord.SetWebSocketClient<WebSocket4NetCoreClient>();
            CommandsNext = Discord.UseCommandsNext(new CommandsNextConfiguration {
                EnableDms = Config.EnableDms,
                EnableMentionPrefix = true,
                EnableDefaultHelp = false,
                StringPrefix = Config.Prefix
            });

            DiscordChannel Log = Discord.GetChannelAsync(valores.IdLogWall_E).Result;
            int iterate = 0;
            CommandsNext.CommandErrored += async (args) => {
                var ctx = args.Context;

                CommandNotFoundException cntfe = (CommandNotFoundException)args.Exception;
                if (!String.IsNullOrEmpty(cntfe.Command)) {              
                    if (iterate == 1) {                   
                        await args.Context.RespondAsync($"Nononononononono, esse comando: `{Config.Prefix}{cntfe.Command}` também non ecziste!");
                        iterate = 0;
                    }
                    else {                   
                        await args.Context.RespondAsync($"Padre Quevedo te alerta, esse comando: `{Config.Prefix}{cntfe.Command}` non ecziste!");
                        iterate++;
                    }
                    Console.WriteLine(args.Exception.ToString());
                    await Log.SendMessageAsync($"O membro `{ctx.Member.DisplayName}` executou um comando inexistente: `{Config.Prefix}{cntfe.Command}`.\nChat: `{ctx.Channel}`\nDia e Hora: `{DateTime.Now}`\n-------------------------------------------------------\n");
                }
            };

            Discord.Ready += DiscordClient_Ready;

            async Task DiscordClient_Ready(ReadyEventArgs e) {            
                await Discord.UpdateStatusAsync(new DiscordGame("no Discord da UBGE!"));
                await Log.SendMessageAsync($"**Wall-E da Ética online!**\nLigado às: ``{DateTime.Now}``");

                DiscordChannel Secretaria = Discord.GetChannelAsync(valores.secretaria_openspades_chat).Result;
                await Secretaria.SendMessageAsync($"<@&{valores.OpenSpades}>, alguém digita: ``/towirc``, ``/arenairc``, ``/semanalirc`` ?\nObrigado pela atenção!");

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
                PaginationBehaviour = TimeoutBehaviour.Delete,
                PaginationTimeout = TimeSpan.FromMinutes(3),
                Timeout = TimeSpan.FromMinutes(3)
            });
        }

        public DiscordClient Discord {
            get; set;
        }

        public async Task StartAsync() {
            await Discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}