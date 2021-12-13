using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;

namespace MIQR
{
    public class GoogleApiConnection
    {
        /// <summary>
        /// 指定日時の全ユーザーの予約状況を格納
        /// </summary>
        public static List<UserInformation> Data = new List<UserInformation>();

        private static string[] _scopes = {SheetsService.Scope.Spreadsheets};
        private static string _applicationName = "MIQR";
        private static string _spreadSheetId = ""; // for real

        public static bool ReadGoogle(string liveList = "TEST")
        {
            try
            {
                UserCredential userCredential;
                using (var fs = new FileStream("googleAuthMIQR.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(fs).Secrets, _scopes, "user", CancellationToken.None,
                        new FileDataStore(credPath,true)).Result;
                }
                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = userCredential,
                    ApplicationName = _applicationName
                });

                SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(_spreadSheetId, liveList + "!A:E");

                ValueRange response = request.Execute();
                IList<IList<Object>> values = response.Values;
                StringBuilder sb = new StringBuilder();
                Data.Clear();
                if (values != null && values.Count > 0)  
                {
                    foreach (var row in values)
                    {
                        if (row.Count > 0)
                        {
                            UserInformation userInformation = new UserInformation()
                            {
                                SeatNumber = row[2] != null ? row[2].ToString() : "NULL",
                                ReserveNumber = row[0] != null ? row[0].ToString() : "-1",
                                Uuid = row[1] != null ? row[1].ToString() : "NULL",
                                CheckedIn = row[3] != null ? row[3].ToString() : "FALSE",
                            };
                            Data.Add(userInformation);
                        }
                        else
                        {
                            UserInformation userInformation = new UserInformation()
                            {
                                SeatNumber = "NULL",
                                ReserveNumber = "-1",
                                Uuid = "NULL",
                                CheckedIn = "FALSE",
                            };
                            Data.Add(userInformation);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public static bool WriteGoogle(bool trigger, int reserveNumber, string liveList = "TEST")
        {
            // 検索ここ入れる / splashの次に設定画面 / 席一覧はウィンドウ追加 / backgroundWorkerを自動生成に切り替え / フォントの埋め込み
            int index = Data.FindIndex(n => int.Parse(n.ReserveNumber) == reserveNumber);
            if (Data[index].CheckedIn == "TRUE") return false;
            try
            {
                UserCredential userCredential;
                using (var fs = new FileStream("googleAuthMIQR.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(fs).Secrets, _scopes, "user", CancellationToken.None,
                        new FileDataStore(credPath,true)).Result;
                }
                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = userCredential, 
                    ApplicationName = _applicationName
                });
                var wv = new List<IList<object>>()
                {
                    new List<object> { trigger.ToString() }
                };
                var body = new ValueRange() { Values = wv};
                SpreadsheetsResource.ValuesResource.UpdateRequest request = service.Spreadsheets.Values.Update(body, _spreadSheetId, liveList + $"!D{index + 1}");
                request.ValueInputOption =
                    SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                var response = request.Execute();
            }
            catch (Exception e)
            {
                return false;
            }
            
            return true;
        }
    }

    public struct UserInformation
    {
        public string SeatNumber;
        public string ReserveNumber;
        public string Uuid;
        public string CheckedIn;
    }
    
}