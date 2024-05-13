using Microsoft.AspNetCore.Components;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Test.GameOfLife;
using System.Diagnostics;
using Timer = System.Timers.Timer;

namespace SpawnDev.BlazorJS.Test.Shared
{
    public partial class ConwayGameOfLife : IDisposable
    {
        HTMLCanvasElement? canvas = null;
        CanvasRenderingContext2D? ctx = null;
        ElementReference CanvasElRef { get; set; }
        Timer? Timer = null;
        int TileSize = 10;
        int LegendColorSize => TileSize * 2;
        int BoardRowWidth => TileSize * Board.Width;
        int BoardRowHeight => TileSize * Board.Height;
        Board Board = new Board();
        bool Paused = false;
        TimeSpan drawTime = new TimeSpan();
        protected override void OnAfterRender(bool firstRender)
        {
            if (canvas == null)
            {
                canvas = new HTMLCanvasElement(CanvasElRef);
                ctx = canvas.Get2DContext();
                Board.OnTicked += Board_OnTicked;
                Board.OnReset += Board_OnReset;
                Board.Resize(64, 64, 30);
                Timer = new Timer();
                Timer.Elapsed += Timer_Elapsed;
                Timer.Interval = 5;
                Timer.AutoReset = false;
                Timer.Start();
            }
        }
        void Snapshot()
        {
            var snapshot = Board.SaveSnapShot();
            Console.WriteLine(snapshot);
        }
        void Reset()
        {
            Board.Reset();
        }
        void TogglePaused()
        {
            Paused = !Paused;
        }
        private void Board_OnReset()
        {
            if (canvas == null || ctx == null) return;
            var canvasWidth = TileSize * Board.Width;
            var canvasHeight = TileSize * Board.Height;
            canvas.Width = canvasWidth;
            canvas.Height = canvasHeight;
            ctx.FillStyle = Colors[BoardTileState.Void];
            ctx.FillRect(0, 0, canvasWidth, canvasHeight);
        }
        Dictionary<BoardTileState, string> Colors = new Dictionary<BoardTileState, string> {
            { BoardTileState.Void, "#000000" },
            { BoardTileState.Birth, "#0062ff" },
            { BoardTileState.Youngling, "#2e7eff" },
            { BoardTileState.Adult, "#73a9ff" },
            { BoardTileState.Elder, "#b8d3ff" },
            { BoardTileState.DeathUnderPopulation, "#3b0d3b" },
            { BoardTileState.DeathOverPopulation, "#3b0d13"},
            //
            { BoardTileState.Alive, "#1fab3d" },
            { BoardTileState.Dead, "#5a5c2f" },
        };
        private void Board_OnTicked(GenerationStat generationStat)
        {
            if (canvas == null || ctx == null) return;
            var sw = Stopwatch.StartNew();
            var fillStyle = ctx.FillStyle;
            foreach (var change in generationStat.Changed)
            {
                var x = change.X;
                var y = change.Y;
                var cx = x * TileSize;
                var cy = y * TileSize;
                var cellValue = change.Value;
                if (!Colors.TryGetValue(cellValue, out var bgColor))
                {
                    bgColor = Colors[BoardTileState.Void];
                }
                if (fillStyle != bgColor)
                {
                    ctx.FillStyle = bgColor;
                    fillStyle = bgColor;
                }
                ctx.FillRect(cx, cy, TileSize, TileSize);
            }
            StateHasChanged();
            sw.Stop();
            drawTime = sw.Elapsed;
        }
        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (IsDisposed || Timer == null) return;
            Timer.Enabled = false;
            if (!Paused) Board.Tick();
            Timer.Start();
        }
        bool IsDisposed = false;
        public void Dispose()
        {
            if (IsDisposed) return;
            IsDisposed = true;
            Timer?.Dispose();
            Timer = null;
            ctx?.Dispose();
            ctx = null;
            canvas?.Dispose();
            canvas = null;
        }
    }
}
