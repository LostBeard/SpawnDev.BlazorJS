namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// WebGL and WebGL2 specification constants (GLenum values).
    /// All values are typed as uint to match the GLenum specification type.
    /// <see href="https://developer.mozilla.org/en-US/docs/Web/API/WebGL_API/Constants"/>
    /// </summary>
    public static class GL
    {
        #region Clearing buffers
        public const uint DEPTH_BUFFER_BIT = 0x00000100;
        public const uint STENCIL_BUFFER_BIT = 0x00000400;
        public const uint COLOR_BUFFER_BIT = 0x00004000;
        #endregion

        #region Rendering primitives
        public const uint POINTS = 0x0000;
        public const uint LINES = 0x0001;
        public const uint LINE_LOOP = 0x0002;
        public const uint LINE_STRIP = 0x0003;
        public const uint TRIANGLES = 0x0004;
        public const uint TRIANGLE_STRIP = 0x0005;
        public const uint TRIANGLE_FAN = 0x0006;
        #endregion

        #region Blending modes
        public const uint ZERO = 0;
        public const uint ONE = 1;
        public const uint SRC_COLOR = 0x0300;
        public const uint ONE_MINUS_SRC_COLOR = 0x0301;
        public const uint SRC_ALPHA = 0x0302;
        public const uint ONE_MINUS_SRC_ALPHA = 0x0303;
        public const uint DST_ALPHA = 0x0304;
        public const uint ONE_MINUS_DST_ALPHA = 0x0305;
        public const uint DST_COLOR = 0x0306;
        public const uint ONE_MINUS_DST_COLOR = 0x0307;
        public const uint SRC_ALPHA_SATURATE = 0x0308;
        public const uint CONSTANT_COLOR = 0x8001;
        public const uint ONE_MINUS_CONSTANT_COLOR = 0x8002;
        public const uint CONSTANT_ALPHA = 0x8003;
        public const uint ONE_MINUS_CONSTANT_ALPHA = 0x8004;
        #endregion

        #region Blending equations
        public const uint FUNC_ADD = 0x8006;
        public const uint FUNC_SUBTRACT = 0x800A;
        public const uint FUNC_REVERSE_SUBTRACT = 0x800B;
        public const uint BLEND_EQUATION = 0x8009;
        public const uint BLEND_EQUATION_RGB = 0x8009;
        public const uint BLEND_EQUATION_ALPHA = 0x883D;
        public const uint BLEND_DST_RGB = 0x80C8;
        public const uint BLEND_SRC_RGB = 0x80C9;
        public const uint BLEND_DST_ALPHA = 0x80CA;
        public const uint BLEND_SRC_ALPHA = 0x80CB;
        public const uint BLEND_COLOR = 0x8005;
        #endregion

        #region Buffers
        public const uint ARRAY_BUFFER = 0x8892;
        public const uint ELEMENT_ARRAY_BUFFER = 0x8893;
        public const uint ARRAY_BUFFER_BINDING = 0x8894;
        public const uint ELEMENT_ARRAY_BUFFER_BINDING = 0x8895;
        public const uint STREAM_DRAW = 0x88E0;
        public const uint STATIC_DRAW = 0x88E4;
        public const uint DYNAMIC_DRAW = 0x88E8;
        public const uint BUFFER_SIZE = 0x8764;
        public const uint BUFFER_USAGE = 0x8765;
        #endregion

        #region Vertex attributes
        public const uint CURRENT_VERTEX_ATTRIB = 0x8626;
        public const uint VERTEX_ATTRIB_ARRAY_ENABLED = 0x8622;
        public const uint VERTEX_ATTRIB_ARRAY_SIZE = 0x8623;
        public const uint VERTEX_ATTRIB_ARRAY_STRIDE = 0x8624;
        public const uint VERTEX_ATTRIB_ARRAY_TYPE = 0x8625;
        public const uint VERTEX_ATTRIB_ARRAY_NORMALIZED = 0x886A;
        public const uint VERTEX_ATTRIB_ARRAY_POINTER = 0x8645;
        public const uint VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 0x889F;
        #endregion

        #region Culling
        public const uint CULL_FACE = 0x0B44;
        public const uint FRONT = 0x0404;
        public const uint BACK = 0x0405;
        public const uint FRONT_AND_BACK = 0x0408;
        #endregion

        #region Enabling and disabling
        public const uint BLEND = 0x0BE2;
        public const uint DEPTH_TEST = 0x0B71;
        public const uint DITHER = 0x0BD0;
        public const uint POLYGON_OFFSET_FILL = 0x8037;
        public const uint SAMPLE_ALPHA_TO_COVERAGE = 0x809E;
        public const uint SAMPLE_COVERAGE = 0x80A0;
        public const uint SCISSOR_TEST = 0x0C11;
        public const uint STENCIL_TEST = 0x0B90;
        #endregion

        #region Errors
        public const uint NO_ERROR = 0;
        public const uint INVALID_ENUM = 0x0500;
        public const uint INVALID_VALUE = 0x0501;
        public const uint INVALID_OPERATION = 0x0502;
        public const uint OUT_OF_MEMORY = 0x0505;
        public const uint CONTEXT_LOST_WEBGL = 0x9242;
        #endregion

        #region Front face directions
        public const uint CW = 0x0900;
        public const uint CCW = 0x0901;
        #endregion

        #region Hints
        public const uint DONT_CARE = 0x1100;
        public const uint FASTEST = 0x1101;
        public const uint NICEST = 0x1102;
        public const uint GENERATE_MIPMAP_HINT = 0x8192;
        #endregion

        #region Data types
        public const uint BYTE = 0x1400;
        public const uint UNSIGNED_BYTE = 0x1401;
        public const uint SHORT = 0x1402;
        public const uint UNSIGNED_SHORT = 0x1403;
        public const uint INT = 0x1404;
        public const uint UNSIGNED_INT = 0x1405;
        public const uint FLOAT = 0x1406;
        #endregion

        #region Pixel formats
        public const uint DEPTH_COMPONENT = 0x1902;
        public const uint ALPHA = 0x1906;
        public const uint RGB = 0x1907;
        public const uint RGBA = 0x1908;
        public const uint LUMINANCE = 0x1909;
        public const uint LUMINANCE_ALPHA = 0x190A;
        #endregion

        #region Pixel types
        public const uint UNSIGNED_SHORT_4_4_4_4 = 0x8033;
        public const uint UNSIGNED_SHORT_5_5_5_1 = 0x8034;
        public const uint UNSIGNED_SHORT_5_6_5 = 0x8363;
        #endregion

        #region Shaders
        public const uint FRAGMENT_SHADER = 0x8B30;
        public const uint VERTEX_SHADER = 0x8B31;
        public const uint COMPILE_STATUS = 0x8B81;
        public const uint DELETE_STATUS = 0x8B80;
        public const uint LINK_STATUS = 0x8B82;
        public const uint VALIDATE_STATUS = 0x8B83;
        public const uint ATTACHED_SHADERS = 0x8B85;
        public const uint ACTIVE_ATTRIBUTES = 0x8B89;
        public const uint ACTIVE_UNIFORMS = 0x8B86;
        public const uint MAX_VERTEX_ATTRIBS = 0x8869;
        public const uint MAX_VERTEX_UNIFORM_VECTORS = 0x8DFB;
        public const uint MAX_VARYING_VECTORS = 0x8DFC;
        public const uint MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D;
        public const uint MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C;
        public const uint MAX_TEXTURE_IMAGE_UNITS = 0x8872;
        public const uint MAX_FRAGMENT_UNIFORM_VECTORS = 0x8DFD;
        public const uint SHADER_TYPE = 0x8B4F;
        public const uint SHADING_LANGUAGE_VERSION = 0x8B8C;
        public const uint CURRENT_PROGRAM = 0x8B8D;
        #endregion

        #region Depth or stencil tests
        public const uint NEVER = 0x0200;
        public const uint LESS = 0x0201;
        public const uint EQUAL = 0x0202;
        public const uint LEQUAL = 0x0203;
        public const uint GREATER = 0x0204;
        public const uint NOTEQUAL = 0x0205;
        public const uint GEQUAL = 0x0206;
        public const uint ALWAYS = 0x0207;
        #endregion

        #region Stencil actions
        public const uint KEEP = 0x1E00;
        public const uint REPLACE = 0x1E01;
        public const uint INCR = 0x1E02;
        public const uint DECR = 0x1E03;
        public const uint INVERT = 0x150A;
        public const uint INCR_WRAP = 0x8507;
        public const uint DECR_WRAP = 0x8508;
        #endregion

        #region Textures
        public const uint NEAREST = 0x2600;
        public const uint LINEAR = 0x2601;
        public const uint NEAREST_MIPMAP_NEAREST = 0x2700;
        public const uint LINEAR_MIPMAP_NEAREST = 0x2701;
        public const uint NEAREST_MIPMAP_LINEAR = 0x2702;
        public const uint LINEAR_MIPMAP_LINEAR = 0x2703;
        public const uint TEXTURE_MAG_FILTER = 0x2800;
        public const uint TEXTURE_MIN_FILTER = 0x2801;
        public const uint TEXTURE_WRAP_S = 0x2802;
        public const uint TEXTURE_WRAP_T = 0x2803;
        public const uint TEXTURE_2D = 0x0DE1;
        public const uint TEXTURE = 0x1702;
        public const uint TEXTURE_CUBE_MAP = 0x8513;
        public const uint TEXTURE_BINDING_CUBE_MAP = 0x8514;
        public const uint TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515;
        public const uint TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516;
        public const uint TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517;
        public const uint TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518;
        public const uint TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519;
        public const uint TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A;
        public const uint MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C;
        public const uint ACTIVE_TEXTURE = 0x84E0;
        public const uint REPEAT = 0x2901;
        public const uint CLAMP_TO_EDGE = 0x812F;
        public const uint MIRRORED_REPEAT = 0x8370;
        #endregion

        #region Texture units
        public const uint TEXTURE0 = 0x84C0;
        public const uint TEXTURE1 = 0x84C1;
        public const uint TEXTURE2 = 0x84C2;
        public const uint TEXTURE3 = 0x84C3;
        public const uint TEXTURE4 = 0x84C4;
        public const uint TEXTURE5 = 0x84C5;
        public const uint TEXTURE6 = 0x84C6;
        public const uint TEXTURE7 = 0x84C7;
        public const uint TEXTURE8 = 0x84C8;
        public const uint TEXTURE9 = 0x84C9;
        public const uint TEXTURE10 = 0x84CA;
        public const uint TEXTURE11 = 0x84CB;
        public const uint TEXTURE12 = 0x84CC;
        public const uint TEXTURE13 = 0x84CD;
        public const uint TEXTURE14 = 0x84CE;
        public const uint TEXTURE15 = 0x84CF;
        public const uint TEXTURE16 = 0x84D0;
        public const uint TEXTURE17 = 0x84D1;
        public const uint TEXTURE18 = 0x84D2;
        public const uint TEXTURE19 = 0x84D3;
        public const uint TEXTURE20 = 0x84D4;
        public const uint TEXTURE21 = 0x84D5;
        public const uint TEXTURE22 = 0x84D6;
        public const uint TEXTURE23 = 0x84D7;
        public const uint TEXTURE24 = 0x84D8;
        public const uint TEXTURE25 = 0x84D9;
        public const uint TEXTURE26 = 0x84DA;
        public const uint TEXTURE27 = 0x84DB;
        public const uint TEXTURE28 = 0x84DC;
        public const uint TEXTURE29 = 0x84DD;
        public const uint TEXTURE30 = 0x84DE;
        public const uint TEXTURE31 = 0x84DF;
        #endregion

        #region Uniform types
        public const uint FLOAT_VEC2 = 0x8B50;
        public const uint FLOAT_VEC3 = 0x8B51;
        public const uint FLOAT_VEC4 = 0x8B52;
        public const uint INT_VEC2 = 0x8B53;
        public const uint INT_VEC3 = 0x8B54;
        public const uint INT_VEC4 = 0x8B55;
        public const uint BOOL = 0x8B56;
        public const uint BOOL_VEC2 = 0x8B57;
        public const uint BOOL_VEC3 = 0x8B58;
        public const uint BOOL_VEC4 = 0x8B59;
        public const uint FLOAT_MAT2 = 0x8B5A;
        public const uint FLOAT_MAT3 = 0x8B5B;
        public const uint FLOAT_MAT4 = 0x8B5C;
        public const uint SAMPLER_2D = 0x8B5E;
        public const uint SAMPLER_CUBE = 0x8B60;
        #endregion

        #region Shader precision-specified types
        public const uint LOW_FLOAT = 0x8DF0;
        public const uint MEDIUM_FLOAT = 0x8DF1;
        public const uint HIGH_FLOAT = 0x8DF2;
        public const uint LOW_INT = 0x8DF3;
        public const uint MEDIUM_INT = 0x8DF4;
        public const uint HIGH_INT = 0x8DF5;
        #endregion

        #region Framebuffers and renderbuffers
        public const uint FRAMEBUFFER = 0x8D40;
        public const uint RENDERBUFFER = 0x8D41;
        public const uint RGBA4 = 0x8056;
        public const uint RGB5_A1 = 0x8057;
        public const uint RGB565 = 0x8D62;
        public const uint DEPTH_COMPONENT16 = 0x81A5;
        public const uint STENCIL_INDEX8 = 0x8D48;
        public const uint DEPTH_STENCIL = 0x84F9;
        public const uint RENDERBUFFER_WIDTH = 0x8D42;
        public const uint RENDERBUFFER_HEIGHT = 0x8D43;
        public const uint RENDERBUFFER_INTERNAL_FORMAT = 0x8D44;
        public const uint RENDERBUFFER_RED_SIZE = 0x8D50;
        public const uint RENDERBUFFER_GREEN_SIZE = 0x8D51;
        public const uint RENDERBUFFER_BLUE_SIZE = 0x8D52;
        public const uint RENDERBUFFER_ALPHA_SIZE = 0x8D53;
        public const uint RENDERBUFFER_DEPTH_SIZE = 0x8D54;
        public const uint RENDERBUFFER_STENCIL_SIZE = 0x8D55;
        public const uint FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = 0x8CD0;
        public const uint FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = 0x8CD1;
        public const uint FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = 0x8CD2;
        public const uint FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = 0x8CD3;
        public const uint COLOR_ATTACHMENT0 = 0x8CE0;
        public const uint DEPTH_ATTACHMENT = 0x8D00;
        public const uint STENCIL_ATTACHMENT = 0x8D20;
        public const uint DEPTH_STENCIL_ATTACHMENT = 0x821A;
        public const uint NONE = 0;
        public const uint FRAMEBUFFER_COMPLETE = 0x8CD5;
        public const uint FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 0x8CD6;
        public const uint FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 0x8CD7;
        public const uint FRAMEBUFFER_INCOMPLETE_DIMENSIONS = 0x8CD9;
        public const uint FRAMEBUFFER_UNSUPPORTED = 0x8CDD;
        public const uint FRAMEBUFFER_BINDING = 0x8CA6;
        public const uint RENDERBUFFER_BINDING = 0x8CA7;
        public const uint MAX_RENDERBUFFER_SIZE = 0x84E8;
        public const uint INVALID_FRAMEBUFFER_OPERATION = 0x0506;
        #endregion

        #region Getting GL parameter information
        public const uint LINE_WIDTH = 0x0B21;
        public const uint ALIASED_POINT_SIZE_RANGE = 0x846D;
        public const uint ALIASED_LINE_WIDTH_RANGE = 0x846E;
        public const uint CULL_FACE_MODE = 0x0B45;
        public const uint FRONT_FACE = 0x0B46;
        public const uint DEPTH_RANGE = 0x0B70;
        public const uint DEPTH_WRITEMASK = 0x0B72;
        public const uint DEPTH_CLEAR_VALUE = 0x0B73;
        public const uint DEPTH_FUNC = 0x0B74;
        public const uint STENCIL_CLEAR_VALUE = 0x0B91;
        public const uint STENCIL_FUNC = 0x0B92;
        public const uint STENCIL_FAIL = 0x0B94;
        public const uint STENCIL_PASS_DEPTH_FAIL = 0x0B95;
        public const uint STENCIL_PASS_DEPTH_PASS = 0x0B96;
        public const uint STENCIL_REF = 0x0B97;
        public const uint STENCIL_VALUE_MASK = 0x0B93;
        public const uint STENCIL_WRITEMASK = 0x0B98;
        public const uint STENCIL_BACK_FUNC = 0x8800;
        public const uint STENCIL_BACK_FAIL = 0x8801;
        public const uint STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802;
        public const uint STENCIL_BACK_PASS_DEPTH_PASS = 0x8803;
        public const uint STENCIL_BACK_REF = 0x8CA3;
        public const uint STENCIL_BACK_VALUE_MASK = 0x8CA4;
        public const uint STENCIL_BACK_WRITEMASK = 0x8CA5;
        public const uint VIEWPORT = 0x0BA2;
        public const uint SCISSOR_BOX = 0x0C10;
        public const uint COLOR_CLEAR_VALUE = 0x0C22;
        public const uint COLOR_WRITEMASK = 0x0C23;
        public const uint UNPACK_ALIGNMENT = 0x0CF5;
        public const uint PACK_ALIGNMENT = 0x0D05;
        public const uint MAX_TEXTURE_SIZE = 0x0D33;
        public const uint MAX_VIEWPORT_DIMS = 0x0D3A;
        public const uint SUBPIXEL_BITS = 0x0D50;
        public const uint RED_BITS = 0x0D52;
        public const uint GREEN_BITS = 0x0D53;
        public const uint BLUE_BITS = 0x0D54;
        public const uint ALPHA_BITS = 0x0D55;
        public const uint DEPTH_BITS = 0x0D56;
        public const uint STENCIL_BITS = 0x0D57;
        public const uint POLYGON_OFFSET_UNITS = 0x2A00;
        public const uint POLYGON_OFFSET_FACTOR = 0x8038;
        public const uint TEXTURE_BINDING_2D = 0x8069;
        public const uint SAMPLE_BUFFERS = 0x80A8;
        public const uint SAMPLES = 0x80A9;
        public const uint SAMPLE_COVERAGE_VALUE = 0x80AA;
        public const uint SAMPLE_COVERAGE_INVERT = 0x80AB;
        public const uint COMPRESSED_TEXTURE_FORMATS = 0x86A3;
        public const uint VENDOR = 0x1F00;
        public const uint RENDERER = 0x1F01;
        public const uint VERSION = 0x1F02;
        public const uint IMPLEMENTATION_COLOR_READ_TYPE = 0x8B9A;
        public const uint IMPLEMENTATION_COLOR_READ_FORMAT = 0x8B9B;
        public const uint BROWSER_DEFAULT_WEBGL = 0x9244;
        #endregion

        #region Pixel storage modes
        public const uint UNPACK_FLIP_Y_WEBGL = 0x9240;
        public const uint UNPACK_PREMULTIPLY_ALPHA_WEBGL = 0x9241;
        public const uint UNPACK_COLORSPACE_CONVERSION_WEBGL = 0x9243;
        #endregion

        // =====================================================================
        // WebGL 2 constants
        // =====================================================================

        #region WebGL2 Getting GL parameter information
        public const uint READ_BUFFER = 0x0C02;
        public const uint UNPACK_ROW_LENGTH = 0x0CF2;
        public const uint UNPACK_SKIP_ROWS = 0x0CF3;
        public const uint UNPACK_SKIP_PIXELS = 0x0CF4;
        public const uint PACK_ROW_LENGTH = 0x0D02;
        public const uint PACK_SKIP_ROWS = 0x0D03;
        public const uint PACK_SKIP_PIXELS = 0x0D04;
        public const uint TEXTURE_BINDING_3D = 0x806A;
        public const uint UNPACK_SKIP_IMAGES = 0x806D;
        public const uint UNPACK_IMAGE_HEIGHT = 0x806E;
        public const uint MAX_3D_TEXTURE_SIZE = 0x8073;
        public const uint MAX_ELEMENTS_VERTICES = 0x80E8;
        public const uint MAX_ELEMENTS_INDICES = 0x80E9;
        public const uint MAX_TEXTURE_LOD_BIAS = 0x84FD;
        public const uint MAX_FRAGMENT_UNIFORM_COMPONENTS = 0x8B49;
        public const uint MAX_VERTEX_UNIFORM_COMPONENTS = 0x8B4A;
        public const uint MAX_ARRAY_TEXTURE_LAYERS = 0x88FF;
        public const uint MIN_PROGRAM_TEXEL_OFFSET = 0x8904;
        public const uint MAX_PROGRAM_TEXEL_OFFSET = 0x8905;
        public const uint MAX_VARYING_COMPONENTS = 0x8B4B;
        public const uint FRAGMENT_SHADER_DERIVATIVE_HINT = 0x8B8B;
        public const uint RASTERIZER_DISCARD = 0x8C89;
        public const uint VERTEX_ARRAY_BINDING = 0x85B5;
        public const uint MAX_VERTEX_OUTPUT_COMPONENTS = 0x9122;
        public const uint MAX_FRAGMENT_INPUT_COMPONENTS = 0x9125;
        public const uint MAX_SERVER_WAIT_TIMEOUT = 0x9111;
        public const uint MAX_ELEMENT_INDEX = 0x8D6B;
        #endregion

        #region WebGL2 Textures
        public const uint RED = 0x1903;
        public const uint RGB8 = 0x8051;
        public const uint RGBA8 = 0x8058;
        public const uint RGB10_A2 = 0x8059;
        public const uint TEXTURE_3D = 0x806F;
        public const uint TEXTURE_WRAP_R = 0x8072;
        public const uint TEXTURE_MIN_LOD = 0x813A;
        public const uint TEXTURE_MAX_LOD = 0x813B;
        public const uint TEXTURE_BASE_LEVEL = 0x813C;
        public const uint TEXTURE_MAX_LEVEL = 0x813D;
        public const uint TEXTURE_COMPARE_MODE = 0x884C;
        public const uint TEXTURE_COMPARE_FUNC = 0x884D;
        public const uint SRGB = 0x8C40;
        public const uint SRGB8 = 0x8C41;
        public const uint SRGB8_ALPHA8 = 0x8C43;
        public const uint COMPARE_REF_TO_TEXTURE = 0x884E;
        public const uint RGBA32F = 0x8814;
        public const uint RGB32F = 0x8815;
        public const uint RGBA16F = 0x881A;
        public const uint RGB16F = 0x881B;
        public const uint TEXTURE_2D_ARRAY = 0x8C1A;
        public const uint TEXTURE_BINDING_2D_ARRAY = 0x8C1D;
        public const uint R11F_G11F_B10F = 0x8C3A;
        public const uint RGB9_E5 = 0x8C3D;
        public const uint RGBA32UI = 0x8D70;
        public const uint RGB32UI = 0x8D71;
        public const uint RGBA16UI = 0x8D76;
        public const uint RGB16UI = 0x8D77;
        public const uint RGBA8UI = 0x8D7C;
        public const uint RGB8UI = 0x8D7D;
        public const uint RGBA32I = 0x8D82;
        public const uint RGB32I = 0x8D83;
        public const uint RGBA16I = 0x8D88;
        public const uint RGB16I = 0x8D89;
        public const uint RGBA8I = 0x8D8E;
        public const uint RGB8I = 0x8D8F;
        public const uint RED_INTEGER = 0x8D94;
        public const uint RGB_INTEGER = 0x8D98;
        public const uint RGBA_INTEGER = 0x8D99;
        public const uint R8 = 0x8229;
        public const uint RG8 = 0x822B;
        public const uint R16F = 0x822D;
        public const uint R32F = 0x822E;
        public const uint RG16F = 0x822F;
        public const uint RG32F = 0x8230;
        public const uint R8I = 0x8231;
        public const uint R8UI = 0x8232;
        public const uint R16I = 0x8233;
        public const uint R16UI = 0x8234;
        public const uint R32I = 0x8235;
        public const uint R32UI = 0x8236;
        public const uint RG8I = 0x8237;
        public const uint RG8UI = 0x8238;
        public const uint RG16I = 0x8239;
        public const uint RG16UI = 0x823A;
        public const uint RG32I = 0x823B;
        public const uint RG32UI = 0x823C;
        public const uint RGB10_A2UI = 0x906F;
        public const uint TEXTURE_IMMUTABLE_FORMAT = 0x912F;
        public const uint TEXTURE_IMMUTABLE_LEVELS = 0x82DF;
        #endregion

        #region WebGL2 Pixel types
        public const uint UNSIGNED_INT_2_10_10_10_REV = 0x8368;
        public const uint UNSIGNED_INT_10F_11F_11F_REV = 0x8C3B;
        public const uint UNSIGNED_INT_5_9_9_9_REV = 0x8C3E;
        public const uint FLOAT_32_UNSIGNED_INT_24_8_REV = 0x8DAD;
        public const uint HALF_FLOAT = 0x140B;
        public const uint RG = 0x8227;
        public const uint RG_INTEGER = 0x8228;
        public const uint INT_2_10_10_10_REV = 0x8D9F;
        #endregion

        #region WebGL2 Queries
        public const uint CURRENT_QUERY = 0x8865;
        public const uint QUERY_RESULT = 0x8866;
        public const uint QUERY_RESULT_AVAILABLE = 0x8867;
        public const uint ANY_SAMPLES_PASSED = 0x8C2F;
        public const uint ANY_SAMPLES_PASSED_CONSERVATIVE = 0x8D6A;
        #endregion

        #region WebGL2 Draw buffers
        public const uint MAX_DRAW_BUFFERS = 0x8824;
        public const uint DRAW_BUFFER0 = 0x8825;
        public const uint DRAW_BUFFER1 = 0x8826;
        public const uint DRAW_BUFFER2 = 0x8827;
        public const uint DRAW_BUFFER3 = 0x8828;
        public const uint DRAW_BUFFER4 = 0x8829;
        public const uint DRAW_BUFFER5 = 0x882A;
        public const uint DRAW_BUFFER6 = 0x882B;
        public const uint DRAW_BUFFER7 = 0x882C;
        public const uint DRAW_BUFFER8 = 0x882D;
        public const uint DRAW_BUFFER9 = 0x882E;
        public const uint DRAW_BUFFER10 = 0x882F;
        public const uint DRAW_BUFFER11 = 0x8830;
        public const uint DRAW_BUFFER12 = 0x8831;
        public const uint DRAW_BUFFER13 = 0x8832;
        public const uint DRAW_BUFFER14 = 0x8833;
        public const uint DRAW_BUFFER15 = 0x8834;
        public const uint MAX_COLOR_ATTACHMENTS = 0x8CDF;
        public const uint COLOR_ATTACHMENT1 = 0x8CE1;
        public const uint COLOR_ATTACHMENT2 = 0x8CE2;
        public const uint COLOR_ATTACHMENT3 = 0x8CE3;
        public const uint COLOR_ATTACHMENT4 = 0x8CE4;
        public const uint COLOR_ATTACHMENT5 = 0x8CE5;
        public const uint COLOR_ATTACHMENT6 = 0x8CE6;
        public const uint COLOR_ATTACHMENT7 = 0x8CE7;
        public const uint COLOR_ATTACHMENT8 = 0x8CE8;
        public const uint COLOR_ATTACHMENT9 = 0x8CE9;
        public const uint COLOR_ATTACHMENT10 = 0x8CEA;
        public const uint COLOR_ATTACHMENT11 = 0x8CEB;
        public const uint COLOR_ATTACHMENT12 = 0x8CEC;
        public const uint COLOR_ATTACHMENT13 = 0x8CED;
        public const uint COLOR_ATTACHMENT14 = 0x8CEE;
        public const uint COLOR_ATTACHMENT15 = 0x8CEF;
        #endregion

        #region WebGL2 Samplers
        public const uint SAMPLER_3D = 0x8B5F;
        public const uint SAMPLER_2D_SHADOW = 0x8B62;
        public const uint SAMPLER_2D_ARRAY = 0x8DC1;
        public const uint SAMPLER_2D_ARRAY_SHADOW = 0x8DC4;
        public const uint SAMPLER_CUBE_SHADOW = 0x8DC5;
        public const uint INT_SAMPLER_2D = 0x8DCA;
        public const uint INT_SAMPLER_3D = 0x8DCB;
        public const uint INT_SAMPLER_CUBE = 0x8DCC;
        public const uint INT_SAMPLER_2D_ARRAY = 0x8DCF;
        public const uint UNSIGNED_INT_SAMPLER_2D = 0x8DD2;
        public const uint UNSIGNED_INT_SAMPLER_3D = 0x8DD3;
        public const uint UNSIGNED_INT_SAMPLER_CUBE = 0x8DD4;
        public const uint UNSIGNED_INT_SAMPLER_2D_ARRAY = 0x8DD7;
        public const uint MAX_SAMPLES = 0x8D57;
        public const uint SAMPLER_BINDING = 0x8919;
        #endregion

        #region WebGL2 Buffers
        public const uint PIXEL_PACK_BUFFER = 0x88EB;
        public const uint PIXEL_UNPACK_BUFFER = 0x88EC;
        public const uint PIXEL_PACK_BUFFER_BINDING = 0x88ED;
        public const uint PIXEL_UNPACK_BUFFER_BINDING = 0x88EF;
        public const uint COPY_READ_BUFFER = 0x8F36;
        public const uint COPY_WRITE_BUFFER = 0x8F37;
        public const uint COPY_READ_BUFFER_BINDING = 0x8F36;
        public const uint COPY_WRITE_BUFFER_BINDING = 0x8F37;
        #endregion

        #region WebGL2 Data types
        public const uint FLOAT_MAT2x3 = 0x8B65;
        public const uint FLOAT_MAT2x4 = 0x8B66;
        public const uint FLOAT_MAT3x2 = 0x8B67;
        public const uint FLOAT_MAT3x4 = 0x8B68;
        public const uint FLOAT_MAT4x2 = 0x8B69;
        public const uint FLOAT_MAT4x3 = 0x8B6A;
        public const uint UNSIGNED_INT_VEC2 = 0x8DC6;
        public const uint UNSIGNED_INT_VEC3 = 0x8DC7;
        public const uint UNSIGNED_INT_VEC4 = 0x8DC8;
        public const uint UNSIGNED_NORMALIZED = 0x8C17;
        public const uint SIGNED_NORMALIZED = 0x8F9C;
        #endregion

        #region WebGL2 Vertex attributes
        public const uint VERTEX_ATTRIB_ARRAY_INTEGER = 0x88FD;
        public const uint VERTEX_ATTRIB_ARRAY_DIVISOR = 0x88FE;
        #endregion

        #region WebGL2 Transform feedback
        public const uint TRANSFORM_FEEDBACK_BUFFER_MODE = 0x8C7F;
        public const uint MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = 0x8C80;
        public const uint TRANSFORM_FEEDBACK_VARYINGS = 0x8C83;
        public const uint TRANSFORM_FEEDBACK_BUFFER_START = 0x8C84;
        public const uint TRANSFORM_FEEDBACK_BUFFER_SIZE = 0x8C85;
        public const uint TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN = 0x8C88;
        public const uint MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = 0x8C8A;
        public const uint MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = 0x8C8B;
        public const uint INTERLEAVED_ATTRIBS = 0x8C8C;
        public const uint SEPARATE_ATTRIBS = 0x8C8D;
        public const uint TRANSFORM_FEEDBACK_BUFFER = 0x8C8E;
        public const uint TRANSFORM_FEEDBACK_BUFFER_BINDING = 0x8C8F;
        public const uint TRANSFORM_FEEDBACK = 0x8E22;
        public const uint TRANSFORM_FEEDBACK_PAUSED = 0x8E23;
        public const uint TRANSFORM_FEEDBACK_ACTIVE = 0x8E24;
        public const uint TRANSFORM_FEEDBACK_BINDING = 0x8E25;
        #endregion

        #region WebGL2 Framebuffers and renderbuffers
        public const uint FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING = 0x8210;
        public const uint FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE = 0x8211;
        public const uint FRAMEBUFFER_ATTACHMENT_RED_SIZE = 0x8212;
        public const uint FRAMEBUFFER_ATTACHMENT_GREEN_SIZE = 0x8213;
        public const uint FRAMEBUFFER_ATTACHMENT_BLUE_SIZE = 0x8214;
        public const uint FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE = 0x8215;
        public const uint FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE = 0x8216;
        public const uint FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE = 0x8217;
        public const uint FRAMEBUFFER_DEFAULT = 0x8218;
        public const uint DEPTH24_STENCIL8 = 0x88F0;
        public const uint DRAW_FRAMEBUFFER_BINDING = 0x8CA6;
        public const uint READ_FRAMEBUFFER = 0x8CA8;
        public const uint DRAW_FRAMEBUFFER = 0x8CA9;
        public const uint READ_FRAMEBUFFER_BINDING = 0x8CAA;
        public const uint RENDERBUFFER_SAMPLES = 0x8CAB;
        public const uint FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = 0x8CD4;
        public const uint FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = 0x8D56;
        #endregion

        #region WebGL2 Uniforms
        public const uint UNIFORM_BUFFER = 0x8A11;
        public const uint UNIFORM_BUFFER_BINDING = 0x8A28;
        public const uint UNIFORM_BUFFER_START = 0x8A29;
        public const uint UNIFORM_BUFFER_SIZE = 0x8A2A;
        public const uint MAX_VERTEX_UNIFORM_BLOCKS = 0x8A2B;
        public const uint MAX_FRAGMENT_UNIFORM_BLOCKS = 0x8A2C;
        public const uint MAX_COMBINED_UNIFORM_BLOCKS = 0x8A2E;
        public const uint MAX_UNIFORM_BUFFER_BINDINGS = 0x8A2F;
        public const uint MAX_UNIFORM_BLOCK_SIZE = 0x8A30;
        public const uint MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = 0x8A31;
        public const uint MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = 0x8A33;
        public const uint UNIFORM_BUFFER_OFFSET_ALIGNMENT = 0x8A34;
        public const uint ACTIVE_UNIFORM_BLOCKS = 0x8A36;
        public const uint UNIFORM_TYPE = 0x8A37;
        public const uint UNIFORM_SIZE = 0x8A38;
        public const uint UNIFORM_BLOCK_INDEX = 0x8A3A;
        public const uint UNIFORM_OFFSET = 0x8A3B;
        public const uint UNIFORM_ARRAY_STRIDE = 0x8A3C;
        public const uint UNIFORM_MATRIX_STRIDE = 0x8A3D;
        public const uint UNIFORM_IS_ROW_MAJOR = 0x8A3E;
        public const uint UNIFORM_BLOCK_BINDING = 0x8A3F;
        public const uint UNIFORM_BLOCK_DATA_SIZE = 0x8A40;
        public const uint UNIFORM_BLOCK_ACTIVE_UNIFORMS = 0x8A42;
        public const uint UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES = 0x8A43;
        public const uint UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER = 0x8A44;
        public const uint UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = 0x8A46;
        #endregion

        #region WebGL2 Sync objects
        public const uint OBJECT_TYPE = 0x9112;
        public const uint SYNC_CONDITION = 0x9113;
        public const uint SYNC_STATUS = 0x9114;
        public const uint SYNC_FLAGS = 0x9115;
        public const uint SYNC_FENCE = 0x9116;
        public const uint SYNC_GPU_COMMANDS_COMPLETE = 0x9117;
        public const uint UNSIGNALED = 0x9118;
        public const uint SIGNALED = 0x9119;
        public const uint ALREADY_SIGNALED = 0x911A;
        public const uint TIMEOUT_EXPIRED = 0x911B;
        public const uint CONDITION_SATISFIED = 0x911C;
        public const uint WAIT_FAILED = 0x911D;
        public const uint SYNC_FLUSH_COMMANDS_BIT = 0x00000001;
        #endregion

        #region WebGL2 Miscellaneous
        public const uint COLOR = 0x1800;
        public const uint DEPTH = 0x1801;
        public const uint STENCIL = 0x1802;
        public const uint MIN = 0x8007;
        public const uint MAX = 0x8008;
        public const uint DEPTH_COMPONENT24 = 0x81A6;
        public const uint STREAM_READ = 0x88E1;
        public const uint STREAM_COPY = 0x88E2;
        public const uint STATIC_READ = 0x88E5;
        public const uint STATIC_COPY = 0x88E6;
        public const uint DYNAMIC_READ = 0x88E9;
        public const uint DYNAMIC_COPY = 0x88EA;
        public const uint DEPTH_COMPONENT32F = 0x8CAC;
        public const uint DEPTH32F_STENCIL8 = 0x8CAD;
        public const uint INVALID_INDEX = 0xFFFFFFFF;
        public const uint TIMEOUT_IGNORED = 0xFFFFFFFF;
        public const uint MAX_CLIENT_WAIT_TIMEOUT_WEBGL = 0x9247;
        #endregion

        // =====================================================================
        // Extension constants
        // =====================================================================

        #region ANGLE_instanced_arrays
        public const uint VERTEX_ATTRIB_ARRAY_DIVISOR_ANGLE = 0x88FE;
        #endregion

        #region WEBGL_debug_renderer_info
        public const uint UNMASKED_VENDOR_WEBGL = 0x9245;
        public const uint UNMASKED_RENDERER_WEBGL = 0x9246;
        #endregion

        #region EXT_texture_filter_anisotropic
        public const uint MAX_TEXTURE_MAX_ANISOTROPY_EXT = 0x84FF;
        public const uint TEXTURE_MAX_ANISOTROPY_EXT = 0x84FE;
        #endregion

        #region WEBGL_compressed_texture_s3tc
        public const uint COMPRESSED_RGB_S3TC_DXT1_EXT = 0x83F0;
        public const uint COMPRESSED_RGBA_S3TC_DXT1_EXT = 0x83F1;
        public const uint COMPRESSED_RGBA_S3TC_DXT3_EXT = 0x83F2;
        public const uint COMPRESSED_RGBA_S3TC_DXT5_EXT = 0x83F3;
        #endregion

        #region WEBGL_compressed_texture_etc
        public const uint COMPRESSED_R11_EAC = 0x9270;
        public const uint COMPRESSED_SIGNED_R11_EAC = 0x9271;
        public const uint COMPRESSED_RG11_EAC = 0x9272;
        public const uint COMPRESSED_SIGNED_RG11_EAC = 0x9273;
        public const uint COMPRESSED_RGB8_ETC2 = 0x9274;
        public const uint COMPRESSED_RGBA8_ETC2_EAC = 0x9275;
        public const uint COMPRESSED_SRGB8_ETC2 = 0x9276;
        public const uint COMPRESSED_SRGB8_ALPHA8_ETC2_EAC = 0x9277;
        public const uint COMPRESSED_RGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 0x9278;
        public const uint COMPRESSED_SRGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 0x9279;
        #endregion

        #region WEBGL_compressed_texture_pvrtc
        public const uint COMPRESSED_RGB_PVRTC_4BPPV1_IMG = 0x8C00;
        public const uint COMPRESSED_RGBA_PVRTC_4BPPV1_IMG = 0x8C02;
        public const uint COMPRESSED_RGB_PVRTC_2BPPV1_IMG = 0x8C01;
        public const uint COMPRESSED_RGBA_PVRTC_2BPPV1_IMG = 0x8C03;
        #endregion

        #region WEBGL_compressed_texture_etc1
        public const uint COMPRESSED_RGB_ETC1_WEBGL = 0x8D64;
        #endregion

        #region WEBGL_depth_texture
        public const uint UNSIGNED_INT_24_8_WEBGL = 0x84FA;
        #endregion

        #region OES_texture_half_float
        public const uint HALF_FLOAT_OES = 0x8D61;
        #endregion

        #region WEBGL_color_buffer_float
        public const uint RGBA32F_EXT = 0x8814;
        public const uint FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE_EXT = 0x8211;
        public const uint UNSIGNED_NORMALIZED_EXT = 0x8C17;
        #endregion

        #region EXT_blend_minmax
        public const uint MIN_EXT = 0x8007;
        public const uint MAX_EXT = 0x8008;
        #endregion

        #region EXT_sRGB
        public const uint SRGB_EXT = 0x8C40;
        public const uint SRGB_ALPHA_EXT = 0x8C42;
        public const uint SRGB8_ALPHA8_EXT = 0x8C43;
        public const uint FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING_EXT = 0x8210;
        #endregion

        #region OES_standard_derivatives
        public const uint FRAGMENT_SHADER_DERIVATIVE_HINT_OES = 0x8B8B;
        #endregion

        #region WEBGL_draw_buffers
        public const uint COLOR_ATTACHMENT0_WEBGL = 0x8CE0;
        public const uint COLOR_ATTACHMENT1_WEBGL = 0x8CE1;
        public const uint COLOR_ATTACHMENT2_WEBGL = 0x8CE2;
        public const uint COLOR_ATTACHMENT3_WEBGL = 0x8CE3;
        public const uint COLOR_ATTACHMENT4_WEBGL = 0x8CE4;
        public const uint COLOR_ATTACHMENT5_WEBGL = 0x8CE5;
        public const uint COLOR_ATTACHMENT6_WEBGL = 0x8CE6;
        public const uint COLOR_ATTACHMENT7_WEBGL = 0x8CE7;
        public const uint COLOR_ATTACHMENT8_WEBGL = 0x8CE8;
        public const uint COLOR_ATTACHMENT9_WEBGL = 0x8CE9;
        public const uint COLOR_ATTACHMENT10_WEBGL = 0x8CEA;
        public const uint COLOR_ATTACHMENT11_WEBGL = 0x8CEB;
        public const uint COLOR_ATTACHMENT12_WEBGL = 0x8CEC;
        public const uint COLOR_ATTACHMENT13_WEBGL = 0x8CED;
        public const uint COLOR_ATTACHMENT14_WEBGL = 0x8CEE;
        public const uint COLOR_ATTACHMENT15_WEBGL = 0x8CEF;
        public const uint DRAW_BUFFER0_WEBGL = 0x8825;
        public const uint DRAW_BUFFER1_WEBGL = 0x8826;
        public const uint DRAW_BUFFER2_WEBGL = 0x8827;
        public const uint DRAW_BUFFER3_WEBGL = 0x8828;
        public const uint DRAW_BUFFER4_WEBGL = 0x8829;
        public const uint DRAW_BUFFER5_WEBGL = 0x882A;
        public const uint DRAW_BUFFER6_WEBGL = 0x882B;
        public const uint DRAW_BUFFER7_WEBGL = 0x882C;
        public const uint DRAW_BUFFER8_WEBGL = 0x882D;
        public const uint DRAW_BUFFER9_WEBGL = 0x882E;
        public const uint DRAW_BUFFER10_WEBGL = 0x882F;
        public const uint DRAW_BUFFER11_WEBGL = 0x8830;
        public const uint DRAW_BUFFER12_WEBGL = 0x8831;
        public const uint DRAW_BUFFER13_WEBGL = 0x8832;
        public const uint DRAW_BUFFER14_WEBGL = 0x8833;
        public const uint DRAW_BUFFER15_WEBGL = 0x8834;
        public const uint MAX_COLOR_ATTACHMENTS_WEBGL = 0x8CDF;
        public const uint MAX_DRAW_BUFFERS_WEBGL = 0x8824;
        #endregion

        #region OES_vertex_array_object
        public const uint VERTEX_ARRAY_BINDING_OES = 0x85B5;
        #endregion

        #region EXT_disjoint_timer_query
        public const uint QUERY_COUNTER_BITS_EXT = 0x8864;
        public const uint CURRENT_QUERY_EXT = 0x8865;
        public const uint QUERY_RESULT_EXT = 0x8866;
        public const uint QUERY_RESULT_AVAILABLE_EXT = 0x8867;
        public const uint TIME_ELAPSED_EXT = 0x88BF;
        public const uint TIMESTAMP_EXT = 0x8E28;
        public const uint GPU_DISJOINT_EXT = 0x8FBB;
        #endregion
    }
}
