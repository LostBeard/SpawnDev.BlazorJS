using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Copntains tracking information for JSObjects created with the same stack trace. This is used for diagnostics purposes to track where JSObjects are being created and disposed, and can be used to identify potential leaks. This will likely be removed in future releases.
    /// </summary>
    public class IDisposableTracker
    {
        public static bool Enabled => CreatedHandleVerboseMode || UndisposedHandleVerboseMode;
        public required string Type { get; set; }
        public required string Trace { get; set; }
        public ulong Created { get; set; }
        public ulong DisposedProper { get; set; }
        public ulong DisposedFinalizer { get; set; }
        public int AliveCount => Alive.Count;
        [JsonIgnore]
        public List<IDisposable> Alive { get; } = new List<IDisposable>();
        /// <summary>
        /// Contains tracking information for JSObjects created with the same stack trace. This is used for diagnostics purposes to track where JSObjects are being created and disposed, and can be used to identify potential leaks. This will likely be removed in future releases.
        /// </summary>
        public static Dictionary<string, IDisposableTracker> JSObjectTraces { get; } = new Dictionary<string, IDisposableTracker>();
        public static void DisposableDisposed(IDisposableTracker? _LifeTrack, IDisposable disposable, bool disposing)
        {
            if (_LifeTrack != null && _LifeTrack.Alive.Contains(disposable))
            {
                _LifeTrack.Alive.Remove(disposable);
                if (disposing)
                {
                    _LifeTrack.DisposedProper++;
                }
                else
                {
                    _LifeTrack.DisposedFinalizer++;
                    if (_LifeTrack.DisposedFinalizer == 1 && UndisposedHandleVerboseMode)
                    {
                        Console.WriteLine($"DEBUG WARNING: IDisposable disposed in finalizer: {_LifeTrack.Type}\n{_LifeTrack.Trace}");
                    }
                }
            }
        }
        public static bool CreatedHandleVerboseMode
        {
            get => _CreatedHandleVerboseMode;
            set
            {
                if (_CreatedHandleVerboseMode == value) return;
                _CreatedHandleVerboseMode = value;
                if (value) Init();
            }
        }
        private static bool _CreatedHandleVerboseMode { get; set; }
        public static bool UndisposedHandleVerboseMode
        {
            get => _UndisposedHandleVerboseMode;
            set
            {
                if (_UndisposedHandleVerboseMode == value) return;
                _UndisposedHandleVerboseMode = value;
                if (value) Init();
            }
        }
        private static bool _UndisposedHandleVerboseMode { get; set; }
        static bool _beenInit = false;
        static void Init()
        {
            if (_beenInit) return;
            _beenInit = true;
            BlazorJSRuntime.JS.Set(nameof(IDisposableTracker), new
            {
                created = Callback.Create(() => IDisposableTracker.JSObjectTraces.Values.OrderByDescending(o => o.Created).ToList()),
                disposedProper = Callback.Create(() => IDisposableTracker.JSObjectTraces.Values.OrderByDescending(o => o.DisposedProper).Where(o => o.DisposedProper > 0).ToList()),
                disposedFinalizer = Callback.Create(() => IDisposableTracker.JSObjectTraces.Values.OrderByDescending(o => o.DisposedFinalizer).Where(o => o.DisposedFinalizer > 0).ToList()),
                aliveCount = Callback.Create(() => IDisposableTracker.JSObjectTraces.Values.OrderByDescending(o => o.AliveCount).Where(o => o.AliveCount > 0).ToList()),
                reset = Callback.Create(() => IDisposableTracker.JSObjectTraces.Clear()),
            });
        }
        public static IDisposableTracker? DisposableCreated(IDisposable disposable)
        {
            if (!Enabled) return null!;
            IDisposableTracker? _LifeTrack = null;
            var creationStackTrace = Environment.StackTrace;
            if (!JSObjectTraces.TryGetValue(creationStackTrace, out _LifeTrack))
            {
                _LifeTrack = new IDisposableTracker
                {
                    Trace = creationStackTrace,
                    Type = disposable.GetType().FullName!
                };
                JSObjectTraces.Add(creationStackTrace, _LifeTrack);
                if (CreatedHandleVerboseMode)
                {
                    Console.WriteLine($"NOTICE: IDisposable created: {_LifeTrack.Type}\n{_LifeTrack.Trace}");
                }
            }
            if (!_LifeTrack.Alive.Contains(disposable))
            {
                _LifeTrack.Alive.Add(disposable);
                _LifeTrack.Created++;
            }
            return _LifeTrack;
        }
    }
}