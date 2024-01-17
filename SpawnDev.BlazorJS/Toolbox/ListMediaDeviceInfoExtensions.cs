//using SpawnDev.BlazorJS.JSObjects;

//namespace SpawnDev.BlazorJS.Toolbox
//{
//    public static class ListMediaDeviceInfoExtensions
//    {
//        public static Dictionary<string, List<MediaDeviceInfo>> GetAudioVideoInputDevices(this List<MediaDeviceInfo> _this, string requireInputType = "")
//        {
//            var list = _this.Where(o => o.Kind == MediaDevices.AUDIO_INPUT || o.Kind == MediaDevices.VIDEO_INPUT).GroupBy(o => o.GroupId).ToDictionary(o => o.Key, o => o.ToList());
//            if (!string.IsNullOrEmpty(requireInputType)) list = list.Where(o => o.Value.GetInputType() == requireInputType).ToDictionary(o => o.Key, o => o.Value);
//            return list;
//        }

//        public static List<MediaDeviceInfo> GetVideoInputs(this List<MediaDeviceInfo> _this)
//        {
//            return _this.Where(o => o.Kind == MediaDevices.VIDEO_INPUT).ToList();
//        }

//        public static List<MediaDeviceInfo> GetAudioInputs(this List<MediaDeviceInfo> _this)
//        {
//            return _this.Where(o => o.Kind == MediaDevices.AUDIO_INPUT).ToList();
//        }

//        public static List<MediaDeviceInfo> GetAudioOutputs(this List<MediaDeviceInfo> _this)
//        {
//            return _this.Where(o => o.Kind == MediaDevices.AUDIO_OUTPUT).ToList();
//        }

//        public static string GetGroupInputType(this List<MediaDeviceInfo> _this, string groupId)
//        {
//            var groupDevices = _this.Where(o => o.GroupId == groupId).ToList();
//            return groupDevices.GetInputType();
//        }

//        public static string GetInputType(this List<MediaDeviceInfo> _this)
//        {
//            if (_this.Count == 0) return "";
//            var hasAudioInput = _this.Any(o => o.Kind == MediaDevices.AUDIO_INPUT);
//            var hasVideoInput = _this.Any(o => o.Kind == MediaDevices.VIDEO_INPUT);
//            if (hasAudioInput && hasVideoInput) return "audiovideoinput";
//            else if (hasVideoInput) return "videoinput";
//            else if (hasAudioInput) return "audioinput";
//            return "";
//        }
//    }
//}
