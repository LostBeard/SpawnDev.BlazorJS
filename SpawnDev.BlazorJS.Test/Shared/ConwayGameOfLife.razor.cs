using Microsoft.AspNetCore.Components;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Test.GameOfLife;
using System.Diagnostics;
using Timer = System.Timers.Timer;
using SpawnDev.BlazorJS.WebWorkers;

namespace SpawnDev.BlazorJS.Test.Shared
{
    public partial class ConwayGameOfLife : IDisposable
    {
        HTMLCanvasElement? canvas = null;
        CanvasRenderingContext2D? ctx = null;
        ElementReference CanvasElRef { get; set; }
        Timer? Timer = null;
        int TileSize = 4;
        int LegendColorSize => 16;
        int BoardRowWidth => TileSize * Board.Width;
        int BoardRowHeight => TileSize * Board.Height;
        Board Board = new Board();
        bool Paused = false;
        TimeSpan drawTime = new TimeSpan();
        //WebWorker? worker = null;
        [Inject]
        WebWorkerService WebWorkerService { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (canvas == null)
            {
                canvas = new HTMLCanvasElement(CanvasElRef);
                //worker = await WebWorkerService.GetWebWorker();
                ctx = canvas.Get2DContext();
                Board.OnTicked += Board_OnTicked;
                Board.OnReset += Board_OnReset;
                Board.Resize(128, 128, 20);
                Timer = new Timer();
                Timer.Elapsed += Timer_Elapsed;
                Timer.Interval = 5;
                Timer.AutoReset = false;
                Timer.Start();
            }
        }
        //public static class Renderer
        //{
        //    static OffscreenCanvas? OffscreenCanvas { get; set; } = null;
        //    static CanvasRenderingContext2D? ctx { get; set; } = null;
        //    static string FillStyle = "";
        //    public static void Render(List<ChangedCell> data)
        //    {

        //    }
        //    public static void Clear(string color)
        //    {

        //    }
        //    public static void Init(OffscreenCanvas offscreenCanvas)
        //    {
        //        OffscreenCanvas = offscreenCanvas;
        //        ctx = offscreenCanvas.Get2DContext();
        //    }
        //    public static void Release()
        //    {
        //        ctx?.Dispose();
        //        ctx = null;
        //        OffscreenCanvas?.Dispose();
        //        OffscreenCanvas = null;
        //    }
        //}
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
        static Dictionary<BoardTileState, string> Colors = new Dictionary<BoardTileState, string> {
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
