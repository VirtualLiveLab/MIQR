using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using OpenCvSharp;
using ZXing;

/// <summary>
/// 各個人に対してこのクラス作ってる、気がする
/// </summary>
namespace MIQR
{
    public class QrProcedure
    {
        // old
        // public int ReserveNumber { get; }

        // new (for 2022)
        public int PerformanceNum { get; }
        public string Name { get; }
        public string Uuid { get; }

        public bool CollectId { get; }

        public QrProcedure(string decodedValue)
        {
            try
            {
                string[] value = decodedValue.Split('_');
                //ReserveNumber = int.Parse(value[0]);
                PerformanceNum = int.Parse(value[0]);
                Uuid = value[1];
                CollectId = true;
            }
            catch (Exception e)
            {
                CollectId = false;
            }
        }

        // public string SearchGoogle(string reserveNumber)
        public string SearchGoogle(string uuid)
        {
            int resultIndex = GoogleApiConnection.Data.FindIndex(n => n.Uuid == uuid);
            if (resultIndex != -1)
            {
                return GoogleApiConnection.Data[resultIndex].Uuid;
            }

            return "Not Found";
        }


        
        //これ多分使わない

        public bool CollateUuid()
        {
            // "0000"は文字列のフォーマット指定用
            // int resultIndex = GoogleApiConnection.Data.FindIndex(n => n.ReserveNumber == ReserveNumber.ToString("0000"));
            int resultIndex = GoogleApiConnection.Data.FindIndex(n => n.Uuid == this.Uuid);

            if (resultIndex != -1)  // 予約があったら
            {
                return true;
                //if (GoogleApiConnection.Data[resultIndex].Uuid == this.Uuid)
                //{
                //    return true;
                //}
            }
            return false;
        }





        // キャンセルのこと気にしてないのちょっとやばいかも
        // DBにはキャンセルした人も含まれる





    }
}