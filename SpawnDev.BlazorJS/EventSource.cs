//using Microsoft.JSInterop;

//namespace SpawnDev.BlazorJS
//{
//    public abstract class EventSourceBase
//    {
//        protected IJSInProcessObjectReference? JSRef;
//        protected string OnFnName;
//        protected string OffFnName;
//        protected string EventName;
//        public EventSourceBase(IJSInProcessObjectReference jsRef, string eventName, string onFnName, string offFnName)
//        {
//            JSRef = jsRef;
//            OnFnName = onFnName;
//            OffFnName = offFnName;
//            EventName = eventName;
//        }
//    }
//    public class EventSource : EventSourceBase
//    {
//        public EventSource(IJSInProcessObjectReference jsRef, string eventName, string onFnName = "on", string offFnName = "off") : base(jsRef, eventName, onFnName, offFnName)
//        {

//        }
//        public void Add(ActionCallback callback) => JSRef?.CallVoid(OnFnName, EventName, callback);
//        public void Remove(ActionCallback callback) => JSRef?.CallVoid(OffFnName, EventName, callback);
//        public event Action Event
//        {
//            add
//            {
//                JSRef?.CallVoid(OnFnName, EventName, value);
//            }
//            remove
//            {
//                JSRef?.CallVoid(OffFnName, EventName, value);
//            }
//        }
//    }
//    public class EventSource<T1> : EventSourceBase
//    {
//        public EventSource(IJSInProcessObjectReference jsRef, string eventName, string onFnName = "on", string offFnName = "off") : base(jsRef, eventName, onFnName, offFnName)
//        {
            
//        }
//        public void Add(ActionCallback<T1> callback) => JSRef?.CallVoid(OnFnName, EventName, callback);
//        public void Remove(ActionCallback<T1> callback) => JSRef?.CallVoid(OffFnName, EventName, callback);
//        public event Action<T1> Event
//        {
//            add
//            {
//                JSRef?.CallVoid(OnFnName, EventName, value);
//            }
//            remove
//            {
//                JSRef?.CallVoid(OffFnName, EventName, value);
//            }
//        }
//    }
//    public class EventSource<T1, T2> : EventSourceBase
//    {
//        public EventSource(IJSInProcessObjectReference jsRef, string eventName, string onFnName = "on", string offFnName = "off") : base(jsRef, eventName, onFnName, offFnName)
//        {
            
//        }
//        public void Add(ActionCallback<T1, T2> callback) => JSRef?.CallVoid(OnFnName, EventName, callback);
//        public void Remove(ActionCallback<T1, T2> callback) => JSRef?.CallVoid(OffFnName, EventName, callback);
//        public event Action<T1, T2> Event
//        {
//            add
//            {
//                JSRef?.CallVoid(OnFnName, EventName, value);
//            }
//            remove
//            {
//                JSRef?.CallVoid(OffFnName, EventName, value);
//            }
//        }
//    }
//    public class EventSource<T1, T2, T3> : EventSourceBase
//    {
//        public EventSource(IJSInProcessObjectReference jsRef, string eventName, string onFnName = "on", string offFnName = "off") : base(jsRef, eventName, onFnName, offFnName)
//        {

//        }
//        public void Add(ActionCallback<T1, T2, T3> callback) => JSRef?.CallVoid(OnFnName, EventName, callback);
//        public void Remove(ActionCallback<T1, T2, T3> callback) => JSRef?.CallVoid(OffFnName, EventName, callback);
//        public event Action<T1, T2, T3> Event
//        {
//            add
//            {
//                JSRef?.CallVoid(OnFnName, EventName, value);
//            }
//            remove
//            {
//                JSRef?.CallVoid(OffFnName, EventName, value);
//            }
//        }
//    }
//}
