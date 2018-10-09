using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E.Utilidades
{
    public class Utilidades
    {
        public DiscordColor randomColor()
        {
            Random _r = new Random(DateTime.Now.Ticks.GetHashCode());
            int r = _r.Next(0, 255);
            int g = _r.Next(0, 255);
            int b = _r.Next(0, 255);
            string rHex = r.ToString("X");
            string gHex = g.ToString("X");
            string bHex = b.ToString("X");
            int cor = Convert.ToInt32(rHex + gHex + bHex, 16);

            DiscordColor color = new DiscordColor(cor);
            return color;
        }

        public int getTime(string tempo)
        {
            int time = 0;
            if (tempo.Contains('s'))
            {

                Int32.TryParse(tempo.Split('s')[0], out time);


                time = time * 1000;
            }
            else if (tempo.Contains('m'))
            {
                Int32.TryParse(tempo.Split('m')[0], out time);

                time = (time * 60) * 1000;
            }
            else if (tempo.Contains('h'))
            {
                Int32.TryParse(tempo.Split('h')[0], out time);

                time = (time * 3600) * 1000;
            }
            return time;
        }

        public string randomHex()
        {
            Random _r = new Random(DateTime.Now.Ticks.GetHashCode());
            String hex = "0x";
            string posthex = "";
            for (int i = 0; i < 8; i++)
            {
                int a = _r.Next(0, 16);

                if (a == 0)
                {
                    posthex += "0";
                }
                else if (a == 1)
                {
                    posthex += "1";
                }
                else if (a == 2)
                {
                    posthex += "2";
                }
                else if (a == 3)
                {
                    posthex += "3";
                }
                else if (a == 4)
                {
                    posthex += "4";
                }
                else if (a == 5)
                {
                    posthex += "5";
                }
                else if (a == 6)
                {
                    posthex += "6";
                }
                else if (a == 7)
                {
                    posthex += "7";
                }
                else if (a == 8)
                {
                    posthex += "8";
                }
                else if (a == 9)
                {
                    posthex += "9";
                }
                else if (a == 10)
                {
                    posthex += "A";
                }
                else if (a == 11)
                {
                    posthex += "B";
                }
                else if (a == 13)
                {
                    posthex += "C";
                }
                else if (a == 14)
                {
                    posthex += "D";
                }
                else if (a == 15)
                {
                    posthex += "E";
                }
                else if (a == 16)
                {
                    posthex += "F";
                }
            }
            hex += posthex;
            return hex;
        }

        public void Wait(int ms)
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms)
            {

            }
        }
    }
}