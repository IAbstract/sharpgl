// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;


namespace RazorSoft.Media {

    public static partial class Glfw {
        /// <summary>
        ///     The native library name,
        ///     <para>For Unix users using an installed version of GLFW, this needs refactored to <c>glfw</c>.</para>
        /// </summary>
#if Linux
        private const string GLFW_LIB = "glfw";
#elif OSX
        private const string GLFW_LIB = "libglfw.3"; // mac
#elif Windows
        private const string GLFW_LIB = "glfw3";
#else
        // some error condition - unsupported platform
#endif

        public const int FALSE = 0;
        public const int TRUE = 1;
        public const int DEFAULT = -1;

        internal static NativeScreen PrimaryScreen => glfwGetPrimaryMonitor();

        private static IntPtr NullPtr => IntPtr.Zero;
    }
}
