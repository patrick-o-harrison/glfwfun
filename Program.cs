using System;
using System.Runtime.InteropServices;

namespace GLFWFun
{
    class Program
    {
        static float[] vertex_buffer_data = {
            -1, -1, 0,
             1, -1, 0,
             0,  1, 0
        };
        static void Main(string[] args)
        {
            Glfw.SetErrorCallback((error, desc) =>
            {
                Console.WriteLine($"Error: {error}, {desc}");
                System.Environment.Exit(1);
            });
            if (Glfw.Init() != Glfw.True)
            {
                Console.WriteLine("Huh...");
                return;
            }

            Glfw.WindowHint(Glfw.ContextVersionMajor, 3);
            Glfw.WindowHint(Glfw.ContextVersionMinor, 3);
            Glfw.WindowHint(Glfw.OpenglForwardCompat, Glfw.True);
            Glfw.WindowHint(Glfw.OpenglProfile, Glfw.OpenglCoreProfile);
            Glfw.WindowHint(Glfw.OpenglDebugContext, Glfw.True);

            var win = Glfw.CreateWindow(800, 600, "Fuzzy Pickles", IntPtr.Zero, IntPtr.Zero);
            Glfw.MakeContextCurrent(win);
            Gl.Init();

//            int numExtensions = Gl.GetIntegerv(Gl.NumExtensions);
//            Console.WriteLine(numExtensions);
//            for( int i = 0; i < numExtensions; i++ ) {
//                string extension = Gl.GetStringi(Gl.Extensions, i);
//                Console.WriteLine(extension);
//            }

            uint vertexArrayID = Gl.GenVertexArray();
            Gl.BindVertexArray(vertexArrayID);

            uint vertexBuffer = Gl.GenBuffer();
            Gl.BindBuffer(Gl.ArrayBuffer, vertexBuffer);
            Gl.BufferData(Gl.ArrayBuffer, vertex_buffer_data, Gl.StaticDraw);

            var vertexShader = Gl.CreateShader(Gl.VertexShader);
            Gl.ShaderSource(vertexShader, @"
            #version 330 core
            layout(location=0) in vec3 vertexPosition_modelspace;
            void main() {
                gl_Position.xyz = vertexPosition_modelspace;
                gl_Position.w = 1.0;
            }
            ");
            Gl.CompileShader(vertexShader);
            int compileStatus = Gl.GetShaderiv(vertexShader, Gl.CompileStatus);
            if (compileStatus != Gl.True)
            {
                int infoLogLength = Gl.GetShaderiv(vertexShader, Gl.InfoLogLength);
                string infoLog = Gl.GetShaderInfoLog(vertexShader, infoLogLength);
                Console.WriteLine(infoLog);
            }

            var fragmentShader = Gl.CreateShader(Gl.FragmentShader);
            Gl.ShaderSource(fragmentShader, @"
            #version 330 core
            out vec3 color;
            void main() {
                color = vec3(1, 0, 0);
            }
            ");
            Gl.CompileShader(fragmentShader);
            compileStatus = Gl.GetShaderiv(fragmentShader, Gl.CompileStatus);
            if (compileStatus != Gl.True)
            {
                int infoLogLength = Gl.GetShaderiv(fragmentShader, Gl.InfoLogLength);
                string infoLog = Gl.GetShaderInfoLog(fragmentShader, infoLogLength);
                Console.WriteLine(infoLog);
                return;
            }

            var program = Gl.CreateProgram();
            Gl.AttachShader(program, vertexShader);
            Gl.AttachShader(program, fragmentShader);
            Gl.LinkProgram(program);

            int linkStatus = Gl.GetProgramiv(program, Gl.LinkStatus);
            if (linkStatus != Gl.True)
            {
                int infoLogLength = Gl.GetProgramiv(program, Gl.InfoLogLength);
                string infoLog = Gl.GetProgramInfoLog(program, infoLogLength);
                Console.WriteLine(infoLog);
                return;
            }

            Gl.DetachShader(program, vertexShader);
            Gl.DetachShader(program, fragmentShader);
            Gl.DeleteShader(vertexShader);
            Gl.DeleteShader(fragmentShader);

            Gl.UseProgram(program);
            Gl.ClearColor(0, 0, 0.4f, 0);

            while (Glfw.WindowShouldClose(win) != Glfw.True)
            {
                Gl.Clear(Gl.ColorBufferBit | Gl.DepthBufferBit);

                Gl.EnableVertexAttribArray(0);
                Gl.BindBuffer(Gl.ArrayBuffer, vertexBuffer);
                Gl.VertexAttribPointer(0, 3, Gl.Float, false, 0, 0);
                Gl.DrawArrays(Gl.Triangles, 0, 3);
                Gl.DisableVertexAttribArray(0);

                Glfw.SwapBuffers(win);
                Glfw.PollEvents();
            }
        }
    }
}
