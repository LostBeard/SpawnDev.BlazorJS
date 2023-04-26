using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Toolbox
{
    public interface IKeyValueStorage
    {
        public Task<IKeyValueItem?> GetItemInfo(string id);
        public Task<List<IKeyValueItem>?> GetChildren(string id);
        public Task<bool> ItemExists(string id);
        public Task RemoveItem(string id);
        public Task<string?> GetItemText(string id);
        public Task<byte[]?> GetItemBytes(string id);
        public Task<T?> GetItemJSON<T>(string id);
        public Task SetItemText(string id, string content, string contentType = "");
        public Task SetItemBytes(string id, byte[] content, string contentType = "");
        public Task SetItemJSON(string id, object content, string contentType = "");
    }
}
