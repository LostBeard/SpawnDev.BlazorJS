using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AudioBuffer interface represents a short audio asset residing in memory, created from an audio file using the AudioContext.decodeAudioData() method, or from raw data using AudioContext.createBuffer(). Once put into an AudioBuffer, the audio can then be played by being passed into an AudioBufferSourceNode.<br/>
    /// Objects of these types are designed to hold small audio snippets, typically less than 45 s. For longer sounds, objects implementing the MediaElementAudioSourceNode are more suitable. The buffer contains the audio signal waveform encoded as a series of amplitudes in the following format: non-interleaved IEEE754 32-bit linear PCM with a nominal range between -1 and +1, that is, a 32-bit floating point buffer, with each sample between -1.0 and 1.0. If the AudioBuffer has multiple channels, they are stored in separate buffers.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioBuffer
    /// </summary>
    public class AudioBuffer : JSObject
    {
        /// <inheritdoc/>
        public AudioBuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public AudioBuffer(AudioBufferOptions options) : base(JS.New(nameof(AudioBuffer), options)) { }
        /// <summary>
        /// Returns an integer representing the length, in sample-frames, of the PCM data stored in the buffer.
        /// </summary>
        public long Length => JSRef!.Get<long>("length");
        /// <summary>
        /// Returns an integer representing the number of discrete audio channels described by the PCM data stored in the buffer.
        /// </summary>
        public int NumberOfChannels => JSRef!.Get<int>("numberOfChannels");
        /// <summary>
        /// Returns a double representing the duration, in seconds, of the PCM data stored in the buffer.
        /// </summary>
        public double Duration => JSRef!.Get<double>("duration");
        /// <summary>
        /// Returns a float representing the sample rate, in samples per second, of the PCM data stored in the buffer.
        /// </summary>
        public float SampleRate => JSRef!.Get<float>("sampleRate");
        /// <summary>
        /// Returns a Float32Array containing the PCM data associated with the channel, defined by the channel parameter (with 0 representing the first channel).
        /// </summary>
        /// <param name="channel">The channel property is an index representing the particular channel to get data for. An index value of 0 represents the first channel. If the channel index value is greater than of equal to AudioBuffer.numberOfChannels, an INDEX_SIZE_ERR exception will be thrown.</param>
        /// <returns></returns>
        public Float32Array GetChannelData(int channel) => JSRef!.Call<Float32Array>("getChannelData", channel);
        /// <summary>
        /// The copyFromChannel() method of the AudioBuffer interface copies the audio sample data from the specified channel of the AudioBuffer to a specified Float32Array.
        /// </summary>
        /// <param name="destination">A Float32Array to copy the channel's samples to.</param>
        /// <param name="channelNumber">The channel number of the current AudioBuffer to copy the channel data from.</param>
        /// <param name="startInChannel">An optional offset into the source channel's buffer from which to begin copying samples. If not specified, a value of 0 (the beginning of the buffer) is assumed by default.</param>
        public void CopyFromChannel(Float32Array destination, int channelNumber, long startInChannel = 0) 
            => JSRef!.CallVoid("copyFromChannel", destination, channelNumber, startInChannel);
        /// <summary>
        /// The copyToChannel() method of the AudioBuffer interface copies the samples to the specified channel of the AudioBuffer, from the source array.
        /// </summary>
        /// <param name="source">A Float32Array that the channel data will be copied from.</param>
        /// <param name="channelNumber">The channel number of the current AudioBuffer to copy the channel data to. If channelNumber is greater than or equal to AudioBuffer.numberOfChannels, an INDEX_SIZE_ERR will be thrown.</param>
        /// <param name="startInChannel">An optional offset to copy the data to. If startInChannel is greater than AudioBuffer.length, an INDEX_SIZE_ERR will be thrown.</param>
        public void CopyToChannel(Float32Array source, int channelNumber, long startInChannel = 0)
            => JSRef!.CallVoid("copyToChannel", source, channelNumber, startInChannel);
    }
}
