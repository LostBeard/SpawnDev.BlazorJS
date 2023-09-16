using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class DataTransferItemList : JSObject
    {
        public DataTransferItemList(IJSInProcessObjectReference _ref) : base(_ref) { }
        public DataTransferItem this[int index]
        {
            get => JSRef.Get<DataTransferItem>(index);
            set => JSRef.Set(index, value);
        }
        public DataTransferItem Add(string data) => JSRef.Call<DataTransferItem>("add", data);
        public DataTransferItem Add(File data) => JSRef.Call<DataTransferItem>("add", data);
        public int Length => JSRef.Get<int>("length");
        public void Remove(int index) => JSRef.CallVoid("remove", index);
        public void Clear(int index) => JSRef.CallVoid("clear", index);

    }
}
