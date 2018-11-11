using DSharpPlus.Entities;
using System;
using System.Linq;
using System.Data.SqlServerCe;
using System.IO;
using Newtonsoft.Json;

namespace Wall_E.Utilidades
{
    public class Utilidades
    {
        public static string CriarPasta;
        public static string DB;

        public DiscordColor randomColor() {
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

        public int getTime(string tempo) {
            int time = 0;
            if (tempo.Contains('s')) {
                Int32.TryParse(tempo.Split('s')[0], out time);
                time = time * 1000;
            }
            else if (tempo.Contains('m')) {
                Int32.TryParse(tempo.Split('m')[0], out time);
                time = (time * 60) * 1000;
            }
            else if (tempo.Contains('h')) {
                Int32.TryParse(tempo.Split('h')[0], out time);
                time = (time * 3600) * 1000;
            }
            return time;
        }

        public void Wait(int ms)
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms) {

            }
        }

        public static void CriarPastaBDTorneioOS() {
            CriarPasta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\TorneioOS\";

            if (!Directory.Exists(CriarPasta)) {
                Directory.CreateDirectory(CriarPasta);
            }

            DB = CriarPasta + "TorneioOS.sdf";
            if (!File.Exists(DB)) {
                CriarDB();
            }
        }

        public static void CriarDB() {
            SqlCeEngine Engine = new SqlCeEngine($"Data Source = {DB}");
            Engine.CreateDatabase();

            SqlCeConnection Conexao = new SqlCeConnection();
            Conexao.ConnectionString = $"Data Source = {DB}";
            Conexao.Open();
                
            string query = "CREATE TABLE TabelaTorneio(" +
                "ID_Time               int not null primary key, " +
                "NomeDoTime            nvarchar(20), " +
                "Jogadores             nvarchar(250), " +
                "Hora_Dia              datetime)";

            SqlCeCommand Comando = new SqlCeCommand(query, Conexao);
            Comando.ExecuteNonQuery();

            Comando.Dispose();
            Conexao.Dispose();
        }

        public partial class Membro
        {
            [JsonProperty("discord_id", NullValueHandling = NullValueHandling.Ignore)]
            public string DiscordId { get; set; }

            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty("registered_at", NullValueHandling = NullValueHandling.Ignore)]
            public string RegisteredAt { get; set; }

            [JsonProperty("roles", NullValueHandling = NullValueHandling.Ignore)]
            public string[] Roles { get; set; }

            [JsonProperty("servers", NullValueHandling = NullValueHandling.Ignore)]
            public Servers Servers { get; set; }

            [JsonProperty("total_captures", NullValueHandling = NullValueHandling.Ignore)]
            public long? TotalCaptures { get; set; }

            [JsonProperty("total_deaths", NullValueHandling = NullValueHandling.Ignore)]
            public long? TotalDeaths { get; set; }

            [JsonProperty("total_kills", NullValueHandling = NullValueHandling.Ignore)]
            public long? TotalKills { get; set; }
        }
    }

    public partial class Servers {
        [JsonProperty("UBGE-TDM", NullValueHandling = NullValueHandling.Ignore)]
        public Ubge UbgeTdm { get; set; }

        [JsonProperty("UBGE-TOW", NullValueHandling = NullValueHandling.Ignore)]
        public Ubge UbgeTow { get; set; }

        [JsonProperty("UBGE-ARENA", NullValueHandling = NullValueHandling.Ignore)]
        public Ubge UbgeArena { get; set; }

        [JsonProperty("[Brasil] Ace of Spades CTF", NullValueHandling = NullValueHandling.Ignore)]
        public BrasilAceOfSpadesCtf BrasilAceOfSpadesCtf { get; set; }
    }

    public partial class BrasilAceOfSpadesCtf {
        [JsonProperty("deaths", NullValueHandling = NullValueHandling.Ignore)]
        public long? Deaths { get; set; }
    }

    public partial class Ubge {
        [JsonProperty("deaths", NullValueHandling = NullValueHandling.Ignore)]
        public long? Deaths { get; set; }

        [JsonProperty("kills", NullValueHandling = NullValueHandling.Ignore)]
        public long? Kills { get; set; }
    }
}