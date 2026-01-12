
namespace SpawnDev.BlazorJS.JSObjects
{
    // https://www.khronos.org/registry/webgl/specs/latest/1.0/#5.14.9
    public partial class WebGLRenderingContext
    {

        /* ClearBufferMask */
        /// <summary>
        /// DEPTH_BUFFER_BIT
        /// </summary>
        public readonly int DEPTH_BUFFER_BIT = 0x00000100;
        /// <summary>
        /// STENCIL_BUFFER_BIT
        /// </summary>
        public readonly int STENCIL_BUFFER_BIT = 0x00000400;
        /// <summary>
        /// COLOR_BUFFER_BIT
        /// </summary>
        public readonly int COLOR_BUFFER_BIT = 0x00004000;

        /* BeginMode */
        /// <summary>
        /// POINTS
        /// </summary>
        public readonly int POINTS = 0x0000;
        /// <summary>
        /// LINES
        /// </summary>
        public readonly int LINES = 0x0001;
        /// <summary>
        /// LINE_LOOP
        /// </summary>
        public readonly int LINE_LOOP = 0x0002;
        /// <summary>
        /// LINE_STRIP
        /// </summary>
        public readonly int LINE_STRIP = 0x0003;
        /// <summary>
        /// TRIANGLES
        /// </summary>
        public readonly int TRIANGLES = 0x0004;
        /// <summary>
        /// TRIANGLE_STRIP
        /// </summary>
        public readonly int TRIANGLE_STRIP = 0x0005;
        /// <summary>
        /// TRIANGLE_FAN
        /// </summary>
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
        /// <summary>
        /// ZERO
        /// </summary>
        public readonly int ZERO = 0;
        /// <summary>
        /// ONE
        /// </summary>
        public readonly int ONE = 1;
        /// <summary>
        /// SRC_COLOR
        /// </summary>
        public readonly int SRC_COLOR = 0x0300;
        /// <summary>
        /// ONE_MINUS_SRC_COLOR
        /// </summary>
        public readonly int ONE_MINUS_SRC_COLOR = 0x0301;
        /// <summary>
        /// SRC_ALPHA
        /// </summary>
        public readonly int SRC_ALPHA = 0x0302;
        /// <summary>
        /// ONE_MINUS_SRC_ALPHA
        /// </summary>
        public readonly int ONE_MINUS_SRC_ALPHA = 0x0303;
        /// <summary>
        /// DST_ALPHA
        /// </summary>
        public readonly int DST_ALPHA = 0x0304;
        /// <summary>
        /// ONE_MINUS_DST_ALPHA
        /// </summary>
        public readonly int ONE_MINUS_DST_ALPHA = 0x0305;

        /* BlendingFactorSrc */
        /*      ZERO */
        /*      ONE */
        /// <summary>
        /// DST_COLOR
        /// </summary>
        public readonly int DST_COLOR = 0x0306;
        /// <summary>
        /// ONE_MINUS_DST_COLOR
        /// </summary>
        public readonly int ONE_MINUS_DST_COLOR = 0x0307;
        /// <summary>
        /// SRC_ALPHA_SATURATE
        /// </summary>
        public readonly int SRC_ALPHA_SATURATE = 0x0308;
        /*      SRC_ALPHA */
        /*      ONE_MINUS_SRC_ALPHA */
        /*      DST_ALPHA */
        /*      ONE_MINUS_DST_ALPHA */

        /* BlendEquationSeparate */
        /// <summary>
        /// FUNC_ADD
        /// </summary>
        public readonly int FUNC_ADD = 0x8006;
        /// <summary>
        /// BLEND_EQUATION
        /// </summary>
        public readonly int BLEND_EQUATION = 0x8009;
        /// <summary>
        /// BLEND_EQUATION_RGB
        /// </summary>
        public readonly int BLEND_EQUATION_RGB = 0x8009;   /* same as BLEND_EQUATION */
        /// <summary>
        /// BLEND_EQUATION_ALPHA
        /// </summary>
        public readonly int BLEND_EQUATION_ALPHA = 0x883D;

        /* BlendSubtract */
        /// <summary>
        /// FUNC_SUBTRACT
        /// </summary>
        public readonly int FUNC_SUBTRACT = 0x800A;
        /// <summary>
        /// FUNC_REVERSE_SUBTRACT
        /// </summary>
        public readonly int FUNC_REVERSE_SUBTRACT = 0x800B;

        /* Separate Blend Functions */
        /// <summary>
        /// BLEND_DST_RGB
        /// </summary>
        public readonly int BLEND_DST_RGB = 0x80C8;
        /// <summary>
        /// BLEND_SRC_RGB
        /// </summary>
        public readonly int BLEND_SRC_RGB = 0x80C9;
        /// <summary>
        /// BLEND_DST_ALPHA
        /// </summary>
        public readonly int BLEND_DST_ALPHA = 0x80CA;
        /// <summary>
        /// BLEND_SRC_ALPHA
        /// </summary>
        public readonly int BLEND_SRC_ALPHA = 0x80CB;
        /// <summary>
        /// CONSTANT_COLOR
        /// </summary>
        public readonly int CONSTANT_COLOR = 0x8001;
        /// <summary>
        /// ONE_MINUS_CONSTANT_COLOR
        /// </summary>
        public readonly int ONE_MINUS_CONSTANT_COLOR = 0x8002;
        /// <summary>
        /// CONSTANT_ALPHA
        /// </summary>
        public readonly int CONSTANT_ALPHA = 0x8003;
        /// <summary>
        /// ONE_MINUS_CONSTANT_ALPHA
        /// </summary>
        public readonly int ONE_MINUS_CONSTANT_ALPHA = 0x8004;
        /// <summary>
        /// BLEND_COLOR
        /// </summary>
        public readonly int BLEND_COLOR = 0x8005;

        /* Buffer Objects */
        /// <summary>
        /// ARRAY_BUFFER
        /// </summary>
        public readonly int ARRAY_BUFFER = 0x8892;
        /// <summary>
        /// ELEMENT_ARRAY_BUFFER
        /// </summary>
        public readonly int ELEMENT_ARRAY_BUFFER = 0x8893;
        /// <summary>
        /// ARRAY_BUFFER_BINDING
        /// </summary>
        public readonly int ARRAY_BUFFER_BINDING = 0x8894;
        /// <summary>
        /// ELEMENT_ARRAY_BUFFER_BINDING
        /// </summary>
        public readonly int ELEMENT_ARRAY_BUFFER_BINDING = 0x8895;

        /// <summary>
        /// STREAM_DRAW
        /// </summary>
        public readonly int STREAM_DRAW = 0x88E0;
        /// <summary>
        /// STATIC_DRAW
        /// </summary>
        public readonly int STATIC_DRAW = 0x88E4;
        /// <summary>
        /// DYNAMIC_DRAW
        /// </summary>
        public readonly int DYNAMIC_DRAW = 0x88E8;

        /// <summary>
        /// BUFFER_SIZE
        /// </summary>
        public readonly int BUFFER_SIZE = 0x8764;
        /// <summary>
        /// BUFFER_USAGE
        /// </summary>
        public readonly int BUFFER_USAGE = 0x8765;

        /// <summary>
        /// CURRENT_VERTEX_ATTRIB
        /// </summary>
        public readonly int CURRENT_VERTEX_ATTRIB = 0x8626;

        /* CullFaceMode */
        /// <summary>
        /// FRONT
        /// </summary>
        public readonly int FRONT = 0x0404;
        /// <summary>
        /// BACK
        /// </summary>
        public readonly int BACK = 0x0405;
        /// <summary>
        /// FRONT_AND_BACK
        /// </summary>
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
        /// <summary>
        /// CULL_FACE
        /// </summary>
        public readonly int CULL_FACE = 0x0B44;
        /// <summary>
        /// BLEND
        /// </summary>
        public readonly int BLEND = 0x0BE2;
        /// <summary>
        /// DITHER
        /// </summary>
        public readonly int DITHER = 0x0BD0;
        /// <summary>
        /// STENCIL_TEST
        /// </summary>
        public readonly int STENCIL_TEST = 0x0B90;
        /// <summary>
        /// DEPTH_TEST
        /// </summary>
        public readonly int DEPTH_TEST = 0x0B71;
        /// <summary>
        /// SCISSOR_TEST
        /// </summary>
        public readonly int SCISSOR_TEST = 0x0C11;
        /// <summary>
        /// POLYGON_OFFSET_FILL
        /// </summary>
        public readonly int POLYGON_OFFSET_FILL = 0x8037;
        /// <summary>
        /// SAMPLE_ALPHA_TO_COVERAGE
        /// </summary>
        public readonly int SAMPLE_ALPHA_TO_COVERAGE = 0x809E;
        /// <summary>
        /// SAMPLE_COVERAGE
        /// </summary>
        public readonly int SAMPLE_COVERAGE = 0x80A0;

        /* ErrorCode */
        /// <summary>
        /// NO_ERROR
        /// </summary>
        public readonly int NO_ERROR = 0;
        /// <summary>
        /// INVALID_ENUM
        /// </summary>
        public readonly int INVALID_ENUM = 0x0500;
        /// <summary>
        /// INVALID_VALUE
        /// </summary>
        public readonly int INVALID_VALUE = 0x0501;
        /// <summary>
        /// INVALID_OPERATION
        /// </summary>
        public readonly int INVALID_OPERATION = 0x0502;
        /// <summary>
        /// OUT_OF_MEMORY
        /// </summary>
        public readonly int OUT_OF_MEMORY = 0x0505;

        /* FrontFaceDirection */
        /// <summary>
        /// CW
        /// </summary>
        public readonly int CW = 0x0900;
        /// <summary>
        /// CCW
        /// </summary>
        public readonly int CCW = 0x0901;

        /* GetPName */
        /// <summary>
        /// LINE_WIDTH
        /// </summary>
        public readonly int LINE_WIDTH = 0x0B21;
        /// <summary>
        /// ALIASED_POINT_SIZE_RANGE
        /// </summary>
        public readonly int ALIASED_POINT_SIZE_RANGE = 0x846D;
        /// <summary>
        /// ALIASED_LINE_WIDTH_RANGE
        /// </summary>
        public readonly int ALIASED_LINE_WIDTH_RANGE = 0x846E;
        /// <summary>
        /// CULL_FACE_MODE
        /// </summary>
        public readonly int CULL_FACE_MODE = 0x0B45;
        /// <summary>
        /// FRONT_FACE
        /// </summary>
        public readonly int FRONT_FACE = 0x0B46;
        /// <summary>
        /// DEPTH_RANGE
        /// </summary>
        public readonly int DEPTH_RANGE = 0x0B70;
        /// <summary>
        /// DEPTH_WRITEMASK
        /// </summary>
        public readonly int DEPTH_WRITEMASK = 0x0B72;
        /// <summary>
        /// DEPTH_CLEAR_VALUE
        /// </summary>
        public readonly int DEPTH_CLEAR_VALUE = 0x0B73;
        /// <summary>
        /// DEPTH_FUNC
        /// </summary>
        public readonly int DEPTH_FUNC = 0x0B74;
        /// <summary>
        /// STENCIL_CLEAR_VALUE
        /// </summary>
        public readonly int STENCIL_CLEAR_VALUE = 0x0B91;
        /// <summary>
        /// STENCIL_FUNC
        /// </summary>
        public readonly int STENCIL_FUNC = 0x0B92;
        /// <summary>
        /// STENCIL_FAIL
        /// </summary>
        public readonly int STENCIL_FAIL = 0x0B94;
        /// <summary>
        /// STENCIL_PASS_DEPTH_FAIL
        /// </summary>
        public readonly int STENCIL_PASS_DEPTH_FAIL = 0x0B95;
        /// <summary>
        /// STENCIL_PASS_DEPTH_PASS
        /// </summary>
        public readonly int STENCIL_PASS_DEPTH_PASS = 0x0B96;
        /// <summary>
        /// STENCIL_REF
        /// </summary>
        public readonly int STENCIL_REF = 0x0B97;
        /// <summary>
        /// STENCIL_VALUE_MASK
        /// </summary>
        public readonly int STENCIL_VALUE_MASK = 0x0B93;
        /// <summary>
        /// STENCIL_WRITEMASK
        /// </summary>
        public readonly int STENCIL_WRITEMASK = 0x0B98;
        /// <summary>
        /// STENCIL_BACK_FUNC
        /// </summary>
        public readonly int STENCIL_BACK_FUNC = 0x8800;
        /// <summary>
        /// STENCIL_BACK_FAIL
        /// </summary>
        public readonly int STENCIL_BACK_FAIL = 0x8801;
        /// <summary>
        /// STENCIL_BACK_PASS_DEPTH_FAIL
        /// </summary>
        public readonly int STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802;
        /// <summary>
        /// STENCIL_BACK_PASS_DEPTH_PASS
        /// </summary>
        public readonly int STENCIL_BACK_PASS_DEPTH_PASS = 0x8803;
        /// <summary>
        /// STENCIL_BACK_REF
        /// </summary>
        public readonly int STENCIL_BACK_REF = 0x8CA3;
        /// <summary>
        /// STENCIL_BACK_VALUE_MASK
        /// </summary>
        public readonly int STENCIL_BACK_VALUE_MASK = 0x8CA4;
        /// <summary>
        /// STENCIL_BACK_WRITEMASK
        /// </summary>
        public readonly int STENCIL_BACK_WRITEMASK = 0x8CA5;
        /// <summary>
        /// VIEWPORT
        /// </summary>
        public readonly int VIEWPORT = 0x0BA2;
        /// <summary>
        /// SCISSOR_BOX
        /// </summary>
        public readonly int SCISSOR_BOX = 0x0C10;
        /*      SCISSOR_TEST */
        /// <summary>
        /// COLOR_CLEAR_VALUE
        /// </summary>
        public readonly int COLOR_CLEAR_VALUE = 0x0C22;
        /// <summary>
        /// COLOR_WRITEMASK
        /// </summary>
        public readonly int COLOR_WRITEMASK = 0x0C23;
        /// <summary>
        /// UNPACK_ALIGNMENT
        /// </summary>
        public readonly int UNPACK_ALIGNMENT = 0x0CF5;
        /// <summary>
        /// PACK_ALIGNMENT
        /// </summary>
        public readonly int PACK_ALIGNMENT = 0x0D05;
        /// <summary>
        /// MAX_TEXTURE_SIZE
        /// </summary>
        public readonly int MAX_TEXTURE_SIZE = 0x0D33;
        /// <summary>
        /// MAX_VIEWPORT_DIMS
        /// </summary>
        public readonly int MAX_VIEWPORT_DIMS = 0x0D3A;
        /// <summary>
        /// SUBPIXEL_BITS
        /// </summary>
        public readonly int SUBPIXEL_BITS = 0x0D50;
        /// <summary>
        /// RED_BITS
        /// </summary>
        public readonly int RED_BITS = 0x0D52;
        /// <summary>
        /// GREEN_BITS
        /// </summary>
        public readonly int GREEN_BITS = 0x0D53;
        /// <summary>
        /// BLUE_BITS
        /// </summary>
        public readonly int BLUE_BITS = 0x0D54;
        /// <summary>
        /// ALPHA_BITS
        /// </summary>
        public readonly int ALPHA_BITS = 0x0D55;
        /// <summary>
        /// DEPTH_BITS
        /// </summary>
        public readonly int DEPTH_BITS = 0x0D56;
        /// <summary>
        /// STENCIL_BITS
        /// </summary>
        public readonly int STENCIL_BITS = 0x0D57;
        /// <summary>
        /// POLYGON_OFFSET_UNITS
        /// </summary>
        public readonly int POLYGON_OFFSET_UNITS = 0x2A00;
        /*      POLYGON_OFFSET_FILL */
        /// <summary>
        /// POLYGON_OFFSET_FACTOR
        /// </summary>
        public readonly int POLYGON_OFFSET_FACTOR = 0x8038;
        /// <summary>
        /// TEXTURE_BINDING_2D
        /// </summary>
        public readonly int TEXTURE_BINDING_2D = 0x8069;
        /// <summary>
        /// SAMPLE_BUFFERS
        /// </summary>
        public readonly int SAMPLE_BUFFERS = 0x80A8;
        /// <summary>
        /// SAMPLES
        /// </summary>
        public readonly int SAMPLES = 0x80A9;
        /// <summary>
        /// SAMPLE_COVERAGE_VALUE
        /// </summary>
        public readonly int SAMPLE_COVERAGE_VALUE = 0x80AA;
        /// <summary>
        /// SAMPLE_COVERAGE_INVERT
        /// </summary>
        public readonly int SAMPLE_COVERAGE_INVERT = 0x80AB;

        /* GetTextureParameter */
        /*      TEXTURE_MAG_FILTER */
        /*      TEXTURE_MIN_FILTER */
        /*      TEXTURE_WRAP_S */
        /*      TEXTURE_WRAP_T */

        /// <summary>
        /// COMPRESSED_TEXTURE_FORMATS
        /// </summary>
        public readonly int COMPRESSED_TEXTURE_FORMATS = 0x86A3;

        /* HintMode */
        /// <summary>
        /// DONT_CARE
        /// </summary>
        public readonly int DONT_CARE = 0x1100;
        /// <summary>
        /// FASTEST
        /// </summary>
        public readonly int FASTEST = 0x1101;
        /// <summary>
        /// NICEST
        /// </summary>
        public readonly int NICEST = 0x1102;

        /* HintTarget */
        /// <summary>
        /// GENERATE_MIPMAP_HINT
        /// </summary>
        public readonly int GENERATE_MIPMAP_HINT = 0x8192;

        /* DataType */
        /// <summary>
        /// BYTE
        /// </summary>
        public readonly int BYTE = 0x1400;
        /// <summary>
        /// UNSIGNED_BYTE
        /// </summary>
        public readonly int UNSIGNED_BYTE = 0x1401;
        /// <summary>
        /// SHORT
        /// </summary>
        public readonly int SHORT = 0x1402;
        /// <summary>
        /// UNSIGNED_SHORT
        /// </summary>
        public readonly int UNSIGNED_SHORT = 0x1403;
        /// <summary>
        /// INT
        /// </summary>
        public readonly int INT = 0x1404;
        /// <summary>
        /// UNSIGNED_INT
        /// </summary>
        public readonly int UNSIGNED_INT = 0x1405;
        /// <summary>
        /// FLOAT
        /// </summary>
        public readonly int FLOAT = 0x1406;

        /* PixelFormat */
        /// <summary>
        /// DEPTH_COMPONENT
        /// </summary>
        public readonly int DEPTH_COMPONENT = 0x1902;
        /// <summary>
        /// ALPHA
        /// </summary>
        public readonly int ALPHA = 0x1906;
        /// <summary>
        /// RGB
        /// </summary>
        public readonly int RGB = 0x1907;
        /// <summary>
        /// RGBA
        /// </summary>
        public readonly int RGBA = 0x1908;
        /// <summary>
        /// LUMINANCE
        /// </summary>
        public readonly int LUMINANCE = 0x1909;
        /// <summary>
        /// LUMINANCE_ALPHA
        /// </summary>
        public readonly int LUMINANCE_ALPHA = 0x190A;

        /* PixelType */
        /*      UNSIGNED_BYTE */
        /// <summary>
        /// UNSIGNED_SHORT_4_4_4_4
        /// </summary>
        public readonly int UNSIGNED_SHORT_4_4_4_4 = 0x8033;
        /// <summary>
        /// UNSIGNED_SHORT_5_5_5_1
        /// </summary>
        public readonly int UNSIGNED_SHORT_5_5_5_1 = 0x8034;
        /// <summary>
        /// UNSIGNED_SHORT_5_6_5
        /// </summary>
        public readonly int UNSIGNED_SHORT_5_6_5 = 0x8363;

        /* Shaders */
        /// <summary>
        /// FRAGMENT_SHADER
        /// </summary>
        public readonly int FRAGMENT_SHADER = 0x8B30;
        /// <summary>
        /// VERTEX_SHADER
        /// </summary>
        public readonly int VERTEX_SHADER = 0x8B31;
        /// <summary>
        /// MAX_VERTEX_ATTRIBS
        /// </summary>
        public readonly int MAX_VERTEX_ATTRIBS = 0x8869;
        /// <summary>
        /// MAX_VERTEX_UNIFORM_VECTORS
        /// </summary>
        public readonly int MAX_VERTEX_UNIFORM_VECTORS = 0x8DFB;
        /// <summary>
        /// MAX_VARYING_VECTORS
        /// </summary>
        public readonly int MAX_VARYING_VECTORS = 0x8DFC;
        /// <summary>
        /// MAX_COMBINED_TEXTURE_IMAGE_UNITS
        /// </summary>
        public readonly int MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D;
        /// <summary>
        /// MAX_VERTEX_TEXTURE_IMAGE_UNITS
        /// </summary>
        public readonly int MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C;
        /// <summary>
        /// MAX_TEXTURE_IMAGE_UNITS
        /// </summary>
        public readonly int MAX_TEXTURE_IMAGE_UNITS = 0x8872;
        /// <summary>
        /// MAX_FRAGMENT_UNIFORM_VECTORS
        /// </summary>
        public readonly int MAX_FRAGMENT_UNIFORM_VECTORS = 0x8DFD;
        /// <summary>
        /// SHADER_TYPE
        /// </summary>
        public readonly int SHADER_TYPE = 0x8B4F;
        /// <summary>
        /// DELETE_STATUS
        /// </summary>
        public readonly int DELETE_STATUS = 0x8B80;
        /// <summary>
        /// LINK_STATUS
        /// </summary>
        public readonly int LINK_STATUS = 0x8B82;
        /// <summary>
        /// VALIDATE_STATUS
        /// </summary>
        public readonly int VALIDATE_STATUS = 0x8B83;
        /// <summary>
        /// ATTACHED_SHADERS
        /// </summary>
        public readonly int ATTACHED_SHADERS = 0x8B85;
        /// <summary>
        /// ACTIVE_UNIFORMS
        /// </summary>
        public readonly int ACTIVE_UNIFORMS = 0x8B86;
        /// <summary>
        /// ACTIVE_ATTRIBUTES
        /// </summary>
        public readonly int ACTIVE_ATTRIBUTES = 0x8B89;
        /// <summary>
        /// SHADING_LANGUAGE_VERSION
        /// </summary>
        public readonly int SHADING_LANGUAGE_VERSION = 0x8B8C;
        /// <summary>
        /// CURRENT_PROGRAM
        /// </summary>
        public readonly int CURRENT_PROGRAM = 0x8B8D;

        /* StencilFunction */
        /// <summary>
        /// NEVER
        /// </summary>
        public readonly int NEVER = 0x0200;
        /// <summary>
        /// LESS
        /// </summary>
        public readonly int LESS = 0x0201;
        /// <summary>
        /// EQUAL
        /// </summary>
        public readonly int EQUAL = 0x0202;
        /// <summary>
        /// LEQUAL
        /// </summary>
        public readonly int LEQUAL = 0x0203;
        /// <summary>
        /// GREATER
        /// </summary>
        public readonly int GREATER = 0x0204;
        /// <summary>
        /// NOTEQUAL
        /// </summary>
        public readonly int NOTEQUAL = 0x0205;
        /// <summary>
        /// GEQUAL
        /// </summary>
        public readonly int GEQUAL = 0x0206;
        /// <summary>
        /// ALWAYS
        /// </summary>
        public readonly int ALWAYS = 0x0207;

        /* StencilOp */
        /*      ZERO */
        /// <summary>
        /// KEEP
        /// </summary>
        public readonly int KEEP = 0x1E00;
        /// <summary>
        /// REPLACE
        /// </summary>
        public readonly int REPLACE = 0x1E01;
        /// <summary>
        /// INCR
        /// </summary>
        public readonly int INCR = 0x1E02;
        /// <summary>
        /// DECR
        /// </summary>
        public readonly int DECR = 0x1E03;
        /// <summary>
        /// INVERT
        /// </summary>
        public readonly int INVERT = 0x150A;
        /// <summary>
        /// INCR_WRAP
        /// </summary>
        public readonly int INCR_WRAP = 0x8507;
        /// <summary>
        /// DECR_WRAP
        /// </summary>
        public readonly int DECR_WRAP = 0x8508;

        /* StringName */
        /// <summary>
        /// VENDOR
        /// </summary>
        public readonly int VENDOR = 0x1F00;
        /// <summary>
        /// RENDERER
        /// </summary>
        public readonly int RENDERER = 0x1F01;
        /// <summary>
        /// VERSION
        /// </summary>
        public readonly int VERSION = 0x1F02;

        /* TextureMagFilter */
        /// <summary>
        /// NEAREST
        /// </summary>
        public readonly int NEAREST = 0x2600;
        /// <summary>
        /// LINEAR
        /// </summary>
        public readonly int LINEAR = 0x2601;

        /* TextureMinFilter */
        /*      NEAREST */
        /*      LINEAR */
        /// <summary>
        /// NEAREST_MIPMAP_NEAREST
        /// </summary>
        public readonly int NEAREST_MIPMAP_NEAREST = 0x2700;
        /// <summary>
        /// LINEAR_MIPMAP_NEAREST
        /// </summary>
        public readonly int LINEAR_MIPMAP_NEAREST = 0x2701;
        /// <summary>
        /// NEAREST_MIPMAP_LINEAR
        /// </summary>
        public readonly int NEAREST_MIPMAP_LINEAR = 0x2702;
        /// <summary>
        /// LINEAR_MIPMAP_LINEAR
        /// </summary>
        public readonly int LINEAR_MIPMAP_LINEAR = 0x2703;

        /* TextureParameterName */
        /// <summary>
        /// TEXTURE_MAG_FILTER
        /// </summary>
        public readonly int TEXTURE_MAG_FILTER = 0x2800;
        /// <summary>
        /// TEXTURE_MIN_FILTER
        /// </summary>
        public readonly int TEXTURE_MIN_FILTER = 0x2801;
        /// <summary>
        /// TEXTURE_WRAP_S
        /// </summary>
        public readonly int TEXTURE_WRAP_S = 0x2802;
        /// <summary>
        /// TEXTURE_WRAP_T
        /// </summary>
        public readonly int TEXTURE_WRAP_T = 0x2803;

        /* TextureTarget */
        /// <summary>
        /// TEXTURE_2D
        /// </summary>
        public readonly int TEXTURE_2D = 0x0DE1;
        /// <summary>
        /// TEXTURE
        /// </summary>
        public readonly int TEXTURE = 0x1702;

        /// <summary>
        /// TEXTURE_CUBE_MAP
        /// </summary>
        public readonly int TEXTURE_CUBE_MAP = 0x8513;
        /// <summary>
        /// TEXTURE_BINDING_CUBE_MAP
        /// </summary>
        public readonly int TEXTURE_BINDING_CUBE_MAP = 0x8514;
        /// <summary>
        /// TEXTURE_CUBE_MAP_POSITIVE_X
        /// </summary>
        public readonly int TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515;
        /// <summary>
        /// TEXTURE_CUBE_MAP_NEGATIVE_X
        /// </summary>
        public readonly int TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516;
        /// <summary>
        /// TEXTURE_CUBE_MAP_POSITIVE_Y
        /// </summary>
        public readonly int TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517;
        /// <summary>
        /// TEXTURE_CUBE_MAP_NEGATIVE_Y
        /// </summary>
        public readonly int TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518;
        /// <summary>
        /// TEXTURE_CUBE_MAP_POSITIVE_Z
        /// </summary>
        public readonly int TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519;
        /// <summary>
        /// TEXTURE_CUBE_MAP_NEGATIVE_Z
        /// </summary>
        public readonly int TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A;
        /// <summary>
        /// MAX_CUBE_MAP_TEXTURE_SIZE
        /// </summary>
        public readonly int MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C;

        /* TextureUnit */
        /// <summary>
        /// TEXTURE0
        /// </summary>
        public readonly int TEXTURE0 = 0x84C0;
        /// <summary>
        /// TEXTURE1
        /// </summary>
        public readonly int TEXTURE1 = 0x84C1;
        /// <summary>
        /// TEXTURE2
        /// </summary>
        public readonly int TEXTURE2 = 0x84C2;
        /// <summary>
        /// TEXTURE3
        /// </summary>
        public readonly int TEXTURE3 = 0x84C3;
        /// <summary>
        /// TEXTURE4
        /// </summary>
        public readonly int TEXTURE4 = 0x84C4;
        /// <summary>
        /// TEXTURE5
        /// </summary>
        public readonly int TEXTURE5 = 0x84C5;
        /// <summary>
        /// TEXTURE6
        /// </summary>
        public readonly int TEXTURE6 = 0x84C6;
        /// <summary>
        /// TEXTURE7
        /// </summary>
        public readonly int TEXTURE7 = 0x84C7;
        /// <summary>
        /// TEXTURE8
        /// </summary>
        public readonly int TEXTURE8 = 0x84C8;
        /// <summary>
        /// TEXTURE9
        /// </summary>
        public readonly int TEXTURE9 = 0x84C9;
        /// <summary>
        /// TEXTURE10
        /// </summary>
        public readonly int TEXTURE10 = 0x84CA;
        /// <summary>
        /// TEXTURE11
        /// </summary>
        public readonly int TEXTURE11 = 0x84CB;
        /// <summary>
        /// TEXTURE12
        /// </summary>
        public readonly int TEXTURE12 = 0x84CC;
        /// <summary>
        /// TEXTURE13
        /// </summary>
        public readonly int TEXTURE13 = 0x84CD;
        /// <summary>
        /// TEXTURE14
        /// </summary>
        public readonly int TEXTURE14 = 0x84CE;
        /// <summary>
        /// TEXTURE15
        /// </summary>
        public readonly int TEXTURE15 = 0x84CF;
        /// <summary>
        /// TEXTURE16
        /// </summary>
        public readonly int TEXTURE16 = 0x84D0;
        /// <summary>
        /// TEXTURE17
        /// </summary>
        public readonly int TEXTURE17 = 0x84D1;
        /// <summary>
        /// TEXTURE18
        /// </summary>
        public readonly int TEXTURE18 = 0x84D2;
        /// <summary>
        /// TEXTURE19
        /// </summary>
        public readonly int TEXTURE19 = 0x84D3;
        /// <summary>
        /// TEXTURE20
        /// </summary>
        public readonly int TEXTURE20 = 0x84D4;
        /// <summary>
        /// TEXTURE21
        /// </summary>
        public readonly int TEXTURE21 = 0x84D5;
        /// <summary>
        /// TEXTURE22
        /// </summary>
        public readonly int TEXTURE22 = 0x84D6;
        /// <summary>
        /// TEXTURE23
        /// </summary>
        public readonly int TEXTURE23 = 0x84D7;
        /// <summary>
        /// TEXTURE24
        /// </summary>
        public readonly int TEXTURE24 = 0x84D8;
        /// <summary>
        /// TEXTURE25
        /// </summary>
        public readonly int TEXTURE25 = 0x84D9;
        /// <summary>
        /// TEXTURE26
        /// </summary>
        public readonly int TEXTURE26 = 0x84DA;
        /// <summary>
        /// TEXTURE27
        /// </summary>
        public readonly int TEXTURE27 = 0x84DB;
        /// <summary>
        /// TEXTURE28
        /// </summary>
        public readonly int TEXTURE28 = 0x84DC;
        /// <summary>
        /// TEXTURE29
        /// </summary>
        public readonly int TEXTURE29 = 0x84DD;
        /// <summary>
        /// TEXTURE30
        /// </summary>
        public readonly int TEXTURE30 = 0x84DE;
        /// <summary>
        /// TEXTURE31
        /// </summary>
        public readonly int TEXTURE31 = 0x84DF;
        /// <summary>
        /// ACTIVE_TEXTURE
        /// </summary>
        public readonly int ACTIVE_TEXTURE = 0x84E0;

        /* TextureWrapMode */
        /// <summary>
        /// REPEAT
        /// </summary>
        public readonly int REPEAT = 0x2901;
        /// <summary>
        /// CLAMP_TO_EDGE
        /// </summary>
        public readonly int CLAMP_TO_EDGE = 0x812F;
        /// <summary>
        /// MIRRORED_REPEAT
        /// </summary>
        public readonly int MIRRORED_REPEAT = 0x8370;

        /* Uniform Types */
        /// <summary>
        /// FLOAT_VEC2
        /// </summary>
        public readonly int FLOAT_VEC2 = 0x8B50;
        /// <summary>
        /// FLOAT_VEC3
        /// </summary>
        public readonly int FLOAT_VEC3 = 0x8B51;
        /// <summary>
        /// FLOAT_VEC4
        /// </summary>
        public readonly int FLOAT_VEC4 = 0x8B52;
        /// <summary>
        /// INT_VEC2
        /// </summary>
        public readonly int INT_VEC2 = 0x8B53;
        /// <summary>
        /// INT_VEC3
        /// </summary>
        public readonly int INT_VEC3 = 0x8B54;
        /// <summary>
        /// INT_VEC4
        /// </summary>
        public readonly int INT_VEC4 = 0x8B55;
        /// <summary>
        /// BOOL
        /// </summary>
        public readonly int BOOL = 0x8B56;
        /// <summary>
        /// BOOL_VEC2
        /// </summary>
        public readonly int BOOL_VEC2 = 0x8B57;
        /// <summary>
        /// BOOL_VEC3
        /// </summary>
        public readonly int BOOL_VEC3 = 0x8B58;
        /// <summary>
        /// BOOL_VEC4
        /// </summary>
        public readonly int BOOL_VEC4 = 0x8B59;
        /// <summary>
        /// FLOAT_MAT2
        /// </summary>
        public readonly int FLOAT_MAT2 = 0x8B5A;
        /// <summary>
        /// FLOAT_MAT3
        /// </summary>
        public readonly int FLOAT_MAT3 = 0x8B5B;
        /// <summary>
        /// FLOAT_MAT4
        /// </summary>
        public readonly int FLOAT_MAT4 = 0x8B5C;
        /// <summary>
        /// SAMPLER_2D
        /// </summary>
        public readonly int SAMPLER_2D = 0x8B5E;
        /// <summary>
        /// SAMPLER_CUBE
        /// </summary>
        public readonly int SAMPLER_CUBE = 0x8B60;

        /* Vertex Arrays */
        /// <summary>
        /// VERTEX_ATTRIB_ARRAY_ENABLED
        /// </summary>
        public readonly int VERTEX_ATTRIB_ARRAY_ENABLED = 0x8622;
        /// <summary>
        /// VERTEX_ATTRIB_ARRAY_SIZE
        /// </summary>
        public readonly int VERTEX_ATTRIB_ARRAY_SIZE = 0x8623;
        /// <summary>
        /// VERTEX_ATTRIB_ARRAY_STRIDE
        /// </summary>
        public readonly int VERTEX_ATTRIB_ARRAY_STRIDE = 0x8624;
        /// <summary>
        /// VERTEX_ATTRIB_ARRAY_TYPE
        /// </summary>
        public readonly int VERTEX_ATTRIB_ARRAY_TYPE = 0x8625;
        /// <summary>
        /// VERTEX_ATTRIB_ARRAY_NORMALIZED
        /// </summary>
        public readonly int VERTEX_ATTRIB_ARRAY_NORMALIZED = 0x886A;
        /// <summary>
        /// VERTEX_ATTRIB_ARRAY_POINTER
        /// </summary>
        public readonly int VERTEX_ATTRIB_ARRAY_POINTER = 0x8645;
        /// <summary>
        /// VERTEX_ATTRIB_ARRAY_BUFFER_BINDING
        /// </summary>
        public readonly int VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 0x889F;

        /* Read Format */
        /// <summary>
        /// IMPLEMENTATION_COLOR_READ_TYPE
        /// </summary>
        public readonly int IMPLEMENTATION_COLOR_READ_TYPE = 0x8B9A;
        /// <summary>
        /// IMPLEMENTATION_COLOR_READ_FORMAT
        /// </summary>
        public readonly int IMPLEMENTATION_COLOR_READ_FORMAT = 0x8B9B;

        /* Shader Source */
        /// <summary>
        /// COMPILE_STATUS
        /// </summary>
        public readonly int COMPILE_STATUS = 0x8B81;

        /* Shader Precision-Specified Types */
        /// <summary>
        /// LOW_FLOAT
        /// </summary>
        public readonly int LOW_FLOAT = 0x8DF0;
        /// <summary>
        /// MEDIUM_FLOAT
        /// </summary>
        public readonly int MEDIUM_FLOAT = 0x8DF1;
        /// <summary>
        /// HIGH_FLOAT
        /// </summary>
        public readonly int HIGH_FLOAT = 0x8DF2;
        /// <summary>
        /// LOW_INT
        /// </summary>
        public readonly int LOW_INT = 0x8DF3;
        /// <summary>
        /// MEDIUM_INT
        /// </summary>
        public readonly int MEDIUM_INT = 0x8DF4;
        /// <summary>
        /// HIGH_INT
        /// </summary>
        public readonly int HIGH_INT = 0x8DF5;

        /* Framebuffer Object. */
        /// <summary>
        /// FRAMEBUFFER
        /// </summary>
        public readonly int FRAMEBUFFER = 0x8D40;
        /// <summary>
        /// RENDERBUFFER
        /// </summary>
        public readonly int RENDERBUFFER = 0x8D41;

        /// <summary>
        /// RGBA4
        /// </summary>
        public readonly int RGBA4 = 0x8056;
        /// <summary>
        /// RGB5_A1
        /// </summary>
        public readonly int RGB5_A1 = 0x8057;
        /// <summary>
        /// RGB565
        /// </summary>
        public readonly int RGB565 = 0x8D62;
        /// <summary>
        /// DEPTH_COMPONENT16
        /// </summary>
        public readonly int DEPTH_COMPONENT16 = 0x81A5;
        /// <summary>
        /// STENCIL_INDEX8
        /// </summary>
        public readonly int STENCIL_INDEX8 = 0x8D48;
        /// <summary>
        /// DEPTH_STENCIL
        /// </summary>
        public readonly int DEPTH_STENCIL = 0x84F9;

        /// <summary>
        /// RENDERBUFFER_WIDTH
        /// </summary>
        public readonly int RENDERBUFFER_WIDTH = 0x8D42;
        /// <summary>
        /// RENDERBUFFER_HEIGHT
        /// </summary>
        public readonly int RENDERBUFFER_HEIGHT = 0x8D43;
        /// <summary>
        /// RENDERBUFFER_INTERNAL_FORMAT
        /// </summary>
        public readonly int RENDERBUFFER_INTERNAL_FORMAT = 0x8D44;
        /// <summary>
        /// RENDERBUFFER_RED_SIZE
        /// </summary>
        public readonly int RENDERBUFFER_RED_SIZE = 0x8D50;
        /// <summary>
        /// RENDERBUFFER_GREEN_SIZE
        /// </summary>
        public readonly int RENDERBUFFER_GREEN_SIZE = 0x8D51;
        /// <summary>
        /// RENDERBUFFER_BLUE_SIZE
        /// </summary>
        public readonly int RENDERBUFFER_BLUE_SIZE = 0x8D52;
        /// <summary>
        /// RENDERBUFFER_ALPHA_SIZE
        /// </summary>
        public readonly int RENDERBUFFER_ALPHA_SIZE = 0x8D53;
        /// <summary>
        /// RENDERBUFFER_DEPTH_SIZE
        /// </summary>
        public readonly int RENDERBUFFER_DEPTH_SIZE = 0x8D54;
        /// <summary>
        /// RENDERBUFFER_STENCIL_SIZE
        /// </summary>
        public readonly int RENDERBUFFER_STENCIL_SIZE = 0x8D55;

        /// <summary>
        /// FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE
        /// </summary>
        public readonly int FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = 0x8CD0;
        /// <summary>
        /// FRAMEBUFFER_ATTACHMENT_OBJECT_NAME
        /// </summary>
        public readonly int FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = 0x8CD1;
        /// <summary>
        /// FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL
        /// </summary>
        public readonly int FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = 0x8CD2;
        /// <summary>
        /// FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE
        /// </summary>
        public readonly int FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = 0x8CD3;

        /// <summary>
        /// COLOR_ATTACHMENT0
        /// </summary>
        public readonly int COLOR_ATTACHMENT0 = 0x8CE0;
        /// <summary>
        /// DEPTH_ATTACHMENT
        /// </summary>
        public readonly int DEPTH_ATTACHMENT = 0x8D00;
        /// <summary>
        /// STENCIL_ATTACHMENT
        /// </summary>
        public readonly int STENCIL_ATTACHMENT = 0x8D20;
        /// <summary>
        /// DEPTH_STENCIL_ATTACHMENT
        /// </summary>
        public readonly int DEPTH_STENCIL_ATTACHMENT = 0x821A;

        /// <summary>
        /// NONE
        /// </summary>
        public readonly int NONE = 0;

        /// <summary>
        /// FRAMEBUFFER_COMPLETE
        /// </summary>
        public readonly int FRAMEBUFFER_COMPLETE = 0x8CD5;
        /// <summary>
        /// FRAMEBUFFER_INCOMPLETE_ATTACHMENT
        /// </summary>
        public readonly int FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 0x8CD6;
        /// <summary>
        /// FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT
        /// </summary>
        public readonly int FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 0x8CD7;
        /// <summary>
        /// FRAMEBUFFER_INCOMPLETE_DIMENSIONS
        /// </summary>
        public readonly int FRAMEBUFFER_INCOMPLETE_DIMENSIONS = 0x8CD9;
        /// <summary>
        /// FRAMEBUFFER_UNSUPPORTED
        /// </summary>
        public readonly int FRAMEBUFFER_UNSUPPORTED = 0x8CDD;

        /// <summary>
        /// FRAMEBUFFER_BINDING
        /// </summary>
        public readonly int FRAMEBUFFER_BINDING = 0x8CA6;
        /// <summary>
        /// RENDERBUFFER_BINDING
        /// </summary>
        public readonly int RENDERBUFFER_BINDING = 0x8CA7;
        /// <summary>
        /// MAX_RENDERBUFFER_SIZE
        /// </summary>
        public readonly int MAX_RENDERBUFFER_SIZE = 0x84E8;

        /// <summary>
        /// INVALID_FRAMEBUFFER_OPERATION
        /// </summary>
        public readonly int INVALID_FRAMEBUFFER_OPERATION = 0x0506;

        /* WebGL-specific enums */
        /// <summary>
        /// UNPACK_FLIP_Y_WEBGL
        /// </summary>
        public readonly int UNPACK_FLIP_Y_WEBGL = 0x9240;
        /// <summary>
        /// UNPACK_PREMULTIPLY_ALPHA_WEBGL
        /// </summary>
        public readonly int UNPACK_PREMULTIPLY_ALPHA_WEBGL = 0x9241;
        /// <summary>
        /// CONTEXT_LOST_WEBGL
        /// </summary>
        public readonly int CONTEXT_LOST_WEBGL = 0x9242;
        /// <summary>
        /// UNPACK_COLORSPACE_CONVERSION_WEBGL
        /// </summary>
        public readonly int UNPACK_COLORSPACE_CONVERSION_WEBGL = 0x9243;
        /// <summary>
        /// BROWSER_DEFAULT_WEBGL
        /// </summary>
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
