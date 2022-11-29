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


        // 取り扱い注意
        private static string _spreadSheetId = "129cjs7Rl_P1rWEHNxaYiEnHqxNuaTXz-1ypvnqYUU4Q"; // for real

        /// <summary>
        /// google スプレッドシートから全情報をfetchする
        /// </summary>
        /// <param name="liveList"></param>
        /// <returns></returns>
        public static bool ReadGoogle(string liveList = "9")
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

                SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(_spreadSheetId, liveList + "!A:F");

                ValueRange response = request.Execute();
                IList<IList<Object>> values = response.Values;
                StringBuilder sb = new StringBuilder();
                Data.Clear();   // これが顧客リストっぽい
                if (values != null && values.Count > 0)  
                {
                    foreach (var row in values)
                    {
                        if (row.Count > 0)
                        {
                            UserInformation userInformation = new UserInformation()
                            {
                                // 構造体の初期化っぽい

                                //SeatNumber = row[2] != null ? row[2].ToString() : "NULL",
                                //ReserveNumber = row[0] != null ? row[0].ToString() : "-1",
                                Name = row[0] != null ? row[0].ToString() : "No name",
                                Uuid = row[3] != null ? row[3].ToString() : "NULL",
                                CheckedIn = row[5] != null ? row[5].ToString() : "FALSE",
                            };

                            // debug
                            //MessageBox.Show($"{userInformation.Name}", $"来る人", MessageBoxButtons.OK);
                            // debug end

                            Data.Add(userInformation);
                        }
                        else
                        {
                            UserInformation userInformation = new UserInformation()
                            {
                                // SeatNumber = "NULL",
                                // ReserveNumber = "-1",
                                Name = "No Name",
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

            // Dataの先頭が表の一番上、項目を持っちゃってるのでリストの先頭を削除
            Data.RemoveAt(0);

            return true;
        }


        public static bool WriteGoogle(bool trigger, string uuid, string liveList = "9")
        {
            // 検索ここ入れる / splashの次に設定画面 / 席一覧はウィンドウ追加 / backgroundWorkerを自動生成に切り替え / フォントの埋め込み

            // 検索(uuidで検索、その人がすでにチェックインしてたら）
            // int index = Data.FindIndex(n => int.Parse(n.ReserveNumber) == reserveNumber);
            int index = Data.FindIndex(n => n.Uuid == uuid);

            if (Data[index].CheckedIn == "TRUE")
            {
                return false;
            }
            // Data[index].CheckedIn == "FALSE" || null すなわち受付されてなかったら
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

                // 書き込むデータを一旦リストの形にしてるのかな？
                var wv = new List<IList<object>>()
                {
                    new List<object> { trigger.ToString() } // これが書き込む内容か、セルを"TRUE"にするってことか
                };
                var body = new ValueRange() { Values = wv };

                // 多分この辺で実際に書き換えてる
                SpreadsheetsResource.ValuesResource.UpdateRequest request =
                        // service.Spreadsheets.Values.Update(body, _spreadSheetId, liveList + $"!D{index + 1}");
                        service.Spreadsheets.Values.Update(body, _spreadSheetId, liveList + $"!F{index + 2}");  // 2022年はFのカラムが「受付済み」を表す
                        // 文字列前の $ マークは、文字列に変数をぶち込むための物、indexの + 1 ってのは、0 始まりか1始まりかの対策かと
                        // +1 でなく +2なのは、カラムの名前の列を考慮するとそうなる
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
        // public string SeatNumber;
        // public string ReserveNumber;
        public string Name;
        public string Uuid;
        public string CheckedIn;
    }
    
}