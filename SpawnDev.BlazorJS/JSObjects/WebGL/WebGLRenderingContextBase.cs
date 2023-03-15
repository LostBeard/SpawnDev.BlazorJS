
namespace SpawnDev.BlazorJS.JSObjects {
    // https://www.khronos.org/registry/webgl/specs/latest/1.0/#5.14.9
    public partial class WebGLRenderingContext {

        /* ClearBufferMask */
        public readonly int DEPTH_BUFFER_BIT = 0x00000100;
        public readonly int STENCIL_BUFFER_BIT = 0x00000400;
        public readonly int COLOR_BUFFER_BIT = 0x00004000;

        /* BeginMode */
        public readonly int POINTS = 0x0000;
        public readonly int LINES = 0x0001;
        public readonly int LINE_LOOP = 0x0002;
        public readonly int LINE_STRIP = 0x0003;
        public readonly int TRIANGLES = 0x0004;
        public readonly int TRIANGLE_STRIP = 0x0005;
        public readonly int TRIANGLE_FAN = 0x0006;

        /* AlphaFunction (not supported in ES20) */
        /*      NEVER */
        /*      LESS */
        /*      EQUAL */
        /*      LEQUAL */
        /*      GREATER */
        /*      NOTEQUAL */
        /*      GEQUAL */
        /*      ALWAYS */

        /* BlendingFactorDest */
        public readonly int ZERO = 0;
        public readonly int ONE = 1;
        public readonly int SRC_COLOR = 0x0300;
        public readonly int ONE_MINUS_SRC_COLOR = 0x0301;
        public readonly int SRC_ALPHA = 0x0302;
        public readonly int ONE_MINUS_SRC_ALPHA = 0x0303;
        public readonly int DST_ALPHA = 0x0304;
        public readonly int ONE_MINUS_DST_ALPHA = 0x0305;

        /* BlendingFactorSrc */
        /*      ZERO */
        /*      ONE */
        public readonly int DST_COLOR = 0x0306;
        public readonly int ONE_MINUS_DST_COLOR = 0x0307;
        public readonly int SRC_ALPHA_SATURATE = 0x0308;
        /*      SRC_ALPHA */
        /*      ONE_MINUS_SRC_ALPHA */
        /*      DST_ALPHA */
        /*      ONE_MINUS_DST_ALPHA */

        /* BlendEquationSeparate */
        public readonly int FUNC_ADD = 0x8006;
        public readonly int BLEND_EQUATION = 0x8009;
        public readonly int BLEND_EQUATION_RGB = 0x8009;   /* same as BLEND_EQUATION */
        public readonly int BLEND_EQUATION_ALPHA = 0x883D;

        /* BlendSubtract */
        public readonly int FUNC_SUBTRACT = 0x800A;
        public readonly int FUNC_REVERSE_SUBTRACT = 0x800B;

        /* Separate Blend Functions */
        public readonly int BLEND_DST_RGB = 0x80C8;
        public readonly int BLEND_SRC_RGB = 0x80C9;
        public readonly int BLEND_DST_ALPHA = 0x80CA;
        public readonly int BLEND_SRC_ALPHA = 0x80CB;
        public readonly int CONSTANT_COLOR = 0x8001;
        public readonly int ONE_MINUS_CONSTANT_COLOR = 0x8002;
        public readonly int CONSTANT_ALPHA = 0x8003;
        public readonly int ONE_MINUS_CONSTANT_ALPHA = 0x8004;
        public readonly int BLEND_COLOR = 0x8005;

        /* Buffer Objects */
        public readonly int ARRAY_BUFFER = 0x8892;
        public readonly int ELEMENT_ARRAY_BUFFER = 0x8893;
        public readonly int ARRAY_BUFFER_BINDING = 0x8894;
        public readonly int ELEMENT_ARRAY_BUFFER_BINDING = 0x8895;

        public readonly int STREAM_DRAW = 0x88E0;
        public readonly int STATIC_DRAW = 0x88E4;
        public readonly int DYNAMIC_DRAW = 0x88E8;

        public readonly int BUFFER_SIZE = 0x8764;
        public readonly int BUFFER_USAGE = 0x8765;

        public readonly int CURRENT_VERTEX_ATTRIB = 0x8626;

        /* CullFaceMode */
        public readonly int FRONT = 0x0404;
        public readonly int BACK = 0x0405;
        public readonly int FRONT_AND_BACK = 0x0408;

        /* DepthFunction */
        /*      NEVER */
        /*      LESS */
        /*      EQUAL */
        /*      LEQUAL */
        /*      GREATER */
        /*      NOTEQUAL */
        /*      GEQUAL */
        /*      ALWAYS */

        /* EnableCap */
        /* TEXTURE_2D */
        public readonly int CULL_FACE = 0x0B44;
        public readonly int BLEND = 0x0BE2;
        public readonly int DITHER = 0x0BD0;
        public readonly int STENCIL_TEST = 0x0B90;
        public readonly int DEPTH_TEST = 0x0B71;
        public readonly int SCISSOR_TEST = 0x0C11;
        public readonly int POLYGON_OFFSET_FILL = 0x8037;
        public readonly int SAMPLE_ALPHA_TO_COVERAGE = 0x809E;
        public readonly int SAMPLE_COVERAGE = 0x80A0;

        /* ErrorCode */
        public readonly int NO_ERROR = 0;
        public readonly int INVALID_ENUM = 0x0500;
        public readonly int INVALID_VALUE = 0x0501;
        public readonly int INVALID_OPERATION = 0x0502;
        public readonly int OUT_OF_MEMORY = 0x0505;

        /* FrontFaceDirection */
        public readonly int CW = 0x0900;
        public readonly int CCW = 0x0901;

        /* GetPName */
        public readonly int LINE_WIDTH = 0x0B21;
        public readonly int ALIASED_POINT_SIZE_RANGE = 0x846D;
        public readonly int ALIASED_LINE_WIDTH_RANGE = 0x846E;
        public readonly int CULL_FACE_MODE = 0x0B45;
        public readonly int FRONT_FACE = 0x0B46;
        public readonly int DEPTH_RANGE = 0x0B70;
        public readonly int DEPTH_WRITEMASK = 0x0B72;
        public readonly int DEPTH_CLEAR_VALUE = 0x0B73;
        public readonly int DEPTH_FUNC = 0x0B74;
        public readonly int STENCIL_CLEAR_VALUE = 0x0B91;
        public readonly int STENCIL_FUNC = 0x0B92;
        public readonly int STENCIL_FAIL = 0x0B94;
        public readonly int STENCIL_PASS_DEPTH_FAIL = 0x0B95;
        public readonly int STENCIL_PASS_DEPTH_PASS = 0x0B96;
        public readonly int STENCIL_REF = 0x0B97;
        public readonly int STENCIL_VALUE_MASK = 0x0B93;
        public readonly int STENCIL_WRITEMASK = 0x0B98;
        public readonly int STENCIL_BACK_FUNC = 0x8800;
        public readonly int STENCIL_BACK_FAIL = 0x8801;
        public readonly int STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802;
        public readonly int STENCIL_BACK_PASS_DEPTH_PASS = 0x8803;
        public readonly int STENCIL_BACK_REF = 0x8CA3;
        public readonly int STENCIL_BACK_VALUE_MASK = 0x8CA4;
        public readonly int STENCIL_BACK_WRITEMASK = 0x8CA5;
        public readonly int VIEWPORT = 0x0BA2;
        public readonly int SCISSOR_BOX = 0x0C10;
        /*      SCISSOR_TEST */
        public readonly int COLOR_CLEAR_VALUE = 0x0C22;
        public readonly int COLOR_WRITEMASK = 0x0C23;
        public readonly int UNPACK_ALIGNMENT = 0x0CF5;
        public readonly int PACK_ALIGNMENT = 0x0D05;
        public readonly int MAX_TEXTURE_SIZE = 0x0D33;
        public readonly int MAX_VIEWPORT_DIMS = 0x0D3A;
        public readonly int SUBPIXEL_BITS = 0x0D50;
        public readonly int RED_BITS = 0x0D52;
        public readonly int GREEN_BITS = 0x0D53;
        public readonly int BLUE_BITS = 0x0D54;
        public readonly int ALPHA_BITS = 0x0D55;
        public readonly int DEPTH_BITS = 0x0D56;
        public readonly int STENCIL_BITS = 0x0D57;
        public readonly int POLYGON_OFFSET_UNITS = 0x2A00;
        /*      POLYGON_OFFSET_FILL */
        public readonly int POLYGON_OFFSET_FACTOR = 0x8038;
        public readonly int TEXTURE_BINDING_2D = 0x8069;
        public readonly int SAMPLE_BUFFERS = 0x80A8;
        public readonly int SAMPLES = 0x80A9;
        public readonly int SAMPLE_COVERAGE_VALUE = 0x80AA;
        public readonly int SAMPLE_COVERAGE_INVERT = 0x80AB;

        /* GetTextureParameter */
        /*      TEXTURE_MAG_FILTER */
        /*      TEXTURE_MIN_FILTER */
        /*      TEXTURE_WRAP_S */
        /*      TEXTURE_WRAP_T */

        public readonly int COMPRESSED_TEXTURE_FORMATS = 0x86A3;

        /* HintMode */
        public readonly int DONT_CARE = 0x1100;
        public readonly int FASTEST = 0x1101;
        public readonly int NICEST = 0x1102;

        /* HintTarget */
        public readonly int GENERATE_MIPMAP_HINT = 0x8192;

        /* DataType */
        public readonly int BYTE = 0x1400;
        public readonly int UNSIGNED_BYTE = 0x1401;
        public readonly int SHORT = 0x1402;
        public readonly int UNSIGNED_SHORT = 0x1403;
        public readonly int INT = 0x1404;
        public readonly int UNSIGNED_INT = 0x1405;
        public readonly int FLOAT = 0x1406;

        /* PixelFormat */
        public readonly int DEPTH_COMPONENT = 0x1902;
        public readonly int ALPHA = 0x1906;
        public readonly int RGB = 0x1907;
        public readonly int RGBA = 0x1908;
        public readonly int LUMINANCE = 0x1909;
        public readonly int LUMINANCE_ALPHA = 0x190A;

        /* PixelType */
        /*      UNSIGNED_BYTE */
        public readonly int UNSIGNED_SHORT_4_4_4_4 = 0x8033;
        public readonly int UNSIGNED_SHORT_5_5_5_1 = 0x8034;
        public readonly int UNSIGNED_SHORT_5_6_5 = 0x8363;

        /* Shaders */
        public readonly int FRAGMENT_SHADER = 0x8B30;
        public readonly int VERTEX_SHADER = 0x8B31;
        public readonly int MAX_VERTEX_ATTRIBS = 0x8869;
        public readonly int MAX_VERTEX_UNIFORM_VECTORS = 0x8DFB;
        public readonly int MAX_VARYING_VECTORS = 0x8DFC;
        public readonly int MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D;
        public readonly int MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C;
        public readonly int MAX_TEXTURE_IMAGE_UNITS = 0x8872;
        public readonly int MAX_FRAGMENT_UNIFORM_VECTORS = 0x8DFD;
        public readonly int SHADER_TYPE = 0x8B4F;
        public readonly int DELETE_STATUS = 0x8B80;
        public readonly int LINK_STATUS = 0x8B82;
        public readonly int VALIDATE_STATUS = 0x8B83;
        public readonly int ATTACHED_SHADERS = 0x8B85;
        public readonly int ACTIVE_UNIFORMS = 0x8B86;
        public readonly int ACTIVE_ATTRIBUTES = 0x8B89;
        public readonly int SHADING_LANGUAGE_VERSION = 0x8B8C;
        public readonly int CURRENT_PROGRAM = 0x8B8D;

        /* StencilFunction */
        public readonly int NEVER = 0x0200;
        public readonly int LESS = 0x0201;
        public readonly int EQUAL = 0x0202;
        public readonly int LEQUAL = 0x0203;
        public readonly int GREATER = 0x0204;
        public readonly int NOTEQUAL = 0x0205;
        public readonly int GEQUAL = 0x0206;
        public readonly int ALWAYS = 0x0207;

        /* StencilOp */
        /*      ZERO */
        public readonly int KEEP = 0x1E00;
        public readonly int REPLACE = 0x1E01;
        public readonly int INCR = 0x1E02;
        public readonly int DECR = 0x1E03;
        public readonly int INVERT = 0x150A;
        public readonly int INCR_WRAP = 0x8507;
        public readonly int DECR_WRAP = 0x8508;

        /* StringName */
        public readonly int VENDOR = 0x1F00;
        public readonly int RENDERER = 0x1F01;
        public readonly int VERSION = 0x1F02;

        /* TextureMagFilter */
        public readonly int NEAREST = 0x2600;
        public readonly int LINEAR = 0x2601;

        /* TextureMinFilter */
        /*      NEAREST */
        /*      LINEAR */
        public readonly int NEAREST_MIPMAP_NEAREST = 0x2700;
        public readonly int LINEAR_MIPMAP_NEAREST = 0x2701;
        public readonly int NEAREST_MIPMAP_LINEAR = 0x2702;
        public readonly int LINEAR_MIPMAP_LINEAR = 0x2703;

        /* TextureParameterName */
        public readonly int TEXTURE_MAG_FILTER = 0x2800;
        public readonly int TEXTURE_MIN_FILTER = 0x2801;
        public readonly int TEXTURE_WRAP_S = 0x2802;
        public readonly int TEXTURE_WRAP_T = 0x2803;

        /* TextureTarget */
        public readonly int TEXTURE_2D = 0x0DE1;
        public readonly int TEXTURE = 0x1702;

        public readonly int TEXTURE_CUBE_MAP = 0x8513;
        public readonly int TEXTURE_BINDING_CUBE_MAP = 0x8514;
        public readonly int TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515;
        public readonly int TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516;
        public readonly int TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517;
        public readonly int TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518;
        public readonly int TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519;
        public readonly int TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A;
        public readonly int MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C;

        /* TextureUnit */
        public readonly int TEXTURE0 = 0x84C0;
        public readonly int TEXTURE1 = 0x84C1;
        public readonly int TEXTURE2 = 0x84C2;
        public readonly int TEXTURE3 = 0x84C3;
        public readonly int TEXTURE4 = 0x84C4;
        public readonly int TEXTURE5 = 0x84C5;
        public readonly int TEXTURE6 = 0x84C6;
        public readonly int TEXTURE7 = 0x84C7;
        public readonly int TEXTURE8 = 0x84C8;
        public readonly int TEXTURE9 = 0x84C9;
        public readonly int TEXTURE10 = 0x84CA;
        public readonly int TEXTURE11 = 0x84CB;
        public readonly int TEXTURE12 = 0x84CC;
        public readonly int TEXTURE13 = 0x84CD;
        public readonly int TEXTURE14 = 0x84CE;
        public readonly int TEXTURE15 = 0x84CF;
        public readonly int TEXTURE16 = 0x84D0;
        public readonly int TEXTURE17 = 0x84D1;
        public readonly int TEXTURE18 = 0x84D2;
        public readonly int TEXTURE19 = 0x84D3;
        public readonly int TEXTURE20 = 0x84D4;
        public readonly int TEXTURE21 = 0x84D5;
        public readonly int TEXTURE22 = 0x84D6;
        public readonly int TEXTURE23 = 0x84D7;
        public readonly int TEXTURE24 = 0x84D8;
        public readonly int TEXTURE25 = 0x84D9;
        public readonly int TEXTURE26 = 0x84DA;
        public readonly int TEXTURE27 = 0x84DB;
        public readonly int TEXTURE28 = 0x84DC;
        public readonly int TEXTURE29 = 0x84DD;
        public readonly int TEXTURE30 = 0x84DE;
        public readonly int TEXTURE31 = 0x84DF;
        public readonly int ACTIVE_TEXTURE = 0x84E0;

        /* TextureWrapMode */
        public readonly int REPEAT = 0x2901;
        public readonly int CLAMP_TO_EDGE = 0x812F;
        public readonly int MIRRORED_REPEAT = 0x8370;

        /* Uniform Types */
        public readonly int FLOAT_VEC2 = 0x8B50;
        public readonly int FLOAT_VEC3 = 0x8B51;
        public readonly int FLOAT_VEC4 = 0x8B52;
        public readonly int INT_VEC2 = 0x8B53;
        public readonly int INT_VEC3 = 0x8B54;
        public readonly int INT_VEC4 = 0x8B55;
        public readonly int BOOL = 0x8B56;
        public readonly int BOOL_VEC2 = 0x8B57;
        public readonly int BOOL_VEC3 = 0x8B58;
        public readonly int BOOL_VEC4 = 0x8B59;
        public readonly int FLOAT_MAT2 = 0x8B5A;
        public readonly int FLOAT_MAT3 = 0x8B5B;
        public readonly int FLOAT_MAT4 = 0x8B5C;
        public readonly int SAMPLER_2D = 0x8B5E;
        public readonly int SAMPLER_CUBE = 0x8B60;

        /* Vertex Arrays */
        public readonly int VERTEX_ATTRIB_ARRAY_ENABLED = 0x8622;
        public readonly int VERTEX_ATTRIB_ARRAY_SIZE = 0x8623;
        public readonly int VERTEX_ATTRIB_ARRAY_STRIDE = 0x8624;
        public readonly int VERTEX_ATTRIB_ARRAY_TYPE = 0x8625;
        public readonly int VERTEX_ATTRIB_ARRAY_NORMALIZED = 0x886A;
        public readonly int VERTEX_ATTRIB_ARRAY_POINTER = 0x8645;
        public readonly int VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 0x889F;

        /* Read Format */
        public readonly int IMPLEMENTATION_COLOR_READ_TYPE = 0x8B9A;
        public readonly int IMPLEMENTATION_COLOR_READ_FORMAT = 0x8B9B;

        /* Shader Source */
        public readonly int COMPILE_STATUS = 0x8B81;

        /* Shader Precision-Specified Types */
        public readonly int LOW_FLOAT = 0x8DF0;
        public readonly int MEDIUM_FLOAT = 0x8DF1;
        public readonly int HIGH_FLOAT = 0x8DF2;
        public readonly int LOW_INT = 0x8DF3;
        public readonly int MEDIUM_INT = 0x8DF4;
        public readonly int HIGH_INT = 0x8DF5;

        /* Framebuffer Object. */
        public readonly int FRAMEBUFFER = 0x8D40;
        public readonly int RENDERBUFFER = 0x8D41;

        public readonly int RGBA4 = 0x8056;
        public readonly int RGB5_A1 = 0x8057;
        public readonly int RGB565 = 0x8D62;
        public readonly int DEPTH_COMPONENT16 = 0x81A5;
        public readonly int STENCIL_INDEX8 = 0x8D48;
        public readonly int DEPTH_STENCIL = 0x84F9;

        public readonly int RENDERBUFFER_WIDTH = 0x8D42;
        public readonly int RENDERBUFFER_HEIGHT = 0x8D43;
        public readonly int RENDERBUFFER_INTERNAL_FORMAT = 0x8D44;
        public readonly int RENDERBUFFER_RED_SIZE = 0x8D50;
        public readonly int RENDERBUFFER_GREEN_SIZE = 0x8D51;
        public readonly int RENDERBUFFER_BLUE_SIZE = 0x8D52;
        public readonly int RENDERBUFFER_ALPHA_SIZE = 0x8D53;
        public readonly int RENDERBUFFER_DEPTH_SIZE = 0x8D54;
        public readonly int RENDERBUFFER_STENCIL_SIZE = 0x8D55;

        public readonly int FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = 0x8CD0;
        public readonly int FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = 0x8CD1;
        public readonly int FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = 0x8CD2;
        public readonly int FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = 0x8CD3;

        public readonly int COLOR_ATTACHMENT0 = 0x8CE0;
        public readonly int DEPTH_ATTACHMENT = 0x8D00;
        public readonly int STENCIL_ATTACHMENT = 0x8D20;
        public readonly int DEPTH_STENCIL_ATTACHMENT = 0x821A;

        public readonly int NONE = 0;

        public readonly int FRAMEBUFFER_COMPLETE = 0x8CD5;
        public readonly int FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 0x8CD6;
        public readonly int FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 0x8CD7;
        public readonly int FRAMEBUFFER_INCOMPLETE_DIMENSIONS = 0x8CD9;
        public readonly int FRAMEBUFFER_UNSUPPORTED = 0x8CDD;

        public readonly int FRAMEBUFFER_BINDING = 0x8CA6;
        public readonly int RENDERBUFFER_BINDING = 0x8CA7;
        public readonly int MAX_RENDERBUFFER_SIZE = 0x84E8;

        public readonly int INVALID_FRAMEBUFFER_OPERATION = 0x0506;

        /* WebGL-specific enums */
        public readonly int UNPACK_FLIP_Y_WEBGL = 0x9240;
        public readonly int UNPACK_PREMULTIPLY_ALPHA_WEBGL = 0x9241;
        public readonly int CONTEXT_LOST_WEBGL = 0x9242;
        public readonly int UNPACK_COLORSPACE_CONVERSION_WEBGL = 0x9243;
        public readonly int BROWSER_DEFAULT_WEBGL = 0x9244;

        //    readonly attribute(HTMLCanvasElement or OffscreenCanvas) canvas;
        //readonly attribute GLsizei drawingBufferWidth;
        //readonly attribute GLsizei drawingBufferHeight;

        //[WebGLHandlesContextLoss] WebGLContextAttributes? getContextAttributes();
        //    [WebGLHandlesContextLoss] boolean isContextLost();

        //    sequence<DOMString>? getSupportedExtensions();
        //    object? getExtension(DOMString name);

        //    undefined activeTexture(GLenum texture);
        //    undefined attachShader(WebGLProgram program, WebGLShader shader);
        //    undefined bindAttribLocation(WebGLProgram program, GLuint index, DOMString name);
        //    undefined bindBuffer(GLenum target, WebGLBuffer? buffer);
        //    undefined bindFramebuffer(GLenum target, WebGLFramebuffer? framebuffer);
        //    undefined bindRenderbuffer(GLenum target, WebGLRenderbuffer? renderbuffer);
        //    undefined bindTexture(GLenum target, WebGLTexture? texture);
        //    undefined blendColor(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);
        //    undefined blendEquation(GLenum mode);
        //    undefined blendEquationSeparate(GLenum modeRGB, GLenum modeAlpha);
        //    undefined blendFunc(GLenum sfactor, GLenum dfactor);
        //    undefined blendFuncSeparate(GLenum srcRGB, GLenum dstRGB,
        //                                GLenum srcAlpha, GLenum dstAlpha);

        //    [WebGLHandlesContextLoss] GLenum checkFramebufferStatus(GLenum target);
        //    undefined clear(GLbitfield mask);
        //    undefined clearColor(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);
        //    undefined clearDepth(GLclampf depth);
        //    undefined clearStencil(GLint s);
        //    undefined colorMask(GLboolean red, GLboolean green, GLboolean blue, GLboolean alpha);
        //    undefined compileShader(WebGLShader shader);

        //    undefined copyTexImage2D(GLenum target, GLint level, GLenum internalformat,
        //                             GLint x, GLint y, GLsizei width, GLsizei height,
        //                             GLint border);
        //    undefined copyTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset,
        //                                GLint x, GLint y, GLsizei width, GLsizei height);

        //    WebGLBuffer? createBuffer();
        //    WebGLFramebuffer? createFramebuffer();
        //    WebGLProgram? createProgram();
        //    WebGLRenderbuffer? createRenderbuffer();
        //    WebGLShader? createShader(GLenum type);
        //    WebGLTexture? createTexture();

        //    undefined cullFace(GLenum mode);

        //    undefined deleteBuffer(WebGLBuffer? buffer);
        //    undefined deleteFramebuffer(WebGLFramebuffer? framebuffer);
        //    undefined deleteProgram(WebGLProgram? program);
        //    undefined deleteRenderbuffer(WebGLRenderbuffer? renderbuffer);
        //    undefined deleteShader(WebGLShader? shader);
        //    undefined deleteTexture(WebGLTexture? texture);

        //    undefined depthFunc(GLenum func);
        //    undefined depthMask(GLboolean flag);
        //    undefined depthRange(GLclampf zNear, GLclampf zFar);
        //    undefined detachShader(WebGLProgram program, WebGLShader shader);
        //    undefined disable(GLenum cap);
        //    undefined disableVertexAttribArray(GLuint index);
        //    undefined drawArrays(GLenum mode, GLint first, GLsizei count);
        //    undefined drawElements(GLenum mode, GLsizei count, GLenum type, GLintptr offset);

        //    undefined enable(GLenum cap);
        //    undefined enableVertexAttribArray(GLuint index);
        //    undefined finish();
        //    undefined flush();
        //    undefined framebufferRenderbuffer(GLenum target, GLenum attachment,
        //                                      GLenum renderbuffertarget,
        //                                      WebGLRenderbuffer? renderbuffer);
        //    undefined framebufferTexture2D(GLenum target, GLenum attachment, GLenum textarget,
        //                                   WebGLTexture? texture, GLint level);
        //    undefined frontFace(GLenum mode);

        //    undefined generateMipmap(GLenum target);

        //    WebGLActiveInfo? getActiveAttrib(WebGLProgram program, GLuint index);
        //    WebGLActiveInfo? getActiveUniform(WebGLProgram program, GLuint index);
        //    sequence<WebGLShader>? getAttachedShaders(WebGLProgram program);

        //    [WebGLHandlesContextLoss] GLint getAttribLocation(WebGLProgram program, DOMString name);

        //    any getBufferParameter(GLenum target, GLenum pname);
        //    any getParameter(GLenum pname);

        //    [WebGLHandlesContextLoss] GLenum getError();

        //    any getFramebufferAttachmentParameter(GLenum target, GLenum attachment,
        //                                          GLenum pname);
        //    any getProgramParameter(WebGLProgram program, GLenum pname);
        //    DOMString? getProgramInfoLog(WebGLProgram program);
        //    any getRenderbufferParameter(GLenum target, GLenum pname);
        //    any getShaderParameter(WebGLShader shader, GLenum pname);
        //    WebGLShaderPrecisionFormat? getShaderPrecisionFormat(GLenum shadertype, GLenum precisiontype);
        //    DOMString? getShaderInfoLog(WebGLShader shader);

        //    DOMString? getShaderSource(WebGLShader shader);

        //    any getTexParameter(GLenum target, GLenum pname);

        //    any getUniform(WebGLProgram program, WebGLUniformLocation location);

        //    WebGLUniformLocation? getUniformLocation(WebGLProgram program, DOMString name);

        //    any getVertexAttrib(GLuint index, GLenum pname);

        //    [WebGLHandlesContextLoss] GLintptr getVertexAttribOffset(GLuint index, GLenum pname);

        //    undefined hint(GLenum target, GLenum mode);
        //    [WebGLHandlesContextLoss] GLboolean isBuffer(WebGLBuffer? buffer);
        //    [WebGLHandlesContextLoss] GLboolean isEnabled(GLenum cap);
        //    [WebGLHandlesContextLoss] GLboolean isFramebuffer(WebGLFramebuffer? framebuffer);
        //    [WebGLHandlesContextLoss] GLboolean isProgram(WebGLProgram? program);
        //    [WebGLHandlesContextLoss] GLboolean isRenderbuffer(WebGLRenderbuffer? renderbuffer);
        //    [WebGLHandlesContextLoss] GLboolean isShader(WebGLShader? shader);
        //    [WebGLHandlesContextLoss] GLboolean isTexture(WebGLTexture? texture);
        //    undefined lineWidth(GLfloat width);
        //    undefined linkProgram(WebGLProgram program);
        //    undefined pixelStorei(GLenum pname, GLint param);
        //    undefined polygonOffset(GLfloat factor, GLfloat units);

        //    undefined renderbufferStorage(GLenum target, GLenum internalformat,
        //                                  GLsizei width, GLsizei height);
        //    undefined sampleCoverage(GLclampf value, GLboolean invert);
        //    undefined scissor(GLint x, GLint y, GLsizei width, GLsizei height);

        //    undefined shaderSource(WebGLShader shader, DOMString source);

        //    undefined stencilFunc(GLenum func, GLint ref, GLuint mask);
        //    undefined stencilFuncSeparate(GLenum face, GLenum func, GLint ref, GLuint mask);
        //    undefined stencilMask(GLuint mask);
        //    undefined stencilMaskSeparate(GLenum face, GLuint mask);
        //    undefined stencilOp(GLenum fail, GLenum zfail, GLenum zpass);
        //    undefined stencilOpSeparate(GLenum face, GLenum fail, GLenum zfail, GLenum zpass);

        //    undefined texParameterf(GLenum target, GLenum pname, GLfloat param);
        //    undefined texParameteri(GLenum target, GLenum pname, GLint param);

        //    undefined uniform1f(WebGLUniformLocation? location, GLfloat x);
        //    undefined uniform2f(WebGLUniformLocation? location, GLfloat x, GLfloat y);
        //    undefined uniform3f(WebGLUniformLocation? location, GLfloat x, GLfloat y, GLfloat z);
        //    undefined uniform4f(WebGLUniformLocation? location, GLfloat x, GLfloat y, GLfloat z, GLfloat w);

        //    undefined uniform1i(WebGLUniformLocation? location, GLint x);
        //    undefined uniform2i(WebGLUniformLocation? location, GLint x, GLint y);
        //    undefined uniform3i(WebGLUniformLocation? location, GLint x, GLint y, GLint z);
        //    undefined uniform4i(WebGLUniformLocation? location, GLint x, GLint y, GLint z, GLint w);

        //    undefined useProgram(WebGLProgram? program);
        //    undefined validateProgram(WebGLProgram program);

        //    undefined vertexAttrib1f(GLuint index, GLfloat x);
        //    undefined vertexAttrib2f(GLuint index, GLfloat x, GLfloat y);
        //    undefined vertexAttrib3f(GLuint index, GLfloat x, GLfloat y, GLfloat z);
        //    undefined vertexAttrib4f(GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);

        //    undefined vertexAttrib1fv(GLuint index, Float32List values);
        //    undefined vertexAttrib2fv(GLuint index, Float32List values);
        //    undefined vertexAttrib3fv(GLuint index, Float32List values);
        //    undefined vertexAttrib4fv(GLuint index, Float32List values);

        //    undefined vertexAttribPointer(GLuint index, GLint size, GLenum type,
        //                                  GLboolean normalized, GLsizei stride, GLintptr offset);

        //    undefined viewport(GLint x, GLint y, GLsizei width, GLsizei height);
        //};

        //interface mixin WebGLRenderingContextOverloads
        //{
        //    undefined bufferData(GLenum target, GLsizeiptr size, GLenum usage);
        //    undefined bufferData(GLenum target, [AllowShared] BufferSource? data, GLenum usage);
        //    undefined bufferSubData(GLenum target, GLintptr offset, [AllowShared] BufferSource data);

        //    undefined compressedTexImage2D(GLenum target, GLint level, GLenum internalformat,
        //                                   GLsizei width, GLsizei height, GLint border,
        //                                   [AllowShared] ArrayBufferView data);
        //    undefined compressedTexSubImage2D(GLenum target, GLint level,
        //                                      GLint xoffset, GLint yoffset,
        //                                      GLsizei width, GLsizei height, GLenum format,
        //                                      [AllowShared] ArrayBufferView data);

        //    undefined readPixels(GLint x, GLint y, GLsizei width, GLsizei height,
        //                         GLenum format, GLenum type, [AllowShared] ArrayBufferView? pixels);

        //    undefined texImage2D(GLenum target, GLint level, GLint internalformat,
        //                         GLsizei width, GLsizei height, GLint border, GLenum format,
        //                         GLenum type, [AllowShared] ArrayBufferView? pixels);
        //    undefined texImage2D(GLenum target, GLint level, GLint internalformat,
        //                         GLenum format, GLenum type, TexImageSource source); // May throw DOMException

        //    undefined texSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset,
        //                            GLsizei width, GLsizei height,
        //                            GLenum format, GLenum type, [AllowShared] ArrayBufferView? pixels);
        //    undefined texSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset,
        //                            GLenum format, GLenum type, TexImageSource source); // May throw DOMException

        //    undefined uniform1fv(WebGLUniformLocation? location, Float32List v);
        //    undefined uniform2fv(WebGLUniformLocation? location, Float32List v);
        //    undefined uniform3fv(WebGLUniformLocation? location, Float32List v);
        //    undefined uniform4fv(WebGLUniformLocation? location, Float32List v);

        //    undefined uniform1iv(WebGLUniformLocation? location, Int32List v);
        //    undefined uniform2iv(WebGLUniformLocation? location, Int32List v);
        //    undefined uniform3iv(WebGLUniformLocation? location, Int32List v);
        //    undefined uniform4iv(WebGLUniformLocation? location, Int32List v);

        //    undefined uniformMatrix2fv(WebGLUniformLocation? location, GLboolean transpose, Float32List value);
        //    undefined uniformMatrix3fv(WebGLUniformLocation? location, GLboolean transpose, Float32List value);
        //    undefined uniformMatrix4fv(WebGLUniformLocation? location, GLboolean transpose, Float32List value);
        //}
    }
}
