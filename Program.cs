using System;
using System.Runtime.InteropServices;

namespace GLFWFun
{
    class Program
    {
        static void Main(string[] args)
        {
            Glfw.SetErrorCallback((error, desc) => { Console.WriteLine("Wow..");});
            if( Glfw.Init() != Glfw.True ) {
                Console.WriteLine("Huh...");
            }

            var win = Glfw.CreateWindow(400, 400, "Fuzzy Pickles", IntPtr.Zero, IntPtr.Zero);

            while( Glfw.WindowShouldClose(win) == Glfw.False ) {
                Glfw.PollEvents();
            }
        }
    }
}
