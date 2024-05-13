using SpawnDev.BlazorJS.Test.Shared;
using System.Diagnostics;
using System.Linq.Dynamic.Core;
using System.Xml.Linq;

namespace SpawnDev.BlazorJS.Test.GameOfLife
{
    public class Board
    {
        private static Random r = new Random();
        private BoardTileState[][,] Data = new BoardTileState[2][,];
        private int ActiveStateIndex => BufferFlipped ? 1 : 0;
        private int BackStateIndex => BufferFlipped ? 0 : 1;
        private bool BufferFlipped = false;
        public BoardTileState[,] ActiveState => Data[ActiveStateIndex];
        private BoardTileState[,] BackState => Data[BackStateIndex];
        private void FlipBuffer() => BufferFlipped = !BufferFlipped;
        public int Height { get; private set; }
        public int Width { get; private set; }
        public long Generation { get; private set; }
        public GenerationStat GenerationStat { get; private set; }
        public event Action<GenerationStat> OnTicked;
        public event Action OnReset;
        public Board(int width, int height, double startingPopulation = 50)
        {
            Height = height;
            Width = width;
            Reset(startingPopulation);
        }
        public Board()
        {
            Reset();
        }
        public string SaveSnapShot()
        {
            return Convert.ToBase64String(SaveSnapShotBytes());
        }
        public byte[] SaveSnapShotBytes()
        {
            var bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(Width));
            bytes.AddRange(BitConverter.GetBytes(Height));
            byte[] boardBytes = new byte[ActiveState.Length];
            Buffer.BlockCopy(ActiveState, 0, boardBytes, 0, ActiveState.Length);
            bytes.AddRange(boardBytes);
            return bytes.ToArray();
        }
        public void LoadSnapShot(string snapshot)
        {
            var bytes = Convert.FromBase64String(snapshot);
            var width = Convert.ToInt32(bytes[0]);
            var height = Convert.ToInt32(bytes[4]);
            Resize(width, height);
            Buffer.BlockCopy(bytes, 8, ActiveState, 0, ActiveState.Length);
        }
        public void Tick()
        {
            var sw = Stopwatch.StartNew();
            var generation = Generation + 1;
            var generationStat = new GenerationStat(generation, Width, Height);
            // process active and put results into back state
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var selfValue = ActiveState[x, y];
                    var selfValueNew = selfValue;
                    var selfAlive = IsAlive(selfValue);
                    var neighbors = GetNeighbors(ActiveState, Width, Height, x, y);
                    var aliveNeighbors = neighbors.Sum(o => IsAlive(o) ? 1 : 0);
                    if (!selfAlive)
                    {
                        // Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
                        if (aliveNeighbors == 3)
                        {
                            selfValueNew = BoardTileState.Birth;
                            generationStat.Babies++;
                            generationStat.Population++;
                        }
                        else if ((selfValue & BoardTileState.Dead) != 0)
                        {
                            //selfValueNew = BoardTileState.Dead;
                        }
                    }
                    else
                    {
                        // Any live cell with fewer than two live neighbors dies, as if by underpopulation.
                        if (aliveNeighbors < 2)
                        {
                            selfValueNew = BoardTileState.DeathUnderPopulation;
                            generationStat.Deaths++;
                        }
                        // Any live cell with two or three live neighbors lives on to the next generation.
                        else if (aliveNeighbors >= 2 && aliveNeighbors <= 3)
                        {
                            switch (selfValue)
                            {
                                case BoardTileState.Birth:
                                    selfValueNew = BoardTileState.Youngling;
                                    generationStat.Younglings++;
                                    break;
                                case BoardTileState.Youngling:
                                    selfValueNew = BoardTileState.Adult;
                                    generationStat.Adults++;
                                    break;
                                case BoardTileState.Adult:
                                default:
                                    selfValueNew = BoardTileState.Elder;
                                    generationStat.Elders++;
                                    break;
                            }
                            generationStat.Population++;
                        }
                        // Any live cell with more than three live neighbors dies, as if by overpopulation.
                        else if (aliveNeighbors > 3)
                        {
                            selfValueNew = BoardTileState.DeathOverPopulation;
                            generationStat.Deaths++;
                        }
                        else
                        {
                            var nmt = true;
                        }
                    }
                    if (selfValueNew != selfValue)
                    {
                        generationStat.Changed.Add(new ChangedCell { X = x, Y = y, OldValue = selfValue, Value = selfValueNew });
                    }
                    BackState[x, y] = selfValueNew;
                }
            }
            sw.Stop();
            generationStat.Elapsed = sw.Elapsed;
            GenerationStat = generationStat;
            Generation = generation;
            // flip back state to active
            FlipBuffer();
            OnTicked?.Invoke(GenerationStat);
        }
        public void Resize(int width, int height, double startingPopulation = 50)
        {
            Width = width;
            Height = height;
            Reset(startingPopulation);
        }
        public void Reset(double startingPopulation = 50)
        {
            Generation = 0;
            GenerationStat = new GenerationStat(Generation, Width, Height);
            Data[0] = new BoardTileState[Width, Height];
            Data[1] = new BoardTileState[Width, Height];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var occupied = NextBool(startingPopulation);
                    var value = occupied ? BoardTileState.Birth : BoardTileState.Void;
                    BackState[x, y] = value;
                    if (occupied)
                    {
                        GenerationStat.Babies++;
                        GenerationStat.Population++;
                        GenerationStat.Changed.Add(new ChangedCell { X = x, Y = y, OldValue = BoardTileState.Void, Value = value });
                    }
                }
            }
            FlipBuffer();
            OnReset?.Invoke();
            OnTicked?.Invoke(GenerationStat);
        }
        private static bool NextBool(double truePercentage = 50) => r.NextDouble() < truePercentage / 100.0d;
        private static BoardTileState[] GetNeighbors(BoardTileState[,] boardData, int width, int height, int x, int y)
        {
            var neighbors = new BoardTileState[8];
            // tl -1 -1
            neighbors[0] = boardData[x == 0 ? width - 1 : x - 1, y == 0 ? height - 1 : y - 1];
            // tm  0 -1
            neighbors[1] = boardData[x, y == 0 ? height - 1 : y - 1];
            // tr +1 -1
            neighbors[2] = boardData[x == width - 1 ? 0 : x + 1, y == 0 ? height - 1 : y - 1];
            // ml -1  0
            neighbors[3] = boardData[x == 0 ? width - 1 : x - 1, y];
            // mr +1  0
            neighbors[4] = boardData[x == width - 1 ? 0 : x + 1, y];
            // bl -1 +1
            neighbors[5] = boardData[x == 0 ? width - 1 : x - 1, y == height - 1 ? 0 : y + 1];
            // bm  0 +1
            neighbors[6] = boardData[x, y == height - 1 ? 0 : y + 1];
            // br +1 +1
            neighbors[7] = boardData[x == width - 1 ? 0 : x + 1, y == height - 1 ? 0 : y + 1];
            return neighbors;
        }
        public int AliveValue(BoardTileState state) => (int)state >> 4;
        public bool IsAlive(BoardTileState state) => (state & BoardTileState.Alive) != 0;
        public bool IsDead(BoardTileState state) => (state & BoardTileState.Dead) != 0;
        public bool IsVoid(BoardTileState state) => state == 0;
    }
}
