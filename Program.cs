using System;
using System.Runtime.InteropServices;
using System.Numerics;
using System.Drawing;

namespace GLFWFun
{
    class Program
    {
        static float[] vertex_buffer_data = {
            -1.0f,-1.0f,-1.0f,
            -1.0f,-1.0f, 1.0f,
            -1.0f, 1.0f, 1.0f,
            1.0f, 1.0f,-1.0f,
            -1.0f,-1.0f,-1.0f,
            -1.0f, 1.0f,-1.0f,
            1.0f,-1.0f, 1.0f,
            -1.0f,-1.0f,-1.0f,
            1.0f,-1.0f,-1.0f,
            1.0f, 1.0f,-1.0f,
            1.0f,-1.0f,-1.0f,
            -1.0f,-1.0f,-1.0f,
            -1.0f,-1.0f,-1.0f,
            -1.0f, 1.0f, 1.0f,
            -1.0f, 1.0f,-1.0f,
            1.0f,-1.0f, 1.0f,
            -1.0f,-1.0f, 1.0f,
            -1.0f,-1.0f,-1.0f,
            -1.0f, 1.0f, 1.0f,
            -1.0f,-1.0f, 1.0f,
            1.0f,-1.0f, 1.0f,
            1.0f, 1.0f, 1.0f,
            1.0f,-1.0f,-1.0f,
            1.0f, 1.0f,-1.0f,
            1.0f,-1.0f,-1.0f,
            1.0f, 1.0f, 1.0f,
            1.0f,-1.0f, 1.0f,
            1.0f, 1.0f, 1.0f,
            1.0f, 1.0f,-1.0f,
            -1.0f, 1.0f,-1.0f,
            1.0f, 1.0f, 1.0f,
            -1.0f, 1.0f,-1.0f,
            -1.0f, 1.0f, 1.0f,
            1.0f, 1.0f, 1.0f,
            -1.0f, 1.0f, 1.0f,
            1.0f,-1.0f, 1.0f
        };

        static float[] color_buffer_data = {
            0.583f,  0.771f,  0.014f,
            0.609f,  0.115f,  0.436f,
            0.327f,  0.483f,  0.844f,
            0.822f,  0.569f,  0.201f,
            0.435f,  0.602f,  0.223f,
            0.310f,  0.747f,  0.185f,
            0.597f,  0.770f,  0.761f,
            0.559f,  0.436f,  0.730f,
            0.359f,  0.583f,  0.152f,
            0.483f,  0.596f,  0.789f,
            0.559f,  0.861f,  0.639f,
            0.195f,  0.548f,  0.859f,
            0.014f,  0.184f,  0.576f,
            0.771f,  0.328f,  0.970f,
            0.406f,  0.615f,  0.116f,
            0.676f,  0.977f,  0.133f,
            0.971f,  0.572f,  0.833f,
            0.140f,  0.616f,  0.489f,
            0.997f,  0.513f,  0.064f,
            0.945f,  0.719f,  0.592f,
            0.543f,  0.021f,  0.978f,
            0.279f,  0.317f,  0.505f,
            0.167f,  0.620f,  0.077f,
            0.347f,  0.857f,  0.137f,
            0.055f,  0.953f,  0.042f,
            0.714f,  0.505f,  0.345f,
            0.783f,  0.290f,  0.734f,
            0.722f,  0.645f,  0.174f,
            0.302f,  0.455f,  0.848f,
            0.225f,  0.587f,  0.040f,
            0.517f,  0.713f,  0.338f,
            0.053f,  0.959f,  0.120f,
            0.393f,  0.621f,  0.362f,
            0.673f,  0.211f,  0.457f,
            0.820f,  0.883f,  0.371f,
            0.982f,  0.099f,  0.879f
        };

       static float[] uv_buffer_data = {
            0.000059f, 1.0f-0.000004f,
            0.000103f, 1.0f-0.336048f,
            0.335973f, 1.0f-0.335903f,
            1.000023f, 1.0f-0.000013f,
            0.667979f, 1.0f-0.335851f,
            0.999958f, 1.0f-0.336064f,
            0.667979f, 1.0f-0.335851f,
            0.336024f, 1.0f-0.671877f,
            0.667969f, 1.0f-0.671889f,
            1.000023f, 1.0f-0.000013f,
            0.668104f, 1.0f-0.000013f,
            0.667979f, 1.0f-0.335851f,
            0.000059f, 1.0f-0.000004f,
            0.335973f, 1.0f-0.335903f,
            0.336098f, 1.0f-0.000071f,
            0.667979f, 1.0f-0.335851f,
            0.335973f, 1.0f-0.335903f,
            0.336024f, 1.0f-0.671877f,
            1.000004f, 1.0f-0.671847f,
            0.999958f, 1.0f-0.336064f,
            0.667979f, 1.0f-0.335851f,
            0.668104f, 1.0f-0.000013f,
            0.335973f, 1.0f-0.335903f,
            0.667979f, 1.0f-0.335851f,
            0.335973f, 1.0f-0.335903f,
            0.668104f, 1.0f-0.000013f,
            0.336098f, 1.0f-0.000071f,
            0.000103f, 1.0f-0.336048f,
            0.000004f, 1.0f-0.671870f,
            0.336024f, 1.0f-0.671877f,
            0.000103f, 1.0f-0.336048f,
            0.336024f, 1.0f-0.671877f,
            0.335973f, 1.0f-0.335903f,
            0.667969f, 1.0f-0.671889f,
            1.000004f, 1.0f-0.671847f,
            0.667979f, 1.0f-0.335851f
        }; 
        static Bitmap textureBitmap = new Bitmap("metal.bmp");
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

            uint vertexArrayID = Gl.GenVertexArray();
            Gl.BindVertexArray(vertexArrayID);

            uint vertexBuffer = Gl.GenBuffer();
            Gl.BindBuffer(Gl.ArrayBuffer, vertexBuffer);
            Gl.BufferData(Gl.ArrayBuffer, vertex_buffer_data, Gl.StaticDraw);

            uint uvBuffer = Gl.GenBuffer();
            Gl.BindBuffer(Gl.ArrayBuffer, uvBuffer);
            Gl.BufferData(Gl.ArrayBuffer, uv_buffer_data, Gl.StaticDraw);

            uint texture = Gl.GenTexture();
            Gl.BindTexture(Gl.Texture2D, texture);

            Gl.TexImage2D(Gl.Texture2D, 0, textureBitmap);

            Gl.TexParameteri(Gl.Texture2D, Gl.TextureMinFilter, Gl.Nearest);
            Gl.TexParameteri(Gl.Texture2D, Gl.TextureMagFilter, Gl.Nearest);

            var vertexShader = Gl.CreateShader(Gl.VertexShader);
            Gl.ShaderSource(vertexShader, @"
            #version 330 core
            layout(location=0) in vec3 vertexPosition_modelspace;
            layout(location=1) in vec2 vertexUV;

            out vec2 UV;

            uniform mat4 MVP;

            void main() {
                gl_Position = MVP * vec4(vertexPosition_modelspace, 1);
                UV = vertexUV;
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
            in vec2 UV;
            out vec3 color;

            uniform sampler2D myTextureSampler;

            void main() {
                color = texture( myTextureSampler, UV ).rgb;
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

            Gl.Enable(Gl.DepthTest);
            Gl.DepthFunc(Gl.Less);

            Matrix4x4 projection = Matrix4x4.CreatePerspectiveFieldOfView(0.785398f, 800.0f / 600.0f, 0.1f, 100.0f);
            Matrix4x4 view = Matrix4x4.CreateLookAt(
                new Vector3(4, 3, 3),
                new Vector3(0, 0, 0),
                new Vector3(0, 1, 0)
            );

            Gl.UseProgram(program);

            int MVPLocation = Gl.GetUniformLocation(program, "MVP");

            Gl.ClearColor(0, 0, 0.4f, 0);

            float i = 0;

            while (Glfw.WindowShouldClose(win) != Glfw.True)
            {
                Matrix4x4 model = Matrix4x4.CreateFromYawPitchRoll(i, i, i);
                i += 0.01f;
                Matrix4x4 mvp = model * view * projection;

                Gl.UniformMatrix4fv(MVPLocation, false, mvp);

                Gl.Clear(Gl.ColorBufferBit | Gl.DepthBufferBit);

                Gl.EnableVertexAttribArray(0);
                Gl.EnableVertexAttribArray(1);
                Gl.BindBuffer(Gl.ArrayBuffer, vertexBuffer);
                Gl.VertexAttribPointer(0, 3, Gl.Float, false, 0, 0);
                Gl.BindBuffer(Gl.ArrayBuffer, uvBuffer);
                Gl.VertexAttribPointer(1, 2, Gl.Float, false, 0, 0);
                Gl.DrawArrays(Gl.Triangles, 0, 3*12);
                Gl.DisableVertexAttribArray(0);
                Gl.DisableVertexAttribArray(1);

                Glfw.SwapBuffers(win);
                Glfw.PollEvents();
            }
        }
    }
}
