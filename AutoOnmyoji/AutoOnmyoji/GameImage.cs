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
    class GameImage
    {
        public static void clickImage(Bitmap image, int x, int y, string imageName = "image", bool doubleClick = false)
        {
            /*int _x = GameRandom.RandomNumber(x, x + 5);
            int _y = GameRandom.RandomNumber(y, y + 5);
            int _x2 = GameRandom.RandomNumber(x, x + 10);
            int _y2 = GameRandom.RandomNumber(y, y + 10);*/
            //AutoControl.SendClickOnPosition(Global.mainHandle, x, y, EMouseKey.LEFT);
            AutoControl.SendDragAndDropOnPosition(Global.mainHandle, x, y, x + 1, y + 1, 10, 10, 0.2);
            if (doubleClick)
            {
                AutoControl.SendDragAndDropOnPosition(Global.mainHandle, x, y, x + 1, y + 1);
                //AutoControl.SendClickOnPosition(Global.mainHandle, x, y, EMouseKey.LEFT);
                GameHelper.Log("Double Clicked to " + imageName);
            }
            else
            {
                GameHelper.Log("Clicked to " + imageName);
            }
        }

        public static bool findAndClickImage(Bitmap image, string imageName = "image", bool cropMode = false, int x = 0, int y = 0, int width = 0, int height = 0, bool capture = false, bool recheck = false)
        {
            Point? imageResult = findGameImage(image, imageName, cropMode, x, y, width, height, capture);
            int i = 0;
            if (imageResult != null)
            {
                clickImage(image, imageResult.Value.X + x, imageResult.Value.Y + y, imageName);
                while (i < 3 && recheck)
                {
                    GameHelper.Delay(500);
                    imageResult = findGameImage(image, imageName, cropMode, x, y, width, height, false);
                    if (imageResult != null)
                    {
                        clickImage(image, imageResult.Value.X + x, imageResult.Value.Y + y, imageName);
                        i++;
                    }
                    else
                    {
                        return true;
                    }
                }
                GameHelper.Log("Found " + imageName);
                return true;
            }
            GameHelper.Log("Cant find " + imageName);
            return false;
        }

        public static Point? findGameImage(Bitmap image, string imageName = "", bool cropMode = false, int x = 0, int y = 0, int width = 0, int height = 0, bool capture = false)
        {
            var scene = CaptureHelper.CaptureWindow(Global.mainHandle);
            if (cropMode == true)
            {
                scene = CaptureHelper.CropImage(scene, new System.Drawing.Rectangle(x, y, width, height));
            }
            var result = ImageScanOpenCV.FindOutPoint((Bitmap)scene, image);
            if (capture == true && result != null)
            {
                var imageSave = ImageScanOpenCV.Find((Bitmap)scene, image);
                imageSave.Save("./img/debug/imageCapture" + result.Value.X + "_" + result.Value.Y + ".png");
            }
            return result;
        }

        public static List<int> findMultiGameImage(Bitmap[] images, bool cropMode = false, int x = 0, int y = 0, int width = 0, int height = 0, bool capture = false)
        {
            List<int> result = new List<int>();
            var scene = CaptureHelper.CaptureWindow(Global.mainHandle);
            if (cropMode == true)
            {
                scene = CaptureHelper.CropImage(scene, new System.Drawing.Rectangle(x, y, width, height));
            }
            var index = 0;
            Point? resultScanImage;
            foreach (Bitmap image in images)
            {
                resultScanImage = null;
                resultScanImage = ImageScanOpenCV.FindOutPoint((Bitmap)scene, image);
                if (resultScanImage != null)
                {
                    result.Add(index);
                }
                index++;
            }
            return result;
        }

        public static bool waitGameImage(Bitmap image, int max_time = 10000, int delay_time = 1000, bool quit = false)
        {
            int i = 0;
            Point? findImageResult = null;
            while (i < max_time / 1000)
            {
                GameHelper.Delay(1000);
                findImageResult = findGameImage(image);
                if (findImageResult != null)
                {
                    return true;
                }
                i++;
            }
            if (quit == true)
            {
                Global.closeGame();
            }

            return false;
        }
        public static void saveImage(int x, int y, int width, int height)
        {
            var scene = CaptureHelper.CaptureWindow(Global.mainHandle);
            scene = CaptureHelper.CropImage(scene, new System.Drawing.Rectangle(x, y, width, height));
            scene.Save("./img/debug/saveImage.png");
        }
    }
}
