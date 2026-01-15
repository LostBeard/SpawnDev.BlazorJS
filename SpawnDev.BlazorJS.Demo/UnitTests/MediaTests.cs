using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Demo.UnitTests
{
    public class MediaTests
    {
        BlazorJSRuntime JS;
        public MediaTests(BlazorJSRuntime js)
        {
            JS = js;
        }

        [TestMethod]
        public async Task EnumerateDevicesTest()
        {
            using var navigator = JS.Get<Navigator>("navigator");
            using var mediaDevices = navigator.MediaDevices;
            if (mediaDevices == null)
            {
                throw new Exception("navigator.mediaDevices not supported");
            }
            var devices = await mediaDevices.EnumerateDevices();
            if (devices == null || devices.Length == 0)
            {
                throw new Exception("No media devices found");
            }
            // Optional: Log device info
            foreach (var device in devices)
            {
                Console.WriteLine($"Device: {device.Label} ({device.Kind})");
            }
        }

        /// <summary>
        /// This test may fail even if things are working as expected<br/>
        /// disabled until a better etst can  be written
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        //[TestMethod]
        public async Task GetUserMediaTest()
        {
            using var navigator = JS.Get<Navigator>("navigator");
            using var mediaDevices = navigator.MediaDevices;
            if (mediaDevices == null)
            {
                throw new Exception("navigator.mediaDevices not supported");
            }
            
            // This relies on the fake webcam args we added to Playwright/Browser
            using var stream = await mediaDevices.GetUserMedia(new { video = true });
            
            if (stream == null)
            {
                throw new Exception("getUserMedia returned null");
            }

            if (!stream.Active)
            {
                throw new Exception("Stream is not active");
            }

            using var tracks = stream.GetTracks();
            if (tracks.Length == 0)
            {
                throw new Exception("No tracks found in stream");
            }

            // Cleanup
            foreach(var track in tracks)
            {
                track.Stop();
                track.Dispose();
            }
        }
    }
}
