using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace _20._10._2023_dz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            StartGame();
        }

        private const int LengthOfRowsColumns = 4;

        private void AddLabel(int X, int Y, int Num)
        {
            System.Windows.Controls.Label label = new System.Windows.Controls.Label();
            label.Content = Num.ToString();

            Grid.SetColumn(label, X);
            Grid.SetRow(label, Y);

            Labeles.Children.Add(label);
        }

        private void RandomLabelSpawn(List<Point> PossibleLocate)
        {
            Random random = new Random();

            const int SmallerNumber = 2;
            const int LargerNumber = 4;
            const int ChanceLargerNumber = 10;

            int NumToSpawn = random.Next(0, 100) <= ChanceLargerNumber ? LargerNumber : SmallerNumber;

            Point LocateToSpawn = PossibleLocate[random.Next(PossibleLocate.Count)];
            AddLabel((int)LocateToSpawn.X, (int)LocateToSpawn.Y, NumToSpawn);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Left && e.Key != Key.Right && e.Key != Key.Up && e.Key != Key.Down) return;

            int[,] Nums = new int[LengthOfRowsColumns, LengthOfRowsColumns];
            foreach (System.Windows.Controls.Label l in Labeles.Children)
            {
                Nums[Grid.GetColumn(l), Grid.GetRow(l)] = int.Parse(l.Content.ToString());
            }

            switch (e.Key)
            {
                case Key.Right: {
                        RotateMatrix.Degrees90(Nums);
                        RotateMatrix.Degrees90(Nums);
                    } break;
                case Key.Down: {
                        RotateMatrix.DegreesMinus90(Nums);
                    } break;
                case Key.Up: {
                        RotateMatrix.Degrees90(Nums);
                    } break;
            }

            for (int i = 0; i < LengthOfRowsColumns; i++)
                for (int y = 1; y < LengthOfRowsColumns; y++)
                    if (Nums[y, i] != 0) 
                    {
                        bool IsJoined = false;
                        for (int z = y - 1; z >= 0; z--)
                            if (Nums[z, i] == Nums[y, i]) 
                            {
                                Nums[z, i] = Nums[z, i] + Nums[y, i];
                                Nums[y, i] = 0;
                                AddScore(Nums[z, i]);
                                IsJoined = true;
                                break;
                            }

                        if (!IsJoined)
                            for (int z = 0; z < y; z++)
                                if (Nums[z, i] == 0)
                                {
                                    Nums[z, i] = Nums[y, i];
                                    Nums[y, i] = 0;
                                    break;
                                }
                    }

            switch (e.Key)
            {
                case Key.Right: {
                        RotateMatrix.Degrees90(Nums);
                        RotateMatrix.Degrees90(Nums);
                    } break;
                case Key.Down: {
                        RotateMatrix.Degrees90(Nums);
                    } break;
                case Key.Up: {
                        RotateMatrix.DegreesMinus90(Nums);
                    } break;
            }

            Labeles.Children.Clear();
            for (int y = 0; y < LengthOfRowsColumns; y++)
                for (int x = 0; x < LengthOfRowsColumns; x++)
                {
                    if (Nums[x, y] != 0) AddLabel(x, y, Nums[x, y]);
                }

            List<Point> CloseLocate = new List<Point>();
            foreach (System.Windows.Controls.Label l in Labeles.Children)
            {
                CloseLocate.Add(new Point(Grid.GetColumn(l), Grid.GetRow(l)));
            }

            List<Point> FreeLocate = new List<Point>();
            for (int x = 0; x < LengthOfRowsColumns; x++)
                for (int y = 0; y < LengthOfRowsColumns; y++)
                {
                    Point point = new Point(x, y);
                    if (!CloseLocate.Contains(point)) FreeLocate.Add(point);
                }

            if (FreeLocate.Count != 0) RandomLabelSpawn(FreeLocate);

            if (IsWin())
            {
                MessageBox.Show("You won");

                StartGame();
            }
        }

        private bool IsWin()
        {
            foreach (System.Windows.Controls.Label l in Labeles.Children)
            {
                if (2048 == int.Parse(l.Content.ToString())) return true;
            }

            return false;
        }

        private void StartGame()
        {
            HighScore.Text = Score.Text;
            Score.Text = "0";

            Labeles.Children.Clear();

            List<Point> FreeLocate = new List<Point>();
            for (int x = 0; x < LengthOfRowsColumns; x++)
                for (int y = 0; y < LengthOfRowsColumns; y++)
                {
                    FreeLocate.Add(new Point(x, y));
                }

            if (FreeLocate.Count != 0) RandomLabelSpawn(FreeLocate);
        }

        private void AddScore(int Value)
        {
            Score.Text = (int.Parse(Score.Text) + Value).ToString();
        }
    }


    public static class RotateMatrix
    {
        public static void Degrees90(int[,] Matrix)
        {
            int Rows = Matrix.GetLength(0);
            int Cols = Matrix.GetLength(1);

            int[,] TempMatrix = new int[Cols, Rows];

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                {
                    TempMatrix[j, Rows - 1 - i] = Matrix[i, j];
                }

            for (int i = 0; i < Cols; i++)
                for (int j = 0; j < Rows; j++)
                {
                    Matrix[i, j] = TempMatrix[i, j];
                }
        }

        public static void DegreesMinus90(int[,] Matrix)
        {
            int Rows = Matrix.GetLength(0);
            int Cols = Matrix.GetLength(1);

            int[,] RotatedMatrix = new int[Cols, Rows];

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                {
                    RotatedMatrix[Cols - 1 - j, i] = Matrix[i, j];
                }

            for (int i = 0; i < Cols; i++)
                for (int j = 0; j < Rows; j++)
                {
                    Matrix[i, j] = RotatedMatrix[i, j];
                }
        }
    }
}