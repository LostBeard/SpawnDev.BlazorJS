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
        public List<ulong> Alive { get; } = new List<ulong>();
        /// <summary>
        /// Contains tracking information for JSObjects created with the same stack trace. This is used for diagnostics purposes to track where JSObjects are being created and disposed, and can be used to identify potential leaks. This will likely be removed in future releases.
        /// </summary>
        public static Dictionary<string, IDisposableTracker> JSObjectTraces { get; } = new Dictionary<string, IDisposableTracker>();
        public static void DisposableDisposed((IDisposableTracker? disposableTracker, ulong disposableId) tracker, bool disposing)
        {
            if (tracker.disposableTracker != null && tracker.disposableTracker.Alive.Contains(tracker.disposableId))
            {
                tracker.disposableTracker.Alive.Remove(tracker.disposableId);
                if (disposing)
                {
                    tracker.disposableTracker.DisposedProper++;
                }
                else
                {
                    tracker.disposableTracker.DisposedFinalizer++;
                    if (tracker.disposableTracker.DisposedFinalizer == 1 && UndisposedHandleVerboseMode)
                    {
                        Console.WriteLine($"DEBUG WARNING: IDisposable disposed in finalizer: {tracker.disposableTracker.Type}\n{tracker.disposableTracker.Trace}");
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
        static ulong _totalCreated = 0;
        public static (IDisposableTracker? disposableTracker, ulong disposableId) DisposableCreated(IDisposable disposable)
        {
            if (!Enabled) return (null, 0);
            var index = _totalCreated++;
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
            _LifeTrack.Alive.Add(index);
            _LifeTrack.Created++;
            return (_LifeTrack, index);
        }
    }
}