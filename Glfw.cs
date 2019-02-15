using System;
using System.Runtime.InteropServices;

namespace GLFWFun {
    class Glfw {

        public delegate void ErrorFun(int error, string description);

        [DllImport("glfw", EntryPoint="glfwInit")]
        public static extern int Init();

        [DllImport("glfw", EntryPoint="glfwSetErrorCallback")]
        public static extern ErrorFun SetErrorCallback(ErrorFun cbfun);

        [DllImport("glfw", EntryPoint="glfwCreateWindow")]
        public static extern IntPtr CreateWindow(int width, int height, string title, IntPtr monitor, IntPtr share);

        [DllImport("glfw", EntryPoint="glfwWindowShouldClose")]
        public static extern int WindowShouldClose(IntPtr win);

        [DllImport("glfw", EntryPoint="glfwPollEvents")]
        public static extern void PollEvents();

        public const int True = 1;
        public const int False = 0;
        
    }
}