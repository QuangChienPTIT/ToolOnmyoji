using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOnmyoji
{
    class GamePos
    {
        //game Pos{x,y,width,height}
        public static int[] shikiCenterRight = { 0, 0, 0, 0 };
        public static int[] shikiCenterBattle = { 365, 230, 506, 476 };
        public static int[] shikiRightBattle = { 594, 293, 755, 551 };
        public static int[][] shikiPositionArray = { shikiCenterRight, shikiCenterBattle, shikiRightBattle };
        public static int[] shikiLeftDrag= { 0, 0, 0, 0 };
        public static int[] shikiCenterDrag = { 503, 307, 614, 404 };
        public static int[] shikiRightDrag = { 146, 267, 248, 369 };
        public static int[][] shikiPositionDrag = { shikiLeftDrag, shikiCenterDrag, shikiRightDrag };
        public static int[] allShikiButton = { 67, 623, 69, 626 };
        public static int[] NShikiButton = { 134, 281, 178, 324 };
        public static int[] MShikiButton = { 40, 263, 85, 311 };
        public static int[] RShikiButton = { 215, 320, 263, 370 };
        public static int[][] shikiTypeButton = { NShikiButton, MShikiButton, RShikiButton };
    }
}
