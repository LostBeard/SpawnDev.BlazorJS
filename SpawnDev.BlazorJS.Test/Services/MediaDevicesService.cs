//using SpawnDev.BlazorJS;
//using SpawnDev.BlazorJS.JSObjects;
//using System.Dynamic;

//namespace SpawnDev.BlazorJS.Test.Services
//{
//    public class MediaDevicesService
//    {
//        public MediaDevices mediaDevices { get; private set; } = null;
//        public bool ShareCameraEnabled { get; private set; } = false;
//        public bool ShareDesktopEnabled { get; private set; } = false;
//        public MediaDeviceInfo[] DeviceInfos { get; private set; } = new MediaDeviceInfo[0];
//        public static bool MediaShareSupported => MediaDevices.Supported;
//        public static bool DesktopShareSupported => MediaDevices.GetDisplayMediaSupported;
//        public static bool Supported => MediaShareSupported || DesktopShareSupported;
//        bool _beenInit = false;

//        public MediaDevicesService()
//        {
//            if (!Supported) return;
//            mediaDevices = BlazorJSRuntime.JS.Get<MediaDevices>("navigator.mediaDevices");
//            mediaDevices.OnDeviceChange(() => { _ = UpdateDeviceList(); });
//        }

//        public bool IsDisposed { get; private set; } = false;

//        public void Dispose()
//        {
//            if (IsDisposed) return;
//            IsDisposed = true;
//            //db?.Dispose();
//            mediaDevices?.Dispose();
//        }

//        public delegate void DeviceInfosChangedDelegate(MediaDeviceInfo[] deviceInfos);
//        public event DeviceInfosChangedDelegate OnDeviceInfosChanged;

//        public async Task<MediaStream?> GetMediaStream(string? videoDeviceId = null, string? audioDeviceId = null)
//        {
//            MediaStream? stream = null;
//            try
//            {
//                stream = await mediaDevices.GetMediaDeviceStream(videoDeviceId, audioDeviceId);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("GetMediaDeviceStream error: " + ex.Message);
//            }
//            return stream;
//        }

//        async Task _UpdateDeviceList()
//        {
//            var t = DeviceInfos.Select(o => o.DeviceId).ToList();
//            var countNow = DeviceInfos.Length;
//            DeviceInfos = await mediaDevices.EnumerateDevices();
//            var changed = countNow != DeviceInfos.Length;
//            if (!changed)
//            {
//                foreach (var d in DeviceInfos)
//                {
//                    if (!t.Contains(d.DeviceId))
//                    {
//                        changed = true;
//                        break;
//                    }
//                }
//            }
//            if (changed)
//            {
//                OnDeviceInfosChanged?.Invoke(DeviceInfos);
//            }
//        }

//        // https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices/getUserMedia
//        public async Task<bool> UpdateDeviceList()
//        {
//            var ret = !await mediaDevices.AreDevicesHidden();
//            await _UpdateDeviceList();
//            if (ret) return true;
//            dynamic constraints = new ExpandoObject();
//            constraints.audio = true;
//            constraints.video = true;
//            MediaStream? stream = null;
//            try
//            {
//                stream = await mediaDevices.GetUserMedia(constraints);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"EXCEPTION getUserMedia: {ex.Message}");
//            }

//            if (stream != null)
//            {
//                stream.RemoveAllTracks();
//                stream.Dispose();
//            }
//            await _UpdateDeviceList();
//            ret = !await mediaDevices.AreDevicesHidden();
//            return ret;
//        }

//        public async Task ShareCameraEnable(bool enable)
//        {
//            ShareCameraEnabled = enable;
//            if (ShareCameraEnabled)
//            {
//                //_ = AccountService.NoSleepEnable(true);
//                ShareCameraEnabled = await UpdateDeviceList();
//            }
//        }

//        public async Task ToggleShareCamera()
//        {
//            await ShareCameraEnable(!ShareCameraEnabled);
//        }

//        public Dictionary<string, MediaStream> DesktopShares { get; } = new Dictionary<string, MediaStream>();

//        public async Task AddDesktopShare()
//        {
//            var stream = await mediaDevices.GetDisplayMedia();
//            if (stream == null) return;
//            var k = Guid.NewGuid().ToString();
//            DesktopShares.Add(k, stream);
//        }

////        public Task<MediaStream> GetMyStream(string socketId, string videoDeviceId, string audioDeviceId)
////        {
////            var t = new TaskCompletionSource<MediaStream>();
////            var callbackId = Guid.NewGuid().ToString();
////            EventHandler<MediaStream> onStream = null;
////            PeerJSMediaConnection mediaConn = null;
////            var cnt = 0;
////            onStream = (sender, e) =>
////            {
////#if DEBUG
////                var w = JSObject.GetWindow();
////                w.SetProperty("__streamIn" + cnt++, e);
////                Console.WriteLine("OnStream tracks: " + e.GetTracks().Count());
////#endif
////                //mediaConn.OnStream -= onStream;
////                Console.WriteLine("OnStream TrySetResult");
////                t.TrySetResult(e);
////            };
////            _OnStreamCallbacks.Add(callbackId, (mediaConnection) =>
////            {
////                mediaConn = mediaConnection;
////                mediaConn.OnStream += onStream;
////            });
////            (new Action(async () =>
////            {
////                var data = new SendMediaSourceRequest { TargetPeerId = AccountService.PeerId, VideoDeviceId = videoDeviceId, AudioDeviceId = audioDeviceId, CallbackId = callbackId };
////                bool succ = false;
////                try
////                {
////                    succ = await AccountService.EmitToSocket<bool>(socketId, "sendMediaSource", data);
////                }
////                catch { }
////                if (!succ)
////                {
////                    _OnStreamCallbacks.Remove(callbackId);
////                    Console.WriteLine("sendMediaSource TrySetException");
////                    t.TrySetException(new Exception("Failed"));
////                }
////            }))();
////            return t.Task;
////        }

////        public Task<MediaStream> GetMyDisplayStream(string socketId, string videoDeviceId = "", string audioDeviceId = "")
////        {
////            var t = new TaskCompletionSource<MediaStream>();
////            var callbackId = Guid.NewGuid().ToString();
////            EventHandler<MediaStream> onStream = null;
////            PeerJSMediaConnection mediaConn = null;
////            var cnt = 0;
////            onStream = (sender, e) =>
////            {
////#if DEBUG
////                var w = JSObject.GetWindow();
////                w.SetProperty("__streamIn" + cnt++, e);
////                Console.WriteLine("OnStream tracks: " + e.GetTracks().Count());
////#endif
////                //mediaConn.OnStream -= onStream;
////                Console.WriteLine("OnStream TrySetResult");
////                t.TrySetResult(e);
////            };
////            _OnStreamCallbacks.Add(callbackId, (mediaConnection) =>
////            {
////                mediaConn = mediaConnection;
////                mediaConn.OnStream += onStream;
////            });
////            (new Action(async () =>
////            {
////                var data = new SendMediaSourceRequest { TargetPeerId = AccountService.PeerId, VideoDeviceId = videoDeviceId, AudioDeviceId = audioDeviceId, CallbackId = callbackId };
////                bool succ = false;
////                try
////                {
////                    succ = await AccountService.EmitToSocket<bool>(socketId, "sendDisplaySource", data);
////                }
////                catch { }
////                if (!succ)
////                {
////                    _OnStreamCallbacks.Remove(callbackId);
////                    Console.WriteLine("sendDisplaySource TrySetException");
////                    t.TrySetException(new Exception("Failed"));
////                }
////            }))();
////            return t.Task;
////        }

//        //async Task<MediaStream> GetMyStream(string socketId, string videoDeviceId, string audioDeviceId)
//        //{
//        //    // if peerId == this pc get the local stream and return it
//        //    // 
//        //    MediaStream ret = null;
//        //    var callbackId = Guid.NewGuid().ToString();
//        //    _OnStreamCallbacks.Add(callbackId, )
//        //    var data = new SendMediaSourceRequest { TargetPeerId = AccountService.PeerId, VideoDeviceId = videoDeviceId, AudioDeviceId = audioDeviceId, CallbackId = callbackId };
//        //    var succ = await AccountService.EmitToSocket<bool>(socketId, "sendMediaSource", data);
//        //    return ret;
//        //}

////        class SendMediaSourceRequest
////        {
////            public string TargetPeerId { get; set; }
////            public string VideoDeviceId { get; set; }
////            public string AudioDeviceId { get; set; }
////            public string CallbackId { get; set; }
////        }

////        public async Task<Dictionary<PeerDevice, DeviceInfo[]>> GetMyDeviceMediaShares()
////        {
////            var tmpRet = new Dictionary<PeerDevice, DeviceInfo[]>();
////            var enabled = await RequestMediaPermissions();
////            if (enabled)
////            {
////                tmpRet.Add(AccountService.PeerDevice, DeviceInfos);
////            }
////            var ret = await AccountService.PeerMsgMyDevices<DeviceInfo[]>("getMediaSources");
////            foreach (var pd in ret.Keys)
////            {
////                if (pd.DeviceId == AccountService.PeerDevice.DeviceId) continue;
////                var value = ret[pd];
////                tmpRet.Add(pd, value);
////            }
////            return tmpRet;
////        }

////        void InitPeerMsgServices()
////        {

////            AccountService.OnPeerJSCreated += AccountService_OnPeerJSCreated;
////            AccountService_OnPeerJSCreated(AccountService.peerJS);

////            AccountService.AddPeerMsgHandler("getMediaSources", (PeerDevice peerDevice, PeerMsgReader request, Action<string, object> callback) =>
////            {
////#if DEBUG
////                Console.WriteLine("peer getMediaSources from " + peerDevice.DeviceId + " " + peerDevice.Username + " " + peerDevice.SocketId);
////#endif
////                var allowed = peerDevice != null && peerDevice.UserId == AccountService.UserId && AccountService.UserId != 0;
////                if (!allowed)
////                {
////                    callback("access denied", null);
////                    return true;
////                }
////                Task.Run(() => { callback(null, ShareCameraEnabled ? DeviceInfos : new DeviceInfo[0]); });
////                return true;
////            });

////            //            AccountService.AddPeerMsgHandler("sendMediaSource", (PeerDevice peerDevice, PeerMsgReader request, Action<string, object> callback) =>
////            //            {
////            //#if DEBUG
////            //                Console.WriteLine("peer getMediaSources from " + peerDevice.DeviceId + " " + peerDevice.Username + " " + peerDevice.SocketId);
////            //#endif
////            //                var allowed = peerDevice != null && peerDevice.UserId == AccountService.UserId;
////            //                if (!allowed)
////            //                {
////            //                    callback("access denied", null);
////            //                    return true;
////            //                }
////            //                SendMediaSourceRequest data = null;
////            //                try
////            //                {
////            //                    //data = request.GetData<GetMediaSourceStreamRequest>();
////            //                }
////            //                catch(Exception ex)
////            //                {
////            //                    callback(null, false);
////            //                    Console.WriteLine("GetMediaSourceStreamRequest error: " + ex.Message);
////            //                    return true;
////            //                }
////            //                Task.Run(async () => {
////            //                    MediaStream stream = null;
////            //                    try
////            //                    {
////            //                        stream = await mediaDevices.GetMediaDeviceStream(data.VideoDeviceId, data.AudioDeviceId);
////            //                    } 
////            //                    catch (Exception ex)
////            //                    {
////            //                        Console.WriteLine("GetMediaDeviceStream error: " + ex.Message);
////            //                    }
////            //                    callback(null, true); 
////            //                });
////            //                return true;
////            //            });
////        }

////        private void AccountService_OnPeerJSCreated(PeerJS peerJS)
////        {
////            if (peerJS == null) return;
////            Console.WriteLine("AccountService_OnPeerJSCreated");
////            peerJS.OnCall += PeerJS_OnCall;
////        }

////        Dictionary<string, Action<PeerJSMediaConnection>> _OnStreamCallbacks = new Dictionary<string, Action<PeerJSMediaConnection>>();

////        private void PeerJS_OnCall(object sender, PeerJSMediaConnection mediaConnection)
////        {
////            Console.WriteLine("PeerJS_OnCall");
////            PeerJSCallMetadataReader metadata = null;
////            try
////            {
////                metadata = mediaConnection.GetMetadata<PeerJSCallMetadataReader>();
////                var callbackId = metadata.CallbackId;
////                if (_OnStreamCallbacks.TryGetValue(callbackId, out Action<PeerJSMediaConnection> reqAwaiter))
////                {
////                    _OnStreamCallbacks.Remove(callbackId);
////                    mediaConnection.Answer();
////                    reqAwaiter.Invoke(mediaConnection);
////                }
////            }
////            catch (Exception ex)
////            {
////                Console.WriteLine("Error handling call");
////            }
////            finally
////            {
////                metadata?.Dispose();
////            }
////        }

////        void InitSIOServices()
////        {

////            AccountService.sio.On("user-self getMediaSources", Callback.Create<PeerDevice, string, FunctionHandle>((device, data, callback) =>
////            {
////                if (callback != null)
////                {
////                    Console.WriteLine("getMediaSources from: " + device.SocketId + " " + DeviceInfos.Length);
////                    var ret = ShareCameraEnabled ? DeviceInfos : new DeviceInfo[0];
////                    callback.CallFnVoid(ret);
////                    callback.Dispose();
////                }
////            }));

////            //AccountService.sio.On("user-self sendMediaSource", Callback.Create<PeerDevice, SendMediaSourceRequest, FunctionHandle>((device, data, callback) => {
////            //    if (callback != null)
////            //    {
////            //        (new Action(async () =>
////            //        {
////            //            var stream = await mediaDevices.GetMediaDeviceStream(data.VideoDeviceId, data.AudioDeviceId);
////            //            var succ = stream != null;
////            //            if (succ)
////            //            {
////            //                dynamic metadata = new ExpandoObject();
////            //                metadata.callbackId = data.CallbackId;
////            //                AccountService.peerJS.Call(data.TargetPeerId, stream, new PeerJSCallOptions { metadata = metadata });
////            //            }
////            //            callback.CallFnVoid(succ);
////            //            callback.Dispose();
////            //        }))();
////            //        Console.WriteLine("sendMediaSource from: " + device.SocketId + " " + DeviceInfos.Length);
////            //        callback.CallFnVoid(true);
////            //        callback.Dispose();
////            //    }
////            //}));

////            AccountService.sio.On("peer-msg sendDisplaySource", Callback.Create<PeerDevice, SendMediaSourceRequest, FunctionHandle>((device, data, callback) =>
////            {
////                if (callback != null)
////                {
////                    var allow = device != null && device.UserId == AccountService.UserId && AccountService.UserId != 0;
////                    if (!ShareCameraEnabled) allow = false;
////                    if (!allow)
////                    {
////                        callback.CallFnVoid(false);
////                        callback.Dispose();
////                        return;
////                    }
////                    (new Action(async () =>
////                    {
////                        var stream = await mediaDevices.GetDisplayMedia();
////#if DEBUG
////                        dynamic w = JSObject.GetWindow();
////                        dynamic c = JSObject.GetGlobal("console");
////                        w.__streamOut = stream;
////#endif
////                        var succ = stream != null;
////                        if (succ)
////                        {
////                            dynamic metadata = new ExpandoObject();
////                            metadata.callbackId = data.CallbackId;
////                            AccountService.peerJS.Call(data.TargetPeerId, stream, new PeerJSCallOptions { metadata = metadata });
////                            stream.Dispose();
////                        }
////                        callback.CallFnVoid(succ);
////                        callback.Dispose();
////                    }))();
////                    //Console.WriteLine("sendMediaSource from: " + device.SocketId + " " + DeviceInfos.Length);
////                    //callback.CallFnVoid(true);
////                    //callback.Dispose();
////                }
////            }));

////            AccountService.sio.On("peer-msg sendMediaSource", Callback.Create<PeerDevice, SendMediaSourceRequest, FunctionHandle>((device, data, callback) =>
////            {
////                if (callback != null)
////                {
////                    var allow = device != null && device.UserId == AccountService.UserId && AccountService.UserId != 0;
////                    if (!ShareCameraEnabled) allow = false;
////                    if (!allow)
////                    {
////                        callback.CallFnVoid(false);
////                        callback.Dispose();
////                        return;
////                    }
////                    (new Action(async () =>
////                    {
////                        var stream = await mediaDevices.GetMediaDeviceStream(data.VideoDeviceId, data.AudioDeviceId);
////                        //var stream = await mediaDevices.GetDisplayMedia();
////#if DEBUG
////                        dynamic w = JSObject.GetWindow();
////                        dynamic c = JSObject.GetGlobal("console");
////                        w.__streamOut = stream;
////#endif
////                        var succ = stream != null;
////                        if (succ)
////                        {
////                            dynamic metadata = new ExpandoObject();
////                            metadata.callbackId = data.CallbackId;
////                            AccountService.peerJS.Call(data.TargetPeerId, stream, new PeerJSCallOptions { metadata = metadata });
////                            stream.Dispose();
////                        }
////                        callback.CallFnVoid(succ);
////                        callback.Dispose();
////                    }))();
////                    //Console.WriteLine("sendMediaSource from: " + device.SocketId + " " + DeviceInfos.Length);
////                    //callback.CallFnVoid(true);
////                    //callback.Dispose();
////                }
////            }));
////        }
//    }
//}
