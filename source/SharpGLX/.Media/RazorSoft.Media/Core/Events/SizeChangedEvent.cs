// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;
using System.Drawing;

using RazorSoft.Core;


namespace RazorSoft.Media.Core {

    /// <summary>
    ///     Arguments supplied with size changing events.
    /// </summary>
    /// <seealso cref="EventArgs" />
    public class SizeChangedEvent : EventArgs, IEventMessage {
        #region Properties

        /// <summary>
        ///     Gets the new size.
        /// </summary>
        /// <value>
        ///     The size.
        /// </value>
        public Size Size { get; }

        #endregion


        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SizeChangedEvent" /> class.
        /// </summary>
        /// <param name="width">The new width.</param>
        /// <param name="height">The new height.</param>
        public SizeChangedEvent(int width, int height) : this(new Size(width, height)) { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SizeChangedEvent" /> class.
        /// </summary>
        /// <param name="size">The new size.</param>
        public SizeChangedEvent(Size size) {
            Size = size;
        }

        #endregion
    }
}