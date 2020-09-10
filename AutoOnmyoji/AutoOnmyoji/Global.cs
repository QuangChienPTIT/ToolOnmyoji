using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoOnmyoji
{
    class Global
    {
        public static IntPtr mainHandle { get; set; }
        public static bool isStop = false;
        public static bool autoClose = false;
        public static void closeGame()
        {

            GameHelper.Log("Tat game di ngu");
            //isStop = true;
            if (autoClose == true)
            {
                foreach (var process in Process.GetProcessesByName("client"))
                {
                    process.Kill();
                }
            }
        }
    }
}
