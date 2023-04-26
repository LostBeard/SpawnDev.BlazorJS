namespace SpawnDev.BlazorJS.Toolbox
{
    public interface IKeyValueItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Parents { get; set; }
        public string MimeType { get; set; }   // inode/directory - directory
        public long? Size { get; set; }
    }
    public class KeyValueItem : IKeyValueItem
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public List<string> Parents { get; set; } = new List<string>();
        public string MimeType { get; set; } = "";  // inode/directory - directory
        public long? Size { get; set; }
    }
}
