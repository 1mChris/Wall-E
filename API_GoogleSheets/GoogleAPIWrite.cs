using DSharpPlus.Entities;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wall_E.Comandos;
using Wall_E.Bot;
using Wall_E.Utilidades;
using Wall_E;

namespace Wall_E.API_GoogleSheets
{
    class GoogleAPIWrite
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Wall-E";

        public async Task googlewriter(DiscordUser a, string infracao, string b, string id, string rang)
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = Environment.GetFolderPath(
                    Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            String spreadsheetId = id;
            String range = rang;
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            //End of API v4

            // string data = " ";
            ValueRange response = await request.ExecuteAsync();
            IList<IList<Object>> values = response.Values;
            int quantity = 0;
            IList<Object> obj = new List<Object>();
            obj.Add(DateTime.Now.ToString("dd/MM/yyyy hh:MM:ss"));
            obj.Add(a.Id.ToString());
            obj.Add(a.Username);
            obj.Add(infracao);
            obj.Add(b);

            IList<IList<Object>> values2 = new List<IList<Object>>();
            values2.Add(obj);

            SpreadsheetsResource.ValuesResource.AppendRequest request2 =
                   service.Spreadsheets.Values.Append(new ValueRange() { Values = values2 }, spreadsheetId, range);
            request2.InsertDataOption = SpreadsheetsResource.ValuesResource.AppendRequest.InsertDataOptionEnum.INSERTROWS;
            request2.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.RAW;

            request2.Execute();
        }
    }
}