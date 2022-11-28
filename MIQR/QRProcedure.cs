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

namespace MIQR
{
    public class QrProcedure
    {
        // old
        public int ReserveNumber { get; }

        // new (for 2022)
        public int PerformanceNum { get; }
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
        public string SearchGoogle(string )
        {
            int resultIndex = GoogleApiConnection.Data.FindIndex(n => n.ReserveNumber == reserveNumber);
            if (resultIndex != -1)
            {
                return GoogleApiConnection.Data[resultIndex].Uuid;
            }

            return "Not Found";
        }


        
        //これ多分使わない

        //public bool CollateUuid()
        //{
        //    int resultIndex = GoogleApiConnection.Data.FindIndex(n => n.ReserveNumber == ReserveNumber.ToString("0000"));
        //    if (resultIndex != -1)
        //    {
        //        if (GoogleApiConnection.Data[resultIndex].Uuid == Uuid)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}


    }
}