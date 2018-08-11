using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class InformaçõesMembro
    {
        [Command("info")]
        [Aliases("Info", "infomembro", "Infomebro", "INFOMEMBRO", "INFO")]

        public async Task MedalhasFoxhole(CommandContext ctx, DiscordMember membro = null, DiscordRole role = null)
        {
            await ctx.TriggerTypingAsync();
            if (membro == null)
            {
                membro = ctx.Member;
            }

            IEnumerable<DiscordRole> cargos = membro.Roles.OrderByDescending(e => e.Position);

            #region Variáveis
            var cordocargo = membro.Color;
            cordocargo.R.ToString("X");
            cordocargo.G.ToString("X");
            cordocargo.B.ToString("X");
            var cortotaldocargo = new SolidBrush(Color.FromArgb(255, cordocargo.R, cordocargo.G, cordocargo.B));
            var retangulofoto = new Pen(Color.FromArgb(255, cordocargo.R, cordocargo.G, cordocargo.B)) { Width = 15 };
            var retangulofotocorsombra = new Pen(Color.FromArgb(255, 0, 0, 0)) { Width = 15 };
            var foto = membro.GetAvatarUrl(DSharpPlus.ImageFormat.Png, 512);
            var tempo = membro.JoinedAt.ToString("dd/MM/yyyy");
            var principalcargo = membro.Roles.OrderBy(e => e.Position).Last().Name;
            var strCargos = string.Join("\n", cargos.Select(x => x.Name));
            string capa = (Directory.GetCurrentDirectory() + @"\Capa.png");
            string fotousuario = (Directory.GetCurrentDirectory() + @"\Foto.png");
            string local = (Directory.GetCurrentDirectory() + @"\img3.png");
            #endregion

            #region Fontes
            PrivateFontCollection collection = new PrivateFontCollection();
            collection.AddFontFile(Directory.GetCurrentDirectory() + @"\Anton.ttf");
            FontFamily fontFamily = new FontFamily("Anton", collection);
            Font font = new Font(fontFamily, 55);
            PrivateFontCollection collection2 = new PrivateFontCollection();
            collection.AddFontFile(Directory.GetCurrentDirectory() + @"\Anton.ttf");
            FontFamily fontFamily2 = new FontFamily("Anton", collection);
            Font font2 = new Font(fontFamily, 52);
            PrivateFontCollection collection3 = new PrivateFontCollection();
            collection.AddFontFile(Directory.GetCurrentDirectory() + @"\Anton.ttf");
            FontFamily fontFamily3 = new FontFamily("Anton", collection);
            Font font3 = new Font(fontFamily, 52);
            PrivateFontCollection collection4 = new PrivateFontCollection();
            collection.AddFontFile(Directory.GetCurrentDirectory() + @"\Anton.ttf");
            FontFamily fontFamily4 = new FontFamily("Anton", collection);
            Font font4 = new Font(fontFamily, 52);
            PrivateFontCollection collection5 = new PrivateFontCollection();
            collection.AddFontFile(Directory.GetCurrentDirectory() + @"\Anton.ttf");
            FontFamily fontFamily5 = new FontFamily("Anton", collection);
            Font font5 = new Font(fontFamily, 52);
            PrivateFontCollection collection6 = new PrivateFontCollection();
            collection.AddFontFile(Directory.GetCurrentDirectory() + @"\Anton.ttf");
            FontFamily fontFamily6 = new FontFamily("Anton", collection);
            Font font6 = new Font(fontFamily, 48);
            #endregion

            #region Sei lá
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(foto), fotousuario);
            }
            Image ImgFoto;
            try
            {
                ImgFoto = Image.FromFile(fotousuario);
            }
            catch (Exception)
            {
                return;
            }
            Image ImgCapa;
            try
            {
                ImgCapa = Image.FromFile(capa);
            }
            catch (Exception)
            {
                return;
            }

            byte posX = 13;
            byte posY = 13;
            #endregion

            Bitmap img3 = new Bitmap(ImgCapa.Width, ImgCapa.Height);
            Graphics g = Graphics.FromImage(img3);

            ImgFoto = ImgFoto.GetThumbnailImage(498, (485 * ImgFoto.Height) / ImgFoto.Width, null, IntPtr.Zero);
            #region Só 'g' até a casa do caixa prego
            g.Clear(Color.Black);
            g.DrawImage(ImgCapa, new Point(0, 0));
            g.DrawImage(ImgFoto, new Point(posX, posY));
            g.DrawRectangle(retangulofotocorsombra, x: 7, y: 7, width: 498, height: 485);
            g.DrawRectangle(retangulofoto, x: 7, y: 7, width: 495, height: 482);
            g.DrawString($"@{membro.DisplayName}#{membro.Discriminator}", font, Brushes.Black, point: new PointF(523, 43));
            g.DrawString($"@{membro.DisplayName}#{membro.Discriminator}", font, brush: (cortotaldocargo), point: new PointF(520, 40));
            g.DrawString($"{membro.Username}#{membro.Discriminator}", font2, Brushes.Black, point: new PointF(523, 118));
            g.DrawString($"{membro.Username}#{membro.Discriminator}", font2, Brushes.Gray, point: new PointF(520, 115));
            g.DrawString($"Entrou:", font4, Brushes.Black, point: new PointF(523, 268));
            g.DrawString($"Entrou:", font4, Brushes.Gray, point: new PointF(520, 265));
            g.DrawString($"{tempo}", font4, Brushes.Black, point: new PointF(741, 268));
            g.DrawString($"{tempo}", font4, Brushes.DarkOrange, point: new PointF(738, 265));
            g.DrawString($"{principalcargo}", font5, Brushes.Black, point: new PointF(523, 346));
            g.DrawString($"{principalcargo}", font5, brush:(cortotaldocargo), point: new PointF(520, 343));
            #endregion
            #region If, else if
            if (membro.Presence.Status == UserStatus.Online)
            {
                var online = new SolidBrush(Color.FromArgb(67, 181, 129));
                g.DrawString("Status:", font3, Brushes.Black, point: new PointF(523, 190));
                g.DrawString("Online", font3, Brushes.Black, point: new PointF(730, 190));
                g.DrawString("Status:", font3, Brushes.Gray, point: new PointF(520, 187));
                g.DrawString("Online", font3, online, point: new PointF(727, 187));
            }
            else if (membro.Presence.Status == UserStatus.DoNotDisturb)
            {
                var naopertube = new SolidBrush(Color.FromArgb(240, 71, 71));
                g.DrawString("Status:", font3, Brushes.Black, point: new PointF(523, 190));
                g.DrawString("Não pertube", font3, Brushes.Black, point: new PointF(730, 190));
                g.DrawString("Status:", font3, Brushes.Gray, point: new PointF(520, 187));
                g.DrawString("Não pertube", font3, naopertube, point: new PointF(727, 187));
            }
            else if (membro.Presence.Status == UserStatus.Offline)
            {
                var offline = new SolidBrush(Color.FromArgb(69, 69, 69));
                g.DrawString("Status:", font3, Brushes.Black, point: new PointF(523, 190));
                g.DrawString("Offline", font3, Brushes.Black, point: new PointF(730, 190));
                g.DrawString("Status:", font3, Brushes.Gray, point: new PointF(520, 187));
                g.DrawString("Offline", font3, offline, point: new PointF(727, 187));
            }
            else if (membro.Presence.Status == UserStatus.Idle)
            {
                var ausente = new SolidBrush(Color.FromArgb(255, 250, 0));
                g.DrawString("Status:", font3, Brushes.Black, point: new PointF(523, 190));
                g.DrawString("Ausente", font3, Brushes.Black, point: new PointF(730, 190));
                g.DrawString("Status:", font3, Brushes.Gray, point: new PointF(520, 187));
                g.DrawString("Ausente", font3, ausente, point: new PointF(727, 187));
            }
            if (membro.IsBot)
            {
                g.FillRectangle(cortotaldocargo, 400, 410, 110, 72);
                g.DrawString("BOT", font6, Brushes.Black, point: new PointF(401, 401));
                g.DrawString("BOT", font6, Brushes.White, point: new PointF(398, 398));
            }
            #endregion

            g.Dispose();
            ImgCapa.Dispose();
            ImgFoto.Dispose();

            img3.Save(local, System.Drawing.Imaging.ImageFormat.Png);
            img3.Dispose();
            await ctx.RespondWithFileAsync(local);
        }
    }
}