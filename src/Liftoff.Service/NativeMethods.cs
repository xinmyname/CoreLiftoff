using System;
using System.Runtime.InteropServices;

namespace Liftoff.Service
{
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();
    }
}