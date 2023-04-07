namespace SpawnDev.BlazorJS.JSObjects
{
    public class StorageManagerEstimate
    {
        public long Quota { get; set; }
        public long Usage { get; set; }
        public StorageManagerEstimateUsageDetails? UsageDetails { get; set; }
    }
}
