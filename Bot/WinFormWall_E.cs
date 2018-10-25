using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wall_E;
using Wall_E.Bot;
using Wall_E.Comandos;

namespace Wall_E.Bot
{
    public partial class WinFormWall_E : Form
    {
        SaidaTextBox Saida;

        public WinFormWall_E() {
            InitializeComponent();

            label5.Text = valores.Versao;

            ConsoleForm.Text = $"[Wall-E] [DSharpPlus] [Discord] Bem-Vindo Luiz!\n[Wall-E] Versão: {valores.Versao}\n";

            Saida = new SaidaTextBox(ConsoleForm);
            Console.SetOut(Saida);
            ConsoleForm.Focus();

            PingDiscord();
            IRCBool();
        }

        private async void PingDiscord() {
            while (true) {
                string ping = $"{Wall_E.Instance.Discord.Ping.ToString()}ms";
                PingBot.Text = ping;

                await Task.Delay(200);
            }
        }
        
        private async void IRCBool() {
            while (true) {
                if (OpenSpadesComandosDiscord.Conectado == false) {               
                    BoolIRC.ForeColor = Color.Red;
                    BoolIRC.Text = "Desconectado";
                }
                else {
                    BoolIRC.ForeColor = Color.Green;
                    BoolIRC.Text = "Conectado";
                }

                await Task.Delay(200);
            }
        }

        private void LinkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string GitHub = "https://github.com/LuizFernandoNB/Wall-E/tree/master";
            System.Diagnostics.Process.Start(GitHub);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string UBGEDiscord = "https://discordapp.com/invite/cPFBXDz";
            System.Diagnostics.Process.Start(UBGEDiscord);
        }
    }
}