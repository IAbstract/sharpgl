// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

using RazorSoft.Media.Native;
using NativePlatform = RazorSoft.Media.Native.Platform;


[assembly: InternalsVisibleTo("RazorSoft.Media.Tests")]
namespace RazorSoft.Media {

    public static partial class Glfw {
        #region		fields

        #endregion	fields


        #region		properties
        private static ErrorCallback ErrorCallback { get; }

        internal static DateTime Started { get; }
        internal static IPlatform Platform { get; }
        internal static bool IsInitialized { get; private set; }
        #endregion	properties


        #region		constructors & destructors
        static Glfw() {
            Platform = NativePlatform.GetPlatform(GLFW_LIB);

            Init();

            if (IsInitialized) {
                SetErrorCallback(ErrorCallback = GlfwError);
            }
        }
        #endregion	constructors & destructors


        #region		public methods & functions
        /// <summary>
        ///     Returns the SDL compatible GUID, as a hexadecimal string, of the specified joystick.
        ///     <para>
        ///         The GUID is what connects a joystick to a gamepad mapping. A connected joystick will always have a GUID even
        ///         if there is no gamepad mapping assigned to it.
        ///     </para>
        /// </summary>
        /// <param name="joystickId">The joystick to query.</param>
        /// <returns>The GUID of the joystick, or <c>null</c> if the joystick is not present or an error occurred.</returns>
        public static string GetJoystickGuid(int joystickId) {
            var ptr = glfwGetJoystickGUID(joystickId);

            return ptr == NullPtr ? string.Empty : PtrToStringUTF8(ptr);
        }
        /// <summary>
        ///     Parses the specified string and updates the internal list with any gamepad mappings it finds.
        ///     <para>
        ///         This string may contain either a single gamepad mapping or many mappings separated by newlines. The parser
        ///         supports the full format of the SDL <c>gamecontrollerdb.txt</c> source file including empty lines and comments.
        ///     </para>
        /// </summary>
        /// <param name="mappings">The string containing the gamepad mappings.</param>
        /// <returns><c>true</c> if successful, or <c>false</c> if an error occurred.</returns>
        public static bool UpdateGamepadMappings(string mappings) {
            return glfwUpdateGamepadMappings(Encoding.ASCII.GetBytes(mappings));
        }
        /// <summary>
        ///     Returns the human-readable name of the gamepad from the gamepad mapping assigned to the specified joystick.
        /// </summary>
        /// <param name="gamepadId">The joystick to query.</param>
        /// <returns>
        ///     The name of the gamepad, or <c>null</c> if the joystick is not present, does not have a mapping or an error
        ///     occurred.
        /// </returns>
        public static string GetGamepadName(int gamepadId) {
            var ptr = glfwGetGamepadName(gamepadId);

            return ptr == NullPtr ? null : PtrToStringUTF8(ptr);
        }
        public static void Terminate() {
            glfwTerminate();
            IsInitialized = false;
        }
        #endregion	public methods & functions


        #region		non-public methods & functions
        /// <summary>
        ///     This function creates a window and its associated OpenGL or OpenGL ES context. Most of the options controlling how
        ///     the window and its context should be created are specified with window hints.
        /// </summary>
        /// <param name="width">The desired width, in screen coordinates, of the window. This must be greater than zero.</param>
        /// <param name="height">The desired height, in screen coordinates, of the window. This must be greater than zero.</param>
        /// <param name="title">The initial window title.</param>
        /// <param name="screen">The screen to use for full screen mode, or <see cref="NativeScreen.Null" /> for windowed mode.</param>
        /// <param name="share">
        ///     A window instance whose context to share resources with, or <see cref="NativeWindow.Null" /> to not share
        ///     resources..
        /// </param>
        /// <returns>The created native window, or <see cref="NativeWindow.Null" /> if an error occurred.</returns>
        internal static NativeWindow CreateWindow(int width, int height, string title, NativeScreen screen, NativeWindow share) {
            return glfwCreateWindow(width, height, Encode(title), screen, share);
        }
        internal static void DestroyWindow(this NativeWindow window) {
            glfwDestroyWindow(window);
        }

        #region     window extension methods
        internal static bool GetAttribute(this NativeWindow window, WindowAttribute attribute) {
            return glfwGetWindowAttrib(window, (int)attribute) != FALSE;
        }
        /// <summary>
        ///     Gets the client API.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>The client API.</returns>
        internal static ClientApi GetClientApi(this NativeWindow window) {
            return (ClientApi)glfwGetWindowAttrib(window, (int)ContextAttributes.ClientApi);
        }
        /// <summary>
        ///     Gets the contents of the system clipboard, if it contains or is convertible to a UTF-8 encoded
        ///     string.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns>The contents of the clipboard as a UTF-8 encoded string, or <c>null</c> if an error occurred.</returns>
        internal static string GetClipboardString(this NativeWindow window) {
            var clipboard = glfwGetClipboardString(window);

            return PtrToStringUTF8(clipboard);
        }
        internal static CursorMode GetCursorMode(this NativeWindow window) {
            return (CursorMode)GetInputMode(window, InputMode.Cursor);
        }
        internal static Point GetCursorPosition(this NativeWindow window) {
            glfwGetCursorPos(window, out double x, out double y);

            return new(Convert.ToInt32(x), Convert.ToInt32(y));
        }
        internal static StickyButtonsMode GetStickyButtonsMode(this NativeWindow window) {
            return (StickyButtonsMode)GetInputMode(window, InputMode.StickyMouseButton);
        }
        internal static StickyKeysMode GetStickyKeysMode(this NativeWindow window) {
            return (StickyKeysMode)GetInputMode(window, InputMode.StickyKeys);
        }
        internal static IntPtr GetUserHandle(this NativeWindow window) {
            return glfwGetWindowUserPointer(window);
        }
         /// <summary>
        ///     Retrieves the content scale for the specified window. The content scale is the ratio between the current DPI and
        ///     the platform's default DPI. This is especially important for text and any UI elements. If the pixel dimensions of
        ///     your UI scaled by this look appropriate on your machine then it should appear at a reasonable size on other
        ///     machines regardless of their DPI and scaling settings. This relies on the system DPI and scaling settings being
        ///     somewhat correct.
        ///     <para>
        ///         On systems where each screens can have its own content scale, the window content scale will depend on which
        ///         screen the system considers the window to be on.
        ///     </para>
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <returns><see cref="PointF"/></returns>
        internal static PointF GetContentScale(this NativeWindow window) {
            glfwGetWindowContentScale(window, out float xScale, out float yScale);

            return new(xScale, yScale);
        }
        internal static Rectangle GetFrameRectangle(this NativeWindow window) {
            glfwGetWindowFrameSize(window, out int x, out int y, out int r, out int b);

            return new(x, y, r - x, b - y);
        }
        /// <summary>
        ///     Returns the opacity of the window, including any decorations.
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <returns>The opacity value of the specified window, a value between <c>0.0</c> and <c>1.0</c> inclusive.</returns>
		internal static float GetOpacity(this NativeWindow window) {
            return glfwGetWindowOpacity(window);
        }
        internal static Point GetPosition(this NativeWindow window) {
            glfwGetWindowPosition(window, out int x, out int y);

            var frameRect = GetFrameRectangle(window);

            return new(x - frameRect.Left, y - frameRect.Top);
        }
        internal static NativeScreen GetScreen(this NativeWindow window) {
            return glfwGetWindowMonitor(window);
        }
        /// <summary>
        ///     This function retrieves the <see cref="Size"/>, in screen coordinates, of the client area of the specified window.
        ///     <para>
        ///         If you wish to retrieve the size of the framebuffer of the window in pixels, use
        ///         <see cref="GetFramebufferSize" />.
        ///     </para>
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <returns><see cref="Size"/></returns>
        internal static Size GetSize(this NativeWindow window) {
            glfwGetWindowSize(window, out int width, out int height);

            return new(width, height);
        }
        internal static void Iconify(this NativeWindow window) {
            var isMinimized = GetAttribute(window, WindowAttribute.AutoIconify);

            if (!isMinimized) {
                glfwIconifyWindow(window);
            }
        }
        internal static void Maximize(this NativeWindow window) {
            var isMaximized = GetAttribute(window, WindowAttribute.Maximized);

            if (!isMaximized) {
                glfwMaximizeWindow(window);
            }
        }
        /// <summary>
        ///     Requests user attention to the specified <paramref name="window" />. On platforms where this is not supported,
        ///     attention is
        ///     requested to the application as a whole.
        ///     <para>
        ///         Once the user has given attention, usually by focusing the window or application, the system will end the
        ///         request automatically.
        ///     </para>
        /// </summary>
        /// <param name="window">The window to request user attention to.</param>
        internal static void RequestAttention(this NativeWindow window) {
            glfwRequestWindowAttention(window);
        }
        internal static void Restore(this NativeWindow window) {
            glfwRestoreWindow(window);
        }
        internal static void SetAspectRatio(this NativeWindow window, int numerator, int denominator) {
            glfwSetWindowAspectRatio(window, numerator, denominator);
        }
        /// <summary>
        ///     Sets the system clipboard to the specified string.
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <param name="clipboard">The string to set to the clipboard.</param>
        internal static void SetClipboardString(this NativeWindow window, string clipboard) {
            glfwSetClipboardString(window, Encode(clipboard));
        }
        internal static void SetCurrentContext(this NativeWindow window) {
            glfwMakeContextCurrent(window);
        }
        internal static void SetCursorMode(this NativeWindow window, CursorMode mode) {
            SetInputMode(window, InputMode.Cursor, (int)mode);
        }
        internal static void SetCursorPosition(this NativeWindow window, Point location) {
            glfwSetCursorPos(window, location.X, location.Y);
        }
        internal static void SetFocus(this NativeWindow window) {
            glfwFocusWindow(window);
        }
        internal static void SetStickKeysMode(this NativeWindow window, StickyKeysMode mode) {
            SetInputMode(window, InputMode.StickyKeys, (int)mode);
        }
        internal static void SetStickyButtonsMode(this NativeWindow window, StickyButtonsMode mode) {
            SetInputMode(window, InputMode.StickyMouseButton, (int)mode);
        }
        internal static void SetIcon(this NativeWindow window, Image[] images) {
            images = images ?? new Image[] { };

            glfwSetWindowIcon(window, images.Length, images);
        }
        /// <summary>
        ///     Sets the opacity of the window, including any decorations.
        ///     <para>
        ///         The opacity (or alpha) value is a positive finite number between zero and one, where zero is fully
        ///         transparent and one is fully opaque.
        ///     </para>
        /// </summary>
        /// <param name="window">The window to set the opacity for.</param>
        /// <param name="opacity">The desired opacity of the specified window.</param>
		internal static void SetOpacity(this NativeWindow window, float opacity) {
            opacity = Min(MAXF, Max(MINF, opacity));

            glfwSetWindowOpacity(window, opacity);
        }
        /// <summary>
        ///     Sets the position, in screen coordinates, of the upper-left corner of the client area of the
        ///     specified windowed mode window.
        ///     <para>If the window is a full screen window, this function does nothing.</para>
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <param name="location">The point location of the upper-left corner of the client area.</param>
        /// <remarks>
        ///     The window manager may put limits on what positions are allowed. GLFW cannot and should not override these
        ///     limits.
        /// </remarks>
        internal static void SetPosition(this NativeWindow window, Point location) {
            glfwSetWindowPos(window, location.X, location.Y);
        }
        internal static void SetScreen(this NativeWindow window, NativeScreen screen, Rectangle client, int refreshRate) {
            glfwSetWindowMonitor(window, screen, client.X, client.Y, client.Width, client.Height, refreshRate);
        }
        internal static void SetShouldClose(this NativeWindow window, bool shouldClose) {
            glfwSetWindowShouldClose(window, shouldClose);
        }
        /// <summary>
        ///     This function sets the window size, in screen coordinates, of the client area of the specified window.
        ///     <para>
        ///         If you wish to retrieve the size of the framebuffer of the window in pixels, use
        ///         <see cref="GetFramebufferSize" />.
        ///     </para>
        /// </summary>
        /// <param name="window">A window instance.</param>
        /// <param name="size">The <see cref="Size"/>, in screen coordinates.</param>
        internal static void SetSize(this NativeWindow window, Size size) {
            glfwSetWindowSize(window, size.Width, size.Height);
        }
        internal static void SetSizeLimits(this NativeWindow window, Size minSize, Size maxSize) {
            glfwSetWindowSizeLimits(window, minSize.Width, minSize.Height, maxSize.Width, maxSize.Height);
        }
        internal static string SetTitle(this NativeWindow window, string title) {
            glfwSetWindowTitle(window, Encode(title ??= string.Empty));

            return title;
        }
        internal static void SetUserHandle(this NativeWindow window, IntPtr ptr) {
            glfwSetWindowUserPointer(window, ptr);
        }
        internal static void SetVisibility(this NativeWindow window, bool isVisible) {
            if (isVisible) {
                glfwShowWindow(window);
            }
            else {
                glfwHideWindow(window);
            }
        }
        internal static void SwapBuffers(this NativeWindow window) {
            glfwSwapBuffers(window);
        }
        internal static bool ShouldClose(this NativeWindow window) {
            return glfwWindowShouldClose((NativeWindow)window);
        }
        internal static void SetPositionCallback(this NativeWindow window, PositionCallback callback) {
            glfwSetWindowPosCallback(window, callback);
        }
        internal static void SetSizeCallback(this NativeWindow window, SizeCallback callback) {
            glfwSetWindowSizeCallback(window, callback);
        }
        internal static void SetFocusCallback(this NativeWindow window, FocusCallback callback) {
            glfwSetWindowFocusCallback(window, callback);
        }
        internal static void SetCloseCallback(this NativeWindow window, WindowCallback callback) {
            glfwSetWindowCloseCallback(window, callback);
        }
        internal static void SetFileDropCallback(this NativeWindow window, FileDropCallback callback) {
            glfwSetDropCallback(window, callback);
        }
        internal static void SetCursorPositionCallback(this NativeWindow window, MouseCallback callback) {
            glfwSetCursorPosCallback(window, callback);
        }
        internal static void SetCursorEnterCallback(this NativeWindow window, MouseEnterCallback callback) {
            glfwSetCursorEnterCallback(window, callback);
        }
        internal static void SetMouseButtonCallback(this NativeWindow window, MouseButtonCallback callback) {
            glfwSetMouseButtonCallback(window, callback);
        }
        internal static void SetScrollCallback(this NativeWindow window, MouseCallback callback) {
            glfwSetScrollCallback(window, callback);
        }
        internal static void SetCharModsCallback(this NativeWindow window, CharModsCallback callback) {
            glfwSetCharModsCallback(window, callback);
        }
        internal static void SetFramebufferSizeCallback(this NativeWindow window, SizeCallback callback) {
            glfwSetFramebufferSizeCallback(window, callback);
        }
        internal static void SetRefreshCallback(this NativeWindow window, WindowCallback callback) {
            glfwSetWindowRefreshCallback(window, callback);
        }
        internal static void SetKeyCallback(this NativeWindow window, KeyCallback callback) {
            glfwSetKeyCallback(window, callback);
        }
        internal static void SetMaximizeCallback(this NativeWindow window, WindowMaximizedCallback callback) {
            glfwSetWindowMaximizeCallback(window, callback);
        }
        internal static void SetContentScaleCallback(this NativeWindow window, WindowContentsScaleCallback callback) {
            glfwSetWindowContentScaleCallback(window, callback);
        }
        #endregion  window extension methods


        #region     screen extension methods        
        /// <summary>
        ///     Retrieves the content scale for the specified screen. The content scale is the ratio between the
        ///     current DPI and the platform's default DPI.
        ///     <para>
        ///         This is especially important for text and any UI elements. If the pixel dimensions of your UI scaled by
        ///         this look appropriate on your machine then it should appear at a reasonable size on other machines
        ///         regardless of their DPI and scaling settings. This relies on the system DPI and scaling settings being
        ///         somewhat correct.
        ///     </para>
        /// </summary>
        /// <param name="screen">The screen to query.</param>
        internal static PointF GetContentScale(this NativeScreen screen) {
            glfwGetMonitorContentScale(screen, out float xScale, out float yScale);

            return new(xScale, yScale);
        }
        /// <summary>
        ///     Returns the current value of the user-defined pointer of the specified <paramref name="screen" />.
        /// </summary>
        /// <param name="screen">The screen whose pointer to return.</param>
        /// <returns>The user-pointer, or <see cref="IntPtr.Zero" /> if none is defined.</returns>
		internal static IntPtr GetUserHandle(this NativeScreen screen) {
            return glfwGetMonitorUserPointer(screen);
        }
        internal static VideoMode GetVideoMode(this NativeScreen screen) {
            if (screen == NativeScreen.Null) {
                screen = PrimaryScreen;
            }

            var ptr = glfwGetVideoMode(screen);

            return Marshal.PtrToStructure<VideoMode>(ptr);
        }
        /// <summary>
        ///     Returns the position, in screen coordinates, of the upper-left corner of the work area of the specified
        ///     screen along with the work area size in screen coordinates.
        ///     <para>
        ///         The work area is defined as the area of the screen not occluded by the operating system task bar
        ///         where present. If no task bar exists then the work area is the screen resolution in screen
        ///         coordinates.
        ///     </para>
        /// </summary>
        /// <param name="screen">The screen to query.</param>
		internal static Rectangle GetWorkArea(this NativeScreen screen) {
            glfwGetMonitorWorkarea(screen, out int x, out int y, out int width, out int height);

            return new(x, y, width, height);
        }
        /// <summary>
        ///     This function sets the user-defined pointer of the specified <paramref name="screen" />.
        ///     <para>The current value is retained until the screen is disconnected.</para>
        /// </summary>
        /// <param name="screen">The current <see cref="NativeScreen"/> whose pointer to set.</param>
        /// <param name="userHandle">The user-defined pointer value.</param>
		internal static void SetUserHandle(this NativeScreen screen, IntPtr userHandle) {
            glfwSetMonitorUserPointer(screen, userHandle);
        }
        #endregion  screen extension methods


        private static void Init() {
            IsInitialized = glfwInit();
        }

        private static void SetErrorCallback(ErrorCallback errorHandler) {
            glfwSetErrorCallback(errorHandler);
        }

        private static void GlfwError(ErrorCode code, IntPtr message) {
            //	I  don't like throwing an exception unless it is absolutely necessary
            throw new Exception(PtrToStringUTF8(message));
        }

        private static int GetInputMode(NativeWindow window, InputMode inputMode) {
            return glfwGetInputMode((NativeWindow)window, inputMode);
        }

        private static void SetInputMode(NativeWindow window, InputMode inputMode, int mode) {
            glfwSetInputMode((NativeWindow)window, inputMode, mode);
        }
        #endregion	non-public methods & functions
    }
}
