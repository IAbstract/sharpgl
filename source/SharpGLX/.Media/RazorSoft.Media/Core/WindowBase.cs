// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;
using System.Linq;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;

using Microsoft.VisualBasic;
using Microsoft.Win32.SafeHandles;

using RazorSoft.Core;
using RazorSoft.Core.Messaging;
using RazorSoft.Core.Extensions;


namespace RazorSoft.Media.Core {

    /// <summary>
    ///     Provides a simplified interface for creating and using a GLFW window with properties, events, etc.
    /// </summary>
    /// <seealso cref="SafeHandleZeroOrMinusOneIsInvalid" />
    public abstract class WindowBase : SafeHandleZeroOrMinusOneIsInvalid, IEquatable<WindowBase> {
        #region		fields
        private static readonly EventPublisher events = EventPublisher.Default;

        private readonly NativeWindow window;

        private string title;

        private PositionCallback windowPositionCallback;
        private SizeCallback windowSizeCallback, framebufferSizeCallback;
        private FocusCallback windowFocusCallback;
        private WindowCallback closeCallback, windowRefreshCallback;
        private FileDropCallback dropCallback;
        private MouseCallback cursorPositionCallback, scrollCallback;
        private MouseEnterCallback cursorEnterCallback;
        private MouseButtonCallback mouseButtonCallback;
        private CharModsCallback charModsCallback;
        private KeyCallback keyCallback;
        private WindowMaximizedCallback windowMaximizeCallback;
        private WindowContentsScaleCallback windowContentScaleCallback;
        #endregion	fields


        #region     events
        /// <summary>
        ///     Occurs when the content scale has been changed.
        /// </summary>
        protected event EventHandler<ContentScaleEvent> ContentScaleChanged;
        /// <summary>
        ///     Occurs when the window is maximized or restored.
        /// </summary>
        protected event EventHandler<MaximizeEvent> MaximizeChanged;
        /// <summary>
        ///     Occurs when the window receives character input.
        /// </summary>
        protected event EventHandler<CharInputEvent> CharacterInput;
        /// <summary>
        ///     Occurs when the window is closed.
        /// </summary>
        protected event EventHandler Closed;
        /// <summary>
        ///     Occurs when the form is closing, and provides subscribers means of canceling the action..
        /// </summary>
        protected event CancelEventHandler Closing;
        /// <summary>
        ///     Occurs when the window is disposed.
        /// </summary>
        protected event EventHandler Disposed;
        /// <summary>
        ///     Occurs when files are dropped onto the window client area with a drag-drop event.
        /// </summary>
        protected event EventHandler<FileDropEvent> FileDrop;
        /// <summary>
        ///     Occurs when the window gains or loses focus.
        /// </summary>
        protected event EventHandler FocusChanged;
        /// <summary>
        ///     Occurs when the size of the internal framebuffer is changed.
        /// </summary>
        protected event EventHandler<SizeChangedEvent> FramebufferSizeChanged;
        /// <summary>
        ///     Occurs when a key is pressed, released, or repeated.
        /// </summary>
        protected event EventHandler<KeyEvent> KeyAction;
        /// <summary>
        ///     Occurs when a key is pressed.
        /// </summary>
        protected event EventHandler<KeyEvent> KeyPress;
        /// <summary>
        ///     Occurs when a key is released.
        /// </summary>
        protected event EventHandler<KeyEvent> KeyRelease;
        /// <summary>
        ///     Occurs when a key is held long enough to raise a repeat event.
        /// </summary>
        protected event EventHandler<KeyEvent> KeyRepeat;
        /// <summary>
        ///     Occurs when a mouse button is pressed or released.
        /// </summary>
        protected event EventHandler<MouseButtonEvent> MouseButton;
        /// <summary>
        ///     Occurs when the mouse cursor enters the client area of the window.
        /// </summary>
        protected event EventHandler MouseEnter;
        /// <summary>
        ///     Occurs when the mouse cursor leaves the client area of the window.
        /// </summary>
        protected event EventHandler MouseLeave;
        /// <summary>
        ///     Occurs when mouse cursor is moved.
        /// </summary>
        protected event EventHandler<MouseEvent> MouseMoved;
        /// <summary>
        ///     Occurs when mouse is scrolled.
        /// </summary>
        protected event EventHandler<MouseEvent> MouseScroll;
        /// <summary>
        ///     Occurs when position of the <see cref="WindowBase" /> is changed.
        /// </summary>
        protected event EventHandler PositionChanged;
        /// <summary>
        ///     Occurs when window is refreshed.
        /// </summary>
        protected event EventHandler Refreshed;
        /// <summary>
        ///     Occurs when size of the <see cref="window.Window" /> is changed.
        /// </summary>
        protected event EventHandler<SizeChangedEvent> SizeChanged;
        #endregion  events


        #region		properties
        /// <summary>
        ///     The <see cref="NativeWindow"/> instance this object wraps.
        /// </summary>
        internal NativeWindow NativeWindow => window;
        /// <summary>
        ///     Gets the monitor this window is fullscreen on.
        ///     <para>Returns <see cref="window.Monitor.None" /> if window is not fullscreen.</para>
        /// </summary>
        /// <value>
        ///     The monitor.
        /// </value>
        internal NativeScreen Screen => window.GetScreen();

        /// <summary>
        ///     Gets or sets the size and location of the window including its non-client elements (borders, title bar, etc.), in
        ///     screen coordinates.
        /// </summary>
        /// <value>
        ///     A <see cref="Rectangle" /> in screen coordinates relative to the parent control that represents the size and
        ///     location of the control including its non-client elements.
        /// </value>
        public Rectangle Bounds {
            get => new Rectangle(Position, Size);
            set {
                Size = value.Size;
                Position = value.Location;
            }
        }
        /// <summary>
        ///     Gets the ratio between the current DPI and the platform's default DPI.
        /// </summary>
        /// <seealso cref="window.GetWindowContentScale" />
        public PointF ContentScale {
            get {
                return window.GetContentScale();
            }
        }
        /// <summary>
        ///     Gets the size and location of the client area of the in screen coordinates.
        /// </summary>
        /// <value>
        ///     A <see cref="Rectangle" /> in screen coordinates that represents the size and location of the window's client area.
        /// </value>
        public Rectangle ClientBounds {
            get => new Rectangle(Position, ClientSize);
            set {
                window.SetPosition(value.Location);
                window.SetSize(value.Size);
            }
        }
        /// <summary>
        ///     Gets or sets the width of the client area of the in screen coordinates.
        /// </summary>
        /// <exception cref="Exception">Thrown when specified value is less than 1.</exception>
        public int ClientWidth {
            get {
                return ClientSize.Width;
            }
            set {
                if (value < 1) {
                    throw new Exception("Window width muts be greater than 0.");
                }

                var size = ClientSize;
                size.Width = value;

                ClientSize = size;
            }
        }
        /// <summary>
        ///     Gets or sets the height of the client area of the in screen coordinates.
        /// </summary>
        /// <exception cref="Exception">Thrown when specified value is less than 1.</exception>
        public int ClientHeight {
            get {
                return ClientSize.Height;
            }
            set {
                if (value < 1) {
                    throw new Exception("Window height muts be greater than 0.");
                }

                var size = ClientSize;
                size.Height = value;

                ClientSize = size;
            }
        }
        /// <summary>
        ///     Gets or sets the size of the client area of the in screen coordinates.
        /// </summary>
        /// <value>
        ///     A <see cref="System.Drawing.Size" /> in screen coordinates that represents the size of the window's client area.
        /// </value>
        public Size ClientSize {
            get => window.GetSize();
            set => window.SetSize(value);
        }
        /// <summary>
        ///     Requests user-attention to this window on platforms that support it,
        ///     <para>
        ///         Once the user has given attention, usually by focusing the window or application, the system will end the
        ///         request automatically.
        ///     </para>
        /// </summary>
        public void RequestAttention() {
            window.RequestAttention();
        }
        /// <summary>
        ///     Gets or sets a string to the system clipboard.
        /// </summary>
        /// <value>
        ///     The clipboard string.
        /// </value>
        public string Clipboard {
            get => window.GetClipboardString();
            set => window.SetClipboardString(value);
        }
        /// <summary>
        ///     Gets or sets the behavior of the mouse cursor.
        /// </summary>
        /// <value>
        ///     The cursor mode.
        /// </value>
        public CursorMode CursorMode {
            get => window.GetCursorMode();
            set => window.SetCursorMode(value);
        }
        /// <summary>
        ///     Gets the underlying pointer used by GLFW for this window instance.
        /// </summary>
        /// <value>
        ///     The GLFW window handle.
        /// </value>
        public IntPtr Handle => handle;

        ///// <summary>
        /////       TODO: Move to WindowsImpl platform
        /////     Gets the Window's HWND for this window.
        /////     <para>WARNING: Windows only.</para>
        ///// </summary>
        ///// <value>
        /////     The HWND pointer.
        ///// </value>
        //// ReSharper disable once IdentifierTypo
        //public IntPtr Hwnd {
        //    get {
        //        try {
        //            return Media.Native.GetWin32Window();
        //        }
        //        catch (Exception) {
        //            return IntPtr.Zero;
        //        }
        //    }
        //}

        /// <summary>
        ///     Gets a value indicating whether this instance is closing.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is closing; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosing => window.ShouldClose();
        /// <summary>
        ///     Gets a value indicating whether this instance is decorated.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is decorated; otherwise, <c>false</c>.
        /// </value>
        public bool IsDecorated => window.GetAttribute(WindowAttribute.Decorated);
        /// <summary>
        ///     Gets a value indicating whether this instance is floating (top-most, always-on-top).
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is floating; otherwise, <c>false</c>.
        /// </value>
        public bool IsFloating => window.GetAttribute(WindowAttribute.Floating);
        /// <summary>
        ///     Gets a value indicating whether this instance is focused.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is focused; otherwise, <c>false</c>.
        /// </value>
        public bool IsFocused => window.GetAttribute(WindowAttribute.Focused);
        /// <summary>
        ///     Gets a value indicating whether this instance is resizable.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is resizable; otherwise, <c>false</c>.
        /// </value>
        public bool IsResizable => window.GetAttribute(WindowAttribute.Resizable);
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="window.Window" /> is maximized.
        ///     <para>Has no effect on fullscreen windows.</para>
        /// </summary>
        /// <value>
        ///     <c>true</c> if maximized; otherwise, <c>false</c>.
        /// </value>
        public bool Maximized {
            get => window.GetAttribute(WindowAttribute.Maximized);
            set {
                if (value) {
                    window.Maximize();
                }
                else {
                    window.Restore();
                }
            }
        }
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="window.Window" /> is minimized.
        ///     <para>If window is already minimized, does nothing.</para>
        /// </summary>
        /// <value>
        ///     <c>true</c> if minimized; otherwise, <c>false</c>.
        /// </value>
        public bool Minimized {
            get => window.GetAttribute(WindowAttribute.AutoIconify);
            set {
                if (value)
                    window.Iconify();
                else
                    window.Restore();
            }
        }
        /// <summary>
        ///     Gets or sets the mouse position in screen-coordinates relative to the client area of the window.
        /// </summary>
        /// <value>
        ///     The mouse position.
        /// </value>
        public Point MousePosition {
            get => window.GetCursorPosition();
            set => window.SetCursorPosition(value);
        }
        /// <summary>
        ///     Gets or sets the opacity of the window in the range of <c>0.0</c> and <c>1.0</c> inclusive.
        /// </summary>
        public float Opacity {
            get => window.GetOpacity();
            set => window.SetOpacity(value);
        }
        /// <summary>
        ///     Gets or sets the position of the window in screen coordinates, including border, titlebar, etc..
        /// </summary>
        /// <value>
        ///     The position.
        /// </value>
        public Point Position {
            get {
                return window.GetPosition();
            }
            set {
                var frameRect = window.GetFrameRectangle();
                var location = new Point(value.X + frameRect.Left, value.Y + frameRect.Top);

                window.SetPosition(location);
            }
        }
        /// <summary>
        ///     Gets or sets the size of the in screen coordinates, including border, titlebar, etc.
        /// </summary>
        /// <value>
        ///     A <see cref="System.Drawing.Size" /> in screen coordinates that represents the size of the window.
        /// </value>
        public Size Size {
            get {
                var size = window.GetSize();
                var framRect = window.GetFrameRectangle();
                var xOffset = framRect.Left + framRect.Right;
                var yOffset = framRect.Top + framRect.Bottom;

                return new(size.Width + xOffset, size.Height + yOffset);
            }
            set {
                var frameRect = window.GetFrameRectangle();
                var xOffset = frameRect.Left - frameRect.Right;
                var yOffset = frameRect.Top - frameRect.Bottom;
                var size = new Size(value.Width - xOffset, value.Height - yOffset);

                window.SetSize(size);
            }
        }
        /// <summary>
        ///     Sets the sticky keys input mode.
        ///     <para>
        ///         Set to <c>true</c> to enable sticky keys, or <c>false</c> to disable it. If sticky keys are enabled, a key
        ///         press will ensure that <see cref="window.GetKey" /> returns <see cref="InputState.Press" /> the next time it is
        ///         called even if the key had been released before the call. This is useful when you are only interested in
        ///         whether keys have been pressed but not when or in which order.
        ///     </para>
        /// </summary>
        public bool StickyKeys {
            // get => window.GetInputMode(InputMode.StickyKeys) == (int)Constants.True;
            get => window.GetStickyKeysMode() == StickyKeysMode.Enabled;
            set => window.SetStickKeysMode(value ? StickyKeysMode.Enabled : StickyKeysMode.Disabled);
        }
        /// <summary>
        ///     Gets or sets the sticky mouse button input mode.
        ///     <para>
        ///         Set to <c>true</c> to enable sticky mouse buttons, or <c>false</c> to disable it. If sticky mouse buttons are
        ///         enabled, a mouse button press will ensure that <see cref="window.GetMouseButton" /> returns
        ///         <see cref="InputState.Press" /> the next time it is called even if the mouse button had been released before
        ///         the call. This is useful when you are only interested in whether mouse buttons have been pressed but not when
        ///         or in which order.
        ///     </para>
        /// </summary>
        public bool StickyMouseButtons {
            get => window.GetStickyButtonsMode() == StickyButtonsMode.Enabled;
            set => window.SetStickyButtonsMode(value ? StickyButtonsMode.Enabled : StickyButtonsMode.Disabled);
        }
        /// <summary>
        ///     Gets or sets the window title or caption.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        public string Title {
            get => title;
            set => title = window.SetTitle(value);
        }
        /// <summary>
        ///     Gets or sets a user-defined pointer for GLFW to retain for this instance.
        /// </summary>
        /// <value>
        ///     The user-defined pointer.
        /// </value>
        public IntPtr UserPointer {
            get => window.GetUserHandle();
            set => window.SetUserHandle(value);
        }
        /// <summary>
        ///     Gets the video mode for the screen this window is fullscreen on.
        ///     <para>If window is not fullscreen, returns the <see cref="window.VideoMode" /> for the primary screen.</para>
        /// </summary>
        /// <value>
        ///     The video mode.
        /// </value>
        public VideoMode VideoMode {
            get => Screen.GetVideoMode();
        }
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="window.Window" /> is visible.
        /// </summary>
        /// <value>
        ///     <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        public bool Visible {
            get => window.GetAttribute(WindowAttribute.Visible);
            set => window.SetVisibility(value);
        }

        #endregion	properties


        #region		constructors & destructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="window.Window" /> class.
        /// </summary>
        public WindowBase() : this(800, 600, string.Empty, NativeScreen.Null, NativeWindow.Null) { }
        /// <summary>
        ///     Initializes a new instance of the <see cref="window.Window" /> class.
        /// </summary>
        /// <param name="width">The desired width, in screen coordinates, of the window. This must be greater than zero.</param>
        /// <param name="height">The desired height, in screen coordinates, of the window. This must be greater than zero.</param>
        /// <param name="title">The initial window title.</param>
        public WindowBase(int width, int height, string title) : this(width, height, title, NativeScreen.Null, NativeWindow.Null) { }
        /// <summary>
        ///     Initializes a new instance of the <see cref="window.Window" /> class.
        /// </summary>
        /// <param name="width">The desired width, in screen coordinates, of the window. This must be greater than zero.</param>
        /// <param name="height">The desired height, in screen coordinates, of the window. This must be greater than zero.</param>
        /// <param name="title">The initial window title.</param>
        /// <param name="monitor">The monitor to use for full screen mode, or <see cref="window.Monitor.None" /> for windowed mode.</param>
        /// <param name="share">
        ///     A window instance whose context to share resources with, or <see cref="window.Window.None" /> to not share
        ///     resources..
        /// </param>
        internal WindowBase(int width, int height, string title, NativeScreen monitor, NativeWindow share) : base(true) {
            window = Glfw.CreateWindow(width, height, title ?? string.Empty, monitor, share);
            SetHandle(window);

            if (window.GetClientApi() != ClientApi.None) {
                MakeCurrent();
            }

            BindCallbacks();
            CreatePublications();
        }
        #endregion	constructors & destructors


        #region		public methods & functions
        /// <summary>
        ///     Determines whether the specified window is equal to this instance.
        /// </summary>
        /// <param name="left">This instance.</param>
        /// <param name="right">A <see cref="window.Window" /> instance to compare for equality.</param>
        /// <returns><c>true</c> if objects represent the same otherwise <c>false</c>.</returns>
        public static bool operator ==(WindowBase left, WindowBase right) {
            return Equals(left, right);
        }
        /// <summary>
        ///     Determines whether the specified window is not equal to this instance.
        /// </summary>
        /// <param name="left">This instance.</param>
        /// <param name="right">A <see cref="window.Window" /> instance to compare for equality.</param>
        /// <returns><c>true</c> if objects do not represent the same otherwise <c>false</c>.</returns>
        public static bool operator !=(WindowBase left, WindowBase right) {
            return !Equals(left, right);
        }

        /// <summary>
        ///     Centers the on window on the screen.
        ///     <para>Has no effect on fullscreen or maximized windows.</para>
        /// </summary>
        public void CenterOnScreen() {
            if (Maximized)
                return;
            var screen = Screen == NativeScreen.Null ? Glfw.PrimaryScreen : Screen;
            var videoMode = screen.GetVideoMode();
            var size = Size;
            Position = new Point((videoMode.Width - size.Width) / 2, (videoMode.Height - size.Height) / 2);
        }
        /// <summary>
        ///     Closes this instance.
        ///     <para>This invalidates the but does not free its resources.</para>
        /// </summary>
        public new void Close() {
            window.SetShouldClose(true);
            OnClosing();

            base.Close();
        }
        /// <summary>
        ///     Focuses this form to receive input and events.
        /// </summary>
        public void Focus() {
            window.SetFocus();
        }
        /// <summary>
        ///     Sets the window fullscreen on the primary monitor.
        /// </summary>
        public void Fullscreen() {
            Fullscreen(Screen == NativeScreen.Null ? Glfw.PrimaryScreen : Screen);
        }
        /// <summary>
        ///     Makes window and its context the current.
        /// </summary>
        public void MakeCurrent() {
            window.SetCurrentContext();
        }
        /// <summary>
        ///     Maximizes this window to fill the screen.
        ///     <para>Has no effect if window is already maximized.</para>
        /// </summary>
        public void Maximize() {
            window.Maximize();
        }
        /// <summary>
        ///     Minimizes this window.
        ///     <para>Has no effect if window is already minimized.</para>
        /// </summary>
        public void Minimize() {
            window.Iconify();
        }
        /// <summary>
        ///     Restores a minimized window to its previous state.
        ///     <para>Has no effect if window was already restored.</para>
        /// </summary>
        public void Restore() {
            window.Restore();
        }
        /// <summary>
        ///     Sets the aspect ratio to maintain for the window.
        ///     <para>This function is ignored for fullscreen windows.</para>
        /// </summary>
        /// <param name="numerator">The numerator of the desired aspect ratio.</param>
        /// <param name="denominator">The denominator of the desired aspect ratio.</param>
        public void SetAspectRatio(int numerator, int denominator) {
            window.SetAspectRatio(numerator, denominator);
        }
        /// <summary>
        ///     Sets the icon(s) used for the titlebar, taskbar, etc.
        ///     <para>Standard sizes are 16x16, 32x32, and 48x48.</para>
        /// </summary>
        /// <param name="images">One or more images to set as an icon.</param>
        public void SetIcons(Image[] images) {
            window.SetIcon(images);
        }
        /// <summary>
        ///     Sets the limits of the client size  area of the window.
        /// </summary>
        /// <param name="minSize">The minimum size of the client area.</param>
        /// <param name="maxSize">The maximum size of the client area.</param>
        public void SetSizeLimits(Size minSize, Size maxSize) {
            window.SetSizeLimits(minSize, maxSize);
        }
        /// <summary>
        ///     Swaps the front and back buffers when rendering with OpenGL or OpenGL ES.
        ///     <para>
        ///         This should not be called on a window that is not using an OpenGL or OpenGL ES context (.i.e. Vulkan).
        ///     </para>
        /// </summary>
        public void SwapBuffers() {
            window.SwapBuffers();
        }
        /// <summary>
        ///     Determines whether the specified <paramref name="window" /> is equal to this instance.
        /// </summary>
        /// <param name="window">A <see cref="WindowBase" /> instance to compare for equality.</param>
        /// <returns><c>true</c> if objects represent the same otherwise <c>false</c>.</returns>
        public bool Equals(WindowBase window) {
            if (ReferenceEquals(null, window)) {
                return false;
            }

            return ReferenceEquals(this, window) || this.window.Equals(window.window);
        }
        /// <inheritdoc cref="Object.Equals(object)" />
        public override bool Equals(object obj) {
            return ReferenceEquals(this, obj) || obj is WindowBase other && Equals(other);
        }
        /// <inheritdoc cref="Object.GetHashCode" />
        public override int GetHashCode() {
            return window.GetHashCode();
        }
        #endregion	public methods & functions


        #region		non-public methods & functions
        protected void Publish(IEventMessage message) {
            message.Publish();
        }
        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only
        ///     unmanaged resources.
        /// </param>
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            Disposed?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        ///     Releases the internal GLFW handle.
        /// </summary>
        /// <returns><c>true</c> if handle was released successfully, otherwise <c>false</c>.</returns>
        protected override bool ReleaseHandle() {
            try {
                window.DestroyWindow();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        /// <summary>
        ///     Sets the window fullscreen on the specified monitor.
        /// </summary>
        /// <param name="screen">The monitor to display the window fullscreen.</param>
        internal void Fullscreen(NativeScreen screen) {
            SetMonitor(screen, new(0, 0, 0, 0), -1);
        }
        /// <summary>
        ///     Sets the window screen.
        ///     <para>
        ///         If <paramref name="screen" /> is not <see cref="NativeScreen.Null" />, the window will be full-screened and
        ///         dimensions ignored.
        ///     </para>
        /// </summary>
        /// <param name="screen">The desired monitor, or <see cref="window.Monitor.None" /> to set windowed mode.</param>
        /// <param name="x">The desired x-coordinate of the upper-left corner of the client area.</param>
        /// <param name="y">The desired y-coordinate of the upper-left corner of the client area.</param>
        /// <param name="width">The desired width, in screen coordinates, of the client area or video mode.</param>
        /// <param name="height">The desired height, in screen coordinates, of the client area or video mode.</param>
        /// <param name="refreshRate">The desired refresh rate, in Hz, of the video mode, or <see cref="Constants.Default" />.</param>
        internal void SetMonitor(NativeScreen screen, Rectangle client, int refreshRate = Glfw.DEFAULT) {
            window.SetScreen(screen, client, refreshRate);
        }

        private void BindCallbacks() {
            windowPositionCallback = (_, x, y) => OnPositionChanged(x, y);
            windowSizeCallback = (_, w, h) => OnSizeChanged(w, h);
            windowFocusCallback = (_, focusing) => OnFocusChanged(focusing);
            closeCallback = _ => OnClosing();
            dropCallback = (_, count, arrayPtr) => OnFileDrop(count, arrayPtr);
            cursorPositionCallback = (_, x, y) => OnMouseMove(x, y);
            cursorEnterCallback = (_, entering) => OnMouseEnter(entering);
            mouseButtonCallback = (_, button, state, mod) => OnMouseButton(button, state, mod);
            scrollCallback = (_, x, y) => OnMouseScroll(x, y);
            charModsCallback = (_, cp, mods) => OnCharacterInput(cp, mods);
            framebufferSizeCallback = (_, w, h) => OnFramebufferSizeChanged(w, h);
            windowRefreshCallback = _ => Refreshed?.Invoke(this, EventArgs.Empty);
            keyCallback = (_, key, code, state, mods) => OnKey(key, code, state, mods);
            windowMaximizeCallback = (_, maximized) => OnMaximizeChanged(maximized);
            windowContentScaleCallback = (_, x, y) => OnContentScaleChanged(x, y);

            window.SetPositionCallback(windowPositionCallback);
            window.SetSizeCallback(windowSizeCallback);
            window.SetFocusCallback(windowFocusCallback);
            window.SetCloseCallback(closeCallback);
            window.SetFileDropCallback(dropCallback);
            window.SetCursorPositionCallback(cursorPositionCallback);
            window.SetCursorEnterCallback(cursorEnterCallback);
            window.SetMouseButtonCallback(mouseButtonCallback);
            window.SetScrollCallback(scrollCallback);
            window.SetCharModsCallback(charModsCallback);
            window.SetFramebufferSizeCallback(framebufferSizeCallback);
            window.SetRefreshCallback(windowRefreshCallback);
            window.SetKeyCallback(keyCallback);
            window.SetMaximizeCallback(windowMaximizeCallback);
            window.SetContentScaleCallback(windowContentScaleCallback);
        }

        private void CreatePublications() {
            events.CreatePublication<CharInputEvent>();
            events.CreatePublication<ContentScaleEvent>();
            events.CreatePublication<FileDropEvent>();
            events.CreatePublication<ClosingEvent>();
            events.CreatePublication<ClosedEvent>();
            events.CreatePublication<FocusChangedEvent>();
            events.CreatePublication<SizeChangedEvent>();
            events.CreatePublication<KeyEvent>();
            events.CreatePublication<MouseMoveEvent>();
            events.CreatePublication<MouseScrollEvent>();
        }


        /// <summary>
        ///     Raises the <see cref="CharacterInput" /> event.
        /// </summary>
        /// <param name="codePoint">The Unicode code point.</param>
        /// <param name="mods">The modifier keys present.</param>
        protected virtual void OnCharacterInput(uint codePoint, ModifierKeys mods) {
            CharInputEvent message =  new CharInputEvent(codePoint, mods);

            CharacterInput?.Invoke(this, message);
            Publish(message);
        }
        /// <summary>
        ///     Raises the <see cref="Closed" /> event.
        /// </summary>
        protected virtual void OnClosed() {
            Closed?.Invoke(this, EventArgs.Empty);
            Publish(new ClosedEvent());
        }
        /// <summary>
        ///     Raises the <see cref="Closing" /> event.
        /// </summary>
        protected virtual void OnClosing() {
            var args = new CancelEventArgs();

            Closing?.Invoke(this, args);
            Publish(new ClosingEvent(args));

            if (args.Cancel) {
                window.SetShouldClose(false);
            }
            else {
                base.Close();
                OnClosed();
            }
        }
        /// <summary>
        ///     Raises the <see cref="ContentScaleChanged" /> event.
        /// </summary>
        /// <param name="xScale">The new scale on the x-axis.</param>
        /// <param name="yScale">The new scale on the y-axis.</param>
        protected virtual void OnContentScaleChanged(float xScale, float yScale) {
            ContentScaleEvent message = new(xScale, yScale);

            ContentScaleChanged?.Invoke(this, message);
            Publish(message);
        }
        /// <summary>
        ///     Raises the <see cref="FileDrop" /> event.
        /// </summary>
        /// <param name="paths">The filenames of the dropped files.</param>
        protected virtual void OnFileDrop(string[] paths) {
            if (paths is null || !paths.Any()) {
                return;
            }
            FileDropEvent message = new FileDropEvent(paths);

            FileDrop?.Invoke(this, message);
            Publish(message);
        }
        /// <summary>
        ///     Raises the <see cref="FocusChanged" /> event.
        /// </summary>
        /// <param name="focusing"><c>true</c> if window is gaining focus, otherwise <c>false</c>.</param>
        protected virtual void OnFocusChanged(bool focusing) {
            FocusChanged?.Invoke(this, EventArgs.Empty);
            Publish(new FocusChangedEvent());
        }
        /// <summary>
        ///     Raises the <see cref="FramebufferSizeChanged" /> event.
        /// </summary>
        /// <param name="width">The new width.</param>
        /// <param name="height">The new height.</param>
        protected virtual void OnFramebufferSizeChanged(int width, int height) {
            SizeChangedEvent message = new SizeChangedEvent(new Size(width, height));

            FramebufferSizeChanged?.Invoke(this, message);
            Publish(message);
        }
        /// <summary>
        ///     Raises the appropriate key events.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="scanCode">The scan code.</param>
        /// <param name="state">The state of the key.</param>
        /// <param name="mods">The modifier keys.</param>
        /// <seealso cref="KeyPress" />
        /// <seealso cref="KeyRelease" />
        /// <seealso cref="KeyRepeat" />
        /// <seealso cref="KeyAction" />
        protected virtual void OnKey(Keys key, int scanCode, InputState state, ModifierKeys mods) {
            KeyEvent message = new (key, scanCode, state, mods);

            if (state.HasFlag(InputState.Press)) {
                KeyPress?.Invoke(this, message);
            }
            else if (state.HasFlag(InputState.Release)) {
                KeyRelease?.Invoke(this, message);
            }
            else {
                KeyRepeat?.Invoke(this, message);
            }


            KeyAction?.Invoke(this, message);
            Publish(message);
        }
        /// <summary>
        ///     Raises the <see cref="Maximized" /> event.
        /// </summary>
        /// <param name="maximized">Flag indicating if window is being maximized or restored.</param>
        protected virtual void OnMaximizeChanged(bool maximized) {
            MaximizeEvent message = new(maximized);

            MaximizeChanged?.Invoke(this, message);
            Publish(message);
        }
        /// <summary>
        ///     Raises the <see cref="MouseButton" /> event.
        /// </summary>
        /// <param name="button">The mouse button.</param>
        /// <param name="state">The state of the mouse button.</param>
        /// <param name="modifiers">The modifier keys.</param>
        protected virtual void OnMouseButton(MouseButton button, InputState state, ModifierKeys modifiers) {
            MouseButtonEvent message = new (button, state, modifiers);

            MouseButton?.Invoke(this, message);
            Publish(message);
        }
        /// <summary>
        ///     Raises the <see cref="MouseEnter" /> and <see cref="MouseLeave" /> events.
        /// </summary>
        /// <param name="entering"><c>true</c> if mouse is entering otherwise <c>false</c> if it is leaving.</param>
        protected virtual void OnMouseEnter(bool entering) {
            if (entering)
                MouseEnter?.Invoke(this, EventArgs.Empty);
            else
                MouseLeave?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        ///     Raises the <see cref="MouseMoved" /> event.
        /// </summary>
        /// <param name="x">The new x-coordinate of the mouse.</param>
        /// <param name="y">The new y-coordinate of the mouse.</param>
        protected virtual void OnMouseMove(double x, double y) {
            MouseMoveEvent message = new (x, y);

            MouseMoved?.Invoke(this, message);
            Publish(message);
        }
        /// <summary>
        ///     Raises the <see cref="MouseScroll" /> event.
        /// </summary>
        /// <param name="x">The amount of the scroll on the x-axis.</param>
        /// <param name="y">The amount of the scroll on the y-axis.</param>
        protected virtual void OnMouseScroll(double x, double y) {
            MouseScrollEvent message = new (x, y);

            MouseScroll?.Invoke(this, message);
            Publish(message);
        }
        /// <summary>
        ///     Raises the <see cref="PositionChanged" /> event.
        /// </summary>
        /// <param name="x">The new position on the x-axis.</param>
        /// <param name="y">The new position on the y-axis.</param>
        protected virtual void OnPositionChanged(double x, double y) {
            PositionChanged?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        ///     Raises the <see cref="SizeChanged" /> event.
        /// </summary>
        /// <param name="width">The new width.</param>
        /// <param name="height">The new height.</param>
        protected virtual void OnSizeChanged(int width, int height) {
            SizeChangedEvent message = new (new Size(width, height));

            SizeChanged?.Invoke(this, message);
            Publish(message);
        }

        private void OnFileDrop(int count, IntPtr pointer) {
            var paths = new string[count];
            var offset = 0;

            for (var i = 0; i < count; i++, offset += IntPtr.Size) {
                var ptr = Marshal.ReadIntPtr(pointer + offset);
                paths[i] = Glfw.PtrToStringUTF8(ptr);
            }

            OnFileDrop(paths);
        }

        #endregion	non-public methods & functions
    }
}
