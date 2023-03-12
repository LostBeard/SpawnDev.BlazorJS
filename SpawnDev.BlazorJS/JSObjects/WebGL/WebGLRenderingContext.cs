using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://www.khronos.org/registry/webgl/specs/latest/1.0/#5.14.9
    [JsonConverter(typeof(JSObjectConverter<WebGLRenderingContext>))]
    public partial class WebGLRenderingContext : JSObject
    {

        public WebGLRenderingContext(IJSInProcessObjectReference _ref) : base(_ref) { }

        // properties
        public HTMLCanvasElement Canvas => JSRef.Get<HTMLCanvasElement>("canvas");
        public int DrawingBufferHeight => JSRef.Get<int>("drawingBufferHeight");
        public int DrawingBufferWidth => JSRef.Get<int>("drawingBufferWidth");
        // functions
        //public void AttachShader(WebGLProgram program, WebGLShader shader) => Get_ref.CallVoid("attachShader", program, shader);
        //public void BufferData(int target, int size, int usage) => Get_ref.CallVoid("bufferData", target, size, usage);
        //public void BufferData(int target, Float32Array srcData, int usage) => Get_ref.CallVoid("bufferData", target, srcData, usage);
        //public void BindBuffer(int target, WebGLBuffer buffer) => Get_ref.CallVoid("bindBuffer", target, buffer);
        //public void BindTexture(int target, WebGLTexture texture) => Get_ref.CallVoid("bindTexture", target, texture);
        //public void Clear(int mask) => Get_ref.CallVoid("clear", mask);
        //public void ClearColor(float r, float g, float b, float a) => Get_ref.CallVoid("clearColor", r, g, b, a);
        //public void CompileShader(WebGLShader shader) => Get_ref.CallVoid("compileShader", shader);
        //public WebGLBuffer CreateBuffer() => _ref.Call<WebGLBuffer>("createBuffer");
        //public WebGLShader CreateFragmentShader() => CreateShader(FRAGMENT_SHADER);
        //public WebGLProgram CreateProgram() => _ref.Call<WebGLProgram>("createProgram");
        //public WebGLShader CreateShader(int type) => _ref.Call<WebGLShader>("createShader", type);
        //public WebGLTexture CreateTexture() => _ref.Call<WebGLTexture>("createTexture");
        //public WebGLShader CreateVertexShader() => CreateShader(VERTEX_SHADER);
        //public void DeleteProgram(WebGLProgram program) => Get_ref.CallVoid("deleteProgram", program);
        //public void DeleteShader(WebGLShader shader) => Get_ref.CallVoid("deleteShader", shader);
        //public void DrawArrays(int mode, int first, int count) => Get_ref.CallVoid("drawArrays", mode, first, count);
        //public void EnableVertexAttribArray(int index) => Get_ref.CallVoid("enableVertexAttribArray", index);
        //public int GetAttribLocation(WebGLProgram program, string name) => _ref.Call<int>("getAttribLocation", program, name);
        //public T GetProgramParameter<T>(WebGLProgram shader, int pname) => _ref.Call<T>("getProgramParameter", shader, pname);
        //public T GetShaderParameter<T>(WebGLShader shader, int pname) => _ref.Call<T>("getShaderParameter", shader, pname);
        //public WebGLUniformLocation GetUniformLocation(WebGLProgram program, string name) => _ref.Call<WebGLUniformLocation>("getUniformLocation", program, name);
        //public void LinkProgram(WebGLProgram program) => Get_ref.CallVoid("linkProgram", program);
        //public void ReadPixels() => throw new Exception("Not implemeneted");
        //public void ShaderSource(WebGLShader shader, string source) => Get_ref.CallVoid("shaderSource", shader, source);
        //public void TexImage2D(int target, int level, int internalformat, int format, int type, HTMLImageElement pixels) => Get_ref.CallVoid("texImage2D", target, level, internalformat, format, type, pixels);
        //public void TexParameterf(int target, int pname, float param) => Get_ref.CallVoid("texParameterf", target, pname, param);
        //public void TexParameteri(int target, int pname, int param) => Get_ref.CallVoid("texParameteri", target, pname, param);
        //public void Uniform2f(WebGLUniformLocation location, float v0, float v1) => Get_ref.CallVoid("uniform2f", location, v0, v1);
        //public void UseProgram(WebGLProgram program) => Get_ref.CallVoid("useProgram", program);
        //public void VertexAttribPointer(int index, int size, int type, bool normalized, int stride, int offset) => Get_ref.CallVoid("vertexAttribPointer", index, size, type, normalized, stride, offset);
        //public void Viewport(int x, int y, int width, int height) => Get_ref.CallVoid("viewport", x, y, width, height);

        // ArrayBufferView - ArrayBufferView is a helper type representing any of the following JavaScript TypedArray types
        public void ActiveTexture(int texture) => JSRef.CallVoid("activeTexture", texture);
        public void AttachShader(WebGLProgram program, WebGLShader shader) => JSRef.CallVoid("attachShader", program, shader);
        public void BindAttribLocation(WebGLProgram program, uint index, string name) => JSRef.CallVoid("bindAttribLocation", index, name);
        public void BindBuffer(int target, WebGLBuffer buffer) => JSRef.CallVoid("bindBuffer", target, buffer);
        public void BindFramebuffer(int target, WebGLFramebuffer framebuffer) => JSRef.CallVoid("bindFramebuffer", target, framebuffer);
        public void BindRenderbuffer(int target, WebGLRenderbuffer renderbuffer) => JSRef.CallVoid("bindRenderbuffer", target, renderbuffer);
        public void BindTexture(int target, WebGLTexture texture) => JSRef.CallVoid("bindTexture", target, texture);
        public void BlendColor(float red, float green, float blue, float alpha) => JSRef.CallVoid("blendColor", red, green, blue, alpha);
        public void BlendEquation(int mode) => JSRef.CallVoid("blendEquation", mode);
        public void BlendEquationSeparate(int modeRGB, int modeAlpha) => JSRef.CallVoid("blendEquationSeparate", modeRGB, modeAlpha);
        public void BlendFunc(int sfactor, int dfactor) => JSRef.CallVoid("blendFunc", sfactor, dfactor);
        public void BlendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha) => JSRef.CallVoid("blendFuncSeparate", srcRGB, dstRGB, srcAlpha, dstAlpha);
        public void BufferData(int target, int size, int usage) => JSRef.CallVoid("bufferData", target, size, usage);
        public void BufferData(int target, Int8Array srcData, int usage) => JSRef.CallVoid("bufferData", target, srcData, usage);
        public void BufferData(int target, Uint8Array srcData, int usage) => JSRef.CallVoid("bufferData", target, srcData, usage);
        public void BufferData(int target, Uint8ClampedArray srcData, int usage) => JSRef.CallVoid("bufferData", target, srcData, usage);
        public void BufferData(int target, Int16Array srcData, int usage) => JSRef.CallVoid("bufferData", target, srcData, usage);
        public void BufferData(int target, Uint16Array srcData, int usage) => JSRef.CallVoid("bufferData", target, srcData, usage);
        public void BufferData(int target, Int32Array srcData, int usage) => JSRef.CallVoid("bufferData", target, srcData, usage);
        public void BufferData(int target, Uint32Array srcData, int usage) => JSRef.CallVoid("bufferData", target, srcData, usage);
        public void BufferData(int target, Float32Array srcData, int usage) => JSRef.CallVoid("bufferData", target, srcData, usage);
        public void BufferData(int target, ArrayBuffer srcData, int usage) => JSRef.CallVoid("bufferData", target, srcData, usage);
        public void BufferSubData(int target, int offset, Int8Array srcData) => JSRef.CallVoid("bufferSubData", target, offset, srcData);
        public void BufferSubData(int target, int offset, Uint8Array srcData) => JSRef.CallVoid("bufferSubData", target, offset, srcData);
        public void BufferSubData(int target, int offset, Uint8ClampedArray srcData) => JSRef.CallVoid("bufferSubData", target, offset, srcData);
        public void BufferSubData(int target, int offset, Int16Array srcData) => JSRef.CallVoid("bufferSubData", target, offset, srcData);
        public void BufferSubData(int target, int offset, Uint16Array srcData) => JSRef.CallVoid("bufferSubData", target, offset, srcData);
        public void BufferSubData(int target, int offset, Int32Array srcData) => JSRef.CallVoid("bufferSubData", target, offset, srcData);
        public void BufferSubData(int target, int offset, Uint32Array srcData) => JSRef.CallVoid("bufferSubData", target, offset, srcData);
        public void BufferSubData(int target, int offset, Float32Array srcData) => JSRef.CallVoid("bufferSubData", target, offset, srcData);
        public void BufferSubData(int target, int offset, ArrayBuffer srcData) => JSRef.CallVoid("bufferSubData", target, offset, srcData);
        public int CheckFramebufferStatus(int target) => JSRef.Call<int>("checkFramebufferStatus", target);
        public void Clear(int mask) => JSRef.CallVoid("clear", mask);
        public void ClearColor(float red, float green, float blue, float alpha) => JSRef.CallVoid("clearColor", red, green, blue, alpha);
        public void ClearDepth(float depth) => JSRef.CallVoid("clearDepth", depth);
        public void ClearStencil(int s) => JSRef.CallVoid("clearStencil", s);
        public void ColorMask(bool red, bool green, bool blue, bool alpha) => JSRef.CallVoid("colorMask", red, green, blue, alpha);
        public void CompileShader(WebGLShader shader) => JSRef.CallVoid("compileShader", shader);
        public void CompressedTexImage2D(int target, int level, int internalformat, int width, int height, int border, Uint8Array data) => JSRef.CallVoid("compressedTexImage2D", target, level, internalformat, width, height, border, data);
        public void CompressedTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, Uint8Array data) => JSRef.CallVoid("compressedTexSubImage2D", target, level, xoffset, yoffset, width, height, format, data);
        public void CopyTexImage2D(int target, int level, int internalformat, int x, int y, int width, int height, int border) => JSRef.CallVoid("copyTexImage2D", target, level, internalformat, x, y, width, height);
        public void CopyTexSubImage2D(int target, int level, int xoffset, int yoffset, int x, int y, int width, int height) => JSRef.CallVoid("copyTexSubImage2D", target, level, xoffset, yoffset, x, y, width, height);
        public WebGLBuffer CreateBuffer() => JSRef.Call<WebGLBuffer>("createBuffer");
        public WebGLFramebuffer CreateFramebuffer() => JSRef.Call<WebGLFramebuffer>("createFramebuffer");
        public WebGLProgram CreateProgram() => JSRef.Call<WebGLProgram>("createProgram");
        public WebGLRenderbuffer CreateRenderbuffer() => JSRef.Call<WebGLRenderbuffer>("createRenderbuffer");
        public WebGLShader CreateShader(int type) => JSRef.Call<WebGLShader>("createShader", type);
        public WebGLTexture CreateTexture() => JSRef.Call<WebGLTexture>("createTexture");
        public void CullFace(int mode) => JSRef.CallVoid("cullFace", mode);
        public void DeleteBuffer(WebGLBuffer buffer) => JSRef.CallVoid("deleteBuffer", buffer);
        public void DeleteFramebuffer(WebGLFramebuffer framebuffer) => JSRef.CallVoid("deleteFramebuffer", framebuffer);
        public void DeleteProgram(WebGLProgram program) => JSRef.CallVoid("deleteProgram", program);
        public void DeleteRenderbuffer(WebGLRenderbuffer renderbuffer) => JSRef.CallVoid("deleteRenderbuffer", renderbuffer);
        public void DeleteShader(WebGLShader shader) => JSRef.CallVoid("deleteShader", shader);
        public void DeleteTexture(WebGLTexture texture) => JSRef.CallVoid("deleteTexture", texture);
        public void DepthFunc(int func) => JSRef.CallVoid("depthFunc", func);
        public void DepthMask(bool flag) => JSRef.CallVoid("depthMask", flag);
        public void DepthRange(float zNear, float zFar) => JSRef.CallVoid("depthRange", zNear, zFar);
        public void DetachShader(WebGLProgram program, WebGLShader shader) => JSRef.CallVoid("detachShader", program, shader);
        public void Disable(int cap) => JSRef.CallVoid("disable", cap);
        public void DisableVertexAttribArray(uint index) => JSRef.CallVoid("disableVertexAttribArray", index);
        public void DrawArrays(int mode, int first, int count) => JSRef.CallVoid("drawArrays", mode, first, count);
        public void DrawElements(int mode, int count, int type, int offset) => JSRef.CallVoid("drawElements", mode, count, type, offset);
        public void Enable(int cap) => JSRef.CallVoid("enable", cap);
        public void EnableVertexAttribArray(int index) => JSRef.CallVoid("enableVertexAttribArray", index);
        public void Finish() => JSRef.CallVoid("finish");
        public void Flush() => JSRef.CallVoid("flush");
        public void FramebufferRenderbuffer(int target, int attachment, int renderbuffertarget, WebGLRenderbuffer renderbuffer) => JSRef.CallVoid("framebufferRenderbuffer", target, attachment, renderbuffertarget, renderbuffer);
        public void FramebufferTexture2D(int target, int attachment, int textarget, WebGLTexture texture, int level) => JSRef.CallVoid("framebufferTexture2D", target, attachment, textarget, texture, level);
        public void FrontFace(int mode) => JSRef.CallVoid("frontFace", mode);
        public void GenerateMipmap(int target) => JSRef.CallVoid("generateMipmap", target);
        public WebGLActiveInfo GetActiveAttrib(WebGLProgram program, uint index) => JSRef.Call<WebGLActiveInfo>("getActiveAttrib", program, index);
        public WebGLActiveInfo GetActiveUniform(WebGLProgram program, uint index) => JSRef.Call<WebGLActiveInfo>("getActiveUniform", program, index);
        public List<WebGLShader> GetAttachedShaders(WebGLProgram program) => JSRef.Call<List<WebGLShader>>("getAttachedShaders", program);
        public int GetAttribLocation(WebGLProgram program, string name) => JSRef.Call<int>("getAttribLocation", program, name);
        public T GetBufferParameter<T>(int target, int pname) => JSRef.Call<T>("getBufferParameter", target, pname);
        public int GetError() => JSRef.Call<int>("getError");
        public T GetExtension<T>(string name) => JSRef.Call<T>("getExtension", name);
        public T GetFramebufferAttachmentParameter<T>(int target, int attachment, int pname) => JSRef.Call<T>("getFramebufferAttachmentParameter", target, attachment, pname);
        public T GetParameter<T>(int pname) => JSRef.Call<T>("getParameter", pname);
        public string GetProgramInfoLog(WebGLProgram program) => JSRef.Call<string>("getProgramInfoLog", program);
        public T GetProgramParameter<T>(WebGLProgram program, int pname) => JSRef.Call<T>("getProgramParameter", program, pname);
        public T GetRenderbufferParameter<T>(int target, int pname) => JSRef.Call<T>("getRenderbufferParameter", target, pname);
        public string GetShaderInfoLog(WebGLShader shader) => JSRef.Call<string>("getShaderInfoLog", shader);
        public T GetShaderParameter<T>(WebGLShader shader, int pname) => JSRef.Call<T>("getShaderParameter", shader, pname);
        public WebGLShaderPrecisionFormat GetShaderPrecisionFormat(int shadertype, int precisiontype) => JSRef.Call<WebGLShaderPrecisionFormat>("getShaderPrecisionFormat", shadertype, precisiontype);
        public string GetShaderSource(WebGLShader shader) => JSRef.Call<string>("getShaderSource", shader);
        public T GetTexParameter<T>(int target, int pname) => JSRef.Call<T>("getTexParameter", target, pname);
        public T GetUniform<T>(WebGLProgram program, WebGLUniformLocation location) => JSRef.Call<T>("getUniform", program, location);
        public WebGLUniformLocation GetUniformLocation(WebGLProgram program, string name) => JSRef.Call<WebGLUniformLocation>("getUniformLocation", program, name);
        public T GetVertexAttrib<T>(uint index, int pname) => JSRef.Call<T>("getVertexAttrib", index, pname);
        public int GetVertexAttribOffset(uint index, int pname) => JSRef.Call<int>("getVertexAttribOffset", index, pname);
        public void Hint(int target, int mode) => JSRef.CallVoid("hint", target, mode);
        public bool IsBuffer(WebGLBuffer buffer) => JSRef.Call<bool>("isBuffer", buffer);
        public bool IsEnabled(int cap) => JSRef.Call<bool>("isEnabled", cap);
        public bool IsFramebuffer(WebGLFramebuffer framebuffer) => JSRef.Call<bool>("isFramebuffer", framebuffer);
        public bool IsProgram(WebGLProgram program) => JSRef.Call<bool>("isProgram", program);
        public bool IsRenderbuffer(WebGLRenderbuffer renderbuffer) => JSRef.Call<bool>("isRenderbuffer", renderbuffer);
        public bool IsShader(WebGLShader shader) => JSRef.Call<bool>("isShader", shader);
        public bool IsTexture(WebGLTexture texture) => JSRef.Call<bool>("isTexture", texture);
        public void LineWidth(float width) => JSRef.CallVoid("lineWidth", width);
        public void LinkProgram(WebGLProgram program) => JSRef.CallVoid("linkProgram", program);
        public void PixelStorei(int pname, int param) => JSRef.CallVoid("pixelStorei", pname, param);
        public void PolygonOffset(float factor, float units) => JSRef.CallVoid("polygonOffset", factor, units);
        public void ReadPixels(int x, int y, int width, int height, int format, int type, Uint8Array pixels) => JSRef.CallVoid("readPixels", x, y, width, height, format, type, pixels);
        public void RenderbufferStorage(int target, int internalformat, int width, int height) => JSRef.CallVoid("renderbufferStorage", target, internalformat, width, height);
        public void SampleCoverage(float value, bool invert) => JSRef.CallVoid("sampleCoverage", value, invert);
        public void Scissor(int x, int y, int width, int height) => JSRef.CallVoid("scissor", x, y, width, height);
        public void ShaderSource(WebGLShader shader, string source) => JSRef.CallVoid("shaderSource", shader, source);
        public void StencilFunc(int func, int @ref, uint mask) => JSRef.CallVoid("stencilFunc", func, @ref, mask);
        public void StencilFuncSeparate(int face, int func, int @ref, uint mask) => JSRef.CallVoid("stencilFuncSeparate", face, func, @ref, mask);
        public void StencilMask(uint mask) => JSRef.CallVoid("stencilMask", mask);
        public void StencilMaskSeparate(int face, uint mask) => JSRef.CallVoid("stencilMaskSeparate", face, mask);
        public void StencilOp(int fail, int zfail, int zpass) => JSRef.CallVoid("stencilOp", fail, zfail, zpass);
        public void StencilOpSeparate(int face, int fail, int zfail, int zpass) => JSRef.CallVoid("stencilOpSeparate", face, fail, zfail, zpass);
        public void TexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, byte[] pixels) => JSRef.CallVoid("texImage2D", target, level, internalformat, width, height, border, format, type, pixels);
        public void TexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, Uint8Array pixels) => JSRef.CallVoid("texImage2D", target, level, internalformat, width, height, border, format, type, pixels);
        public void TexImage2D(int target, int level, int internalformat, int format, int type, ImageData source) => JSRef.CallVoid("texImage2D", target, level, internalformat, format, type, source);
        public void TexImage2D(int target, int level, int internalformat, int format, int type, HTMLImageElement source) => JSRef.CallVoid("texImage2D", target, level, internalformat, format, type, source);
        public void TexImage2D(int target, int level, int internalformat, int format, int type, HTMLCanvasElement source) => JSRef.CallVoid("texImage2D", target, level, internalformat, format, type, source);
        public void TexImage2D(int target, int level, int internalformat, int format, int type, HTMLVideoElement source) => JSRef.CallVoid("texImage2D", target, level, internalformat, format, type, source);
        public void TexParameterf(int target, int pname, float param) => JSRef.CallVoid("texParameterf", target, pname, param);
        public void TexParameteri(int target, int pname, int param) => JSRef.CallVoid("texParameteri", target, pname, param);
        public void TexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, Uint8Array pixels) => JSRef.CallVoid("texSubImage2D", target, level, xoffset, yoffset, width, height, format, type, pixels);
        public void TexSubImage2D(int target, int level, int xoffset, int yoffset, int format, int type, ImageData source) => JSRef.CallVoid("texSubImage2D", target, level, xoffset, yoffset, format, type, source);
        public void TexSubImage2D(int target, int level, int xoffset, int yoffset, int format, int type, HTMLImageElement source) => JSRef.CallVoid("texSubImage2D", target, level, xoffset, yoffset, format, type, source);
        public void TexSubImage2D(int target, int level, int xoffset, int yoffset, int format, int type, HTMLCanvasElement source) => JSRef.CallVoid("texSubImage2D", target, level, xoffset, yoffset, format, type, source);
        public void TexSubImage2D(int target, int level, int xoffset, int yoffset, int format, int type, HTMLVideoElement source) => JSRef.CallVoid("texSubImage2D", target, level, xoffset, yoffset, format, type, source);
        public void Uniform1f(WebGLUniformLocation location, float x) => JSRef.CallVoid("uniform1f", location, x);
        public void Uniform1fv(WebGLUniformLocation location, IEnumerable<float> v) => JSRef.CallVoid("uniform1fv", location, v);
        public void Uniform1i(WebGLUniformLocation location, int x) => JSRef.CallVoid("uniform1i", location, x);
        public void Uniform1iv(WebGLUniformLocation location, IEnumerable<int> v) => JSRef.CallVoid("uniform1iv", location, v);
        public void Uniform2f(WebGLUniformLocation location, float x, float y) => JSRef.CallVoid("uniform2f", location, x, y);
        public void Uniform2fv(WebGLUniformLocation location, IEnumerable<float> v) => JSRef.CallVoid("uniform2fv", location, v);
        public void Uniform2i(WebGLUniformLocation location, int x, int y) => JSRef.CallVoid("uniform2i", location, x, y);
        public void Uniform2iv(WebGLUniformLocation location, IEnumerable<int> v) => JSRef.CallVoid("uniform2iv", location, v);
        public void Uniform3f(WebGLUniformLocation location, float x, float y, float z) => JSRef.CallVoid("uniform3f", location, x, y, z);
        public void Uniform3fv(WebGLUniformLocation location, IEnumerable<float> v) => JSRef.CallVoid("uniform3fv", location, v);
        public void Uniform3i(WebGLUniformLocation location, int x, int y, int z) => JSRef.CallVoid("uniform3i", location, x, y, z);
        public void Uniform3iv(WebGLUniformLocation location, IEnumerable<int> v) => JSRef.CallVoid("uniform3iv", location, v);
        public void Uniform4f(WebGLUniformLocation location, float x, float y, float z, float w) => JSRef.CallVoid("uniform4f", location, x, y, z, w);
        public void Uniform4fv(WebGLUniformLocation location, IEnumerable<float> v) => JSRef.CallVoid("uniform4fv", location, v);
        public void Uniform4i(WebGLUniformLocation location, int x, int y, int z, int w) => JSRef.CallVoid("uniform4i", location, x, y, z, w);
        public void Uniform4iv(WebGLUniformLocation location, IEnumerable<int> v) => JSRef.CallVoid("uniform4iv", location, v);
        public void UniformMatrix2fv(WebGLUniformLocation location, bool transpose, IEnumerable<float> value) => JSRef.CallVoid("uniformMatrix2fv", location, transpose, value);
        public void UniformMatrix3fv(WebGLUniformLocation location, bool transpose, IEnumerable<float> value) => JSRef.CallVoid("uniformMatrix3fv", location, transpose, value);
        public void UniformMatrix4fv(WebGLUniformLocation location, bool transpose, IEnumerable<float> value) => JSRef.CallVoid("uniformMatrix4fv", location, transpose, value);
        public void UseProgram(WebGLProgram program) => JSRef.CallVoid("useProgram", program);
        public void ValidateProgram(WebGLProgram program) => JSRef.CallVoid("validateProgram", program);
        public void VertexAttrib1f(uint index, float x) => JSRef.CallVoid("vertexAttrib1f", index, x);
        public void VertexAttrib1fv(uint index, IEnumerable<float> values) => JSRef.CallVoid("vertexAttrib1fv", index, values);
        public void VertexAttrib2f(uint index, float x, float y) => JSRef.CallVoid("vertexAttrib2f", index, x, y);
        public void VertexAttrib2fv(uint index, IEnumerable<float> values) => JSRef.CallVoid("vertexAttrib2fv", index, values);
        public void VertexAttrib3f(uint index, float x, float y, float z) => JSRef.CallVoid("vertexAttrib3f", index, x, y, z);
        public void VertexAttrib3fv(uint index, IEnumerable<float> values) => JSRef.CallVoid("vertexAttrib3fv", index, values);
        public void VertexAttrib4f(uint index, float x, float y, float z, float w) => JSRef.CallVoid("vertexAttrib4f", index, x, y, z, w);
        public void VertexAttrib4fv(uint index, IEnumerable<float> values) => JSRef.CallVoid("vertexAttrib4fv", index, values);
        public void VertexAttribPointer(int index, int size, int type, bool normalized, int stride, int offset) => JSRef.CallVoid("vertexAttribPointer", index, size, type, normalized, stride, offset);
        public void Viewport(int x, int y, int width, int height) => JSRef.CallVoid("viewport", x, y, width, height);

        // Helper functions (non-spec) 
        public WebGLProgram CreateProgram(string vertexShader, string fragmentShader)
        {
            //vertex shader
            using var vsShader = CreateShader(VERTEX_SHADER);
            ShaderSource(vsShader, vertexShader);
            CompileShader(vsShader);
            var vsShaderSucc = GetShaderParameter<bool>(vsShader, COMPILE_STATUS);
            if (!vsShaderSucc)
            {
                var compilationLog = GetShaderInfoLog(vsShader);
                DeleteShader(vsShader);
                throw new Exception($"Error compile vertex shader for WebGLProgram. {compilationLog}");
            }
            // fragment shader
            using var psShader = CreateShader(FRAGMENT_SHADER);
            ShaderSource(psShader, fragmentShader);
            CompileShader(psShader);
            var psShaderSucc = GetShaderParameter<bool>(psShader, COMPILE_STATUS);
            if (!psShaderSucc)
            {
                var compilationLog = GetShaderInfoLog(psShader);
                DeleteShader(vsShader);
                DeleteShader(psShader);
                throw new Exception($"Error compile fragment shader for WebGLProgram. {compilationLog}");
            }
            // program
            var program = CreateProgram();
            AttachShader(program, vsShader);
            AttachShader(program, psShader);
            LinkProgram(program);
            var programSucc = GetProgramParameter<bool>(program, LINK_STATUS);
            DeleteShader(vsShader);
            DeleteShader(psShader);
            if (programSucc) return program;
            //DeleteShader(vsShader);
            //DeleteShader(psShader);
            DeleteProgram(program);
            program.Dispose();
            throw new Exception("Error creating shader program for WebGLProgram");
        }
    }
}
