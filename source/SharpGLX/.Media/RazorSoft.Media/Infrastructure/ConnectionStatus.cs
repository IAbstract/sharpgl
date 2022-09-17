// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.

namespace RazorSoft.Media {
    /// <summary>
    ///     Strongly-typed values indicating connection status of joysticks, monitors, etc.
    /// </summary>
    public enum ConnectionStatus {
        /// <summary>
        ///     Unknown connection status.
        /// </summary>
        Unknown = 0x00000000,

        /// <summary>
        ///     Device is currently connected and visible to GLFW.
        /// </summary>
        Connected = 0x00040001,

        /// <summary>
        ///     Device is disconnected and/or not visible to GLFW.
        /// </summary>
        Disconnected = 0x00040002
    }
}
