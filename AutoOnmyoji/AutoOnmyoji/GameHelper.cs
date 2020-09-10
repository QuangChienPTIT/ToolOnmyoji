using KAutoHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoOnmyoji
{
    class GameHelper
    {

        public static void Delay(double delay)
        {
            //var randomTime = GameRandom.RandomNumber(0, 300);
            Thread.Sleep(TimeSpan.FromMilliseconds(delay));
            /*double i = 0;
            delay = delay + randomTime;
            while (i < delay)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(200));
                i += 200;
            }*/
        }

        public static void clickGame(int x, int y, bool doubleClick = false)
        {
            //AutoControl.SendClickOnPosition(Global.mainHandle, x, y);
            AutoControl.SendDragAndDropOnPosition(Global.mainHandle, x, y, x+2, y+2,10,10,0.2);
            if (doubleClick)
            {
                //AutoControl.SendClickOnPosition(Global.mainHandle, x, y);
                AutoControl.SendDragAndDropOnPosition(Global.mainHandle, x, y, x+2, y+2);
            }
        }

        public static void dragAndDropGame(int x1, int y1, int x2, int y2, int stepx = 10, int stepy = 10, double delay = 0.05)
        {
            AutoControl.SendDragAndDropOnPosition(Global.mainHandle, x1, y1, x2, y2, stepx, stepy, delay);
        }
        public static void dragAndDropMultiGame(Point[] points, int stepx = 10, int stepy = 10, double delay = 0.05)
        {
            AutoControl.SendDragAndDropOnMultiPosition(Global.mainHandle, points, stepx, stepy, delay);
        }

        public static void clickRandomArea(int x1, int y1, int x2, int y2, bool doubleClick = false)
        {
            int _x = GameRandom.RandomNumber(x1, x2);
            int _y = GameRandom.RandomNumber(y1, y2);
            AutoControl.SendDragAndDropOnPosition(Global.mainHandle, _x, _y, _x+1, _y+1,10,10,0.2);
            //AutoControl.SendClickOnPosition(Global.mainHandle, _x, _y);
            if (doubleClick)
            {
                AutoControl.SendDragAndDropOnPosition(Global.mainHandle, _x, _y, _x+1, _y+1);
                //AutoControl.SendClickOnPosition(Global.mainHandle, _x, _y);
            }
        }
        public static void Log(string message,
                    [CallerFilePath] string file = null,
                    [CallerLineNumber] int line = 0)
        {
            string currentTime = DateTime.Now.ToString("HH:mm:ss dd-MM-yyyy");
            Console.WriteLine("{0} ({1}): {2}", Path.GetFileName(file), line, currentTime + "     " + message);
        }
    }
}
