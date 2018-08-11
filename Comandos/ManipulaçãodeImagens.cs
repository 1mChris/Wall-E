using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Configuration;
using System.Net;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Wall_E.Comandos
{
    public class ManipulaçãodeImagens
    {
        [Command("Medalhas")]
        [Aliases("medalhas", "medalha", "MEDALHA", "MEDALHAS", "m", "M")]

        public async Task MedalhasFoxhole(CommandContext ctx, DiscordMember membro = null, DiscordRole role = null)
        {
            await ctx.TriggerTypingAsync();
            if (membro == null)
            {
                membro = ctx.Member;
            }

            var cordocargo = membro.Color;
            cordocargo.R.ToString("X");
            cordocargo.G.ToString("X");
            cordocargo.B.ToString("X");
            var cortotaldocargo = new SolidBrush(Color.FromArgb(255, cordocargo.R, cordocargo.G, cordocargo.B));
            var retangulofoto = new Pen(Color.FromArgb(255, cordocargo.R, cordocargo.G, cordocargo.B)) { Width = 9 };
            var foto = membro.GetAvatarUrl(DSharpPlus.ImageFormat.Png, 256);

            string capa = (Directory.GetCurrentDirectory() + @"\Capa.png");
            string fotousuario = (Directory.GetCurrentDirectory() + @"\Foto.png");

            PrivateFontCollection collection = new PrivateFontCollection();
            collection.AddFontFile(Directory.GetCurrentDirectory() + @"\Anton.ttf");
            FontFamily fontFamily = new FontFamily("Anton", collection);
            Font font = new Font(fontFamily, 48);
            PrivateFontCollection collection2 = new PrivateFontCollection();
            collection.AddFontFile(Directory.GetCurrentDirectory() + @"\Anton.ttf");
            FontFamily fontFamily2 = new FontFamily("Anton", collection);
            Font font2 = new Font(fontFamily, 35);

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

            string local = (Directory.GetCurrentDirectory() + @"\img3.png");

            Bitmap img3 = new Bitmap(ImgCapa.Width, ImgCapa.Height);
            Graphics g = Graphics.FromImage(img3);

            ImgFoto = ImgFoto.GetThumbnailImage(277, (295 * ImgFoto.Height) / ImgFoto.Width, null, IntPtr.Zero);

            g.Clear(Color.Black);
            g.DrawImage(ImgCapa, new Point(0, 0));
            g.DrawImage(ImgFoto, new Point(posX, posY));
            g.DrawRectangle(retangulofoto, x: 11, y: 11, width: 280, height: 299);
            g.DrawString($"@{membro.DisplayName}#{membro.Discriminator}", font, Brushes.Black, point: new PointF(302, 43));
            g.DrawString($"@{membro.DisplayName}#{membro.Discriminator}", font, brush: (cortotaldocargo), point: new PointF(299, 40));
            g.DrawString($"{membro.Username}#{membro.Discriminator}", font2, Brushes.Black, point: new PointF(306, 111));
            g.DrawString($"{membro.Username}#{membro.Discriminator}", font2, Brushes.Gray, point: new PointF(303, 108));

            g.Dispose();
            ImgCapa.Dispose();
            ImgFoto.Dispose();

            img3.Save(local, System.Drawing.Imaging.ImageFormat.Png);
            img3.Dispose();
            await ctx.RespondWithFileAsync(local);
        }
    }
}