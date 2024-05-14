using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.Test.GameOfLife
{
    public class ChangedCell
    {
        public int X { get; set; }
        public int Y { get; set; }
        [JsonPropertyName("V")]
        public BoardTileState Value { get; set; }
    }
    public class GenerationStat
    {
        public TimeSpan Elapsed { get; set; }
        public long BoardWidth { get; set; } = 0;
        public long BoardHeight { get; set; } = 0;
        public long Population { get; set; } = 0;
        public long Deaths { get; set; } = 0;
        public long Babies { get; set; } = 0;
        public long Younglings { get; set; } = 0;
        public long Adults { get; set; } = 0;
        public long Elders { get; set; } = 0;
        public long Generation { get; set; }
        public List<ChangedCell> Changed { get; set; } = new List<ChangedCell>();
        public GenerationStat() { }
        public GenerationStat(long generation, int boardWidth, int boardHeight)
        {
            Generation = generation;
            BoardWidth = boardWidth;
            BoardHeight = boardHeight;
        }
    }
}
