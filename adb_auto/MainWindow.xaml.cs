using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KAutoHelper;
using Color = System.Drawing.Color;

namespace adb_auto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region data
        Bitmap BOMB_BMP;
        Bitmap BIG_BOMB_BMP;
        Bitmap WIN_BMP;
        Bitmap LEVEL_UP_BMP;
        Bitmap STAGE1_BMP;
        Bitmap STAGE2_BMP;
        Bitmap STAGE3_BMP;
        Bitmap STAGE4_BMP;
        Bitmap STAGE5_BMP;
        Bitmap STAGE6_BMP;
        Bitmap STAGE7_BMP;
        Bitmap UPGRADE_BUILDING_BMP;
        Bitmap PLUS_BMP;
        Bitmap PYRO_BMP;
        Bitmap BUILDING_RIGHT_YELLOW_CAR_BMP;
        Bitmap PLUS_COLLECT_BMP;
        Bitmap PLUS_COLLECT_2_BMP;
        Bitmap BUILD_FARM_1_BMP;
        Bitmap BUILD_FARM_2_BMP;
        Bitmap PLUS_COLLECT_3_BMP;
        Bitmap BUILD_FARM_3_BMP;
        Bitmap UPGRADE_ROCK_BMP;
        Bitmap BUILD_FARM_4_BMP;
        Bitmap PLUS_COLLECT_4_BMP;
        Bitmap TOMATO_BMP;
        Bitmap BUILD_FARM_5_BMP;
        Bitmap EXIT_BMP;
        Bitmap ROCK_BMP;
        Bitmap SCHOOL_BMP;
        Bitmap GREEN_UPGRADE_ICON_BMP;
        Bitmap OUTPOST_BMP;
        Bitmap FIGHT_NFT_BMP;
        Bitmap WIN_PVP_BMP;
        Bitmap LOSE_BMP;
        Bitmap HET_MANA_BMP;
        Bitmap OUTPOST_OK_BMP;
        #endregion

        int delayShort = 50, delayLong = 500;
        List<Stage> listName;
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            BOMB_BMP = (Bitmap)Bitmap.FromFile("Data/bomb.png");
            BIG_BOMB_BMP = (Bitmap)Bitmap.FromFile("Data/big_bomb.png");
            WIN_BMP = (Bitmap)Bitmap.FromFile("Data/win.png");
            LEVEL_UP_BMP = (Bitmap)Bitmap.FromFile("Data/level_up.png");
            STAGE1_BMP = (Bitmap)Bitmap.FromFile("Data/stage1.png");
            STAGE2_BMP = (Bitmap)Bitmap.FromFile("Data/stage2.png");
            STAGE3_BMP = (Bitmap)Bitmap.FromFile("Data/stage3.png");
            STAGE4_BMP = (Bitmap)Bitmap.FromFile("Data/stage4.png");
            STAGE5_BMP = (Bitmap)Bitmap.FromFile("Data/stage5.png");
            STAGE6_BMP = (Bitmap)Bitmap.FromFile("Data/stage6.png");
            STAGE7_BMP = (Bitmap)Bitmap.FromFile("Data/stage7.png");
            UPGRADE_BUILDING_BMP = (Bitmap)Bitmap.FromFile("Data/upgrade_building.png");
            PLUS_BMP = (Bitmap)Bitmap.FromFile("Data/plus.png");
            PYRO_BMP = (Bitmap)Bitmap.FromFile("Data/pyro.png");
            BUILDING_RIGHT_YELLOW_CAR_BMP = (Bitmap)Bitmap.FromFile("Data/buildingRightYellowCar.png");
            PLUS_COLLECT_BMP = (Bitmap)Bitmap.FromFile("Data/plus_collect.png");
            PLUS_COLLECT_2_BMP = (Bitmap)Bitmap.FromFile("Data/plus_collect_2.png");
            BUILD_FARM_1_BMP = (Bitmap)Bitmap.FromFile("Data/build_farm_1.png");
            BUILD_FARM_2_BMP = (Bitmap)Bitmap.FromFile("Data/build_farm_2.png");
            PLUS_COLLECT_3_BMP = (Bitmap)Bitmap.FromFile("Data/plus_collect_3.png");
            BUILD_FARM_3_BMP = (Bitmap)Bitmap.FromFile("Data/build_farm_3.png");
            UPGRADE_ROCK_BMP = (Bitmap)Bitmap.FromFile("Data/upgrade_rock.png");
            BUILD_FARM_4_BMP = (Bitmap)Bitmap.FromFile("Data/build_farm_4.png");
            PLUS_COLLECT_4_BMP = (Bitmap)Bitmap.FromFile("Data/plus_collect_4.png");
            TOMATO_BMP = (Bitmap)Bitmap.FromFile("Data/tomato.png");
            BUILD_FARM_5_BMP = (Bitmap)Bitmap.FromFile("Data/build_farm_5.png");
            EXIT_BMP = (Bitmap)Bitmap.FromFile("Data/exit.png");
            ROCK_BMP = (Bitmap)Bitmap.FromFile("Data/rock.png");
            SCHOOL_BMP = (Bitmap)Bitmap.FromFile("Data/school.png");
            GREEN_UPGRADE_ICON_BMP = (Bitmap)Bitmap.FromFile("Data/green_upgrade_icon.png");
            OUTPOST_BMP = (Bitmap)Bitmap.FromFile("Data/outpost.png");
            FIGHT_NFT_BMP = (Bitmap)Bitmap.FromFile("Data/fight_nft.png");
            WIN_PVP_BMP = (Bitmap)Bitmap.FromFile("Data/win_pvp.png");
            LOSE_BMP = (Bitmap)Bitmap.FromFile("Data/lose.png");
            HET_MANA_BMP = (Bitmap)Bitmap.FromFile("Data/het_mana.png");
            OUTPOST_OK_BMP = (Bitmap)Bitmap.FromFile("Data/outpost_ok.png");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Task t = new Task(() =>
            //{
                isStop = false;
            if(cbItemSource.SelectedValue != null)
            {
                Auto();
            }
            else
            {
                MessageBox.Show("Chưa chọn màn");
            }
           
            
                
            //});
            //t.Start();
        }

        bool isStop = false;
        string[,] IntArray = new string[7, 5];

        bool ColorsAreClose(Color a, Color z, int threshold = 20)
        {
            int r = (int)a.R - z.R,
                g = (int)a.G - z.G,
                b = (int)a.B - z.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }

        void scanBoard(string deviceID)
        {
            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
            //var bluePoints = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, BLUE_BMP);
            //var redPoints = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, RED_BMP);
            //var yellowPoints = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, YELLOW_BMP);
            //var greenPoints = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, GREEN_BMP);
            //var purplePoints = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, PURPLE_BMP);
            //var bomBluePoints = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, BOMB_BLUE_BMP);
            //var bomYellowPoints = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, BOMB_YELLOW_BMP);
            //var bigBombYellowPoints = KAutoHelper.ImageScanOpenCV.FindOutPoints(screen, BIG_BOMB_YELLOW_BMP);
            //yellow 255 255 239 198 
            //blue 255 62 218 247
            //green 255 147 232 71
            //red 255 249 79 79
            //purple 255 243 134 243
            Color yellow = Color.FromArgb(255, 239, 198);
            Color yellow2 = Color.FromArgb(248, 205, 61);
            Color blue = Color.FromArgb(62, 199, 249);
            Color blue2 = Color.FromArgb(72, 166, 197);
            Color blue3 = Color.FromArgb(56, 213, 246);
            Color blue4 = Color.FromArgb(89, 140, 171);
            Color blue5 = Color.FromArgb(44, 200, 233);
            Color blue6 = Color.FromArgb(50, 207, 240);
            Color blue7 = Color.FromArgb(52, 150, 193);
            Color green = Color.FromArgb(147, 232, 71);
            Color green2 = Color.FromArgb(147, 232, 71);
            Color red = Color.FromArgb(249, 79, 79);
            Color red2 = Color.FromArgb(223, 151, 151);
            Color red3 = Color.FromArgb(247, 210, 210);
            Color red4 = Color.FromArgb(230, 84, 84);
            Color red5 = Color.FromArgb(239, 77, 78);
            Color red6 = Color.FromArgb(225, 176, 176);
            Color purple = Color.FromArgb(243, 134, 243);
            Color purple2 = Color.FromArgb(243, 134, 243);
            //Color pixcelColor = screen.GetPixel(1 * 100 + 60, 3 * 100 + 510);
            //System.Diagnostics.Debug.WriteLine(pixcelColor);
            //System.Diagnostics.Debug.WriteLine(ColorsAreClose(pixcelColor, red6));




            //(60, 510); (160, 510); (260, 510); (360; 510); (460; 510); (560; 510); (660; 510); 
            //(60, 610); (160, 610); (260, 610); (360; 610); (460; 610); (560; 610); (660; 610); 
            //(60, 710); (160, 710); (260, 710); (360; 710); (460; 710); (560; 710); (660; 710); 
            //(60, 810); (160, 810); (260, 810); (360; 810); (460; 810); (560; 810); (660; 810); 
            //(60, 910); (160, 910); (260, 910); (360; 910); (460; 910); (560; 910); (660; 910); 

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Color pixcelColor = screen.GetPixel(i * 100 + 60, j * 100 + 510);
                    if (ColorsAreClose(pixcelColor, yellow) || ColorsAreClose(pixcelColor, yellow2))
                    {
                        IntArray[i, j] = "yellow";
                        continue;
                    }
                    if (ColorsAreClose(pixcelColor, blue) || ColorsAreClose(pixcelColor, blue2) || ColorsAreClose(pixcelColor, blue3) || ColorsAreClose(pixcelColor, blue4) || ColorsAreClose(pixcelColor, blue5) || ColorsAreClose(pixcelColor, blue6) || ColorsAreClose(pixcelColor, blue7))
                    {
                        IntArray[i, j] = "blue";
                        continue;
                    }
                    if (ColorsAreClose(pixcelColor, green) || ColorsAreClose(pixcelColor, green2))
                    {
                        IntArray[i, j] = "green";
                        continue;
                    }
                    if (ColorsAreClose(pixcelColor, red) || ColorsAreClose(pixcelColor, red2) || ColorsAreClose(pixcelColor, red3) || ColorsAreClose(pixcelColor, red4) || ColorsAreClose(pixcelColor, red5) || ColorsAreClose(pixcelColor, red6))
                    {
                        IntArray[i, j] = "red";
                        continue;
                    }
                    if (ColorsAreClose(pixcelColor, purple) || ColorsAreClose(pixcelColor, purple2))
                    {
                        IntArray[i, j] = "purple";
                        continue;
                    }

                    //System.Diagnostics.Debug.WriteLine(pixcelColor);
                    //System.Diagnostics.Debug.WriteLine(ColorsAreClose(pixcelColor, blue));
                }
            }
        }

            int count = 0;

        void playSwap(string deviceID)
        {
            //----------------------------NEW----------------------------------
            int delay = 100;
            scanBoard(deviceID);

            //IntArray[0, 0] = "yellow";
            //IntArray[1, 0] = "blue";
            //IntArray[2, 0] = "red";
            //IntArray[3, 0] = "blue";
            //IntArray[4, 0] = "green";
            //IntArray[5, 0] = "red";
            //IntArray[6, 0] = "yellow";

            //IntArray[0, 1] = "blue";
            //IntArray[1, 1] = "yellow";
            //IntArray[2, 1] = "red";
            //IntArray[3, 1] = "green";
            //IntArray[4, 1] = "green";
            //IntArray[5, 1] = "red";
            //IntArray[6, 1] = "purple";

            //IntArray[0, 2] = "blue";
            //IntArray[1, 2] = "blue";
            //IntArray[2, 2] = "yellow";
            //IntArray[3, 2] = "blue";
            //IntArray[4, 2] = "yellow";
            //IntArray[5, 2] = "blue";
            //IntArray[6, 2] = "purple";

            //IntArray[0, 3] = "green";
            //IntArray[1, 3] = "green";
            //IntArray[2, 3] = "blue";
            //IntArray[3, 3] = "purple";
            //IntArray[4, 3] = "blue";
            //IntArray[5, 3] = "green";
            //IntArray[6, 3] = "green";

            //IntArray[0, 4] = "yellow";
            //IntArray[1, 4] = "purple";
            //IntArray[2, 4] = "green";
            //IntArray[3, 4] = "red";
            //IntArray[4, 4] = "purple";
            //IntArray[5, 4] = "blue";
            //IntArray[6, 4] = "red";
            //bool boardIsMoving = isBoardMoving();
            //while(boardIsMoving)
            //{
            //    scanBoard(deviceID);
            //    boardIsMoving = isBoardMoving();
            //}

            System.Diagnostics.Debug.WriteLine("-------------Result--------------");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    System.Diagnostics.Debug.Write(IntArray[j, i] + " ");
                }
                System.Diagnostics.Debug.WriteLine("\n");
            }

            if (count == 5)
            {
                //Click character 1
                KAutoHelper.ADBHelper.Tap(deviceID, 66, 1081);
                Delay(delay);
                if (isStop)
                    return;
                //Click character 2
                KAutoHelper.ADBHelper.Tap(deviceID, 211, 1088);
                Delay(delay);
                if (isStop)
                    return;
                //Click character 3
                KAutoHelper.ADBHelper.Tap(deviceID, 351, 1085);
                Delay(delay);
                if (isStop)
                    return;
                //Click character 4
                KAutoHelper.ADBHelper.Tap(deviceID, 491, 1088);
                Delay(delay);
                if (isStop)
                    return;
                //Click character 5
                KAutoHelper.ADBHelper.Tap(deviceID, 638, 1083);
                Delay(delay);
                if (isStop)
                    return;
                var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
                var bigBombPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BIG_BOMB_BMP);
                var bombPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BOMB_BMP);
                if (bigBombPoint != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, bigBombPoint.Value.X, bigBombPoint.Value.Y);
                    Delay(delay);
                    if (isStop)
                        return;
                }
                if (bombPoint != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, bombPoint.Value.X, bombPoint.Value.Y);
                    Delay(delay);
                    if (isStop)
                        return;
                }
                count = 0;
            }




            //oneTwo: blue blue green
            //oneThree: blue green blue
            //twoThree: green blue blue
            int moveFromX = -1, moveFromY = -1, moveToX = -1, moveToY = -1;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (j < 5)
                    {
                        bool oneTwoX = IntArray[j, i] == IntArray[j + 1, i];
                        bool oneThreeX = IntArray[j, i] == IntArray[j + 2, i];
                        bool twoThreeX = IntArray[j + 1, i] == IntArray[j + 2, i];
                        if (oneTwoX)
                        {
                            if (j != 4) //Not last column
                            {
                                //check move horizontal to right
                                if (IntArray[j, i] == IntArray[j + 3, i])
                                {
                                    moveFromX = j + 2;
                                    moveFromY = i;
                                    moveToX = j + 3;
                                    moveToY = i;
                                    break;
                                }
                            }
                            if (i != 4) //Not last row
                            {
                                //check move vertical to down
                                if (IntArray[j, i] == IntArray[j + 2, i + 1])
                                {
                                    moveFromX = j + 2;
                                    moveFromY = i;
                                    moveToX = j + 2;
                                    moveToY = i + 1;
                                    break;
                                }
                            }
                            if (i != 0) //Not first row
                            {
                                //check move vertical to up
                                if (IntArray[j, i] == IntArray[j + 2, i - 1])
                                {
                                    moveFromX = j + 2;
                                    moveFromY = i;
                                    moveToX = j + 2;
                                    moveToY = i - 1;
                                    break;
                                }
                            }
                        }
                        else if (oneThreeX)
                        {
                            if (i != 4) //Not last row
                            {
                                //check move vertical to down
                                if (IntArray[j, i] == IntArray[j + 1, i + 1])
                                {
                                    moveFromX = j + 1;
                                    moveFromY = i;
                                    moveToX = j + 1;
                                    moveToY = i + 1;
                                    break;
                                }
                            }
                            if (i != 0) //Not first row
                            {
                                //check move vertical to up
                                if (IntArray[j, i] == IntArray[j + 1, i - 1])
                                {
                                    moveFromX = j + 1;
                                    moveFromY = i;
                                    moveToX = j + 1;
                                    moveToY = i - 1;
                                    break;
                                }
                            }
                        }
                        else if (twoThreeX)
                        {
                            if (j != 0) //not first column
                            {
                                //check move horizontal to left
                                if (IntArray[j + 1, i] == IntArray[j - 1, i])
                                {
                                    moveFromX = j;
                                    moveFromY = i;
                                    moveToX = j - 1;
                                    moveToY = i;
                                    break;
                                }
                            }
                            if (i != 4) //Not last row
                            {
                                //check move vertical to down
                                if (IntArray[j + 1, i] == IntArray[j, i + 1])
                                {
                                    moveFromX = j;
                                    moveFromY = i;
                                    moveToX = j;
                                    moveToY = i + 1;
                                    break;
                                }
                            }
                            if (i != 0) //Not first row
                            {
                                //check move vertical to up
                                if (IntArray[j + 1, i] == IntArray[j, i - 1])
                                {
                                    moveFromX = j;
                                    moveFromY = i;
                                    moveToX = j;
                                    moveToY = i - 1;
                                    break;
                                }
                            }
                        }
                    }

                    if (i < 3)
                    {
                        bool oneTwoY = IntArray[j, i] == IntArray[j, i + 1];
                        bool oneThreeY = IntArray[j, i] == IntArray[j, i + 2];
                        bool twoThreeY = IntArray[j, i + 1] == IntArray[j, i + 2];
                        if (oneTwoY)
                        {
                            if (i != 2) //Not last row
                            {
                                //check move vertical down
                                if (IntArray[j, i] == IntArray[j, i + 3])
                                {
                                    moveFromX = j;
                                    moveFromY = i + 2;
                                    moveToX = j;
                                    moveToY = i + 3;
                                    break;
                                }
                            }
                            if (j != 6) //Not last column
                            {
                                //check move horizontal to right
                                if (IntArray[j, i] == IntArray[j + 1, i + 2])
                                {
                                    moveFromX = j;
                                    moveFromY = i + 2;
                                    moveToX = j + 1;
                                    moveToY = i + 2;
                                    break;
                                }
                            }
                            if (j != 0) //Not first column
                            {
                                //check move horizontal to left
                                if (IntArray[j, i] == IntArray[j - 1, i + 2])
                                {
                                    moveFromX = j;
                                    moveFromY = i + 2;
                                    moveToX = j - 1;
                                    moveToY = i + 2;
                                    break;
                                }
                            }
                        }
                        else if (oneThreeY)
                        {
                            if (j != 6) //Not last column
                            {
                                //check move horizontal to right
                                if (IntArray[j, i] == IntArray[j + 1, i + 1])
                                {
                                    moveFromX = j;
                                    moveFromY = i + 1;
                                    moveToX = j + 1;
                                    moveToY = i + 1;
                                    break;
                                }
                            }
                            if (j != 0) //Not first column
                            {
                                //check move horizontal to left
                                if (IntArray[j, i] == IntArray[j - 1, i + 1])
                                {
                                    moveFromX = j;
                                    moveFromY = i + 1;
                                    moveToX = j - 1;
                                    moveToY = i + 1;
                                    break;
                                }
                            }
                        }
                        else if (twoThreeY)
                        {
                            if (i != 0) //Not first row
                            {
                                //check move vertical down
                                if (IntArray[j, i + 1] == IntArray[j, i - 1])
                                {
                                    moveFromX = j;
                                    moveFromY = i;
                                    moveToX = j;
                                    moveToY = i - 1;
                                    break;
                                }
                            }
                            if (j != 6) //Not last column
                            {
                                //check move horizontal to right
                                if (IntArray[j, i + 1] == IntArray[j + 1, i])
                                {
                                    moveFromX = j;
                                    moveFromY = i;
                                    moveToX = j + 1;
                                    moveToY = i;
                                    break;
                                }
                            }
                            if (j != 0) //Not first column
                            {
                                //check move horizontal to left
                                if (IntArray[j, i + 1] == IntArray[j - 1, i])
                                {
                                    moveFromX = j;
                                    moveFromY = i;
                                    moveToX = j - 1;
                                    moveToY = i;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            //System.Diagnostics.Debug.Write("----MOVE FROM (" + moveFromX + "," + moveFromY + ") TO (" + moveToX + "," + moveToY + ")---------");
            KAutoHelper.ADBHelper.Swipe(deviceID, moveFromX * 100 + 50, moveFromY * 100 + 550, moveToX * 100 + 50, moveToY * 100 + 550);
            count++;




            //----------------------------OLD---------------------------------
            //int aX = 55, aY = 541, delta = 100, delay = 100;
            ////swipe horizontal (left to right)
            //for (int i = 1; i < 6; i++)
            //{
            //    for (int j = 0; j < 6; j++)
            //    {
            //        KAutoHelper.ADBHelper.Swipe(deviceID, aX + j * delta, aY, aX + (j + 1) * delta, aY);
            //        Delay(delay);
            //        if (isStop)
            //            return;
            //    }
            //    aY = 541 + i * delta;
            //}
            //aY = 541;
            //Delay(2000);
            ////Click character 1
            //KAutoHelper.ADBHelper.Tap(deviceID, 66, 1081);
            //Delay(delay);
            //if (isStop)
            //    return;
            ////Click character 2
            //KAutoHelper.ADBHelper.Tap(deviceID, 211, 1088);
            //Delay(delay);
            //if (isStop)
            //    return;
            ////Click character 3
            //KAutoHelper.ADBHelper.Tap(deviceID, 351, 1085);
            //Delay(delay);
            //if (isStop)
            //    return;
            ////Click character 4
            //KAutoHelper.ADBHelper.Tap(deviceID, 491, 1088);
            //Delay(delay);
            //if (isStop)
            //    return;
            ////Click character 5
            //KAutoHelper.ADBHelper.Tap(deviceID, 638, 1083);
            //Delay(delay);
            //if (isStop)
            //    return;
            //var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
            //var bigBombPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BIG_BOMB_BMP, 0.7);
            //var bombPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BOMB_BMP);
            //if (bigBombPoint != null)
            //{
            //    KAutoHelper.ADBHelper.Tap(deviceID, bigBombPoint.Value.X, bigBombPoint.Value.Y);
            //    Delay(delay);
            //    if (isStop)
            //        return;
            //}
            //if (bombPoint != null)
            //{
            //    KAutoHelper.ADBHelper.Tap(deviceID, bombPoint.Value.X, bombPoint.Value.Y);
            //    Delay(delay);
            //    if (isStop)
            //        return;
            //}

            //screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
            //var winPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WIN_BMP);
            //var plusPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, PLUS_BMP);
            //var winPVPPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WIN_PVP_BMP);
            //var losePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOSE_BMP);
            //if (plusPoint != null || winPoint != null || winPVPPoint != null || losePoint != null)
            //{
            //    return;
            //}
            ////swipe vertical (up to down)
            //for (int k = 1; k < 8; k++)
            //{
            //    for (int l = 0; l < 4; l++)
            //    {
            //        KAutoHelper.ADBHelper.Swipe(deviceID, aX, aY + l * delta, aX, aY + (l + 1) * delta);
            //        Delay(delay);
            //        if (isStop)
            //            return;
            //    }
            //    aX = 55 + k * delta;
            //}
            //aX = 655;
            //aY = 541;
            //Delay(2000);
            ////Click character 1
            //KAutoHelper.ADBHelper.Tap(deviceID, 66, 1081);
            //Delay(delay);
            //if (isStop)
            //    return;
            ////Click character 2
            //KAutoHelper.ADBHelper.Tap(deviceID, 211, 1088);
            //Delay(delay);
            //if (isStop)
            //    return;
            ////Click character 3
            //KAutoHelper.ADBHelper.Tap(deviceID, 351, 1085);
            //Delay(delay);
            //if (isStop)
            //    return;
            ////Click character 4
            //KAutoHelper.ADBHelper.Tap(deviceID, 491, 1088);
            //Delay(delay);
            //if (isStop)
            //    return;
            ////Click character 5
            //KAutoHelper.ADBHelper.Tap(deviceID, 638, 1083);
            //Delay(delay);
            //if (isStop)
            //    return;
            //screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
            //bigBombPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BIG_BOMB_BMP, 0.7);
            //bombPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BOMB_BMP);
            //if (bigBombPoint != null)
            //{
            //    KAutoHelper.ADBHelper.Tap(deviceID, bigBombPoint.Value.X, bigBombPoint.Value.Y);
            //    Delay(delay);
            //    if (isStop)
            //        return;
            //}
            //if (bombPoint != null)
            //{
            //    KAutoHelper.ADBHelper.Tap(deviceID, bombPoint.Value.X, bombPoint.Value.Y);
            //    Delay(delay);
            //    if (isStop)
            //        return;
            //}
            //screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
            //winPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WIN_BMP);
            //plusPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, PLUS_BMP);
            //winPVPPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WIN_PVP_BMP);
            //losePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOSE_BMP);
            //if (plusPoint != null || winPoint != null || winPVPPoint != null || losePoint != null)
            //{
            //    return;
            //}
            ////swipe horizontal (right to left)
            //for (int i = 1; i < 6; i++)
            //{
            //    for (int j = 0; j < 6; j++)
            //    {
            //        KAutoHelper.ADBHelper.Swipe(deviceID, aX - j * delta, aY, aX - (j + 1) * delta, aY);
            //        Delay(delay);
            //        if (isStop)
            //            return;
            //    }
            //    aY = 541 + i * delta;
            //}
            //aX = 55; 
            //aY = 541;
            //Delay(2000);
            ////Click character 1
            //KAutoHelper.ADBHelper.Tap(deviceID, 66, 1081);
            //Delay(delay);
            //if (isStop)
            //    return;
            ////Click character 2
            //KAutoHelper.ADBHelper.Tap(deviceID, 211, 1088);
            //Delay(delay);
            //if (isStop)
            //    return;
            ////Click character 3
            //KAutoHelper.ADBHelper.Tap(deviceID, 351, 1085);
            //Delay(delay);
            //if (isStop)
            //    return;
            ////Click character 4
            //KAutoHelper.ADBHelper.Tap(deviceID, 491, 1088);
            //Delay(delay);
            //if (isStop)
            //    return;
            ////Click character 5
            //KAutoHelper.ADBHelper.Tap(deviceID, 638, 1083);
            //Delay(delay);
            //if (isStop)
            //    return;
            //screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
            //bigBombPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BIG_BOMB_BMP, 0.7);
            //bombPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BOMB_BMP);
            //if (bigBombPoint != null)
            //{
            //    KAutoHelper.ADBHelper.Tap(deviceID, bigBombPoint.Value.X, bigBombPoint.Value.Y);
            //    Delay(delay);
            //    if (isStop)
            //        return;
            //}
            //if (bombPoint != null)
            //{
            //    KAutoHelper.ADBHelper.Tap(deviceID, bombPoint.Value.X, bombPoint.Value.Y);
            //    Delay(delay);
            //    if (isStop)
            //        return;
            //}
            //screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
            //winPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WIN_BMP);
            //plusPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, PLUS_BMP);
            //winPVPPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WIN_PVP_BMP);
            //losePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOSE_BMP);
            //if (plusPoint != null || winPoint != null || winPVPPoint != null || losePoint != null)
            //{
            //    return;
            //}
            ////swipe vertical (up to down)
            //for (int k = 1; k < 8; k++)
            //{
            //    for (int l = 0; l < 4; l++)
            //    {
            //        KAutoHelper.ADBHelper.Swipe(deviceID, aX, aY + l * delta, aX, aY + (l + 1) * delta);
            //        Delay(delay);
            //        if (isStop)
            //            return;
            //    }
            //    aX = 55 + k * delta;
            //}
            //Delay(2000);
            ////Click character 1
            //KAutoHelper.ADBHelper.Tap(deviceID, 66, 1081);
            //Delay(delay);
            //if (isStop)
            //    return;
            ////Click character 2
            //KAutoHelper.ADBHelper.Tap(deviceID, 211, 1088);
            //Delay(delay);
            //if (isStop)
            //    return;
            ////Click character 3
            //KAutoHelper.ADBHelper.Tap(deviceID, 351, 1085);
            //Delay(delay);
            //if (isStop)
            //    return;
            ////Click character 4
            //KAutoHelper.ADBHelper.Tap(deviceID, 491, 1088);
            //Delay(delay);
            //if (isStop)
            //    return;
            ////Click character 5
            //KAutoHelper.ADBHelper.Tap(deviceID, 638, 1083);
            //Delay(delay);
            //if (isStop)
            //    return;
            //screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
            //bigBombPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BIG_BOMB_BMP, 0.7);
            //bombPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BOMB_BMP);
            //if (bigBombPoint != null)
            //{
            //    KAutoHelper.ADBHelper.Tap(deviceID, bigBombPoint.Value.X, bigBombPoint.Value.Y);
            //    Delay(delay);
            //    if (isStop)
            //        return;
            //}
            //if (bombPoint != null)
            //{
            //    KAutoHelper.ADBHelper.Tap(deviceID, bombPoint.Value.X, bombPoint.Value.Y);
            //    Delay(delay);
            //    if (isStop)
            //        return;
            //}

        }

        void playNewBie(string deviceID, int stageX, int stageY, ref int region, ref int stage, ref bool isLose)
        {
            //Màn 1.x
            KAutoHelper.ADBHelper.Tap(deviceID, stageX, stageY);
            Delay(1000);
            if (isStop)
                return;
            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
            var outPostPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, OUTPOST_BMP);
            var outPostOkPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, OUTPOST_OK_BMP);
            if (outPostPoint != null)
            {
                //Click go
                KAutoHelper.ADBHelper.Tap(deviceID, 360, 779);
                Delay(1000);
                if (isStop)
                    return;
                //Click rebuild
                KAutoHelper.ADBHelper.Tap(deviceID, 368, 554);
                Delay(1000);
                if (isStop)
                    return;
                //Click watchtower
                KAutoHelper.ADBHelper.Tap(deviceID, 184, 296);
                Delay(5000);
                if (isStop)
                    return;
                //Click map
                KAutoHelper.ADBHelper.Tap(deviceID, 355, 1210);
                Delay(1000);
                if (isStop)
                    return;
            }
            else if (outPostOkPoint != null) 
            {
                //Click OK
                KAutoHelper.ADBHelper.Tap(deviceID, 360, 1195);
                Delay(1000);
                if (isStop)
                    return;
                region = region + 1;
                stage = 1;
                //Click back
                KAutoHelper.ADBHelper.Tap(deviceID, 58, 1174);
                Delay(delayLong);
                if (isStop)
                    return;
            }
            else
            {
                //Click next
                KAutoHelper.ADBHelper.Tap(deviceID, 360, 1204);
                Delay(1000);
                if (isStop)
                    return;
                //Click fight
                KAutoHelper.ADBHelper.Tap(deviceID, 351, 1202);
                Delay(1000);
                if (isStop)
                    return;
                screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
                var fightNftPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, FIGHT_NFT_BMP);
                var hetManaPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, HET_MANA_BMP);
                if (fightNftPoint != null)
                {
                    //Click fight (non NFT)
                    KAutoHelper.ADBHelper.Tap(deviceID, 498, 783);
                    Delay(1000);
                    if (isStop)
                        return;
                }
                if (hetManaPoint != null)
                {
                    MessageBox.Show("Đã hết năng lượng!!!");
                    return;
                }
                screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
                var winPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WIN_BMP);
                var winPVPPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WIN_PVP_BMP);
                var losePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOSE_BMP);
                //Chơi đến khi win
                while (winPoint == null && winPVPPoint == null && losePoint == null)
                {
                    playSwap(deviceID);
                    screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
                    winPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WIN_BMP);
                    winPVPPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WIN_PVP_BMP);
                    losePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOSE_BMP);
                    if (isStop)
                        return;
                }
                if (winPoint != null || winPVPPoint != null)
                {
                    if (winPoint != null)
                    {
                        //Click next
                        KAutoHelper.ADBHelper.Tap(deviceID, 498, 1198);
                    }
                    else if (winPVPPoint != null)
                    {
                        //Click next
                        KAutoHelper.ADBHelper.Tap(deviceID, 355, 1161);
                    }
                    Delay(delayLong);
                    if (isStop)
                        return;
                    if (!isLose)
                    {
                        switch (region)
                        {
                            case 2:
                            case 3:
                                if (stage == 7)
                                {
                                    //Tăng 1 stage và 1 region
                                    region = region + 1;
                                    stage = 1;
                                }
                                else
                                {
                                    //Tăng 1 stage
                                    stage = stage + 1;
                                }
                                break;
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                                if (stage == 10)
                                {
                                    //Tăng 1 stage và 1 region
                                    region = region + 1;
                                    stage = 1;
                                }
                                else
                                {
                                    //Tăng 1 stage
                                    stage = stage + 1;
                                }
                                break;
                        }
                    }

                }
                else if (losePoint != null)
                {
                    //Click next
                    KAutoHelper.ADBHelper.Tap(deviceID, 355, 1200);
                    Delay(delayLong);
                    if (isStop)
                        return;
                    isLose = true;
                    switch (region)
                    {
                        case 2:
                        case 3:
                        case 4:
                            if (stage == 1)
                            {
                                //lùi 1 stage và 1 region
                                region = region - 1;
                                stage = 6;
                            }
                            else
                            {
                                //lùi 1 stage
                                stage = stage - 1;
                            }
                            break;
                        case 5:
                            if (stage == 1)
                            {
                                //lùi 1 stage và 1 region
                                region = region - 1;
                                stage = 10;
                            }
                            else
                            {
                                //lùi 1 stage
                                stage = stage - 1;
                            }
                            break;
                        case 6:
                        case 7:
                            if (stage == 1)
                            {
                                //lùi 1 stage và 1 region
                                region = region - 1;
                                stage = 9;
                            }
                            else
                            {
                                //lùi 1 stage
                                stage = stage - 1;
                            }
                            break;
                    }
                }
                //Nếu level up
                screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
                var levelUpPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LEVEL_UP_BMP);
                if (levelUpPoint != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, 353, 1003);
                    Delay(delayLong);
                    if (isStop)
                        return;
                }
                //Click back
                KAutoHelper.ADBHelper.Tap(deviceID, 58, 1174);
                Delay(delayLong);
                if (isStop)
                    return;
            } 
        }

        void clickConversation(string deviceID, int delayTime)
        {
            KAutoHelper.ADBHelper.Tap(deviceID, 405, 1174);
            Delay(delayTime);
            if (isStop)
                return;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listName = new List<Stage>() {
                new Stage(){Name="Stage 2.3", Value="2.3" },
                new Stage(){Name="Stage 2.4", Value="2.4" },
                new Stage(){Name="Stage 2.5", Value="2.5" },
                new Stage(){Name="Stage 2.6", Value="2.6" },
                new Stage(){Name="Stage 2.7", Value="2.7" },
                new Stage(){Name="Stage 3.1", Value="3.1" },
                new Stage(){Name="Stage 3.2", Value="3.2" },
                new Stage(){Name="Stage 3.3", Value="3.3" },
                new Stage(){Name="Stage 3.4", Value="3.4" },
                new Stage(){Name="Stage 3.5", Value="3.5" },
                new Stage(){Name="Stage 3.6", Value="3.6" },
                new Stage(){Name="Stage 4.1", Value="4.1" },
                new Stage(){Name="Stage 4.2", Value="4.2" },
                new Stage(){Name="Stage 4.3", Value="4.3" },
                new Stage(){Name="Stage 4.4", Value="4.4" },
                new Stage(){Name="Stage 4.5", Value="4.5" },
                new Stage(){Name="Stage 4.6", Value="4.6" },
                new Stage(){Name="Stage 4.7", Value="4.7" },
                new Stage(){Name="Stage 4.8", Value="4.8" },
                new Stage(){Name="Stage 4.9", Value="4.9" },
                new Stage(){Name="Stage 5.1", Value="5.1" },
                new Stage(){Name="Stage 5.2", Value="5.2" },
                new Stage(){Name="Stage 5.3", Value="5.3" },
                new Stage(){Name="Stage 5.4", Value="5.4" },
                new Stage(){Name="Stage 5.5", Value="5.5" },
                new Stage(){Name="Stage 5.6", Value="5.6" },
                new Stage(){Name="Stage 5.7", Value="5.7" },
                new Stage(){Name="Stage 5.8", Value="5.8" },
                new Stage(){Name="Stage 5.9", Value="5.9" },
                new Stage(){Name="Stage 6.1", Value="6.1" },
                new Stage(){Name="Stage 6.2", Value="6.2" },
                new Stage(){Name="Stage 6.3", Value="6.3" },
                new Stage(){Name="Stage 6.4", Value="6.4" },
                new Stage(){Name="Stage 6.5", Value="6.5" },
                new Stage(){Name="Stage 6.6", Value="6.6" },
                new Stage(){Name="Stage 6.7", Value="6.7" },
                new Stage(){Name="Stage 6.8", Value="6.8" },
                new Stage(){Name="Stage 6.9", Value="6.9" },
                new Stage(){Name="Stage 7.1", Value="7.1" }
               };
            cbItemSource.ItemsSource = listName;
            cbItemSource.DisplayMemberPath = "Name";
            cbItemSource.SelectedValuePath = "Value";

            cbItemSource.SelectionChanged += CbItemSource_SelectionChanged;
        }
        void Auto()
        {
            //Lấy ra danh sách devices để dùng
            List<string> devices = new List<string>();
            devices = KAutoHelper.ADBHelper.GetDevices();
            var cbItem = cbItemSource.SelectedValue.ToString();
            var region = Int32.Parse(cbItem[0].ToString());
            var stage = Int32.Parse(cbItem[cbItem.Length - 1].ToString());
            var isLose = false;
            //Chạy từng device
            foreach (var deviceID in devices)
            {

                //Tạo ra 1 luồng xử lí riêng biệt
                
                Task t = new Task(() =>
                {
                    var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
                    var hetManaPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, HET_MANA_BMP);
                    while (hetManaPoint == null)
                    {
                        switch (region)
                        {
                            case 2:
                                screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
                                var stage2Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, STAGE2_BMP);
                                if (stage2Point != null)
                                {

                                    KAutoHelper.ADBHelper.Tap(deviceID, stage2Point.Value.X, stage2Point.Value.Y);
                                    Delay(1000);
                                    if (isStop)
                                        return;
                                }
                                switch (stage)
                                {
                                    case 3:
                                        //Click màn 2.3
                                        playNewBie(deviceID, 355, 458, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 4:
                                        //Click màn 2.4
                                        playNewBie(deviceID, 286, 599, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 5:
                                        //Click màn 2.5
                                        playNewBie(deviceID, 251, 773, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 6:
                                        //Click màn 2.6
                                        playNewBie(deviceID, 299, 926, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 7:
                                        //Click màn 2.7
                                        playNewBie(deviceID, 394, 1059, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                }
                                break;
                            case 3:
                                screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
                                var stage3Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, STAGE3_BMP);
                                if (stage3Point != null)
                                {

                                    KAutoHelper.ADBHelper.Tap(deviceID, stage3Point.Value.X, stage3Point.Value.Y);
                                    Delay(1000);
                                    if (isStop)
                                        return;
                                }
                                switch (stage)
                                {
                                    case 1:
                                        //Click màn 3.1
                                        playNewBie(deviceID, 373, 263, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 2:
                                        //Click màn 3.2
                                        playNewBie(deviceID, 490, 369, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 3:
                                        //Click màn 3.3
                                        playNewBie(deviceID, 552, 513, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 4:
                                        //Click màn 3.4
                                        playNewBie(deviceID, 572, 669, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 5:
                                        //Click màn 3.5
                                        playNewBie(deviceID, 518, 842, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 6:
                                        //Click màn 3.6
                                        playNewBie(deviceID, 379, 920, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 7:
                                        //Click màn 3.7
                                        playNewBie(deviceID, 201, 900, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                }
                                break;
                            case 4:
                                screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
                                var stage4Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, STAGE4_BMP);
                                if (stage4Point != null)
                                {

                                    KAutoHelper.ADBHelper.Tap(deviceID, stage4Point.Value.X, stage4Point.Value.Y);
                                    Delay(1000);
                                    if (isStop)
                                        return;
                                }
                                switch (stage)
                                {
                                    case 1:
                                        //Click màn 4.1
                                        playNewBie(deviceID, 624, 458, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 2:
                                        //Click màn 4.2
                                        playNewBie(deviceID, 546, 346, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 3:
                                        //Click màn 4.3
                                        playNewBie(deviceID, 425, 278, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 4:
                                        //Click màn 4.4
                                        playNewBie(deviceID, 279, 322, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 5:
                                        //Click màn 4.5
                                        playNewBie(deviceID, 173, 415, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 6:
                                        //Click màn 4.6
                                        playNewBie(deviceID, 121, 547, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 7:
                                        //Click màn 4.7
                                        playNewBie(deviceID, 143, 688, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 8:
                                        //Click màn 4.8
                                        playNewBie(deviceID, 201, 822, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 9:
                                        //Click màn 4.9
                                        playNewBie(deviceID, 295, 931, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 10:
                                        //Click màn 4.10
                                        playNewBie(deviceID, 414, 1024, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                }
                                break;
                            case 5:
                                screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
                                var stage5Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, STAGE5_BMP);
                                if (stage5Point != null)
                                {

                                    KAutoHelper.ADBHelper.Tap(deviceID, stage5Point.Value.X, stage5Point.Value.Y);
                                    Delay(1000);
                                    if (isStop)
                                        return;
                                }
                                switch (stage)
                                {
                                    case 1:
                                        //Click màn 5.1
                                        playNewBie(deviceID, 576, 224, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 2:
                                        //Click màn 5.2
                                        playNewBie(deviceID, 468, 315, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 3:
                                        //Click màn 5.3
                                        playNewBie(deviceID, 370, 400, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 4:
                                        //Click màn 5.4
                                        playNewBie(deviceID, 275, 506, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 5:
                                        //Click màn 5.5
                                        playNewBie(deviceID, 195, 632, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 6:
                                        //Click màn 5.6
                                        playNewBie(deviceID, 141, 768, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 7:
                                        //Click màn 5.7
                                        playNewBie(deviceID, 145, 916, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 8:
                                        //Click màn 5.8
                                        playNewBie(deviceID, 219, 1048, ref region, ref stage, ref isLose); 
                                        if (isStop)
                                            return;
                                        break;
                                    case 9:
                                        //Click màn 5.9
                                        playNewBie(deviceID, 366, 1072, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 10:
                                        //Click màn 5.10
                                        playNewBie(deviceID, 516, 1074, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                }
                                break;
                            case 6:
                                screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
                                var stage6Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, STAGE6_BMP);
                                if (stage6Point != null)
                                {

                                    KAutoHelper.ADBHelper.Tap(deviceID, stage6Point.Value.X, stage6Point.Value.Y);
                                    Delay(1000);
                                    if (isStop)
                                        return;
                                }
                                switch (stage)
                                {
                                    case 1:
                                        //Click màn 6.1
                                        playNewBie(deviceID, 123, 452, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 2:
                                        //Click màn 6.2
                                        playNewBie(deviceID, 234, 348, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 3:
                                        //Click màn 6.3
                                        playNewBie(deviceID, 368, 287, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 4:
                                        //Click màn 6.4
                                        playNewBie(deviceID, 522, 307, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 5:
                                        //Click màn 6.5
                                        playNewBie(deviceID, 596, 430, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 6:
                                        //Click màn 6.6
                                        playNewBie(deviceID, 617, 584, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 7:
                                        //Click màn 6.7
                                        playNewBie(deviceID, 591, 727, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 8:
                                        //Click màn 6.8
                                        playNewBie(deviceID, 537, 859, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 9:
                                        //Click màn 6.9
                                        playNewBie(deviceID, 444, 992, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                    case 10:
                                        //Click màn 6.10
                                        playNewBie(deviceID, 305, 1087, ref region, ref stage, ref isLose);
                                        if (isStop)
                                            return;
                                        break;
                                }
                                break;
                            case 7:
                                screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
                                var stage7Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, STAGE7_BMP);
                                if (stage7Point != null)
                                {

                                    KAutoHelper.ADBHelper.Tap(deviceID, stage7Point.Value.X, stage7Point.Value.Y);
                                    Delay(1000);
                                    if (isStop)
                                        return;
                                }
                                switch (stage)
                                {
                                    case 1:
                                        MessageBox.Show("Chơi màn 7.1");
                                        break;
                                    case 2:
                                        MessageBox.Show("Chơi màn 7.2");
                                        break;
                                    case 3:
                                        MessageBox.Show("Chơi màn 7.3");
                                        break;
                                    case 4:
                                        MessageBox.Show("Chơi màn 7.4");
                                        break;
                                    case 5:
                                        MessageBox.Show("Chơi màn 7.5");
                                        break;
                                    case 6:
                                        MessageBox.Show("Chơi màn 7.6");
                                        break;
                                }
                                break;
                        }
                        screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
                        hetManaPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, HET_MANA_BMP);
                    }
                });
                t.Start();
            }
        }


        void Delay(int delay)
        {
                while(delay > 0)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(1));
                    delay--;
                    if (isStop)
                        break;
                }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            isStop = true;
        }

        //private void Button_Click_3(object sender, RoutedEventArgs e)
        //{
        //    //Lấy ra danh sách devices để dùng
        //    List<string> devices = new List<string>();
        //    devices = KAutoHelper.ADBHelper.GetDevices();

        //    //Chạy từng device
        //    foreach (var deviceID in devices)
        //    {
        //        //Tạo ra 1 luồng xử lí riêng biệt
        //        Task t1 = new Task(() =>
        //        {
        //            /*------------------START STAGE 2----------------*/

        //            //building
        //            //Click building on the right of yellow car
        //            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //            var buildingRightYellowCar = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BUILDING_RIGHT_YELLOW_CAR_BMP);
        //            if (buildingRightYellowCar != null)
        //            {
        //                KAutoHelper.ADBHelper.Tap(deviceID, buildingRightYellowCar.Value.X, buildingRightYellowCar.Value.Y);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click farm
        //                KAutoHelper.ADBHelper.Tap(deviceID, 173, 311);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //            }

        //            //Click plus_collect_1
        //            screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //            var plusCollectPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, PLUS_COLLECT_BMP);
        //            if (plusCollectPoint != null)
        //            {
        //                KAutoHelper.ADBHelper.Tap(deviceID, plusCollectPoint.Value.X, plusCollectPoint.Value.Y);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click +
        //                KAutoHelper.ADBHelper.Tap(deviceID, 112, 560);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click first guy
        //                KAutoHelper.ADBHelper.Tap(deviceID, 69, 786);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click ok
        //                KAutoHelper.ADBHelper.Tap(deviceID, 364, 502);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //            }

        //            //Click plus collect 2
        //            screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //            var plusCollect2Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, PLUS_COLLECT_2_BMP);
        //            if (plusCollect2Point != null)
        //            {
        //                KAutoHelper.ADBHelper.Tap(deviceID, plusCollect2Point.Value.X, plusCollect2Point.Value.Y);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click +
        //                KAutoHelper.ADBHelper.Tap(deviceID, 112, 560);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click first guy
        //                KAutoHelper.ADBHelper.Tap(deviceID, 69, 786);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click ok
        //                KAutoHelper.ADBHelper.Tap(deviceID, 364, 502);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //            }


        //            //swipe to left
        //            KAutoHelper.ADBHelper.Swipe(deviceID, 665, 686, 535, 671);
        //            Delay(1000);
        //            if (isStop)
        //                return;

        //            //Click build farm 1
        //            screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //            var buildFarm1Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BUILD_FARM_1_BMP);
        //            if (buildFarm1Point != null)
        //            {
        //                KAutoHelper.ADBHelper.Tap(deviceID, buildFarm1Point.Value.X, buildFarm1Point.Value.Y);
        //                Delay(1000);
        //                if (isStop)
        //                    return;
        //                //Click farm
        //                KAutoHelper.ADBHelper.Tap(deviceID, 195, 309);
        //                Delay(6000);
        //                if (isStop)
        //                    return;
        //            }

        //            //Click build farm 2  
        //            KAutoHelper.ADBHelper.Tap(deviceID, 451, 398);
        //            Delay(1000);
        //            if (isStop)
        //                return;
        //            //Click food storage
        //            KAutoHelper.ADBHelper.Tap(deviceID, 180, 311);
        //            Delay(2000);
        //            if (isStop)
        //                return;


        //            //Click plus collect 3
        //            screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //            var plusCollect3Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, PLUS_COLLECT_3_BMP);
        //            if (plusCollect3Point != null)
        //            {
        //                KAutoHelper.ADBHelper.Tap(deviceID, plusCollect3Point.Value.X, plusCollect3Point.Value.Y);
        //                Delay(1000);
        //                if (isStop)
        //                    return;
        //                //Click +
        //                KAutoHelper.ADBHelper.Tap(deviceID, 112, 560);
        //                Delay(1000);
        //                if (isStop)
        //                    return;
        //                //Click first guy
        //                KAutoHelper.ADBHelper.Tap(deviceID, 69, 786);
        //                Delay(1000);
        //                if (isStop)
        //                    return;
        //                //Click ok
        //                KAutoHelper.ADBHelper.Tap(deviceID, 364, 502);
        //                Delay(2000);
        //                if (isStop)
        //                    return;
        //            }

        //            //Click build farm 3
        //            KAutoHelper.ADBHelper.Tap(deviceID, 286, 1000);
        //            Delay(1000);
        //            if (isStop)
        //                return;
        //            //Click biolab
        //            KAutoHelper.ADBHelper.Tap(deviceID, 173, 571);
        //            Delay(2000);
        //            if (isStop)
        //                return;

        //            //Click map
        //            KAutoHelper.ADBHelper.Tap(deviceID, 355, 1210);
        //            Delay(1000);
        //            if (isStop)
        //                return;

        //            screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //            var stage1Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, STAGE1_BMP);
        //            if (stage1Point != null)
        //            {

        //                KAutoHelper.ADBHelper.Tap(deviceID, stage1Point.Value.X, stage1Point.Value.Y);
        //                Delay(1000);
        //                if (isStop)
        //                    return;
        //                //Click màn 1.1
        //                playNewBie(deviceID, 141, 565);
        //                if (isStop)
        //                    return;
        //                //Click màn 1.2
        //                playNewBie(deviceID, 286, 496);
        //                if (isStop)
        //                    return;
        //                //Click màn 1.3
        //                playNewBie(deviceID, 481, 506);
        //                if (isStop)
        //                    return;
        //                //Click back
        //                KAutoHelper.ADBHelper.Tap(deviceID, 58, 1174);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //            }

        //            //Click shelter
        //            KAutoHelper.ADBHelper.Tap(deviceID, 364, 1221);
        //            Delay(delayLong);
        //            if (isStop)
        //                return;

        //            //swipe to right
        //            KAutoHelper.ADBHelper.Swipe(deviceID, 535, 671, 665, 686);
        //            Delay(1000);
        //            if (isStop)
        //                return;

        //            //Click upgrade rock to level 2
        //            screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //            var upgradeRockPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, UPGRADE_ROCK_BMP);
        //            if (upgradeRockPoint != null)
        //            {
        //                KAutoHelper.ADBHelper.Tap(deviceID, upgradeRockPoint.Value.X, upgradeRockPoint.Value.Y);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click upgrade
        //            screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //                var greenUpgradeIconPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, GREEN_UPGRADE_ICON_BMP);
        //                if (greenUpgradeIconPoint != null)
        //                {
        //                    KAutoHelper.ADBHelper.Tap(deviceID, greenUpgradeIconPoint.Value.X, greenUpgradeIconPoint.Value.Y);
        //                }
        //                Delay(1000);
        //                if (isStop)
        //                    return;
        //                //Click upgrade 900 tomatoes
        //            KAutoHelper.ADBHelper.Tap(deviceID, 360, 924);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //            }


        //            //Click map
        //            KAutoHelper.ADBHelper.Tap(deviceID, 355, 1210);
        //            Delay(delayLong);
        //            if (isStop)
        //                return;

        //            //Click màn 1
        //            screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //            stage1Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, STAGE1_BMP);
        //            if (stage1Point != null)
        //            {

        //                KAutoHelper.ADBHelper.Tap(deviceID, stage1Point.Value.X, stage1Point.Value.Y);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click màn 1.4
        //                playNewBie(deviceID, 597, 627);
        //                //Click back
        //                KAutoHelper.ADBHelper.Tap(deviceID, 58, 1174);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //            }


        //            //Click shelter
        //            KAutoHelper.ADBHelper.Tap(deviceID, 364, 1221);
        //            Delay(delayLong);
        //            if (isStop)
        //                return;

        //            //swipe to top
        //            KAutoHelper.ADBHelper.Swipe(deviceID, 396, 760, 368, 682);
        //            Delay(1000);
        //            if (isStop)
        //                return;

        //            //click build farm 4
        //            screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //            var buildFarm4Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BUILD_FARM_4_BMP);
        //            if (buildFarm4Point != null)
        //            {
        //                KAutoHelper.ADBHelper.Tap(deviceID, buildFarm4Point.Value.X, buildFarm4Point.Value.Y);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click farm
        //                KAutoHelper.ADBHelper.Tap(deviceID, 182, 311);
        //                Delay(7000);
        //                if (isStop)
        //                    return;
        //            }

        //            //Click plus collect 4
        //            screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //            var plusCollect4Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, PLUS_COLLECT_4_BMP);
        //            if (plusCollect4Point != null)
        //            {
        //                KAutoHelper.ADBHelper.Tap(deviceID, plusCollect4Point.Value.X, plusCollect4Point.Value.Y);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click +
        //                KAutoHelper.ADBHelper.Tap(deviceID, 112, 560);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click first guy
        //                KAutoHelper.ADBHelper.Tap(deviceID, 69, 786);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click ok
        //                KAutoHelper.ADBHelper.Tap(deviceID, 364, 502);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //            }


        //            //Click map
        //            KAutoHelper.ADBHelper.Tap(deviceID, 355, 1210);
        //            Delay(1000);
        //            if (isStop)
        //                return;

        //            //Click màn 1
        //            screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //            stage1Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, STAGE1_BMP);
        //            if (stage1Point != null)
        //            {

        //                KAutoHelper.ADBHelper.Tap(deviceID, stage1Point.Value.X, stage1Point.Value.Y);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click màn 1.5
        //                playNewBie(deviceID, 563, 813);
        //                //Click màn 1.6
        //                playNewBie(deviceID, 420, 917);
        //            }

        //            //Click màn 1
        //            screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //            stage1Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, STAGE1_BMP);
        //            if (stage1Point != null)
        //            {

        //                KAutoHelper.ADBHelper.Tap(deviceID, stage1Point.Value.X, stage1Point.Value.Y);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click gift
        //            KAutoHelper.ADBHelper.Tap(deviceID, 416, 1031);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;

        //                //Click claim
        //                KAutoHelper.ADBHelper.Tap(deviceID, 364, 957);
        //                Delay(1000);
        //                if (isStop)
        //                    return;
        //                //Click ok
        //                KAutoHelper.ADBHelper.Tap(deviceID, 347, 766);
        //                Delay(1000);
        //                if (isStop)
        //                    return;
        //                //Click back
        //                KAutoHelper.ADBHelper.Tap(deviceID, 58, 1174);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //            }


        //            //Click shelter
        //            KAutoHelper.ADBHelper.Tap(deviceID, 364, 1221);
        //            Delay(delayLong);
        //            if (isStop)
        //                return;

        //            //Click tomato
        //            screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //            var tomatoPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, TOMATO_BMP);
        //            if (tomatoPoint != null)
        //            {
        //                KAutoHelper.ADBHelper.Tap(deviceID, tomatoPoint.Value.X, tomatoPoint.Value.Y);
        //                Delay(2000);
        //                if (isStop)
        //                    return;
        //            }

        //            //Click map
        //            KAutoHelper.ADBHelper.Tap(deviceID, 355, 1210);
        //            Delay(delayLong);
        //            if (isStop)
        //                return;

        //            //Click màn 2
        //            screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //            var stage2Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, STAGE2_BMP);
        //            if (stage2Point != null)
        //            {

        //                KAutoHelper.ADBHelper.Tap(deviceID, stage2Point.Value.X, stage2Point.Value.Y);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click màn 2.1
        //                playNewBie(deviceID, 526, 206);
        //                //Click màn 2.2
        //                playNewBie(deviceID, 437, 338);

        //                //Click back
        //                KAutoHelper.ADBHelper.Tap(deviceID, 58, 1174);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //            }

        //            //Click shelter
        //            KAutoHelper.ADBHelper.Tap(deviceID, 364, 1221);
        //            Delay(delayLong);
        //            if (isStop)
        //                return;

        //            //Click school
        //            screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //            var schoolPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, SCHOOL_BMP);
        //            if (schoolPoint != null)
        //            {
        //                KAutoHelper.ADBHelper.Tap(deviceID, schoolPoint.Value.X, schoolPoint.Value.Y);
        //                Delay(2000);
        //                if (isStop)
        //                    return;
        //                //Click upgrade
        //                screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //                var greenUpgradeIconPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, GREEN_UPGRADE_ICON_BMP);
        //                if (greenUpgradeIconPoint != null)
        //                {
        //                    KAutoHelper.ADBHelper.Tap(deviceID, greenUpgradeIconPoint.Value.X, greenUpgradeIconPoint.Value.Y);
        //                }
        //                //Click upgrade 12k rocks
        //                KAutoHelper.ADBHelper.Tap(deviceID, 342, 926);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //            }

        //            //Click map
        //            KAutoHelper.ADBHelper.Tap(deviceID, 355, 1210);
        //            Delay(delayLong);
        //            if (isStop)
        //                return;

        //            //Click màn 2
        //            screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID, false);
        //            stage2Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, STAGE2_BMP);
        //            if (stage2Point != null)
        //            {

        //                KAutoHelper.ADBHelper.Tap(deviceID, stage2Point.Value.X, stage2Point.Value.Y);
        //                Delay(delayLong);
        //                if (isStop)
        //                    return;
        //                //Click màn 2.3
        //                playNewBie(deviceID, 351, 457);
        //            }





        //            /*------------------END STAGE 2----------------*/
        //        });
        //        t1.Start();
        //    }
        // }

       

        private void CbItemSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(cbItemSource.SelectedValue.ToString());
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtSelectTeam.Visibility = cbItemSource.SelectedItem == null ? Visibility.Visible : Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/C memuc listvms -r";
            //p.StartInfo.Arguments = "/C adb connect localhost:21523";
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            System.Diagnostics.Debug.WriteLine($"Current devices: {output}");
            string[] arrListStr = output.Split('\n');

            //Đoạn này để cmd ko bị treo
            p.StartInfo.Arguments = $"/C adb devices";
            p.Start();
            p.WaitForExit();
            for (int i = 0; i < arrListStr.Length; i++)
            {
                if (arrListStr[i].Length > 0)
                {
                    char currentDevice = arrListStr[i][0];
                    if (currentDevice - '0' >= 0)
                    { 
                        p.StartInfo.Arguments = $"/C adb connect 127.0.0.1:215{currentDevice}3";
                        p.Start();

                        output = p.StandardOutput.ReadToEnd();
                        p.WaitForExit();
                        System.Diagnostics.Debug.WriteLine(output);
                        MessageBox.Show(output, "Connect devices");
                    }     
                   
                }
            }

        }
    }

    public class Stage
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
