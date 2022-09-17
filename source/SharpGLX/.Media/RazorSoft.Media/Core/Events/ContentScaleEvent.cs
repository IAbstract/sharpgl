// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;

using RazorSoft.Core;


namespace RazorSoft.Media.Core {

    /// <summary>
    ///     Arguments used when a window content scaling is changed.
    /// </summary>
    public class ContentScaleEvent : EventArgs, IEventMessage {
        /// <summary>
        /// </summary>
        /// <param name="xScale">The new scale on the x-axis.</param>
        /// <param name="yScale">The new scale on the y-axis.</param>
        public ContentScaleEvent(float xScale, float yScale) {
            XScale = xScale;
            YScale = yScale;
        }

        /// <summary>
        ///     Gets the new scale on the x-axis.
        /// </summary>
        public float XScale { get; }

        /// <summary>
        ///     Gets the new scale on the y-axis.
        /// </summary>
        public float YScale { get; }
    }
}