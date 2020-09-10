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
    class ShikiFood
    {
        public static Bitmap allShikiImage = ImageScanOpenCV.GetImage("./img/QUAN-BU.png");
        private static Bitmap shikiMaxImage = ImageScanOpenCV.GetImage("./img/shiki-max.png");
        private static Bitmap shikiFightImage = ImageScanOpenCV.GetImage("./img/shiki-fight.png");
        private static Bitmap twoStarGrayImage = ImageScanOpenCV.GetImage("./img/two-star-gray.png");
        private int x1 = 0;
        private int y1 = 0;
        private int x2 = 0;
        private int y2 = 0;
        public int[] getPosition()
        {
            int[] result = { x1, y1, x2, y2 };
            return result;
        }
        public void setPosition(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public static ShikiFood findShikiFood(int foodType = 0, List<int> shikiMaxPositions = null)
        {
            /*
             * foodType: 0 => N ; 1 => Daruma ; 2 => R
             */
            GameHelper.Log(foodType.ToString());
            if (foodType > 2 || foodType < 0)
            {
                foodType = 0;
            }
            int[] shikiTypePos = GamePos.shikiTypeButton[foodType];
            GameHelper.Delay(500);
            GameImage.waitGameImage(allShikiImage, 5000, 1000);
            GameHelper.clickRandomArea(GamePos.allShikiButton[0], GamePos.allShikiButton[1], GamePos.allShikiButton[2], GamePos.allShikiButton[3]);
            GameHelper.Delay(1000);
            GameHelper.clickRandomArea(shikiTypePos[0], shikiTypePos[1], shikiTypePos[2], shikiTypePos[3]);
            GameHelper.Delay(1000);
            if (shikiMaxPositions.Count > 0)
            {
                int swipeCount = 0;
                shikiMaxPositions.ForEach(delegate (int position)
                    {
                        int[] shikiMaxPos = GamePos.shikiPositionDrag[position];
                        while (swipeCount < 3)
                        {
                            int shikiStartX = findShiki(swipeCount);
                            if (shikiStartX != -1)
                            {
                                GameHelper.Delay(1000);
                                //GameHelper.dragAndDropGame(shikiStartX + 50, 490, shikiMaxPos[0] + (shikiMaxPos[2] - shikiMaxPos[0]) / 2, shikiMaxPos[1] + (shikiMaxPos[3] - shikiMaxPos[1]) / 2);
                                Point point1 = new Point();
                                point1.X = shikiStartX + 50;
                                point1.Y = 490;
                                Point point2 = new Point();
                                point2.X = point1.X;
                                point2.Y = shikiMaxPos[1];
                                Point point3 = new Point();
                                point3.X = shikiMaxPos[0] + (shikiMaxPos[2] - shikiMaxPos[0]) / 2;
                                point3.Y = point2.Y;
                                Point[] points = { point1, point2, point3 };
                                GameHelper.dragAndDropMultiGame(points);
                                GameHelper.Delay(1500);
                                break;
                            }
                            else
                            {
                                GameHelper.dragAndDropGame(903, 541, 201, 531);
                                swipeCount++;
                            }
                        }
                    });
            }

            //go to food storage
            return null;
        }

        public static int findShiki(int swipeCount)
        {
            int start_y = 441;
            int start_x = 136;
            int end_x = 917;
            int width = 113;
            int height = 161;
            var current_x = start_x;
            Bitmap[] imagesFind = { shikiMaxImage, shikiFightImage };
            List<int> searchResult = null;
            while (!Global.isStop && current_x < end_x)
            {
                searchResult = GameImage.findMultiGameImage(imagesFind, true, current_x, start_y, width, height);
                if (searchResult.Count < 1)
                {
                    return current_x;
                }
                else
                {
                    GameHelper.Log("Khong hop le");
                    current_x += width;
                }

            }
            return -1;
        }

        public void dragFoodToPosition(int position)
        {
            /*
             * position: 0 = left; 1 = center; 2 = right;
             * */
            int[] dropFoodPosition = GamePos.shikiPositionArray[position];
            int xCenter = this.x1 + this.x2 / 2;
            int yCenter = this.y1 + this.y2 / 2;
            int[] pointDrag = { GameRandom.RandomNumber(xCenter, xCenter + 10), GameRandom.RandomNumber(yCenter, yCenter + 10) };
            int _xCenter = dropFoodPosition[0] + dropFoodPosition[2] / 2;
            int _yCenter = dropFoodPosition[1] + dropFoodPosition[3] / 2;
            int[] pointDrop = { GameRandom.RandomNumber(_xCenter, _xCenter + 10), GameRandom.RandomNumber(_yCenter, _yCenter + 10) };
            GameHelper.dragAndDropGame(pointDrag[0], pointDrag[1], pointDrop[0], pointDrop[1]);
        }
    }
}
