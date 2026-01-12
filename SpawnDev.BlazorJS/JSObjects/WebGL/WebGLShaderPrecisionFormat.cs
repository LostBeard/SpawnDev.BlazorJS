using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGLShaderPrecisionFormat interface is part of the WebGL API and represents the information returned by calling the WebGLRenderingContext.getShaderPrecisionFormat() method.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGLShaderPrecisionFormat
    /// </summary>
    public class WebGLShaderPrecisionFormat
    {
        [JsonPropertyName("rangeMin")]
        public int RangeMin { get; set; }
        [JsonPropertyName("rangeMax")]
        public int RangeMax { get; set; }
        [JsonPropertyName("precision")]
        public int Precision { get; set; }
    }
    //public interface IWebGLRenderingContext
    //{
    //    TValue GetExtension<TValue>(string name);
    //    void ActiveTexture(int texture);
    //    void AttachShader(WebGLProgram program, WebGLShader shader);
    //    void BindAttribLocation(WebGLProgram program, uint index, string name);
    //    void BindBuffer(int target, WebGLBuffer buffer);
    //    void BindFramebuffer(int target, WebGLFramebuffer framebuffer);
    //    void BindRenderbuffer(int target, WebGLRenderbuffer renderbuffer);
    //    void BindTexture(int target, WebGLTexture texture);
    //    void BlendColor(float red, float green, float blue, float alpha);
    //    void BlendEquation(int mode);
    //    void BlendEquationSeparate(int modeRGB, int modeAlpha);
    //    void BlendFunc(int sfactor, int dfactor);
    //    void BlendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha);
    //    // WebGLHandlesContextLoss
    //    int CheckFramebufferStatus(int target);
    //    void Clear(int mask);
    //    void ClearColor(float red, float green, float blue, float alpha);
    //    void ClearDepth(float depth);
    //    void ClearStencil(int s);
    //    void ColorMask(bool red, bool green, bool blue, bool alpha);
    //    void CompileShader(WebGLShader shader);
    //    void CopyTexImage2D(int target, int level, int internalformat, int x, int y, int width, int height, int border);
    //    void CopyTexSubImage2D(int target, int level, int xoffset, int yoffset, int x, int y, int width, int height);
    //    WebGLBuffer CreateBuffer();
    //    WebGLFramebuffer CreateFramebuffer();
    //    WebGLProgram CreateProgram();
    //    WebGLRenderbuffer CreateRenderbuffer();
    //    WebGLShader CreateShader(int type);
    //    WebGLTexture CreateTexture();
    //    void CullFace(int mode);
    //    void DeleteBuffer(WebGLBuffer buffer);
    //    void DeleteFramebuffer(WebGLFramebuffer framebuffer);
    //    void DeleteProgram(WebGLProgram program);
    //    void DeleteRenderbuffer(WebGLRenderbuffer renderbuffer);
    //    void DeleteShader(WebGLShader shader);
    //    void DeleteTexture(WebGLTexture texture);
    //    void DepthFunc(int func);
    //    void DepthMask(bool flag);
    //    void DepthRange(float zNear, float zFar);
    //    void DetachShader(WebGLProgram program, WebGLShader shader);
    //    void Disable(int cap);
    //    void DisableVertexAttribArray(uint index);
    //    void DrawArrays(int mode, int first, int count);
    //    void DrawElements(int mode, int count, int type, int offset);
    //    void Enable(int cap);
    //    void EnableVertexAttribArray(uint index);
    //    void Finish();
    //    void Flush();
    //    void FramebufferRenderbuffer(int target, int attachment, int renderbuffertarget, WebGLRenderbuffer renderbuffer);
    //    void FramebufferTexture2D(int target, int attachment, int textarget, WebGLTexture texture, int level);
    //    void FrontFace(int mode);
    //    void GenerateMipmap(int target);
    //    WebGLActiveInfo GetActiveAttrib(WebGLProgram program, uint index);
    //    WebGLActiveInfo GetActiveUniform(WebGLProgram program, uint index);
    //    List<WebGLShader> GetAttachedShaders(WebGLProgram program);
    //    // WebGLHandlesContextLoss
    //    int GetAttribLocation(WebGLProgram program, string name);
    //    TValue GetBufferParameter<TValue>(int target, int pname);
    //    TValue GetParameter<TValue>(int pname);
    //    // WebGLHandlesContextLoss
    //    int GetError();
    //    TValue GetFramebufferAttachmentParameter<TValue>(int target, int attachment, int pname);
    //    TValue GetProgramParameter<TValue>(WebGLProgram program, int pname);
    //    string GetProgramInfoLog(WebGLProgram program);
    //    TValue GetRenderbufferParameter<TValue>(int target, int pname);
    //    TValue GetShaderParameter<TValue>(WebGLShader shader, int pname);
    //    WebGLShaderPrecisionFormat GetShaderPrecisionFormat(int shadertype, int precisiontype);
    //    string GetShaderInfoLog(WebGLShader shader);
    //    string GetShaderSource(WebGLShader shader);
    //    TValue GetTexParameter<TValue>(int target, int pname);
    //    TValue GetUniform<TValue>(WebGLProgram program, WebGLUniformLocation location);
    //    WebGLUniformLocation GetUniformLocation(WebGLProgram program, string name);
    //    TValue GetVertexAttrib<TValue>(uint index, int pname);
    //    // WebGLHandlesContextLoss
    //    int GetVertexAttribOffset(uint index, int pname);
    //    void Hint(int target, int mode);
    //    // [WebGLHandlesContextLoss] 
    //    bool IsBuffer(WebGLBuffer buffer);
    //    // [WebGLHandlesContextLoss] 
    //    bool IsEnabled(int cap);
    //    // [WebGLHandlesContextLoss] 
    //    bool IsFramebuffer(WebGLFramebuffer framebuffer);
    //    // [WebGLHandlesContextLoss] 
    //    bool IsProgram(WebGLProgram program);
    //    // [WebGLHandlesContextLoss] 
    //    bool IsRenderbuffer(WebGLRenderbuffer renderbuffer);
    //    // [WebGLHandlesContextLoss] 
    //    bool IsShader(WebGLShader shader);
    //    // [WebGLHandlesContextLoss] 
    //    bool IsTexture(WebGLTexture texture);
    //    void LineWidth(float width);
    //    void LinkProgram(WebGLProgram program);
    //    void PixelStorei(int pname, int param);
    //    void PolygonOffset(float factor, float units);
    //    void RenderbufferStorage(int target, int internalformat, int width, int height);
    //    void SampleCoverage(float value, bool invert);
    //    void Scissor(int x, int y, int width, int height);
    //    void ShaderSource(WebGLShader shader, string source);
    //    void StencilFunc(int func, int @ref, uint mask);
    //    void StencilFuncSeparate(int face, int func, int @ref, uint mask);
    //    void StencilMask(uint mask);
    //    void StencilMaskSeparate(int face, uint mask);
    //    void StencilOp(int fail, int zfail, int zpass);
    //    void StencilOpSeparate(int face, int fail, int zfail, int zpass);
    //    void TexParameterf(int target, int pname, float param);
    //    void TexParameteri(int target, int pname, int param);
    //    void Uniform1f(WebGLUniformLocation location, float x);
    //    void Uniform2f(WebGLUniformLocation location, float x, float y);
    //    void Uniform3f(WebGLUniformLocation location, float x, float y, float z);
    //    void Uniform4f(WebGLUniformLocation location, float x, float y, float z, float w);
    //    void Uniform1i(WebGLUniformLocation location, int x);
    //    void Uniform2i(WebGLUniformLocation location, int x, int y);
    //    void Uniform3i(WebGLUniformLocation location, int x, int y, int z);
    //    void Uniform4i(WebGLUniformLocation location, int x, int y, int z, int w);
    //    void UseProgram(WebGLProgram program);
    //    void ValidateProgram(WebGLProgram program);
    //    void VertexAttrib1f(uint index, float x);
    //    void VertexAttrib2f(uint index, float x, float y);
    //    void VertexAttrib3f(uint index, float x, float y, float z);
    //    void VertexAttrib4f(uint index, float x, float y, float z, float w);
    //    void VertexAttrib1fv(uint index, IEnumerable<float> values);
    //    void VertexAttrib2fv(uint index, IEnumerable<float> values);
    //    void VertexAttrib3fv(uint index, IEnumerable<float> values);
    //    void VertexAttrib4fv(uint index, IEnumerable<float> values);
    //    void VertexAttribPointer(uint index, int size, int type, bool normalized, int stride, int offset);
    //    void Viewport(int x, int y, int width, int height);

    //    void BufferData(int target, int size, int usage);
    //    void BufferData(int target,  BufferSource data, int usage);
    //    void BufferSubData(int target, int offset,  BufferSource data);
    //    void CompressedTexImage2D(int target, int level, int internalformat, int width, int height, int border, ArrayBufferView data);
    //    void CompressedTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, ArrayBufferView data);
    //    void ReadPixels(int x, int y, int width, int height, int format, int type,  ArrayBufferView pixels);
    //    void TexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type,  ArrayBufferView pixels);
    //    void TexImage2D(int target, int level, int internalformat, int format, int type, TexImageSource source);
    //    void TexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type,  ArrayBufferView pixels);
    //    void TexSubImage2D(int target, int level, int xoffset, int yoffset, int format, int type, TexImageSource source);

    //    void Uniform1fv(WebGLUniformLocation location, IEnumerable<float> v);
    //    void Uniform2fv(WebGLUniformLocation location, IEnumerable<float> v);
    //    void Uniform3fv(WebGLUniformLocation location, IEnumerable<float> v);
    //    void Uniform4fv(WebGLUniformLocation location, IEnumerable<float> v);

    //    void Uniform1iv(WebGLUniformLocation location, IEnumerable<int> v);
    //    void Uniform2iv(WebGLUniformLocation location, IEnumerable<int> v);
    //    void Uniform3iv(WebGLUniformLocation location, IEnumerable<int> v);
    //    void Uniform4iv(WebGLUniformLocation location, IEnumerable<int> v);

    //    void UniformMatrix2fv(WebGLUniformLocation location, bool transpose, IEnumerable<float> value);
    //    void UniformMatrix3fv(WebGLUniformLocation location, bool transpose, IEnumerable<float> value);
    //    void UniformMatrix4fv(WebGLUniformLocation location, bool transpose, IEnumerable<float> value);
    //}
}
