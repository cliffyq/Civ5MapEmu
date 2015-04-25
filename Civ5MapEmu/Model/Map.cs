using System;

namespace Civ5MapEmu.Model
{
    internal class Map
    {
        private static readonly double[] CostDistribution =
        {
            0.4,
            0.5,
            0.1
        };

        public int Width { get;  set; }
        public int Height { get; set; }
        public bool HorizontalWrap { get; set; }
        public bool VerticalWrap { get; set; }
        public Tile[,] Tiles { get; set; }
        public Map(int width, int height, bool hWrap=false, bool vWrap = false)
        {
            Width = width;
            Height = height;
            HorizontalWrap = hWrap;
            VerticalWrap = vWrap;
            InitTiles();
        }

        private void InitTiles()
        {
            Tiles = new Tile[Width, Height];
            Random rnd = new Random();
            for (int i = 0; i < Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < Tiles.GetLength(1); j++)
                {
                    double rand = rnd.NextDouble();
                    double sum = 0;
                    for (int c = 0; c < CostDistribution.Length; c++)
                    {
                        sum += CostDistribution[c];
                        int cost = c == CostDistribution.Length - 1 ? -1 : c + 1;
                        if (rand > sum) continue;
                        Tiles[i,j] = new Tile(cost);
                        break;
                    }
                }
            }
        }
    }
}
