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
        /// <summary>
        /// READ_BUFFER
        /// </summary>
        public readonly GLenum READ_BUFFER = 0x0C02;
        /// <summary>
        /// UNPACK_ROW_LENGTH
        /// </summary>
        public readonly GLenum UNPACK_ROW_LENGTH = 0x0CF2;
        /// <summary>
        /// UNPACK_SKIP_ROWS
        /// </summary>
        public readonly GLenum UNPACK_SKIP_ROWS = 0x0CF3;
        /// <summary>
        /// UNPACK_SKIP_PIXELS
        /// </summary>
        public readonly GLenum UNPACK_SKIP_PIXELS = 0x0CF4;
        /// <summary>
        /// PACK_ROW_LENGTH
        /// </summary>
        public readonly GLenum PACK_ROW_LENGTH = 0x0D02;
        /// <summary>
        /// PACK_SKIP_ROWS
        /// </summary>
        public readonly GLenum PACK_SKIP_ROWS = 0x0D03;
        /// <summary>
        /// PACK_SKIP_PIXELS
        /// </summary>
        public readonly GLenum PACK_SKIP_PIXELS = 0x0D04;
        /// <summary>
        /// TEXTURE_BINDING_3D
        /// </summary>
        public readonly GLenum TEXTURE_BINDING_3D = 0x806A;
        /// <summary>
        /// UNPACK_SKIP_IMAGES
        /// </summary>
        public readonly GLenum UNPACK_SKIP_IMAGES = 0x806D;
        /// <summary>
        /// UNPACK_IMAGE_HEIGHT
        /// </summary>
        public readonly GLenum UNPACK_IMAGE_HEIGHT = 0x806E;
        /// <summary>
        /// MAX_3D_TEXTURE_SIZE
        /// </summary>
        public readonly GLenum MAX_3D_TEXTURE_SIZE = 0x8073;
        /// <summary>
        /// MAX_ELEMENTS_VERTICES
        /// </summary>
        public readonly GLenum MAX_ELEMENTS_VERTICES = 0x80E8;
        /// <summary>
        /// MAX_ELEMENTS_INDICES
        /// </summary>
        public readonly GLenum MAX_ELEMENTS_INDICES = 0x80E9;
        /// <summary>
        /// MAX_TEXTURE_LOD_BIAS
        /// </summary>
        public readonly GLenum MAX_TEXTURE_LOD_BIAS = 0x84FD;
        /// <summary>
        /// MAX_FRAGMENT_UNIFORM_COMPONENTS
        /// </summary>
        public readonly GLenum MAX_FRAGMENT_UNIFORM_COMPONENTS = 0x8B49;
        /// <summary>
        /// MAX_VERTEX_UNIFORM_COMPONENTS
        /// </summary>
        public readonly GLenum MAX_VERTEX_UNIFORM_COMPONENTS = 0x8B4A;
        /// <summary>
        /// MAX_ARRAY_TEXTURE_LAYERS
        /// </summary>
        public readonly GLenum MAX_ARRAY_TEXTURE_LAYERS = 0x88FF;
        /// <summary>
        /// MIN_PROGRAM_TEXEL_OFFSET
        /// </summary>
        public readonly GLenum MIN_PROGRAM_TEXEL_OFFSET = 0x8904;
        /// <summary>
        /// MAX_PROGRAM_TEXEL_OFFSET
        /// </summary>
        public readonly GLenum MAX_PROGRAM_TEXEL_OFFSET = 0x8905;
        /// <summary>
        /// MAX_VARYING_COMPONENTS
        /// </summary>
        public readonly GLenum MAX_VARYING_COMPONENTS = 0x8B4B;
        /// <summary>
        /// FRAGMENT_SHADER_DERIVATIVE_HINT
        /// </summary>
        public readonly GLenum FRAGMENT_SHADER_DERIVATIVE_HINT = 0x8B8B;
        /// <summary>
        /// RASTERIZER_DISCARD
        /// </summary>
        public readonly GLenum RASTERIZER_DISCARD = 0x8C89;
        /// <summary>
        /// VERTEX_ARRAY_BINDING
        /// </summary>
        public readonly GLenum VERTEX_ARRAY_BINDING = 0x85B5;
        /// <summary>
        /// MAX_VERTEX_OUTPUT_COMPONENTS
        /// </summary>
        public readonly GLenum MAX_VERTEX_OUTPUT_COMPONENTS = 0x9122;
        /// <summary>
        /// MAX_FRAGMENT_INPUT_COMPONENTS
        /// </summary>
        public readonly GLenum MAX_FRAGMENT_INPUT_COMPONENTS = 0x9125;
        /// <summary>
        /// MAX_SERVER_WAIT_TIMEOUT
        /// </summary>
        public readonly GLenum MAX_SERVER_WAIT_TIMEOUT = 0x9111;
        /// <summary>
        /// MAX_ELEMENT_INDEX
        /// </summary>
        public readonly GLenum MAX_ELEMENT_INDEX = 0x8D6B;

        // Textures
        /// <summary>
        /// RED
        /// </summary>
        public readonly GLenum RED = 0x1903;
        /// <summary>
        /// RGB8
        /// </summary>
        public readonly GLenum RGB8 = 0x8051;
        /// <summary>
        /// RGBA8
        /// </summary>
        public readonly GLenum RGBA8 = 0x8058;
        /// <summary>
        /// RGB10_A2
        /// </summary>
        public readonly GLenum RGB10_A2 = 0x8059;
        /// <summary>
        /// TEXTURE_3D
        /// </summary>
        public readonly GLenum TEXTURE_3D = 0x806F;
        /// <summary>
        /// TEXTURE_WRAP_R
        /// </summary>
        public readonly GLenum TEXTURE_WRAP_R = 0x8072;
        /// <summary>
        /// TEXTURE_MIN_LOD
        /// </summary>
        public readonly GLenum TEXTURE_MIN_LOD = 0x813A;
        /// <summary>
        /// TEXTURE_MAX_LOD
        /// </summary>
        public readonly GLenum TEXTURE_MAX_LOD = 0x813B;
        /// <summary>
        /// TEXTURE_BASE_LEVEL
        /// </summary>
        public readonly GLenum TEXTURE_BASE_LEVEL = 0x813C;
        /// <summary>
        /// TEXTURE_MAX_LEVEL
        /// </summary>
        public readonly GLenum TEXTURE_MAX_LEVEL = 0x813D;
        /// <summary>
        /// TEXTURE_COMPARE_MODE
        /// </summary>
        public readonly GLenum TEXTURE_COMPARE_MODE = 0x884C;
        /// <summary>
        /// TEXTURE_COMPARE_FUNC
        /// </summary>
        public readonly GLenum TEXTURE_COMPARE_FUNC = 0x884D;
        /// <summary>
        /// SRGB
        /// </summary>
        public readonly GLenum SRGB = 0x8C40;
        /// <summary>
        /// SRGB8
        /// </summary>
        public readonly GLenum SRGB8 = 0x8C41;
        /// <summary>
        /// SRGB8_ALPHA8
        /// </summary>
        public readonly GLenum SRGB8_ALPHA8 = 0x8C43;
        /// <summary>
        /// COMPARE_REF_TO_TEXTURE
        /// </summary>
        public readonly GLenum COMPARE_REF_TO_TEXTURE = 0x884E;
        /// <summary>
        /// RGBA32F
        /// </summary>
        public readonly GLenum RGBA32F = 0x8814;
        /// <summary>
        /// RGB32F
        /// </summary>
        public readonly GLenum RGB32F = 0x8815;
        /// <summary>
        /// RGBA16F
        /// </summary>
        public readonly GLenum RGBA16F = 0x881A;
        /// <summary>
        /// RGB16F
        /// </summary>
        public readonly GLenum RGB16F = 0x881B;
        /// <summary>
        /// TEXTURE_2D_ARRAY
        /// </summary>
        public readonly GLenum TEXTURE_2D_ARRAY = 0x8C1A;
        /// <summary>
        /// TEXTURE_BINDING_2D_ARRAY
        /// </summary>
        public readonly GLenum TEXTURE_BINDING_2D_ARRAY = 0x8C1D;
        /// <summary>
        /// R11F_G11F_B10F
        /// </summary>
        public readonly GLenum R11F_G11F_B10F = 0x8C3A;
        /// <summary>
        /// RGB9_E5
        /// </summary>
        public readonly GLenum RGB9_E5 = 0x8C3D;
        /// <summary>
        /// RGBA32UI
        /// </summary>
        public readonly GLenum RGBA32UI = 0x8D70;
        /// <summary>
        /// RGB32UI
        /// </summary>
        public readonly GLenum RGB32UI = 0x8D71;
        /// <summary>
        /// RGBA16UI
        /// </summary>
        public readonly GLenum RGBA16UI = 0x8D76;
        /// <summary>
        /// RGB16UI
        /// </summary>
        public readonly GLenum RGB16UI = 0x8D77;
        /// <summary>
        /// RGBA8UI
        /// </summary>
        public readonly GLenum RGBA8UI = 0x8D7C;
        /// <summary>
        /// RGB8UI
        /// </summary>
        public readonly GLenum RGB8UI = 0x8D7D;
        /// <summary>
        /// RGBA32I
        /// </summary>
        public readonly GLenum RGBA32I = 0x8D82;
        /// <summary>
        /// RGB32I
        /// </summary>
        public readonly GLenum RGB32I = 0x8D83;
        /// <summary>
        /// RGBA16I
        /// </summary>
        public readonly GLenum RGBA16I = 0x8D88;
        /// <summary>
        /// RGB16I
        /// </summary>
        public readonly GLenum RGB16I = 0x8D89;
        /// <summary>
        /// RGBA8I
        /// </summary>
        public readonly GLenum RGBA8I = 0x8D8E;
        /// <summary>
        /// RGB8I
        /// </summary>
        public readonly GLenum RGB8I = 0x8D8F;
        /// <summary>
        /// RED_INTEGER
        /// </summary>
        public readonly GLenum RED_INTEGER = 0x8D94;
        /// <summary>
        /// RGB_INTEGER
        /// </summary>
        public readonly GLenum RGB_INTEGER = 0x8D98;
        /// <summary>
        /// RGBA_INTEGER
        /// </summary>
        public readonly GLenum RGBA_INTEGER = 0x8D99;
        /// <summary>
        /// R8
        /// </summary>
        public readonly GLenum R8 = 0x8229;
        /// <summary>
        /// RG8
        /// </summary>
        public readonly GLenum RG8 = 0x822B;
        /// <summary>
        /// R16F
        /// </summary>
        public readonly GLenum R16F = 0x822D;
        /// <summary>
        /// R32F
        /// </summary>
        public readonly GLenum R32F = 0x822E;
        /// <summary>
        /// RG16F
        /// </summary>
        public readonly GLenum RG16F = 0x822F;
        /// <summary>
        /// RG32F
        /// </summary>
        public readonly GLenum RG32F = 0x8230;
        /// <summary>
        /// R8I
        /// </summary>
        public readonly GLenum R8I = 0x8231;
        /// <summary>
        /// R8UI
        /// </summary>
        public readonly GLenum R8UI = 0x8232;
        /// <summary>
        /// R16I
        /// </summary>
        public readonly GLenum R16I = 0x8233;
        /// <summary>
        /// R16UI
        /// </summary>
        public readonly GLenum R16UI = 0x8234;
        /// <summary>
        /// R32I
        /// </summary>
        public readonly GLenum R32I = 0x8235;
        /// <summary>
        /// R32UI
        /// </summary>
        public readonly GLenum R32UI = 0x8236;
        /// <summary>
        /// RG8I
        /// </summary>
        public readonly GLenum RG8I = 0x8237;
        /// <summary>
        /// RG8UI
        /// </summary>
        public readonly GLenum RG8UI = 0x8238;
        /// <summary>
        /// RG16I
        /// </summary>
        public readonly GLenum RG16I = 0x8239;
        /// <summary>
        /// RG16UI
        /// </summary>
        public readonly GLenum RG16UI = 0x823A;
        /// <summary>
        /// RG32I
        /// </summary>
        public readonly GLenum RG32I = 0x823B;
        /// <summary>
        /// RG32UI
        /// </summary>
        public readonly GLenum RG32UI = 0x823C;
        /// <summary>
        /// R8_SNORM
        /// </summary>
        public readonly GLenum R8_SNORM = 0x8F94;
        /// <summary>
        /// RG8_SNORM
        /// </summary>
        public readonly GLenum RG8_SNORM = 0x8F95;
        /// <summary>
        /// RGB8_SNORM
        /// </summary>
        public readonly GLenum RGB8_SNORM = 0x8F96;
        /// <summary>
        /// RGBA8_SNORM
        /// </summary>
        public readonly GLenum RGBA8_SNORM = 0x8F97;
        /// <summary>
        /// RGB10_A2UI
        /// </summary>
        public readonly GLenum RGB10_A2UI = 0x906F;
        /// <summary>
        /// TEXTURE_IMMUTABLE_FORMAT
        /// </summary>
        public readonly GLenum TEXTURE_IMMUTABLE_FORMAT = 0x912F;
        /// <summary>
        /// TEXTURE_IMMUTABLE_LEVELS
        /// </summary>
        public readonly GLenum TEXTURE_IMMUTABLE_LEVELS = 0x82DF;

        // Pixel types
        /// <summary>
        /// UNSIGNED_INT_2_10_10_10_REV
        /// </summary>
        public readonly GLenum UNSIGNED_INT_2_10_10_10_REV = 0x8368;
        /// <summary>
        /// UNSIGNED_INT_10F_11F_11F_REV
        /// </summary>
        public readonly GLenum UNSIGNED_INT_10F_11F_11F_REV = 0x8C3B;
        /// <summary>
        /// UNSIGNED_INT_5_9_9_9_REV
        /// </summary>
        public readonly GLenum UNSIGNED_INT_5_9_9_9_REV = 0x8C3E;
        /// <summary>
        /// FLOAT_32_UNSIGNED_INT_24_8_REV
        /// </summary>
        public readonly GLenum FLOAT_32_UNSIGNED_INT_24_8_REV = 0x8DAD;
        /// <summary>
        /// UNSIGNED_INT_24_8
        /// </summary>
        public readonly GLenum UNSIGNED_INT_24_8 = 0x84FA;
        /// <summary>
        /// HALF_FLOAT
        /// </summary>
        public readonly GLenum HALF_FLOAT = 0x140B;
        /// <summary>
        /// RG
        /// </summary>
        public readonly GLenum RG = 0x8227;
        /// <summary>
        /// RG_INTEGER
        /// </summary>
        public readonly GLenum RG_INTEGER = 0x8228;
        /// <summary>
        /// INT_2_10_10_10_REV
        /// </summary>
        public readonly GLenum INT_2_10_10_10_REV = 0x8D9F;

        // Queries
        /// <summary>
        /// CURRENT_QUERY
        /// </summary>
        public readonly GLenum CURRENT_QUERY = 0x8865;
        /// <summary>
        /// QUERY_RESULT
        /// </summary>
        public readonly GLenum QUERY_RESULT = 0x8866;
        /// <summary>
        /// QUERY_RESULT_AVAILABLE
        /// </summary>
        public readonly GLenum QUERY_RESULT_AVAILABLE = 0x8867;
        /// <summary>
        /// ANY_SAMPLES_PASSED
        /// </summary>
        public readonly GLenum ANY_SAMPLES_PASSED = 0x8C2F;
        /// <summary>
        /// ANY_SAMPLES_PASSED_CONSERVATIVE
        /// </summary>
        public readonly GLenum ANY_SAMPLES_PASSED_CONSERVATIVE = 0x8D6A;

        // Draw buffers
        /// <summary>
        /// MAX_DRAW_BUFFERS
        /// </summary>
        public readonly GLenum MAX_DRAW_BUFFERS = 0x8824;
        /// <summary>
        /// DRAW_BUFFER0
        /// </summary>
        public readonly GLenum DRAW_BUFFER0 = 0x8825;
        /// <summary>
        /// DRAW_BUFFER1
        /// </summary>
        public readonly GLenum DRAW_BUFFER1 = 0x8826;
        /// <summary>
        /// DRAW_BUFFER2
        /// </summary>
        public readonly GLenum DRAW_BUFFER2 = 0x8827;
        /// <summary>
        /// DRAW_BUFFER3
        /// </summary>
        public readonly GLenum DRAW_BUFFER3 = 0x8828;
        /// <summary>
        /// DRAW_BUFFER4
        /// </summary>
        public readonly GLenum DRAW_BUFFER4 = 0x8829;
        /// <summary>
        /// DRAW_BUFFER5
        /// </summary>
        public readonly GLenum DRAW_BUFFER5 = 0x882A;
        /// <summary>
        /// DRAW_BUFFER6
        /// </summary>
        public readonly GLenum DRAW_BUFFER6 = 0x882B;
        /// <summary>
        /// DRAW_BUFFER7
        /// </summary>
        public readonly GLenum DRAW_BUFFER7 = 0x882C;
        /// <summary>
        /// DRAW_BUFFER8
        /// </summary>
        public readonly GLenum DRAW_BUFFER8 = 0x882D;
        /// <summary>
        /// DRAW_BUFFER9
        /// </summary>
        public readonly GLenum DRAW_BUFFER9 = 0x882E;
        /// <summary>
        /// DRAW_BUFFER10
        /// </summary>
        public readonly GLenum DRAW_BUFFER10 = 0x882F;
        /// <summary>
        /// DRAW_BUFFER11
        /// </summary>
        public readonly GLenum DRAW_BUFFER11 = 0x8830;
        /// <summary>
        /// DRAW_BUFFER12
        /// </summary>
        public readonly GLenum DRAW_BUFFER12 = 0x8831;
        /// <summary>
        /// DRAW_BUFFER13
        /// </summary>
        public readonly GLenum DRAW_BUFFER13 = 0x8832;
        /// <summary>
        /// DRAW_BUFFER14
        /// </summary>
        public readonly GLenum DRAW_BUFFER14 = 0x8833;
        /// <summary>
        /// DRAW_BUFFER15
        /// </summary>
        public readonly GLenum DRAW_BUFFER15 = 0x8834;
        /// <summary>
        /// MAX_COLOR_ATTACHMENTS
        /// </summary>
        public readonly GLenum MAX_COLOR_ATTACHMENTS = 0x8CDF;
        /// <summary>
        /// COLOR_ATTACHMENT1
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT1 = 0x8CE1;
        /// <summary>
        /// COLOR_ATTACHMENT2
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT2 = 0x8CE2;
        /// <summary>
        /// COLOR_ATTACHMENT3
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT3 = 0x8CE3;
        /// <summary>
        /// COLOR_ATTACHMENT4
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT4 = 0x8CE4;
        /// <summary>
        /// COLOR_ATTACHMENT5
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT5 = 0x8CE5;
        /// <summary>
        /// COLOR_ATTACHMENT6
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT6 = 0x8CE6;
        /// <summary>
        /// COLOR_ATTACHMENT7
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT7 = 0x8CE7;
        /// <summary>
        /// COLOR_ATTACHMENT8
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT8 = 0x8CE8;
        /// <summary>
        /// COLOR_ATTACHMENT9
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT9 = 0x8CE9;
        /// <summary>
        /// COLOR_ATTACHMENT10
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT10 = 0x8CEA;
        /// <summary>
        /// COLOR_ATTACHMENT11
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT11 = 0x8CEB;
        /// <summary>
        /// COLOR_ATTACHMENT12
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT12 = 0x8CEC;
        /// <summary>
        /// COLOR_ATTACHMENT13
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT13 = 0x8CED;
        /// <summary>
        /// COLOR_ATTACHMENT14
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT14 = 0x8CEE;
        /// <summary>
        /// COLOR_ATTACHMENT15
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT15 = 0x8CEF;

        //  Samplers
        /// <summary>
        /// SAMPLER_3D
        /// </summary>
        public readonly GLenum SAMPLER_3D = 0x8B5F;
        /// <summary>
        /// SAMPLER_2D_SHADOW
        /// </summary>
        public readonly GLenum SAMPLER_2D_SHADOW = 0x8B62;
        /// <summary>
        /// SAMPLER_2D_ARRAY
        /// </summary>
        public readonly GLenum SAMPLER_2D_ARRAY = 0x8DC1;
        /// <summary>
        /// SAMPLER_2D_ARRAY_SHADOW
        /// </summary>
        public readonly GLenum SAMPLER_2D_ARRAY_SHADOW = 0x8DC4;
        /// <summary>
        /// SAMPLER_CUBE_SHADOW
        /// </summary>
        public readonly GLenum SAMPLER_CUBE_SHADOW = 0x8DC5;
        /// <summary>
        /// INT_SAMPLER_2D
        /// </summary>
        public readonly GLenum INT_SAMPLER_2D = 0x8DCA;
        /// <summary>
        /// INT_SAMPLER_3D
        /// </summary>
        public readonly GLenum INT_SAMPLER_3D = 0x8DCB;
        /// <summary>
        /// INT_SAMPLER_CUBE
        /// </summary>
        public readonly GLenum INT_SAMPLER_CUBE = 0x8DCC;
        /// <summary>
        /// INT_SAMPLER_2D_ARRAY
        /// </summary>
        public readonly GLenum INT_SAMPLER_2D_ARRAY = 0x8DCF;
        /// <summary>
        /// UNSIGNED_INT_SAMPLER_2D
        /// </summary>
        public readonly GLenum UNSIGNED_INT_SAMPLER_2D = 0x8DD2;
        /// <summary>
        /// UNSIGNED_INT_SAMPLER_3D
        /// </summary>
        public readonly GLenum UNSIGNED_INT_SAMPLER_3D = 0x8DD3;
        /// <summary>
        /// UNSIGNED_INT_SAMPLER_CUBE
        /// </summary>
        public readonly GLenum UNSIGNED_INT_SAMPLER_CUBE = 0x8DD4;
        /// <summary>
        /// UNSIGNED_INT_SAMPLER_2D_ARRAY
        /// </summary>
        public readonly GLenum UNSIGNED_INT_SAMPLER_2D_ARRAY = 0x8DD7;
        /// <summary>
        /// MAX_SAMPLES
        /// </summary>
        public readonly GLenum MAX_SAMPLES = 0x8D57;
        /// <summary>
        /// SAMPLER_BINDING
        /// </summary>
        public readonly GLenum SAMPLER_BINDING = 0x8919;

        // Buffers
        /// <summary>
        /// PIXEL_PACK_BUFFER
        /// </summary>
        public readonly GLenum PIXEL_PACK_BUFFER = 0x88EB;
        /// <summary>
        /// PIXEL_UNPACK_BUFFER
        /// </summary>
        public readonly GLenum PIXEL_UNPACK_BUFFER = 0x88EC;
        /// <summary>
        /// PIXEL_PACK_BUFFER_BINDING
        /// </summary>
        public readonly GLenum PIXEL_PACK_BUFFER_BINDING = 0x88ED;
        /// <summary>
        /// PIXEL_UNPACK_BUFFER_BINDING
        /// </summary>
        public readonly GLenum PIXEL_UNPACK_BUFFER_BINDING = 0x88EF;
        /// <summary>
        /// COPY_READ_BUFFER
        /// </summary>
        public readonly GLenum COPY_READ_BUFFER = 0x8F36;
        /// <summary>
        /// COPY_WRITE_BUFFER
        /// </summary>
        public readonly GLenum COPY_WRITE_BUFFER = 0x8F37;
        /// <summary>
        /// COPY_READ_BUFFER_BINDING
        /// </summary>
        public readonly GLenum COPY_READ_BUFFER_BINDING = 0x8F36;
        /// <summary>
        /// COPY_WRITE_BUFFER_BINDING
        /// </summary>
        public readonly GLenum COPY_WRITE_BUFFER_BINDING = 0x8F37;

        // Data types
        /// <summary>
        /// FLOAT_MAT2x3
        /// </summary>
        public readonly GLenum FLOAT_MAT2x3 = 0x8B65;
        /// <summary>
        /// FLOAT_MAT2x4
        /// </summary>
        public readonly GLenum FLOAT_MAT2x4 = 0x8B66;
        /// <summary>
        /// FLOAT_MAT3x2
        /// </summary>
        public readonly GLenum FLOAT_MAT3x2 = 0x8B67;
        /// <summary>
        /// FLOAT_MAT3x4
        /// </summary>
        public readonly GLenum FLOAT_MAT3x4 = 0x8B68;
        /// <summary>
        /// FLOAT_MAT4x2
        /// </summary>
        public readonly GLenum FLOAT_MAT4x2 = 0x8B69;
        /// <summary>
        /// FLOAT_MAT4x3
        /// </summary>
        public readonly GLenum FLOAT_MAT4x3 = 0x8B6A;
        /// <summary>
        /// UNSIGNED_INT_VEC2
        /// </summary>
        public readonly GLenum UNSIGNED_INT_VEC2 = 0x8DC6;
        /// <summary>
        /// UNSIGNED_INT_VEC3
        /// </summary>
        public readonly GLenum UNSIGNED_INT_VEC3 = 0x8DC7;
        /// <summary>
        /// UNSIGNED_INT_VEC4
        /// </summary>
        public readonly GLenum UNSIGNED_INT_VEC4 = 0x8DC8;
        /// <summary>
        /// UNSIGNED_NORMALIZED
        /// </summary>
        public readonly GLenum UNSIGNED_NORMALIZED = 0x8C17;
        /// <summary>
        /// SIGNED_NORMALIZED
        /// </summary>
        public readonly GLenum SIGNED_NORMALIZED = 0x8F9C;

        // Vertex attributes
        /// <summary>
        /// VERTEX_ATTRIB_ARRAY_INTEGER
        /// </summary>
        public readonly GLenum VERTEX_ATTRIB_ARRAY_INTEGER = 0x88FD;
        /// <summary>
        /// VERTEX_ATTRIB_ARRAY_DIVISOR
        /// </summary>
        public readonly GLenum VERTEX_ATTRIB_ARRAY_DIVISOR = 0x88FE;

        // Transform feedback
        /// <summary>
        /// TRANSFORM_FEEDBACK_BUFFER_MODE
        /// </summary>
        public readonly GLenum TRANSFORM_FEEDBACK_BUFFER_MODE = 0x8C7F;
        /// <summary>
        /// MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS
        /// </summary>
        public readonly GLenum MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = 0x8C80;
        /// <summary>
        /// TRANSFORM_FEEDBACK_VARYINGS
        /// </summary>
        public readonly GLenum TRANSFORM_FEEDBACK_VARYINGS = 0x8C83;
        /// <summary>
        /// TRANSFORM_FEEDBACK_BUFFER_START
        /// </summary>
        public readonly GLenum TRANSFORM_FEEDBACK_BUFFER_START = 0x8C84;
        /// <summary>
        /// TRANSFORM_FEEDBACK_BUFFER_SIZE
        /// </summary>
        public readonly GLenum TRANSFORM_FEEDBACK_BUFFER_SIZE = 0x8C85;
        /// <summary>
        /// TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN
        /// </summary>
        public readonly GLenum TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN = 0x8C88;
        /// <summary>
        /// MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS
        /// </summary>
        public readonly GLenum MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = 0x8C8A;
        /// <summary>
        /// MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS
        /// </summary>
        public readonly GLenum MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = 0x8C8B;
        /// <summary>
        /// INTERLEAVED_ATTRIBS
        /// </summary>
        public readonly GLenum INTERLEAVED_ATTRIBS = 0x8C8C;
        /// <summary>
        /// SEPARATE_ATTRIBS
        /// </summary>
        public readonly GLenum SEPARATE_ATTRIBS = 0x8C8D;
        /// <summary>
        /// TRANSFORM_FEEDBACK_BUFFER
        /// </summary>
        public readonly GLenum TRANSFORM_FEEDBACK_BUFFER = 0x8C8E;
        /// <summary>
        /// TRANSFORM_FEEDBACK_BUFFER_BINDING
        /// </summary>
        public readonly GLenum TRANSFORM_FEEDBACK_BUFFER_BINDING = 0x8C8F;
        /// <summary>
        /// TRANSFORM_FEEDBACK
        /// </summary>
        public readonly GLenum TRANSFORM_FEEDBACK = 0x8E22;
        /// <summary>
        /// TRANSFORM_FEEDBACK_PAUSED
        /// </summary>
        public readonly GLenum TRANSFORM_FEEDBACK_PAUSED = 0x8E23;
        /// <summary>
        /// TRANSFORM_FEEDBACK_ACTIVE
        /// </summary>
        public readonly GLenum TRANSFORM_FEEDBACK_ACTIVE = 0x8E24;
        /// <summary>
        /// TRANSFORM_FEEDBACK_BINDING
        /// </summary>
        public readonly GLenum TRANSFORM_FEEDBACK_BINDING = 0x8E25;

        // Framebuffers and renderbuffers
        /// <summary>
        /// FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING
        /// </summary>
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING = 0x8210;
        /// <summary>
        /// FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE
        /// </summary>
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE = 0x8211;
        /// <summary>
        /// FRAMEBUFFER_ATTACHMENT_RED_SIZE
        /// </summary>
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_RED_SIZE = 0x8212;
        /// <summary>
        /// FRAMEBUFFER_ATTACHMENT_GREEN_SIZE
        /// </summary>
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_GREEN_SIZE = 0x8213;
        /// <summary>
        /// FRAMEBUFFER_ATTACHMENT_BLUE_SIZE
        /// </summary>
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_BLUE_SIZE = 0x8214;
        /// <summary>
        /// FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE
        /// </summary>
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE = 0x8215;
        /// <summary>
        /// FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE
        /// </summary>
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE = 0x8216;
        /// <summary>
        /// FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE
        /// </summary>
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE = 0x8217;
        /// <summary>
        /// FRAMEBUFFER_DEFAULT
        /// </summary>
        public readonly GLenum FRAMEBUFFER_DEFAULT = 0x8218;
        /// <summary>
        /// DEPTH24_STENCIL8
        /// </summary>
        public readonly GLenum DEPTH24_STENCIL8 = 0x88F0;
        /// <summary>
        /// DRAW_FRAMEBUFFER_BINDING
        /// </summary>
        public readonly GLenum DRAW_FRAMEBUFFER_BINDING = 0x8CA6;
        /// <summary>
        /// READ_FRAMEBUFFER
        /// </summary>
        public readonly GLenum READ_FRAMEBUFFER = 0x8CA8;
        /// <summary>
        /// DRAW_FRAMEBUFFER
        /// </summary>
        public readonly GLenum DRAW_FRAMEBUFFER = 0x8CA9;
        /// <summary>
        /// READ_FRAMEBUFFER_BINDING
        /// </summary>
        public readonly GLenum READ_FRAMEBUFFER_BINDING = 0x8CAA;
        /// <summary>
        /// RENDERBUFFER_SAMPLES
        /// </summary>
        public readonly GLenum RENDERBUFFER_SAMPLES = 0x8CAB;
        /// <summary>
        /// FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER
        /// </summary>
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = 0x8CD4;
        /// <summary>
        /// FRAMEBUFFER_INCOMPLETE_MULTISAMPLE
        /// </summary>
        public readonly GLenum FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = 0x8D56;

        // Uniforms
        /// <summary>
        /// UNIFORM_BUFFER
        /// </summary>
        public readonly GLenum UNIFORM_BUFFER = 0x8A11;
        /// <summary>
        /// UNIFORM_BUFFER_BINDING
        /// </summary>
        public readonly GLenum UNIFORM_BUFFER_BINDING = 0x8A28;
        /// <summary>
        /// UNIFORM_BUFFER_START
        /// </summary>
        public readonly GLenum UNIFORM_BUFFER_START = 0x8A29;
        /// <summary>
        /// UNIFORM_BUFFER_SIZE
        /// </summary>
        public readonly GLenum UNIFORM_BUFFER_SIZE = 0x8A2A;
        /// <summary>
        /// MAX_VERTEX_UNIFORM_BLOCKS
        /// </summary>
        public readonly GLenum MAX_VERTEX_UNIFORM_BLOCKS = 0x8A2B;
        /// <summary>
        /// MAX_FRAGMENT_UNIFORM_BLOCKS
        /// </summary>
        public readonly GLenum MAX_FRAGMENT_UNIFORM_BLOCKS = 0x8A2D;
        /// <summary>
        /// MAX_COMBINED_UNIFORM_BLOCKS
        /// </summary>
        public readonly GLenum MAX_COMBINED_UNIFORM_BLOCKS = 0x8A2E;
        /// <summary>
        /// MAX_UNIFORM_BUFFER_BINDINGS
        /// </summary>
        public readonly GLenum MAX_UNIFORM_BUFFER_BINDINGS = 0x8A2F;
        /// <summary>
        /// MAX_UNIFORM_BLOCK_SIZE
        /// </summary>
        public readonly GLenum MAX_UNIFORM_BLOCK_SIZE = 0x8A30;
        /// <summary>
        /// MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS
        /// </summary>
        public readonly GLenum MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = 0x8A31;
        /// <summary>
        /// MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS
        /// </summary>
        public readonly GLenum MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = 0x8A33;
        /// <summary>
        /// UNIFORM_BUFFER_OFFSET_ALIGNMENT
        /// </summary>
        public readonly GLenum UNIFORM_BUFFER_OFFSET_ALIGNMENT = 0x8A34;
        /// <summary>
        /// ACTIVE_UNIFORM_BLOCKS
        /// </summary>
        public readonly GLenum ACTIVE_UNIFORM_BLOCKS = 0x8A36;
        /// <summary>
        /// UNIFORM_TYPE
        /// </summary>
        public readonly GLenum UNIFORM_TYPE = 0x8A37;
        /// <summary>
        /// UNIFORM_SIZE
        /// </summary>
        public readonly GLenum UNIFORM_SIZE = 0x8A38;
        /// <summary>
        /// UNIFORM_BLOCK_INDEX
        /// </summary>
        public readonly GLenum UNIFORM_BLOCK_INDEX = 0x8A3A;
        /// <summary>
        /// UNIFORM_OFFSET
        /// </summary>
        public readonly GLenum UNIFORM_OFFSET = 0x8A3B;
        /// <summary>
        /// UNIFORM_ARRAY_STRIDE
        /// </summary>
        public readonly GLenum UNIFORM_ARRAY_STRIDE = 0x8A3C;
        /// <summary>
        /// UNIFORM_MATRIX_STRIDE
        /// </summary>
        public readonly GLenum UNIFORM_MATRIX_STRIDE = 0x8A3D;
        /// <summary>
        /// UNIFORM_IS_ROW_MAJOR
        /// </summary>
        public readonly GLenum UNIFORM_IS_ROW_MAJOR = 0x8A3E;
        /// <summary>
        /// UNIFORM_BLOCK_BINDING
        /// </summary>
        public readonly GLenum UNIFORM_BLOCK_BINDING = 0x8A3F;
        /// <summary>
        /// UNIFORM_BLOCK_DATA_SIZE
        /// </summary>
        public readonly GLenum UNIFORM_BLOCK_DATA_SIZE = 0x8A40;
        /// <summary>
        /// UNIFORM_BLOCK_ACTIVE_UNIFORMS
        /// </summary>
        public readonly GLenum UNIFORM_BLOCK_ACTIVE_UNIFORMS = 0x8A42;
        /// <summary>
        /// UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES
        /// </summary>
        public readonly GLenum UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES = 0x8A43;
        /// <summary>
        /// UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER
        /// </summary>
        public readonly GLenum UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER = 0x8A44;
        /// <summary>
        /// UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER
        /// </summary>
        public readonly GLenum UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = 0x8A46;

        // Sync objects
        /// <summary>
        /// OBJECT_TYPE
        /// </summary>
        public readonly GLenum OBJECT_TYPE = 0x9112;
        /// <summary>
        /// SYNC_CONDITION
        /// </summary>
        public readonly GLenum SYNC_CONDITION = 0x9113;
        /// <summary>
        /// SYNC_STATUS
        /// </summary>
        public readonly GLenum SYNC_STATUS = 0x9114;
        /// <summary>
        /// SYNC_FLAGS
        /// </summary>
        public readonly GLenum SYNC_FLAGS = 0x9115;
        /// <summary>
        /// SYNC_FENCE
        /// </summary>
        public readonly GLenum SYNC_FENCE = 0x9116;
        /// <summary>
        /// SYNC_GPU_COMMANDS_COMPLETE
        /// </summary>
        public readonly GLenum SYNC_GPU_COMMANDS_COMPLETE = 0x9117;
        /// <summary>
        /// UNSIGNALED
        /// </summary>
        public readonly GLenum UNSIGNALED = 0x9118;
        /// <summary>
        /// SIGNALED
        /// </summary>
        public readonly GLenum SIGNALED = 0x9119;
        /// <summary>
        /// ALREADY_SIGNALED
        /// </summary>
        public readonly GLenum ALREADY_SIGNALED = 0x911A;
        /// <summary>
        /// TIMEOUT_EXPIRED
        /// </summary>
        public readonly GLenum TIMEOUT_EXPIRED = 0x911B;
        /// <summary>
        /// CONDITION_SATISFIED
        /// </summary>
        public readonly GLenum CONDITION_SATISFIED = 0x911C;
        /// <summary>
        /// WAIT_FAILED
        /// </summary>
        public readonly GLenum WAIT_FAILED = 0x911D;
        /// <summary>
        /// SYNC_FLUSH_COMMANDS_BIT
        /// </summary>
        public readonly GLenum SYNC_FLUSH_COMMANDS_BIT = 0x00000001;

        // Miscellaneous constants
        /// <summary>
        /// COLOR
        /// </summary>
        public readonly GLenum COLOR = 0x1800;
        /// <summary>
        /// DEPTH
        /// </summary>
        public readonly GLenum DEPTH = 0x1801;
        /// <summary>
        /// STENCIL
        /// </summary>
        public readonly GLenum STENCIL = 0x1802;
        /// <summary>
        /// MIN
        /// </summary>
        public readonly GLenum MIN = 0x8007;
        /// <summary>
        /// MAX
        /// </summary>
        public readonly GLenum MAX = 0x8008;
        /// <summary>
        /// DEPTH_COMPONENT24
        /// </summary>
        public readonly GLenum DEPTH_COMPONENT24 = 0x81A6;
        /// <summary>
        /// STREAM_READ
        /// </summary>
        public readonly GLenum STREAM_READ = 0x88E1;
        /// <summary>
        /// STREAM_COPY
        /// </summary>
        public readonly GLenum STREAM_COPY = 0x88E2;
        /// <summary>
        /// STATIC_READ
        /// </summary>
        public readonly GLenum STATIC_READ = 0x88E5;
        /// <summary>
        /// STATIC_COPY
        /// </summary>
        public readonly GLenum STATIC_COPY = 0x88E6;
        /// <summary>
        /// DYNAMIC_READ
        /// </summary>
        public readonly GLenum DYNAMIC_READ = 0x88E9;
        /// <summary>
        /// DYNAMIC_COPY
        /// </summary>
        public readonly GLenum DYNAMIC_COPY = 0x88EA;
        /// <summary>
        /// DEPTH_COMPONENT32F
        /// </summary>
        public readonly GLenum DEPTH_COMPONENT32F = 0x8CAC;
        /// <summary>
        /// DEPTH32F_STENCIL8
        /// </summary>
        public readonly GLenum DEPTH32F_STENCIL8 = 0x8CAD;
        /// <summary>
        /// MAX_CLIENT_WAIT_TIMEOUT_WEBGL
        /// </summary>
        public readonly GLenum MAX_CLIENT_WAIT_TIMEOUT_WEBGL = 0x9247;

        /// <summary>
        /// INVALID_INDEX
        /// </summary>
        public readonly GLuint INVALID_INDEX = 0xFFFFFFFF;
        /// <summary>
        /// TIMEOUT_IGNORED
        /// </summary>
        public readonly GLint TIMEOUT_IGNORED = -1;

        // Constants defined in WebGL extensions

        // Constants defined in WebGL extensions
        /// <summary>
        /// Describes the frequency divisor used for instanced rendering.
        /// </summary>
        /// <summary>
        /// VERTEX_ATTRIB_ARRAY_DIVISOR_ANGLE
        /// </summary>
        public readonly GLenum VERTEX_ATTRIB_ARRAY_DIVISOR_ANGLE = 0x88FE;

        // WEBGL_debug_renderer_info
        /// <summary>
        /// Passed to getParameter to get the vendor string of the graphics driver.
        /// </summary>
        /// <summary>
        /// UNMASKED_VENDOR_WEBGL
        /// </summary>
        public readonly GLenum UNMASKED_VENDOR_WEBGL = 0x9245;
        /// <summary>
        /// Passed to getParameter to get the renderer string of the graphics driver.
        /// </summary>
        /// <summary>
        /// UNMASKED_RENDERER_WEBGL
        /// </summary>
        public readonly GLenum UNMASKED_RENDERER_WEBGL = 0x9246;

        // EXT_texture_filter_anisotropic
        /// <summary>
        /// Returns the maximum available anisotropy.
        /// </summary>
        /// <summary>
        /// MAX_TEXTURE_MAX_ANISOTROPY_EXT
        /// </summary>
        public readonly GLenum MAX_TEXTURE_MAX_ANISOTROPY_EXT = 0x84FF;
        /// <summary>
        /// Passed to texParameter to set the desired maximum anisotropy for a texture.
        /// </summary>
        /// <summary>
        /// TEXTURE_MAX_ANISOTROPY_EXT
        /// </summary>
        public readonly GLenum TEXTURE_MAX_ANISOTROPY_EXT = 0x84FE;

        // WEBGL_compressed_texture_s3tc
        /// <summary>
        /// A DXT1-compressed image in an RGB image format.
        /// </summary>
        /// <summary>
        /// COMPRESSED_RGB_S3TC_DXT1_EXT
        /// </summary>
        public readonly GLenum COMPRESSED_RGB_S3TC_DXT1_EXT = 0x83F0;
        /// <summary>
        /// A DXT1-compressed image in an RGB image format with an on/off alpha value.
        /// </summary>
        /// <summary>
        /// COMPRESSED_RGBA_S3TC_DXT1_EXT
        /// </summary>
        public readonly GLenum COMPRESSED_RGBA_S3TC_DXT1_EXT = 0x83F1;
        /// <summary>
        /// A DXT3-compressed image in an RGBA image format. Compared to a 32-bit RGBA texture, it offers 4:1 compression.
        /// </summary>
        /// <summary>
        /// COMPRESSED_RGBA_S3TC_DXT3_EXT
        /// </summary>
        public readonly GLenum COMPRESSED_RGBA_S3TC_DXT3_EXT = 0x83F2;
        /// <summary>
        /// A DXT5-compressed image in an RGBA image format. It also provides a 4:1 compression, but differs to the DXT3 compression in how the alpha compression is done.
        /// </summary>
        /// <summary>
        /// COMPRESSED_RGBA_S3TC_DXT5_EXT
        /// </summary>
        public readonly GLenum COMPRESSED_RGBA_S3TC_DXT5_EXT = 0x83F3;

        // WEBGL_compressed_texture_etc
        /// <summary>
        /// One-channel (red) unsigned format compression.
        /// </summary>
        /// <summary>
        /// COMPRESSED_R11_EAC
        /// </summary>
        public readonly GLenum COMPRESSED_R11_EAC = 0x9270;
        /// <summary>
        /// One-channel (red) signed format compression.
        /// </summary>
        /// <summary>
        /// COMPRESSED_SIGNED_R11_EAC
        /// </summary>
        public readonly GLenum COMPRESSED_SIGNED_R11_EAC = 0x9271;
        /// <summary>
        /// Two-channel (red and green) unsigned format compression.
        /// </summary>
        /// <summary>
        /// COMPRESSED_RG11_EAC
        /// </summary>
        public readonly GLenum COMPRESSED_RG11_EAC = 0x9272;
        /// <summary>
        /// Two-channel (red and green) signed format compression.
        /// </summary>
        /// <summary>
        /// COMPRESSED_SIGNED_RG11_EAC
        /// </summary>
        public readonly GLenum COMPRESSED_SIGNED_RG11_EAC = 0x9273;
        /// <summary>
        /// Compresses RGB8 data with no alpha channel.
        /// </summary>
        /// <summary>
        /// COMPRESSED_RGB8_ETC2
        /// </summary>
        public readonly GLenum COMPRESSED_RGB8_ETC2 = 0x9274;
        /// <summary>
        /// Compresses RGBA8 data. The RGB part is encoded the same as RGB_ETC2, but the alpha part is encoded separately.
        /// </summary>
        /// <summary>
        /// COMPRESSED_RGBA8_ETC2_EAC
        /// </summary>
        public readonly GLenum COMPRESSED_RGBA8_ETC2_EAC = 0x9275;
        /// <summary>
        /// Compresses sRGB8 data with no alpha channel.
        /// </summary>
        /// <summary>
        /// COMPRESSED_SRGB8_ETC2
        /// </summary>
        public readonly GLenum COMPRESSED_SRGB8_ETC2 = 0x9276;
        /// <summary>
        /// Compresses sRGBA8 data. The sRGB part is encoded the same as SRGB_ETC2, but the alpha part is encoded separately.
        /// </summary>
        /// <summary>
        /// COMPRESSED_SRGB8_ALPHA8_ETC2_EAC
        /// </summary>
        public readonly GLenum COMPRESSED_SRGB8_ALPHA8_ETC2_EAC = 0x9277;
        /// <summary>
        /// Similar to RGB8_ETC, but with ability to punch through the alpha channel, which means to make it completely opaque or transparent.
        /// </summary>
        /// <summary>
        /// COMPRESSED_RGB8_PUNCHTHROUGH_ALPHA1_ETC2
        /// </summary>
        public readonly GLenum COMPRESSED_RGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 0x9278;
        /// <summary>
        /// Similar to SRGB8_ETC, but with ability to punch through the alpha channel, which means to make it completely opaque or transparent.
        /// </summary>
        /// <summary>
        /// COMPRESSED_SRGB8_PUNCHTHROUGH_ALPHA1_ETC2
        /// </summary>
        public readonly GLenum COMPRESSED_SRGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 0x9279;

        // WEBGL_compressed_texture_pvrtc
        /// <summary>
        /// RGB compression in 4-bit mode. One block for each 4×4 pixels.
        /// </summary>
        /// <summary>
        /// COMPRESSED_RGB_PVRTC_4BPPV1_IMG
        /// </summary>
        public readonly GLenum COMPRESSED_RGB_PVRTC_4BPPV1_IMG = 0x8C00;
        /// <summary>
        /// RGBA compression in 4-bit mode. One block for each 4×4 pixels.
        /// </summary>
        /// <summary>
        /// COMPRESSED_RGBA_PVRTC_4BPPV1_IMG
        /// </summary>
        public readonly GLenum COMPRESSED_RGBA_PVRTC_4BPPV1_IMG = 0x8C02;
        /// <summary>
        /// RGB compression in 2-bit mode. One block for each 8×4 pixels.
        /// </summary>
        /// <summary>
        /// COMPRESSED_RGB_PVRTC_2BPPV1_IMG
        /// </summary>
        public readonly GLenum COMPRESSED_RGB_PVRTC_2BPPV1_IMG = 0x8C01;
        /// <summary>
        /// RGBA compression in 2-bit mode. One block for each 8×4 pixels.
        /// </summary>
        /// <summary>
        /// COMPRESSED_RGBA_PVRTC_2BPPV1_IMG
        /// </summary>
        public readonly GLenum COMPRESSED_RGBA_PVRTC_2BPPV1_IMG = 0x8C03;

        // WEBGL_compressed_texture_etc1
        /// <summary>
        /// Compresses 24-bit RGB data with no alpha channel.
        /// </summary>
        /// <summary>
        /// COMPRESSED_RGB_ETC1_WEBGL
        /// </summary>
        public readonly GLenum COMPRESSED_RGB_ETC1_WEBGL = 0x8D64;

        // WEBGL_depth_texture
        /// <summary>
        /// Unsigned integer type for 24-bit depth texture data.
        /// </summary>
        /// <summary>
        /// UNSIGNED_INT_24_8_WEBGL
        /// </summary>
        public readonly GLenum UNSIGNED_INT_24_8_WEBGL = 0x84FA;

        // OES_texture_half_float
        /// <summary>
        /// Half floating-point type (16-bit).
        /// </summary>
        /// <summary>
        /// HALF_FLOAT_OES
        /// </summary>
        public readonly GLenum HALF_FLOAT_OES = 0x8D61;

        // WEBGL_color_buffer_float
        /// <summary>
        /// RGBA 32-bit floating-point color-renderable format.
        /// </summary>
        /// <summary>
        /// RGBA32F_EXT
        /// </summary>
        public readonly GLenum RGBA32F_EXT = 0x8814;
        /// <summary>
        /// RGB 32-bit floating-point color-renderable format.
        /// </summary>
        /// <summary>
        /// RGB32F_EXT
        /// </summary>
        public readonly GLenum RGB32F_EXT = 0x8815;
        /// <summary>
        /// UNSIGNED_NORMALIZED_EXT	0x8C17	
        /// </summary>
        /// <summary>
        /// FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE_EXT
        /// </summary>
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE_EXT = 0x8211;

        // EXT_blend_minmax
        /// <summary>
        /// Produces the minimum color components of the source and destination colors.
        /// </summary>
        /// <summary>
        /// MIN_EXT
        /// </summary>
        public readonly GLenum MIN_EXT = 0x8007;
        /// <summary>
        /// Produces the maximum color components of the source and destination colors.
        /// </summary>
        /// <summary>
        /// MAX_EXT
        /// </summary>
        public readonly GLenum MAX_EXT = 0x8008;

        // EXT_sRGB
        /// <summary>
        /// Unsized sRGB format that leaves the precision up to the driver.
        /// </summary>
        /// <summary>
        /// SRGB_EXT
        /// </summary>
        public readonly GLenum SRGB_EXT = 0x8C40;
        /// <summary>
        /// Unsized sRGB format with unsized alpha component.
        /// </summary>
        /// <summary>
        /// SRGB_ALPHA_EXT
        /// </summary>
        public readonly GLenum SRGB_ALPHA_EXT = 0x8C42;
        /// <summary>
        /// Sized (8-bit) sRGB and alpha formats.
        /// </summary>
        /// <summary>
        /// SRGB8_ALPHA8_EXT
        /// </summary>
        public readonly GLenum SRGB8_ALPHA8_EXT = 0x8C43;
        /// <summary>
        /// Returns the framebuffer color encoding.
        /// </summary>
        /// <summary>
        /// FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING_EXT
        /// </summary>
        public readonly GLenum FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING_EXT = 0x8210;

        // OES_standard_derivatives
        /// <summary>
        /// Indicates the accuracy of the derivative calculation for the GLSL built-in functions: dFdx, dFdy, and fwidth.
        /// </summary>
        /// <summary>
        /// FRAGMENT_SHADER_DERIVATIVE_HINT_OES
        /// </summary>
        public readonly GLenum FRAGMENT_SHADER_DERIVATIVE_HINT_OES = 0x8B8B;

        // WEBGL_draw_buffers
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        /// <summary>
        /// COLOR_ATTACHMENT0_WEBGL
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT0_WEBGL = 0x8CE0;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        /// <summary>
        /// COLOR_ATTACHMENT1_WEBGL
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT1_WEBGL = 0x8CE1;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        /// <summary>
        /// COLOR_ATTACHMENT2_WEBGL
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT2_WEBGL = 0x8CE2;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        /// <summary>
        /// COLOR_ATTACHMENT3_WEBGL
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT3_WEBGL = 0x8CE3;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        /// <summary>
        /// COLOR_ATTACHMENT4_WEBGL
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT4_WEBGL = 0x8CE4;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        /// <summary>
        /// COLOR_ATTACHMENT5_WEBGL
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT5_WEBGL = 0x8CE5;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        /// <summary>
        /// COLOR_ATTACHMENT6_WEBGL
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT6_WEBGL = 0x8CE6;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        /// <summary>
        /// COLOR_ATTACHMENT7_WEBGL
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT7_WEBGL = 0x8CE7;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        /// <summary>
        /// COLOR_ATTACHMENT8_WEBGL
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT8_WEBGL = 0x8CE8;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        /// <summary>
        /// COLOR_ATTACHMENT9_WEBGL
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT9_WEBGL = 0x8CE9;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        /// <summary>
        /// COLOR_ATTACHMENT10_WEBGL
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT10_WEBGL = 0x8CEA;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        /// <summary>
        /// COLOR_ATTACHMENT11_WEBGL
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT11_WEBGL = 0x8CEB;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        /// <summary>
        /// COLOR_ATTACHMENT12_WEBGL
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT12_WEBGL = 0x8CEC;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        /// <summary>
        /// COLOR_ATTACHMENT13_WEBGL
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT13_WEBGL = 0x8CED;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        /// <summary>
        /// COLOR_ATTACHMENT14_WEBGL
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT14_WEBGL = 0x8CEE;
        /// <summary>
        /// Framebuffer color attachment point
        /// </summary>
        /// <summary>
        /// COLOR_ATTACHMENT15_WEBGL
        /// </summary>
        public readonly GLenum COLOR_ATTACHMENT15_WEBGL = 0x8CEF;
        /// <summary>
        /// Draw buffer
        /// </summary>
        /// <summary>
        /// DRAW_BUFFER0_WEBGL
        /// </summary>
        public readonly GLenum DRAW_BUFFER0_WEBGL = 0x8825;
        /// <summary>
        /// Draw buffer
        /// </summary>
        /// <summary>
        /// DRAW_BUFFER1_WEBGL
        /// </summary>
        public readonly GLenum DRAW_BUFFER1_WEBGL = 0x8826;
        /// <summary>
        /// Draw buffer
        /// </summary>
        /// <summary>
        /// DRAW_BUFFER2_WEBGL
        /// </summary>
        public readonly GLenum DRAW_BUFFER2_WEBGL = 0x8827;
        /// <summary>
        /// Draw buffer
        /// </summary>
        /// <summary>
        /// DRAW_BUFFER3_WEBGL
        /// </summary>
        public readonly GLenum DRAW_BUFFER3_WEBGL = 0x8828;
        /// <summary>
        /// Draw buffer
        /// </summary>
        /// <summary>
        /// DRAW_BUFFER4_WEBGL
        /// </summary>
        public readonly GLenum DRAW_BUFFER4_WEBGL = 0x8829;
        /// <summary>
        /// Draw buffer
        /// </summary>
        /// <summary>
        /// DRAW_BUFFER5_WEBGL
        /// </summary>
        public readonly GLenum DRAW_BUFFER5_WEBGL = 0x882A;
        /// <summary>
        /// Draw buffer
        /// </summary>
        /// <summary>
        /// DRAW_BUFFER6_WEBGL
        /// </summary>
        public readonly GLenum DRAW_BUFFER6_WEBGL = 0x882B;
        /// <summary>
        /// Draw buffer
        /// </summary>
        /// <summary>
        /// DRAW_BUFFER7_WEBGL
        /// </summary>
        public readonly GLenum DRAW_BUFFER7_WEBGL = 0x882C;
        /// <summary>
        /// Draw buffer
        /// </summary>
        /// <summary>
        /// DRAW_BUFFER8_WEBGL
        /// </summary>
        public readonly GLenum DRAW_BUFFER8_WEBGL = 0x882D;
        /// <summary>
        /// Draw buffer
        /// </summary>
        /// <summary>
        /// DRAW_BUFFER9_WEBGL
        /// </summary>
        public readonly GLenum DRAW_BUFFER9_WEBGL = 0x882E;
        /// <summary>
        /// Draw buffer
        /// </summary>
        /// <summary>
        /// DRAW_BUFFER10_WEBGL
        /// </summary>
        public readonly GLenum DRAW_BUFFER10_WEBGL = 0x882F;
        /// <summary>
        /// Draw buffer
        /// </summary>
        /// <summary>
        /// DRAW_BUFFER11_WEBGL
        /// </summary>
        public readonly GLenum DRAW_BUFFER11_WEBGL = 0x8830;
        /// <summary>
        /// Draw buffer
        /// </summary>
        /// <summary>
        /// DRAW_BUFFER12_WEBGL
        /// </summary>
        public readonly GLenum DRAW_BUFFER12_WEBGL = 0x8831;
        /// <summary>
        /// Draw buffer
        /// </summary>
        /// <summary>
        /// DRAW_BUFFER13_WEBGL
        /// </summary>
        public readonly GLenum DRAW_BUFFER13_WEBGL = 0x8832;
        /// <summary>
        /// Draw buffer
        /// </summary>
        /// <summary>
        /// DRAW_BUFFER14_WEBGL
        /// </summary>
        public readonly GLenum DRAW_BUFFER14_WEBGL = 0x8833;
        /// <summary>
        /// Draw buffer
        /// </summary>
        /// <summary>
        /// DRAW_BUFFER15_WEBGL
        /// </summary>
        public readonly GLenum DRAW_BUFFER15_WEBGL = 0x8834;
        /// <summary>
        /// Maximum number of framebuffer color attachment points
        /// </summary>
        /// <summary>
        /// MAX_COLOR_ATTACHMENTS_WEBGL
        /// </summary>
        public readonly GLenum MAX_COLOR_ATTACHMENTS_WEBGL = 0x8CDF;
        /// <summary>
        /// Maximum number of draw buffers
        /// </summary>
        /// <summary>
        /// MAX_DRAW_BUFFERS_WEBGL
        /// </summary>
        public readonly GLenum MAX_DRAW_BUFFERS_WEBGL = 0x8824;

        // OES_vertex_array_object
        /// <summary>
        /// The bound vertex array object (VAO).
        /// </summary>
        /// <summary>
        /// VERTEX_ARRAY_BINDING_OES
        /// </summary>
        public readonly GLenum VERTEX_ARRAY_BINDING_OES = 0x85B5;

        // EXT_disjoint_timer_query
        /// <summary>
        /// The number of bits used to hold the query result for the given target.
        /// </summary>
        /// <summary>
        /// QUERY_COUNTER_BITS_EXT
        /// </summary>
        public readonly GLenum QUERY_COUNTER_BITS_EXT = 0x8864;
        /// <summary>
        /// The currently active query.
        /// </summary>
        /// <summary>
        /// CURRENT_QUERY_EXT
        /// </summary>
        public readonly GLenum CURRENT_QUERY_EXT = 0x8865;
        /// <summary>
        /// The query result.
        /// </summary>
        /// <summary>
        /// QUERY_RESULT_EXT
        /// </summary>
        public readonly GLenum QUERY_RESULT_EXT = 0x8866;
        /// <summary>
        /// A Boolean indicating whether or not a query result is available.
        /// </summary>
        /// <summary>
        /// QUERY_RESULT_AVAILABLE_EXT
        /// </summary>
        public readonly GLenum QUERY_RESULT_AVAILABLE_EXT = 0x8867;
        /// <summary>
        /// Elapsed time (in nanoseconds).
        /// </summary>
        /// <summary>
        /// TIME_ELAPSED_EXT
        /// </summary>
        public readonly GLenum TIME_ELAPSED_EXT = 0x88BF;
        /// <summary>
        /// The current time.
        /// </summary>
        /// <summary>
        /// TIMESTAMP_EXT
        /// </summary>
        public readonly GLenum TIMESTAMP_EXT = 0x8E28;
        /// <summary>
        /// A Boolean indicating whether or not the GPU performed any disjoint operation.
        /// </summary>
        /// <summary>
        /// GPU_DISJOINT_EXT
        /// </summary>
        public readonly GLenum GPU_DISJOINT_EXT = 0x8FBB;
    }
}
