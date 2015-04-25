namespace Civ5MapEmu.Model
{
    class Tile
    {
        public Tile(int movementCost)
        {
            MovementCost = movementCost;
        }
        public Terrain Terrain { get; set; } 
        public int MovementCost { get; set; }
    }
}
