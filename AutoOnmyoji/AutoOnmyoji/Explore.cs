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
    class Explore
    {
        private static Bitmap expImage = ImageScanOpenCV.GetImage("./img/EXP.png");
        private static Bitmap nearExpImage = ImageScanOpenCV.GetImage("./img/NEAR-EXP.png");
        private static Bitmap farExpImage = ImageScanOpenCV.GetImage("./img/FAR-EXP.png");
        private static Bitmap fightImage = ImageScanOpenCV.GetImage("./img/FIGHT.png");
        private static Bitmap bossImage = ImageScanOpenCV.GetImage("./img/BOSS.png");
        private static Bitmap exploreImage = ImageScanOpenCV.GetImage("./img/courtyard_explore.png");
        private static Bitmap yingbingImage = ImageScanOpenCV.GetImage("./img/YING-BING.png");
        private static Bitmap exitCheckImage = ImageScanOpenCV.GetImage("./img/EXIT_CHECK.png");
        private static Bitmap okImage = ImageScanOpenCV.GetImage("./img/OK.png");
        private static Bitmap maxLvlImage = ImageScanOpenCV.GetImage("./img/MAX-EXP.png");
        private static int foodType = 0;
        private static int totalTurnFight = 0;
        private static int currentTurnFight = 0;

        public static void setFoodType(int foodType = 0)
        {
            Explore.foodType = foodType;
        }
        public static int getFoodType()
        {
            return foodType;
        }
        public static void setTotalTurnFight(int totalTurnFight = 0)
        {
            Explore.totalTurnFight = totalTurnFight;
        }
        public static int getTotalTurnFight()
        {
            return Explore.totalTurnFight;
        }
        public static void clickExplore()
        {
            GameImage.findAndClickImage(exploreImage, "explore", false, 0, 0, 0, 0, true);
        }
        public static Point? findExpMonster()
        {
            int i = 0;
            Point? expMonsterImage = null;
            Image scene = null; ;
            GameHelper.Log("Finding exp monster....");
            while (i < 5)
            {
                scene = CaptureHelper.CaptureWindow(Global.mainHandle);
                expMonsterImage = ImageScanOpenCV.FindOutPoint((Bitmap)scene, expImage);
                //expMonsterImage = GameImage.findGameImage(expImage);
                if (expMonsterImage != null)
                {
                    GameHelper.Log("Found Exp Monster(Middle)!!!");
                    break;
                }
                expMonsterImage = ImageScanOpenCV.FindOutPoint((Bitmap)scene, nearExpImage);
                if (expMonsterImage != null)
                {
                    GameHelper.Log("Found Exp Monster(Near)!!!");
                    break;
                }
                expMonsterImage = ImageScanOpenCV.FindOutPoint((Bitmap)scene, farExpImage);
                if (expMonsterImage != null)
                {
                    GameHelper.Log("Found Exp Monster(Far)!!!");
                    break;
                }
                i++;
                GameHelper.Delay(200);
            }
            if (expMonsterImage == null)
            {
                GameHelper.Log("Found Exp Monster Fail!!!");
            }
            return expMonsterImage;
        }

        public static bool clickToMonster(Point? monsterLocation)
        {
            int i = 0;
            Point? fightExpMonsterImage = null;
            GameHelper.Log("Finding to fight....");
            while (i < 5)
            {
                fightExpMonsterImage = GameImage.findGameImage(fightImage, "Fight Monster", true, monsterLocation.Value.X - 150, monsterLocation.Value.Y - 250, 300, 300);
                if (fightExpMonsterImage != null)
                {
                    GameImage.clickImage(fightImage, fightExpMonsterImage.Value.X + monsterLocation.Value.X - 150, fightExpMonsterImage.Value.Y + monsterLocation.Value.Y - 250, "Fight Monster");
                    GameHelper.Log("Click to fight exp monster");
                    return true;
                }
                i++;
                GameHelper.Delay(100);
            }

            if (fightExpMonsterImage == null)
            {
                fightExpMonsterImage = GameImage.findGameImage(bossImage, "Fight BOSS", true, monsterLocation.Value.X - 100, monsterLocation.Value.Y - 300, 200, 300);
                if (fightExpMonsterImage != null)
                {
                    GameImage.clickImage(bossImage, fightExpMonsterImage.Value.X + monsterLocation.Value.X - 100, fightExpMonsterImage.Value.Y + monsterLocation.Value.Y - 250, "Fight Boss");
                }
            }

            if (fightExpMonsterImage == null)
            {
                GameHelper.Log("Found fight image of exp monster Fail");
            }
            return false;
        }

        public static bool isExploreArea()
        {
            bool result = GameImage.waitGameImage(yingbingImage, 50000, 1000, true);
            if (result == true)
            {
                GameHelper.Log("In Explore Area");
                return true;
            }
            return false;
        }

        public static void swipeToNextExplore()
        {
            GameHelper.Log("Swipe");
            AutoControl.SendDragAndDropOnPosition(Global.mainHandle, 1077, 85, 385, 83, 10, 10, 0.01);
            GameHelper.Delay(1230);
        }

        public static void fightExpMonster(Point? monster)
        {
            if (clickToMonster(monster) == false)
            {
                return;
            }
            if (GameBattle.waitBattleReady() == false)
            {
                return;
            }
            checkFoodFullExp();
            GameHelper.Delay(500);
            GameBattle.battleStart();
            GameBattle.waitBattleEnd();
            GameHelper.Delay(500);
            GameBattle.clickEndBattle();
            GameHelper.Delay(500);
            GameImage.waitGameImage(yingbingImage);
            checkTurnFight();
        }

        public static void checkTurnFight()
        {
            if (totalTurnFight > 0)
            {
                currentTurnFight++;
                if (currentTurnFight >= totalTurnFight)
                {
                    Global.isStop = true;
                    Global.closeGame();
                }
            }
        }

        public static void findAndAttackExpMonster()
        {
            int i = 0;
            GameHelper.Delay(1000);
            while (i < 3 && !Global.isStop)
            {
                var expMonster = findExpMonster();
                if (expMonster != null)
                {
                    fightExpMonster(expMonster);
                }
                else
                {
                    swipeToNextExplore();
                    expMonster = null;
                    i++;
                }
            }
            return;
        }

        public static void exitExploreArea()
        {
            if (isExploreArea() != true)
            {
                return;
            }
            AutoControl.SendKeyBoardPress(Global.mainHandle, VKeys.VK_ESCAPE);
            GameHelper.Delay(1200);
            GameImage.findAndClickImage(okImage);

        }

        public static List<int> checkFoodFullExp()
        {
            List<int> result = new List<int>();
            if (GameImage.findGameImage(maxLvlImage, "Max exp image", true, GamePos.shikiCenterBattle[0], GamePos.shikiCenterBattle[1], GamePos.shikiCenterBattle[2] - GamePos.shikiCenterBattle[0], GamePos.shikiCenterBattle[3] - GamePos.shikiCenterBattle[1]) != null)
            {
                result.Add(1);
            }
            if (GameImage.findGameImage(maxLvlImage, "Max exp image", true, GamePos.shikiRightBattle[0], GamePos.shikiRightBattle[1], GamePos.shikiRightBattle[2] - GamePos.shikiRightBattle[0], GamePos.shikiRightBattle[3] - GamePos.shikiRightBattle[1]) != null)
            {
                result.Add(2);
            }

            if (result.Count > 0)
            {
                GameHelper.Log("Click to change shiki");
                GameHelper.clickGame(655, 482, true);
                GameHelper.Delay(1000);
                ShikiFood.findShikiFood(foodType, result);
            }
            return result;
        }

        public static void ExploreAction()
        {
            GameHelper.Log("Start new Explore");
            if (GameImage.waitGameImage(exploreImage, 100000, 1000, true) == false)
            {
                Global.isStop = true;
                return;
            }
            clickExplore();
            GameHelper.Delay(516);
            if (isExploreArea() != true)
            {
                Global.isStop = true;
                return;
            }
            GameHelper.Delay(525);
            swipeToNextExplore();
            GameHelper.Delay(525);
            findAndAttackExpMonster();
            GameHelper.Delay(525);
            exitExploreArea();
            GameHelper.Delay(528);
        }
    }
}
