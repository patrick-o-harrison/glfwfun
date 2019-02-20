using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Text;

namespace GLFWFun
{
    class Glfw
    {
        public delegate void ErrorFun(int error, string description);

        [DllImport("glfw", EntryPoint = "glfwInit")]
        public static extern int Init();

        [DllImport("glfw", EntryPoint = "glfwSetErrorCallback")]
        public static extern ErrorFun SetErrorCallback(ErrorFun cbfun);

        [DllImport("glfw", EntryPoint = "glfwWindowHint")]
        public static extern void WindowHint(int hint, int value);

        [DllImport("glfw", EntryPoint = "glfwCreateWindow")]
        public static extern IntPtr CreateWindow(
            int width, int height, string title, IntPtr monitor, IntPtr share);

        [DllImport("glfw", EntryPoint = "glfwMakeContextCurrent")]
        public static extern void MakeContextCurrent(IntPtr window);

        [DllImport("glfw", EntryPoint = "glfwGetProcAddress")]
        public static extern IntPtr GetProcAddress(string procname);

        [DllImport("glfw", EntryPoint = "glfwWindowShouldClose")]
        public static extern int WindowShouldClose(IntPtr window);

        [DllImport("glfw", EntryPoint = "glfwSwapBuffers")]
        public static extern void SwapBuffers(IntPtr window);

        [DllImport("glfw", EntryPoint = "glfwPollEvents")]
        public static extern void PollEvents();

        public const int True = 1;
        public const int False = 0;

        public const int ContextVersionMajor = 0x00022002;
        public const int ContextVersionMinor = 0x00022003;
        public const int OpenglForwardCompat = 0x00022006;
        public const int OpenglDebugContext = 0x00022007;
        public const int OpenglProfile = 0x00022008;

        public const int OpenglCoreProfile = 0x00032001;

    }

    public class Gl
    {
        private static T getFunction<T>()
        {
            return Marshal.GetDelegateForFunctionPointer<T>(
                Glfw.GetProcAddress(typeof(T).Name)
            );
        }

        public static void Init()
        {
            glCreateShaderPtr = getFunction<glCreateShader>();
            glDeleteShaderPtr = getFunction<glDeleteShader>();
            glShaderSourcePtr = getFunction<glShaderSource>();
            glCompileShaderPtr = getFunction<glCompileShader>();
            glGetShaderivPtr = getFunction<glGetShaderiv>();
            glGetShaderInfoLogPtr = getFunction<glGetShaderInfoLog>();
            glClearPtr = getFunction<glClear>();
            glClearColorPtr = getFunction<glClearColor>();
            glGenVertexArraysPtr = getFunction<glGenVertexArrays>();
            glBindVertexArrayPtr = getFunction<glBindVertexArray>();
            glGenBuffersPtr = getFunction<glGenBuffers>();
            glBindBufferPtr = getFunction<glBindBuffer>();
            glBufferDataPtr = getFunction<glBufferData>();
            glDrawArraysPtr = getFunction<glDrawArrays>();
            glEnableVertexAttribArrayPtr = getFunction<glEnableVertexAttribArray>();
            glDisableVertexAttribArrayPtr = getFunction<glDisableVertexAttribArray>();
            glVertexAttribPointerPtr = getFunction<glVertexAttribPointer>();
            glCreateProgramPtr = getFunction<glCreateProgram>();
            glAttachShaderPtr = getFunction<glAttachShader>();
            glDetachShaderPtr = getFunction<glDetachShader>();
            glLinkProgramPtr = getFunction<glLinkProgram>();
            glGetProgramivPtr = getFunction<glGetProgramiv>();
            glGetProgramInfoLogPtr = getFunction<glGetProgramInfoLog>();
            glUseProgramPtr = getFunction<glUseProgram>();
            glGetErrorPtr = getFunction<glGetError>();
            glGetStringiPtr = getFunction<glGetStringi>();
            glGetIntegervPtr = getFunction<glGetIntegerv>();
        }

        // Delegates.

        private delegate uint glCreateShader(uint shaderType);
        private delegate void glDeleteShader(uint shader);
        private delegate void glShaderSource(
            uint shader, int count, IntPtr sourceString, IntPtr length);
        private delegate void glCompileShader(uint shader);
        private delegate void glGetShaderiv(
            uint shader, uint pname, ref int shaderParams);
        private delegate void glGetShaderInfoLog(
            uint shader, int maxLength, ref int length, IntPtr infoLog);
        private delegate void glClear(uint mask);
        private delegate void glClearColor(float r, float g, float b, float a);
        private delegate void glGenVertexArrays(int count, IntPtr arrays);
        private delegate void glBindVertexArray(uint vertexArray);
        private delegate void glGenBuffers(int count, IntPtr buffers);
        private delegate void glBindBuffer(uint type, uint buffer);
        private delegate void glBufferData(
            uint target, int size, IntPtr data, uint usage);
        private delegate void glEnableVertexAttribArray(uint index);
        private delegate void glDisableVertexAttribArray(uint index);
        private delegate void glDrawArrays(uint mode, int first, int count);
        private delegate void glVertexAttribPointer(
            uint index, int size, uint type,
            byte normalize, int stride, IntPtr pointer);
        private delegate uint glCreateProgram();
        private delegate void glAttachShader(uint program, uint shader);
        private delegate void glDetachShader(uint program, uint shader);
        private delegate void glLinkProgram(uint program);
        private delegate void glGetProgramiv(
            uint program, uint pname, ref int programParams);
        private delegate void glGetProgramInfoLog(
            uint program, int maxLength, ref int length, IntPtr infoLog);
        private delegate void glUseProgram(uint program);
        private delegate uint glGetError();
        private delegate IntPtr glGetStringi(uint name, int index);
        private delegate void glGetIntegerv(uint name, ref int value);


        // Static pointers to delegates.

        private static glCreateShader glCreateShaderPtr;
        private static glDeleteShader glDeleteShaderPtr;
        private static glShaderSource glShaderSourcePtr;
        private static glCompileShader glCompileShaderPtr;
        private static glGetShaderiv glGetShaderivPtr;
        private static glGetShaderInfoLog glGetShaderInfoLogPtr;
        private static glClear glClearPtr;
        private static glClearColor glClearColorPtr;
        private static glGenVertexArrays glGenVertexArraysPtr;
        private static glBindVertexArray glBindVertexArrayPtr;
        private static glGenBuffers glGenBuffersPtr;
        private static glBindBuffer glBindBufferPtr;
        private static glBufferData glBufferDataPtr;
        private static glEnableVertexAttribArray glEnableVertexAttribArrayPtr;
        private static glDisableVertexAttribArray glDisableVertexAttribArrayPtr;
        private static glDrawArrays glDrawArraysPtr;
        private static glVertexAttribPointer glVertexAttribPointerPtr;
        private static glCreateProgram glCreateProgramPtr;
        private static glAttachShader glAttachShaderPtr;
        private static glDetachShader glDetachShaderPtr;
        private static glLinkProgram glLinkProgramPtr;
        private static glGetProgramiv glGetProgramivPtr;
        private static glGetProgramInfoLog glGetProgramInfoLogPtr;
        private static glUseProgram glUseProgramPtr;
        private static glGetError glGetErrorPtr;
        private static glGetStringi glGetStringiPtr;
        private static glGetIntegerv glGetIntegervPtr;

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        private static void checkError()
        {
            string caller = new StackFrame(1).GetMethod().Name;
            uint error = GetError();
            if (error != NoError)
            {
                Console.Error.WriteLine($"GL Error in {caller}: {error}");
            }
        }

        // Public interface.

        public static uint CreateShader(uint shaderType)
        {
            uint shader = glCreateShaderPtr(shaderType);
            checkError();
            return shader;
        }

        public static void DeleteShader(uint shader)
        {
            glDeleteShaderPtr(shader);
            checkError();
        }

        public static void ShaderSource(uint shader, string source)
        {
            byte[] sourceBuf = Encoding.ASCII.GetBytes(source);
            unsafe
            {
                fixed (byte* sourceBufPtr = sourceBuf)
                {
                    glShaderSourcePtr(shader, 1, new IntPtr(&sourceBufPtr), IntPtr.Zero);
                    checkError();
                }
            }
        }

        public static void CompileShader(uint shader)
        {
            glCompileShaderPtr(shader);
            checkError();
        }

        public static int GetShaderiv(uint shader, uint pname)
        {
            int shaderParams = 0;
            glGetShaderivPtr(shader, pname, ref shaderParams);
            checkError();
            return shaderParams;
        }

        public static string GetShaderInfoLog(uint shader, int maxLength)
        {
            byte[] infoLogBuffer = new byte[maxLength + 1];
            unsafe
            {
                fixed (byte* infoLogBufferPtr = infoLogBuffer)
                {
                    int length = 0; // Don't care.
                    glGetShaderInfoLogPtr(
                        shader, maxLength, ref length, new IntPtr(infoLogBufferPtr));
                    checkError();
                }
            }
            return Encoding.ASCII.GetString(infoLogBuffer);
        }

        public static void Clear(uint mask)
        {
            glClearPtr(mask);
            checkError();
        }

        public static void ClearColor(float r, float g, float b, float a)
        {
            glClearColorPtr(r, g, b, a);
            checkError();
        }

        public static uint GenVertexArray()
        {
            uint[] vertexArrays = new uint[1];
            unsafe
            {
                fixed (uint* vertexArraysPtr = vertexArrays)
                {
                    glGenVertexArraysPtr(1, new IntPtr(vertexArraysPtr));
                    checkError();
                }
            }
            return vertexArrays[0];
        }

        public static void BindVertexArray(uint vertexArray)
        {
            glBindVertexArrayPtr(vertexArray);
            checkError();
        }

        public static uint GenBuffer()
        {
            uint[] buffers = new uint[1];
            unsafe
            {
                fixed (uint* buffersPtr = buffers)
                {
                    glGenBuffersPtr(1, new IntPtr(buffersPtr));
                    checkError();
                }
            }
            return buffers[0];
        }

        public static void BindBuffer(uint target, uint buffer)
        {
            glBindBufferPtr(target, buffer);
            checkError();
        }

        public static void BufferData(uint target, float[] data, uint usage)
        {
            unsafe
            {
                fixed (float* dataPtr = data)
                {
                    glBufferDataPtr(target, data.Length * sizeof(float), new IntPtr(dataPtr), usage);
                    checkError();
                }
            }
        }

        public static void EnableVertexAttribArray(uint index)
        {
            glEnableVertexAttribArrayPtr(index);
            checkError();
        }

        public static void DisableVertexAttribArray(uint index)
        {
            glDisableVertexAttribArrayPtr(index);
            checkError();
        }

        public static void VertexAttribPointer(
            uint index, int size, uint type, bool normalized, int stride, int offset)
        {
            glVertexAttribPointerPtr(
                index, size, type, normalized ? True : False, stride, IntPtr.Zero + offset);
            checkError();
        }

        public static void DrawArrays(uint mode, int first, int count)
        {
            glDrawArraysPtr(mode, first, count);
            checkError();
        }

        public static uint CreateProgram()
        {
            uint program = glCreateProgramPtr();
            checkError();
            return program;
        }

        public static void AttachShader(uint program, uint shader)
        {
            glAttachShaderPtr(program, shader);
            checkError();
        }

        public static void DetachShader(uint program, uint shader)
        {
            glDetachShaderPtr(program, shader);
            checkError();
        }

        public static void LinkProgram(uint program)
        {
            glLinkProgramPtr(program);
            checkError();
        }

        public static int GetProgramiv(uint program, uint pname)
        {
            int programParams = 0;
            glGetProgramivPtr(program, pname, ref programParams);
            checkError();
            return programParams;
        }

        public static string GetProgramInfoLog(uint program, int maxLength)
        {
            byte[] infoLogBuffer = new byte[maxLength + 1];
            unsafe
            {
                fixed (byte* infoLogBufferPtr = infoLogBuffer)
                {
                    int length = 0; // Don't care.
                    glGetProgramInfoLogPtr(
                        program, maxLength, ref length, new IntPtr(infoLogBufferPtr));
                    checkError();
                }
            }
            return Encoding.ASCII.GetString(infoLogBuffer);
        }

        public static int GetIntegerv(uint name)
        {
            int value = 0;
            glGetIntegervPtr(name, ref value);
            checkError();
            return value;
        }

        public static string GetStringi(uint name, int index)
        {
            // We've got to copy the string out by hand, because
            // dotnet tries to free the pointer returned from
            // glGetStringi...
            const int buffer_limit = 256; // Make the security flaw less bad.
            IntPtr strPtr = glGetStringiPtr(name, index);
            byte[] buffer = new byte[buffer_limit];
            unsafe {
                byte* str = (byte*)strPtr.ToPointer();
                int i = 0;
                do {
                    buffer[i] = *str;
                } while( ++i < buffer_limit && *str++ != 0);
            }
            checkError();
            return Encoding.ASCII.GetString(buffer);
        }

        public static void UseProgram(uint program)
        {
            glUseProgramPtr(program);
            checkError();
        }

        public static uint GetError()
        {
            return glGetErrorPtr();
        }

        public const byte False = 0;
        public const byte True = 1;
        public const uint FragmentShader = 0x8b30;
        public const uint VertexShader = 0x8b31;
        public const uint CompileStatus = 0x8b81;
        public const uint LinkStatus = 0x8b82;
        public const uint InfoLogLength = 0x8b84;
        public const uint ColorBufferBit = 0x00004000;
        public const uint DepthBufferBit = 0x00000100;
        public const uint ArrayBuffer = 0x8892;
        public const uint StaticDraw = 0x88e4;
        public const uint Triangles = 0x0004;
        public const uint Float = 0x1406;
        public const uint Extensions = 0x1f03;
        public const uint NumExtensions = 0x821d;
        public const uint NoError = 0;
    }
}