namespace SpawnDev.BlazorJS
{
    public class CallbackGroup : IDisposable
    {
        public List<Callback> group = new List<Callback>();

        public T Add<T>(T wrapper) where T : Callback
        {
            group.Add(wrapper);
            return wrapper;
        }

        public void Clear()
        {
            foreach (var cbw in group)
            {
                cbw.Dispose();
            }
            group.Clear();
        }

        public void Dispose()
        {
            Clear();
        }
    }
}
