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
using Wall_E.Comandos;
using Wall_E.Utilidades;
using Wall_E.Bot;
using Wall_E;

namespace Wall_E
{
    public class Wall_E
    {
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