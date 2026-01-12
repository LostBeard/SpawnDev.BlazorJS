namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCSdpType enum is used to describe the type of an RTCSessionDescription.
    /// </summary>
    public static class RTCSdpType
    {
        /// <summary>
        /// The session description is an answer.
        /// </summary>
        public const string Answer = "answer";
        /// <summary>
        /// The session description is an offer.
        /// </summary>
        public const string Offer = "offer";
        /// <summary>
        /// The session description is a partial answer.
        /// </summary>
        public const string PRAnswer = "pranswer";
        /// <summary>
        /// The session description is a rollback.
        /// </summary>
        public const string Rollback = "rollback";
    }
}
