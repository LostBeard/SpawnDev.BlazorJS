﻿using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Reflection;
using System.Reflection;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.WebWorkers
{
    /// <summary>
    /// Represents a known WebWorkerService app instance connection
    /// </summary>
    public class AppInstance : AsyncCallDispatcher
    {
        List<ServiceCallDispatcher> IncomingConnections = new List<ServiceCallDispatcher>();
        WebWorkerService? WebWorkerService = null;
        ServiceCallDispatcher? _Dispatcher = null;
        /// <summary>
        /// Returns true if the Dispatcher has been loaded
        /// </summary>
        public bool DispatcherLoaded => _Dispatcher != null;
        /// <summary>
        /// Returns true if the dispatcher failed to load
        /// </summary>
        public bool DispatcherLoadFailed { get; private set; }
        /// <summary>
        /// Returns true is this WebWorkerService instance is the local instance
        /// </summary>
        public bool IsLocal { get; private set; }
        /// <summary>
        /// Instance info
        /// </summary>
        public AppInstanceInfo Info { get; private set; }
        /// <summary>
        /// Returns the service call dispatcher for this instance
        /// </summary>
        ServiceCallDispatcher? Dispatcher
        {
            get
            {
                if (_Dispatcher != null) return _Dispatcher;
                if (!IsDisposed && !DispatcherLoadFailed) TryConnect();
                return _Dispatcher;
            }
        }
        public override Task<object?> Call(MethodInfo methodInfo, object?[]? args = null)
        {
            return Dispatcher!.Call(methodInfo, args);
        }
        internal AppInstance(WebWorkerService webWorkerService, AppInstanceInfo info)
        {
            WebWorkerService = webWorkerService;
            Info = info;
            if (Info.InstanceId == WebWorkerService.InstanceId)
            {
                IsLocal = true;
            }
            else
            {
                _InstanceBroadcastChannel = new Lazy<BroadcastChannel>(() => new BroadcastChannel(Info.InstanceId));
            }
        }
        void TryConnect()
        {
            if (WebWorkerService == null) return;
            try
            {
                if (IsLocal)
                {
                    // best connection is via WebWorkerService.Local
#if DEBUG && false
                    Console.WriteLine("best connection is via WebWorkerService.Local");
#endif
                    _Dispatcher = WebWorkerService.Local;
                }
                else if (Info.Scope == GlobalScope.SharedWorker)
                {
                    // best connection is via a shared web worker connection
#if DEBUG && false
                    Console.WriteLine("best connection is via a shared web worker connection");
#endif
                    _Dispatcher = WebWorkerService.GetSharedWebWorkerSync(Info.Name!);
                }
                else if (WebWorkerService.InterConnectSupported && WebWorkerService.InterConnectEnabled)
                {
                    // best connection is a MessageChannel that we can pass along via interconnect (supports transferables)
#if DEBUG && false
                    Console.WriteLine("best connection is a MessageChannel that we can pass along via interconnect");
#endif
                    using var messageChannel = new MessageChannel();
                    var port1 = messageChannel.Port1;
                    using var port2 = messageChannel.Port2;
                    _Dispatcher = new ServiceCallDispatcher(WebWorkerService.WebAssemblyServices, port1);
                    port1.Start();
                    WebWorkerService.SendInterconnectPort(Info.InstanceId, port2);
                    _Dispatcher.SendReadyFlag();
                }
                else if (WebWorkerService.BroadcastChannelSupported)
                {
                    // best connection is a separate BroadcastChannel (does not support transferables)
#if DEBUG && false
                    Console.WriteLine("best connection is a separate BroadcastChannel");
#endif
                    var connectionId = Guid.NewGuid().ToString();
                    var messageChannel = new BroadcastChannel(connectionId);
                    _Dispatcher = new ServiceCallDispatcher(WebWorkerService.WebAssemblyServices, messageChannel);
                    SendConnectMessageToInstanceBroadcastChannel(connectionId);
                    _Dispatcher.SendReadyFlag();
                }
                else
                {
                    throw new NotSupportedException("No communication channel available");
                }
            }
            catch
            {
                DispatcherLoadFailed = true;
            }
        }
        Lazy<BroadcastChannel>? _InstanceBroadcastChannel = null;
        BroadcastChannel? InstanceBroadcastChannel => _InstanceBroadcastChannel?.Value;
        void SendConnectMessageToInstanceBroadcastChannel(string broadcastChannelId)
        {
            SendMessageToInstanceBroadcastChannel(new object[] { "broadcastChannelConnect", WebWorkerService!.Info, broadcastChannelId });
        }
        void SendMessageToInstanceBroadcastChannel(object data)
        {
            if (!IsLocal)
            {
                InstanceBroadcastChannel?.PostMessage(data);
            }
        }
        internal void AddIncomingInterconnectPort(IMessagePortSimple incomingPort)
        {
#if DEBUG && false
            Console.WriteLine($"AddIncomingConnection: {Info.InstanceId}");
#endif
            var incomingHandler = new ServiceCallDispatcher(WebWorkerService.WebAssemblyServices, incomingPort);
            IncomingConnections.Add(incomingHandler);
            if (incomingPort is MessagePort messagePort)
            {
                messagePort.Start();
            }
#if DEBUG && false
            Console.WriteLine($"AddIncomingInterconnectPort SupportsTransferable: {incomingHandler.MessagePortSupportsTransferable}");
#endif
            incomingHandler.SendReadyFlag();
        }
        /// <summary>
        /// Returns true if this has been disposed
        /// </summary>
        [JsonIgnore]
        public bool IsDisposed { get; private set; }
        /// <summary>
        /// Releases all resources
        /// </summary>
        public void Dispose()
        {
            if (IsDisposed) return;
            IsDisposed = true;
            if (_InstanceBroadcastChannel != null && _InstanceBroadcastChannel.IsValueCreated)
            {
                _InstanceBroadcastChannel.Value.Close();
                _InstanceBroadcastChannel.Value.Dispose();
                _InstanceBroadcastChannel = null;
            }
            foreach (var incomingConnection in IncomingConnections)
            {
                incomingConnection.Dispose();
            }
            IncomingConnections.Clear();
            if (_Dispatcher != null)
            {
                if (IsLocal)
                {
                    _Dispatcher = null;
                }
                else
                {
                    _Dispatcher.Dispose();
                    _Dispatcher = null;
                }
            }
            WebWorkerService = null;
        }
    }
}
