// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


namespace RazorSoft.Media {

    /// <summary>
    ///     Indicates the behavior of the mouse cursor.
    /// </summary>
    public enum CursorMode {
        /// <summary>
        ///     The cursor is visible and behaves normally.
        /// </summary>
        Normal = 0x00034001,
        /// <summary>
        ///     The cursor is invisible when it is over the client area of the window but does not restrict the cursor from
        ///     leaving.
        /// </summary>
        Hidden = 0x00034002,
        /// <summary>
        ///     Hides and grabs the cursor, providing virtual and unlimited cursor movement. This is useful for implementing for
        ///     example 3D camera controls.
        /// </summary>
        Disabled = 0x00034003
    }

    /// <summary>
    ///     Indicates sticky key mode for a <see cref="NativeWindow"/>
    /// </summary>
    public enum StickyKeysMode {
        /// <summary>
        ///     Mode unknown until we query native window
        /// </summary>
        Unknown = Glfw.DEFAULT,
        /// <summary>
        ///     Sticky keys mode enabled
        /// </summary>
        Enabled = Glfw.TRUE,
        /// <summary>
        ///     Sticky keys mode disabled
        /// </summary>
        Disabled = Glfw.FALSE,
    }

    /// <summary>
    ///     Indicates sticky button mode for a <see cref="NativeWindow"/>
    /// </summary>
    public enum StickyButtonsMode {
        /// <summary>
        ///     Mode unknown until we query native window
        /// </summary>
        Unknown = Glfw.DEFAULT,
        /// <summary>
        ///     Sticky buttons mode enabled
        /// </summary>
        Enabled = Glfw.TRUE,
        /// <summary>
        ///     Sticky buttons mode disabled
        /// </summary>
        Disabled = Glfw.FALSE,
    }
}
