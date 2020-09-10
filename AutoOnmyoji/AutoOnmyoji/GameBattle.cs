using KAutoHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoOnmyoji
{

    class GameBattle
    {
        private static Bitmap readyImage = ImageScanOpenCV.GetImage("./img/READY.png");
        private static Bitmap battleLoadedImage = ImageScanOpenCV.GetImage("./img/BATTLE_LOADED.png");
        private static Bitmap goldImage = ImageScanOpenCV.GetImage("./img/GOLD.png");
        private static Bitmap winImage = ImageScanOpenCV.GetImage("./img/WIN.png");
        private static Bitmap loseImage = ImageScanOpenCV.GetImage("./img/LOSE.png");
        public static bool waitBattleReady()
        {
            if (GameImage.waitGameImage(battleLoadedImage, 10000, 2000) == true)
            {
                GameHelper.Log("Battle Ready");
                return true;
            }
            return false;
        }

        public static void battleStart()
        {
            GameImage.clickImage(readyImage, 976, 488, "start Battle");
        }

        public static void clickEndBattle()
        {
            GameHelper.clickGame(567, 627);
            GameHelper.Delay(500);
            GameHelper.clickGame(568, 627);
            GameHelper.Delay(500);
            GameHelper.clickGame(568, 627);
        }

        public static bool waitBattleEnd()
        {

            Bitmap[] images = { loseImage, goldImage };
            List<int> imageResult = new List<int>();
            int i = 0;
            while (i < 20)
            {
                GameHelper.Delay(3000);
                imageResult = GameImage.findMultiGameImage(images);
                if (imageResult.Count() > 0)
                {
                    break;
                }
                i++;
            }
            if (imageResult.Count() < 1)
            {
                GameHelper.Log("Battle Error");
                return false;
            }
            if(imageResult[0] == 1)
            {
                GameHelper.Log("Win Battle");
                return true;
            }
            if (imageResult[0] == 0)
            {
                GameHelper.Log("Lose Battle");
                return true;
            }
            /*bool result = GameImage.waitGameImage(goldImage, 100000, 5000);
            if (result == true)
            {
                GameHelper.Log("End Battle");
                return true;
            }*/
            return false;
        }
    }
}
