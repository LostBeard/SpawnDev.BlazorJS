namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGL2RenderingContext interface provides the OpenGL ES 3.0 rendering context for the drawing surface of an HTML canvas element.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGL_API/Constants#additional_constants_defined_webgl_2
    /// </summary>
    public partial class WebGL2RenderingContext
    {
        // Constants passed to WebGLRenderingContext.getParameter() to specify what information to return.
        public readonly GLenum READ_BUFFER = 0x0C02;
        public readonly GLenum UNPACK_ROW_LENGTH = 0x0CF2;
        public readonly GLenum UNPACK_SKIP_ROWS = 0x0CF3;
        public readonly GLenum UNPACK_SKIP_PIXELS = 0x0CF4;
        public readonly GLenum PACK_ROW_LENGTH = 0x0D02;
        public readonly GLenum PACK_SKIP_ROWS = 0x0D03;
        public readonly GLenum PACK_SKIP_PIXELS = 0x0D04;
        public readonly GLenum TEXTURE_BINDING_3D = 0x806A;
        public readonly GLenum UNPACK_SKIP_IMAGES = 0x806D;
        public readonly GLenum UNPACK_IMAGE_HEIGHT = 0x806E;
        public readonly GLenum MAX_3D_TEXTURE_SIZE = 0x8073;
        public readonly GLenum MAX_ELEMENTS_VERTICES = 0x80E8;
        public readonly GLenum MAX_ELEMENTS_INDICES = 0x80E9;
        public readonly GLenum MAX_TEXTURE_LOD_BIAS = 0x84FD;
        public readonly GLenum MAX_FRAGMENT_UNIFORM_COMPONENTS = 0x8B49;
        public readonly GLenum MAX_VERTEX_UNIFORM_COMPONENTS = 0x8B4A;
        public readonly GLenum MAX_ARRAY_TEXTURE_LAYERS = 0x88FF;
        public readonly GLenum MIN_PROGRAM_TEXEL_OFFSET = 0x8904;
        public readonly GLenum MAX_PROGRAM_TEXEL_OFFSET = 0x8905;
        public readonly GLenum MAX_VARYING_COMPONENTS = 0x8B4B;
        public readonly GLenum FRAGMENT_SHADER_DERIVATIVE_HINT = 0x8B8B;
        public readonly GLenum RASTERIZER_DISCARD = 0x8C89;
        public readonly GLenum VERTEX_ARRAY_BINDING = 0x85B5;
        public readonly GLenum MAX_VERTEX_OUTPUT_COMPONENTS = 0x9122;
        public readonly GLenum MAX_FRAGMENT_INPUT_COMPONENTS = 0x9125;
        public readonly GLenum MAX_SERVER_WAIT_TIMEOUT = 0x9111;
        public readonly GLenum MAX_ELEMENT_INDEX = 0x8D6B;

        // Textures
        public readonly GLenum RED = 0x1903;
        public readonly GLenum RGB8 = 0x8051;
        public readonly GLenum RGBA8 = 0x8058;
        public readonly GLenum RGB10_A2 = 0x8059;
        public readonly GLenum TEXTURE_3D = 0x806F;
        public readonly GLenum TEXTURE_WRAP_R = 0x8072;
        public readonly GLenum TEXTURE_MIN_LOD = 0x813A;
        public readonly GLenum TEXTURE_MAX_LOD = 0x813B;
        public readonly GLenum TEXTURE_BASE_LEVEL = 0x813C;
        public readonly GLenum TEXTURE_MAX_LEVEL = 0x813D;
        public readonly GLenum TEXTURE_COMPARE_MODE = 0x884C;
        public readonly GLenum TEXTURE_COMPARE_FUNC = 0x884D;
        public readonly GLenum SRGB = 0x8C40;
        public readonly GLenum SRGB8 = 0x8C41;
        public readonly GLenum SRGB8_ALPHA8 = 0x8C43;
        public readonly GLenum COMPARE_REF_TO_TEXTURE = 0x884E;
        public readonly GLenum RGBA32F = 0x8814;
        public readonly GLenum RGB32F = 0x8815;
        public readonly GLenum RGBA16F = 0x881A;
        public readonly GLenum RGB16F = 0x881B;
        public readonly GLenum TEXTURE_2D_ARRAY = 0x8C1A;
        public readonly GLenum TEXTURE_BINDING_2D_ARRAY = 0x8C1D;
        public readonly GLenum R11F_G11F_B10F = 0x8C3A;
        public readonly GLenum RGB9_E5 = 0x8C3D;
        public readonly GLenum RGBA32UI = 0x8D70;
        public readonly GLenum RGB32UI = 0x8D71;
        public readonly GLenum RGBA16UI = 0x8D76;
        public readonly GLenum RGB16UI = 0x8D77;
        public readonly GLenum RGBA8UI = 0x8D7C;
        public readonly GLenum RGB8UI = 0x8D7D;
        public readonly GLenum RGBA32I = 0x8D82;
        public readonly GLenum RGB32I = 0x8D83;
        public readonly GLenum RGBA16I = 0x8D88;
        public readonly GLenum RGB16I = 0x8D89;
        public readonly GLenum RGBA8I = 0x8D8E;
        public readonly GLenum RGB8I = 0x8D8F;
        public readonly GLenum RED_INTEGER = 0x8D94;
        public readonly GLenum RGB_INTEGER = 0x8D98;
        public readonly GLenum RGBA_INTEGER = 0x8D99;
        public readonly GLenum R8 = 0x8229;
        public readonly GLenum RG8 = 0x822B;
        public readonly GLenum R16F = 0x822D;
        public readonly GLenum R32F = 0x822E;
        public readonly GLenum RG16F = 0x822F;
        public readonly GLenum RG32F = 0x8230;
        public readonly GLenum R8I = 0x8231;
        public readonly GLenum R8UI = 0x8232;
        public readonly GLenum R16I = 0x8233;
        public readonly GLenum R16UI = 0x8234;
        public readonly GLenum R32I = 0x8235;
        public readonly GLenum R32UI = 0x8236;
        public readonly GLenum RG8I = 0x8237;
        public readonly GLenum RG8UI = 0x8238;
        public readonly GLenum RG16I = 0x8239;
        public readonly GLenum RG16UI = 0x823A;
        public readonly GLenum RG32I = 0x823B;
        public readonly GLenum RG32UI = 0x823C;
        public readonly GLenum R8_SNORM = 0x8F94;
        public readonly GLenum RG8_SNORM = 0x8F95;
        public readonly GLenum RGB8_SNORM = 0x8F96;
        public readonly GLenum RGBA8_SNORM = 0x8F97;
        public readonly GLenum RGB10_A2UI = 0x906F;
        public readonly GLenum TEXTURE_IMMUTABLE_FORMAT = 0x912F;
        public readonly GLenum TEXTURE_IMMUTABLE_LEVELS = 0x82DF;

        // Pixel types
        public readonly GLenum UNSIGNED_INT_2_10_10_10_REV = 0x8368;
        public readonly GLenum UNSIGNED_INT_10F_11F_11F_REV = 0x8C3B;
        public readonly GLenum UNSIGNED_INT_5_9_9_9_REV = 0x8C3E;
        public readonly GLenum FLOAT_32_UNSIGNED_INT_24_8_REV = 0x8DAD;
        public readonly GLenum UNSIGNED_INT_24_8 = 0x84FA;
        public readonly GLenum HALF_FLOAT = 0x140B;
        public readonly GLenum RG = 0x8227;
        public readonly GLenum RG_INTEGER = 0x8228;
        public readonly GLenum INT_2_10_10_10_REV = 0x8D9F;

        // Queries
        public readonly GLenum CURRENT_QUERY = 0x8865;
        public readonly GLenum QUERY_RESULT = 0x8866;
        public readonly GLenum QUERY_RESULT_AVAILABLE = 0x8867;
        public readonly GLenum ANY_SAMPLES_PASSED = 0x8C2F;
        public readonly GLenum ANY_SAMPLES_PASSED_CONSERVATIVE = 0x8D6A;

        // Draw buffers
        public readonly GLenum MAX_DRAW_BUFFERS = 0x8824;
        public readonly GLenum DRAW_BUFFER0 = 0x8825;
        public readonly GLenum DRAW_BUFFER1 = 0x8826;
        public readonly GLenum DRAW_BUFFER2 = 0x8827;
        public readonly GLenum DRAW_BUFFER3 = 0x8828;
        public readonly GLenum DRAW_BUFFER4 = 0x8829;
        public readonly GLenum DRAW_BUFFER5 = 0x882A;
        public readonly GLenum DRAW_BUFFER6 = 0x882B;
        public readonly GLenum DRAW_BUFFER7 = 0x882C;
        public readonly GLenum DRAW_BUFFER8 = 0x882D;
        public readonly GLenum DRAW_BUFFER9 = 0x882E;
        public readonly GLenum DRAW_BUFFER10 = 0x882F;
        public readonly GLenum DRAW_BUFFER11 = 0x8830;
        public readonly GLenum DRAW_BUFFER12 = 0x8831;
        public readonly GLenum DRAW_BUFFER13 = 0x8832;
        public readonly GLenum DRAW_BUFFER14 = 0x8833;
        public readonly GLenum DRAW_BUFFER15 = 0x8834;
        public readonly GLenum MAX_COLOR_ATTACHMENTS = 0x8CDF;
        public readonly GLenum COLOR_ATTACHMENT1 = 0x8CE1;
        public readonly GLenum COLOR_ATTACHMENT2 = 0x8CE2;
        public readonly GLenum COLOR_ATTACHMENT3 = 0x8CE3;
        public readonly GLenum COLOR_ATTACHMENT4 = 0x8CE4;
        public readonly GLenum COLOR_ATTACHMENT5 = 0x8CE5;
        public readonly GLenum COLOR_ATTACHMENT6 = 0x8CE6;
        public readonly GLenum COLOR_ATTACHMENT7 = 0x8CE7;
        public readonly GLenum COLOR_ATTACHMENT8 = 0x8CE8;
        public readonly GLenum COLOR_ATTACHMENT9 = 0x8CE9;
        public readonly GLenum COLOR_ATTACHMENT10 = 0x8CEA;
        public readonly GLenum COLOR_ATTACHMENT11 = 0x8CEB;
        public readonly GLenum COLOR_ATTACHMENT12 = 0x8CEC;
        public readonly GLenum COLOR_ATTACHMENT13 = 0x8CED;
        public readonly GLenum COLOR_ATTACHMENT14 = 0x8CEE;
        public readonly GLenum COLOR_ATTACHMENT15 = 0x8CEF;

        //  Samplers
        public readonly GLenum SAMPLER_3D = 0x8B5F;
        public readonly GLenum SAMPLER_2D_SHADOW = 0x8B62;
        public readonly GLenum SAMPLER_2D_ARRAY = 0x8DC1;
        public readonly GLenum SAMPLER_2D_ARRAY_SHADOW = 0x8DC4;
        public readonly GLenum SAMPLER_CUBE_SHADOW = 0x8DC5;
        public readonly GLenum INT_SAMPLER_2D = 0x8DCA;
        public readonly GLenum INT_SAMPLER_3D = 0x8DCB;
        public readonly GLenum INT_SAMPLER_CUBE = 0x8DCC;
        public readonly GLenum INT_SAMPLER_2D_ARRAY = 0x8DCF;
        public readonly GLenum UNSIGNED_INT_SAMPLER_2D = 0x8DD2;
        public readonly GLenum UNSIGNED_INT_SAMPLER_3D = 0x8DD3;
        public readonly GLenum UNSIGNED_INT_SAMPLER_CUBE = 0x8DD4;
        public readonly GLenum UNSIGNED_INT_SAMPLER_2D_ARRAY = 0x8DD7;
        public readonly GLenum MAX_SAMPLES = 0x8D57;
        public readonly GLenum SAMPLER_BINDING = 0x8919;

        // Buffers
        public readonly GLenum PIXEL_PACK_BUFFER = 0x88EB;
        public readonly GLenum PIXEL_UNPACK_BUFFER = 0x88EC;
        public readonly GLenum PIXEL_PACK_BUFFER_BINDING = 0x88ED;
        public readonly GLenum PIXEL_UNPACK_BUFFER_BINDING = 0x88EF;
        public readonly GLenum COPY_READ_BUFFER = 0x8F36;
        public readonly GLenum COPY_WRITE_BUFFER = 0x8F37;
        public readonly GLenum COPY_READ_BUFFER_BINDING = 0x8F36;
        public readonly GLenum COPY_WRITE_BUFFER_BINDING = 0x8F37;

        // Data types
        public readonly GLenum FLOAT_MAT2x3 = 0x8B65;
        public readonly GLenum FLOAT_MAT2x4 = 0x8B66;
        public readonly GLenum FLOAT_MAT3x2 = 0x8B67;
        public readonly GLenum FLOAT_MAT3x4 = 0x8B68;
        public readonly GLenum FLOAT_MAT4x2 = 0x8B69;
        public readonly GLenum FLOAT_MAT4x3 = 0x8B6A;
        public readonly GLenum UNSIGNED_INT_VEC2 = 0x8DC6;
        public readonly GLenum UNSIGNED_INT_VEC3 = 0x8DC7;
        public readonly GLenum UNSIGNED_INT_VEC4 = 0x8DC8;
        public readonly GLenum UNSIGNED_NORMALIZED = 0x8C17;
        public readonly GLenum SIGNED_NORMALIZED = 0x8F9C;

        // Vertex attributes
        public readonly GLenum VERTEX_ATTRIB_ARRAY_INTEGER = 0x88FD;
        public readonly GLenum VERTEX_ATTRIB_ARRAY_DIVISOR = 0x88FE;

        // Transform feedback
        public readonly GLenum TRANSFORM_FEEDBACK_BUFFER_MODE = 0x8C7F;
        public readonly GLenum MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = 0x8C80;
        public readonly GLenum TRANSFORM_FEEDBACK_VARYINGS = 0x8C83;
        public readonly GLenum TRANSFORM_FEEDBACK_BUFFER_START = 0x8C84;
        public readonly GLenum TRANSFORM_FEEDBACK_BUFFER_SIZE = 0x8C85;
        public readonly GLenum TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN = 0x8C88;
        public readonly GLenum MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = 0x8C8A;
        public readonly GLenum MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = 0x8C8B;
        public readonly GLenum INTERLEAVED_ATTRIBS = 0x8C8C;
        public readonly GLenum SEPARATE_ATTRIBS = 0x8C8D;
        public readonly GLenum TRANSFORM_FEEDBACK_BUFFER = 0x8C8E;
        public readonly GLenum TRANSFORM_FEEDBACK_BUFFER_BINDING = 0x8C8F;
        public readonly GLenum TRANSFORM_FEEDBACK = 0x8E22;
        public readonly GLenum TRANSFORM_FEEDBACK_PAUSED = 0x8E23;
        public readonly GLenum TRANSFORM_FEEDBACK_ACTIVE = 0x8E24;
        public readonly GLenum TRANSFORM_FEEDBACK_BINDING = 0x8E25;

        // Framebuffers and renderbuffers
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING = 0x8210;
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE = 0x8211;
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_RED_SIZE = 0x8212;
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_GREEN_SIZE = 0x8213;
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_BLUE_SIZE = 0x8214;
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE = 0x8215;
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE = 0x8216;
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE = 0x8217;
        public readonly GLenum FRAMEBUFFER_DEFAULT = 0x8218;
        public readonly GLenum DEPTH_STENCIL_ATTACHMENT = 0x821A;
        public readonly GLenum DEPTH_STENCIL = 0x84F9;
        public readonly GLenum DEPTH24_STENCIL8 = 0x88F0;
        public readonly GLenum DRAW_FRAMEBUFFER_BINDING = 0x8CA6;
        public readonly GLenum READ_FRAMEBUFFER = 0x8CA8;
        public readonly GLenum DRAW_FRAMEBUFFER = 0x8CA9;
        public readonly GLenum READ_FRAMEBUFFER_BINDING = 0x8CAA;
        public readonly GLenum RENDERBUFFER_SAMPLES = 0x8CAB;
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = 0x8CD4;
        public readonly GLenum FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = 0x8D56;

        // Uniforms
        public readonly GLenum UNIFORM_BUFFER = 0x8A11;
        public readonly GLenum UNIFORM_BUFFER_BINDING = 0x8A28;
        public readonly GLenum UNIFORM_BUFFER_START = 0x8A29;
        public readonly GLenum UNIFORM_BUFFER_SIZE = 0x8A2A;
        public readonly GLenum MAX_VERTEX_UNIFORM_BLOCKS = 0x8A2B;
        public readonly GLenum MAX_FRAGMENT_UNIFORM_BLOCKS = 0x8A2D;
        public readonly GLenum MAX_COMBINED_UNIFORM_BLOCKS = 0x8A2E;
        public readonly GLenum MAX_UNIFORM_BUFFER_BINDINGS = 0x8A2F;
        public readonly GLenum MAX_UNIFORM_BLOCK_SIZE = 0x8A30;
        public readonly GLenum MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = 0x8A31;
        public readonly GLenum MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = 0x8A33;
        public readonly GLenum UNIFORM_BUFFER_OFFSET_ALIGNMENT = 0x8A34;
        public readonly GLenum ACTIVE_UNIFORM_BLOCKS = 0x8A36;
        public readonly GLenum UNIFORM_TYPE = 0x8A37;
        public readonly GLenum UNIFORM_SIZE = 0x8A38;
        public readonly GLenum UNIFORM_BLOCK_INDEX = 0x8A3A;
        public readonly GLenum UNIFORM_OFFSET = 0x8A3B;
        public readonly GLenum UNIFORM_ARRAY_STRIDE = 0x8A3C;
        public readonly GLenum UNIFORM_MATRIX_STRIDE = 0x8A3D;
        public readonly GLenum UNIFORM_IS_ROW_MAJOR = 0x8A3E;
        public readonly GLenum UNIFORM_BLOCK_BINDING = 0x8A3F;
        public readonly GLenum UNIFORM_BLOCK_DATA_SIZE = 0x8A40;
        public readonly GLenum UNIFORM_BLOCK_ACTIVE_UNIFORMS = 0x8A42;
        public readonly GLenum UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES = 0x8A43;
        public readonly GLenum UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER = 0x8A44;
        public readonly GLenum UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = 0x8A46;

        // Sync objects
        public readonly GLenum OBJECT_TYPE = 0x9112;
        public readonly GLenum SYNC_CONDITION = 0x9113;
        public readonly GLenum SYNC_STATUS = 0x9114;
        public readonly GLenum SYNC_FLAGS = 0x9115;
        public readonly GLenum SYNC_FENCE = 0x9116;
        public readonly GLenum SYNC_GPU_COMMANDS_COMPLETE = 0x9117;
        public readonly GLenum UNSIGNALED = 0x9118;
        public readonly GLenum SIGNALED = 0x9119;
        public readonly GLenum ALREADY_SIGNALED = 0x911A;
        public readonly GLenum TIMEOUT_EXPIRED = 0x911B;
        public readonly GLenum CONDITION_SATISFIED = 0x911C;
        public readonly GLenum WAIT_FAILED = 0x911D;
        public readonly GLenum SYNC_FLUSH_COMMANDS_BIT = 0x00000001;

        // Miscellaneous constants
        public readonly GLenum COLOR = 0x1800;
        public readonly GLenum DEPTH = 0x1801;
        public readonly GLenum STENCIL = 0x1802;
        public readonly GLenum MIN = 0x8007;
        public readonly GLenum MAX = 0x8008;
        public readonly GLenum DEPTH_COMPONENT24 = 0x81A6;
        public readonly GLenum STREAM_READ = 0x88E1;
        public readonly GLenum STREAM_COPY = 0x88E2;
        public readonly GLenum STATIC_READ = 0x88E5;
        public readonly GLenum STATIC_COPY = 0x88E6;
        public readonly GLenum DYNAMIC_READ = 0x88E9;
        public readonly GLenum DYNAMIC_COPY = 0x88EA;
        public readonly GLenum DEPTH_COMPONENT32F = 0x8CAC;
        public readonly GLenum DEPTH32F_STENCIL8 = 0x8CAD;
        public readonly GLenum MAX_CLIENT_WAIT_TIMEOUT_WEBGL = 0x9247;

        public readonly GLuint INVALID_INDEX = 0xFFFFFFFF;
        public readonly GLint TIMEOUT_IGNORED = -1;

        // Constants defined in WebGL extensions

        // Constants defined in WebGL extensions
        /// <summary>
        /// Describes the frequency divisor used for instanced rendering.
        /// </summary>
        public readonly GLenum VERTEX_ATTRIB_ARRAY_DIVISOR_ANGLE = 0x88FE;

        // WEBGL_debug_renderer_info
        /// <summary>
        /// Passed to getParameter to get the vendor string of the graphics driver.
        /// </summary>
        public readonly GLenum UNMASKED_VENDOR_WEBGL = 0x9245;
        /// <summary>
        /// Passed to getParameter to get the renderer string of the graphics driver.
        /// </summary>
        public readonly GLenum UNMASKED_RENDERER_WEBGL = 0x9246;

        // EXT_texture_filter_anisotropic
        /// <summary>
        /// Returns the maximum available anisotropy.
        /// </summary>
        public readonly GLenum MAX_TEXTURE_MAX_ANISOTROPY_EXT = 0x84FF;
        /// <summary>
        /// Passed to texParameter to set the desired maximum anisotropy for a texture.
        /// </summary>
        public readonly GLenum TEXTURE_MAX_ANISOTROPY_EXT = 0x84FE;

        // WEBGL_compressed_texture_s3tc
        /// <summary>
        /// A DXT1-compressed image in an RGB image format.
        /// </summary>
        public readonly GLenum COMPRESSED_RGB_S3TC_DXT1_EXT = 0x83F0;
        /// <summary>
        /// A DXT1-compressed image in an RGB image format with an on/off alpha value.
        /// </summary>
        public readonly GLenum COMPRESSED_RGBA_S3TC_DXT1_EXT = 0x83F1;
        /// <summary>
        /// A DXT3-compressed image in an RGBA image format. Compared to a 32-bit RGBA texture, it offers 4:1 compression.
        /// </summary>
        public readonly GLenum COMPRESSED_RGBA_S3TC_DXT3_EXT = 0x83F2;
        /// <summary>
        /// A DXT5-compressed image in an RGBA image format. It also provides a 4:1 compression, but differs to the DXT3 compression in how the alpha compression is done.
        /// </summary>
        public readonly GLenum COMPRESSED_RGBA_S3TC_DXT5_EXT = 0x83F3;

        // WEBGL_compressed_texture_etc
        /// <summary>
        /// One-channel (red) unsigned format compression.
        /// </summary>
        public readonly GLenum COMPRESSED_R11_EAC = 0x9270;
        /// <summary>
        /// One-channel (red) signed format compression.
        /// </summary>
        public readonly GLenum COMPRESSED_SIGNED_R11_EAC = 0x9271;
        /// <summary>
        /// Two-channel (red and green) unsigned format compression.
        /// </summary>
        public readonly GLenum COMPRESSED_RG11_EAC = 0x9272;
        /// <summary>
        /// Two-channel (red and green) signed format compression.
        /// </summary>
        public readonly GLenum COMPRESSED_SIGNED_RG11_EAC = 0x9273;
        /// <summary>
        /// Compresses RGB8 data with no alpha channel.
        /// </summary>
        public readonly GLenum COMPRESSED_RGB8_ETC2 = 0x9274;
        /// <summary>
        /// Compresses RGBA8 data. The RGB part is encoded the same as RGB_ETC2, but the alpha part is encoded separately.
        /// </summary>
        public readonly GLenum COMPRESSED_RGBA8_ETC2_EAC = 0x9275;
        /// <summary>
        /// Compresses sRGB8 data with no alpha channel.
        /// </summary>
        public readonly GLenum COMPRESSED_SRGB8_ETC2 = 0x9276;
        /// <summary>
        /// Compresses sRGBA8 data. The sRGB part is encoded the same as SRGB_ETC2, but the alpha part is encoded separately.
        /// </summary>
        public readonly GLenum COMPRESSED_SRGB8_ALPHA8_ETC2_EAC = 0x9277;
        /// <summary>
        /// Similar to RGB8_ETC, but with ability to punch through the alpha channel, which means to make it completely opaque or transparent.
        /// </summary>
        public readonly GLenum COMPRESSED_RGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 0x9278;
        /// <summary>
        /// Similar to SRGB8_ETC, but with ability to punch through the alpha channel, which means to make it completely opaque or transparent.
        /// </summary>
        public readonly GLenum COMPRESSED_SRGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 0x9279;

        // WEBGL_compressed_texture_pvrtc
        /// <summary>
        /// RGB compression in 4-bit mode. One block for each 4×4 pixels.
        /// </summary>
        public readonly GLenum COMPRESSED_RGB_PVRTC_4BPPV1_IMG = 0x8C00;
        /// <summary>
        /// RGBA compression in 4-bit mode. One block for each 4×4 pixels.
        /// </summary>
        public readonly GLenum COMPRESSED_RGBA_PVRTC_4BPPV1_IMG = 0x8C02;
        /// <summary>
        /// RGB compression in 2-bit mode. One block for each 8×4 pixels.
        /// </summary>
        public readonly GLenum COMPRESSED_RGB_PVRTC_2BPPV1_IMG = 0x8C01;
        /// <summary>
        /// RGBA compression in 2-bit mode. One block for each 8×4 pixels.
        /// </summary>
        public readonly GLenum COMPRESSED_RGBA_PVRTC_2BPPV1_IMG = 0x8C03;

        // WEBGL_compressed_texture_etc1
        /// <summary>
        /// Compresses 24-bit RGB data with no alpha channel.
        /// </summary>
        public readonly GLenum COMPRESSED_RGB_ETC1_WEBGL = 0x8D64;

        // WEBGL_depth_texture
        /// <summary>
        /// Unsigned integer type for 24-bit depth texture data.
        /// </summary>
        public readonly GLenum UNSIGNED_INT_24_8_WEBGL = 0x84FA;

        // OES_texture_half_float
        /// <summary>
        /// Half floating-point type (16-bit).
        /// </summary>
        public readonly GLenum HALF_FLOAT_OES = 0x8D61;

        // WEBGL_color_buffer_float
        /// <summary>
        /// RGBA 32-bit floating-point color-renderable format.
        /// </summary>
        public readonly GLenum RGBA32F_EXT = 0x8814;
        /// <summary>
        /// RGB 32-bit floating-point color-renderable format.
        /// </summary>
        public readonly GLenum RGB32F_EXT = 0x8815;
        /// <summary>
        /// UNSIGNED_NORMALIZED_EXT	0x8C17	
        /// </summary>
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE_EXT = 0x8211;

        // EXT_blend_minmax
        /// <summary>
        /// Produces the minimum color components of the source and destination colors.
        /// </summary>
        public readonly GLenum MIN_EXT = 0x8007;
        /// <summary>
        /// Produces the maximum color components of the source and destination colors.
        /// </summary>
        public readonly GLenum MAX_EXT = 0x8008;

        // EXT_sRGB
        /// <summary>
        /// Unsized sRGB format that leaves the precision up to the driver.
        /// </summary>
        public readonly GLenum SRGB_EXT = 0x8C40;
        /// <summary>
        /// Unsized sRGB format with unsized alpha component.
        /// </summary>
        public readonly GLenum SRGB_ALPHA_EXT = 0x8C42;
        /// <summary>
        /// Sized (8-bit) sRGB and alpha formats.
        /// </summary>
        public readonly GLenum SRGB8_ALPHA8_EXT = 0x8C43;
        /// <summary>
        /// Returns the framebuffer color encoding.
        /// </summary>
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING_EXT = 0x8210;

        // OES_standard_derivatives
        /// <summary>
        /// Indicates the accuracy of the derivative calculation for the GLSL built-in functions: dFdx, dFdy, and fwidth.
        /// </summary>
        public readonly GLenum FRAGMENT_SHADER_DERIVATIVE_HINT_OES = 0x8B8B;

        // WEBGL_draw_buffers
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT0_WEBGL = 0x8CE0;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT1_WEBGL = 0x8CE1;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT2_WEBGL = 0x8CE2;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT3_WEBGL = 0x8CE3;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT4_WEBGL = 0x8CE4;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT5_WEBGL = 0x8CE5;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT6_WEBGL = 0x8CE6;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT7_WEBGL = 0x8CE7;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT8_WEBGL = 0x8CE8;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT9_WEBGL = 0x8CE9;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT10_WEBGL = 0x8CEA;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT11_WEBGL = 0x8CEB;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT12_WEBGL = 0x8CEC;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT13_WEBGL = 0x8CED;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT14_WEBGL = 0x8CEE;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT15_WEBGL = 0x8CEF;
        /// <summary>
        /// Draw buffer
        /// </summary>
        public readonly GLenum DRAW_BUFFER0_WEBGL = 0x8825;
        /// <summary>
        /// Draw buffer
        /// </summary>
        public readonly GLenum DRAW_BUFFER1_WEBGL = 0x8826;
        /// <summary>
        /// Draw buffer
        /// </summary>
        public readonly GLenum DRAW_BUFFER2_WEBGL = 0x8827;
        /// <summary>
        /// Draw buffer
        /// </summary>
        public readonly GLenum DRAW_BUFFER3_WEBGL = 0x8828;
        /// <summary>
        /// Draw buffer
        /// </summary>
        public readonly GLenum DRAW_BUFFER4_WEBGL = 0x8829;
        /// <summary>
        /// Draw buffer
        /// </summary>
        public readonly GLenum DRAW_BUFFER5_WEBGL = 0x882A;
        /// <summary>
        /// Draw buffer
        /// </summary>
        public readonly GLenum DRAW_BUFFER6_WEBGL = 0x882B;
        /// <summary>
        /// Draw buffer
        /// </summary>
        public readonly GLenum DRAW_BUFFER7_WEBGL = 0x882C;
        /// <summary>
        /// Draw buffer
        /// </summary>
        public readonly GLenum DRAW_BUFFER8_WEBGL = 0x882D;
        /// <summary>
        /// Draw buffer
        /// </summary>
        public readonly GLenum DRAW_BUFFER9_WEBGL = 0x882E;
        /// <summary>
        /// Draw buffer
        /// </summary>
        public readonly GLenum DRAW_BUFFER10_WEBGL = 0x882F;
        /// <summary>
        /// Draw buffer
        /// </summary>
        public readonly GLenum DRAW_BUFFER11_WEBGL = 0x8830;
        /// <summary>
        /// Draw buffer
        /// </summary>
        public readonly GLenum DRAW_BUFFER12_WEBGL = 0x8831;
        /// <summary>
        /// Draw buffer
        /// </summary>
        public readonly GLenum DRAW_BUFFER13_WEBGL = 0x8832;
        /// <summary>
        /// Draw buffer
        /// </summary>
        public readonly GLenum DRAW_BUFFER14_WEBGL = 0x8833;
        /// <summary>
        /// Draw buffer
        /// </summary>
        public readonly GLenum DRAW_BUFFER15_WEBGL = 0x8834;
        /// <summary>
        /// Maximum number of framebuffer color attachment points
        /// </summary>
        public readonly GLenum MAX_COLOR_ATTACHMENTS_WEBGL = 0x8CDF;
        /// <summary>
        /// Maximum number of draw buffers
        /// </summary>
        public readonly GLenum MAX_DRAW_BUFFERS_WEBGL = 0x8824;

        // OES_vertex_array_object
        /// <summary>
        /// The bound vertex array object (VAO).
        /// </summary>
        public readonly GLenum VERTEX_ARRAY_BINDING_OES = 0x85B5;

        // EXT_disjoint_timer_query
        /// <summary>
        /// The number of bits used to hold the query result for the given target.
        /// </summary>
        public readonly GLenum QUERY_COUNTER_BITS_EXT = 0x8864;
        /// <summary>
        /// The currently active query.
        /// </summary>
        public readonly GLenum CURRENT_QUERY_EXT = 0x8865;
        /// <summary>
        /// The query result.
        /// </summary>
        public readonly GLenum QUERY_RESULT_EXT = 0x8866;
        /// <summary>
        /// A Boolean indicating whether or not a query result is available.
        /// </summary>
        public readonly GLenum QUERY_RESULT_AVAILABLE_EXT = 0x8867;
        /// <summary>
        /// Elapsed time (in nanoseconds).
        /// </summary>
        public readonly GLenum TIME_ELAPSED_EXT = 0x88BF;
        /// <summary>
        /// The current time.
        /// </summary>
        public readonly GLenum TIMESTAMP_EXT = 0x8E28;
        /// <summary>
        /// A Boolean indicating whether or not the GPU performed any disjoint operation.
        /// </summary>
        public readonly GLenum GPU_DISJOINT_EXT = 0x8FBB;
    }
}
