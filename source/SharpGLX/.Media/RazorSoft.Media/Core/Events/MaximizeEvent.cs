// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;

using RazorSoft.Core;


namespace RazorSoft.Media.Core {

    /// <summary>
    ///     Arguments supplied with maximize events.
    /// </summary>
    public class MaximizeEvent : EventArgs, IEventMessage {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MaximizeEvent" /> class.
        /// </summary>
        /// <param name="maximized"><c>true</c> it maximized, otherwise <c>false</c>.</param>
        public MaximizeEvent(bool maximized) { IsMaximized = maximized; }

        /// <summary>
        ///     Gets value indicating if window was maximized, or being restored.
        /// </summary>
        public bool IsMaximized { get; }
    }
}