// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;
using System.Drawing;

using RazorSoft.Core;


namespace RazorSoft.Media.Core {

    /// <summary>
    ///     Arguments supplied with mouse movement events.
    /// </summary>
    /// <seealso cref="EventArgs" />
    public class MouseEvent : EventArgs, IEventMessage {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MouseEvent" /> class.
        /// </summary>
        /// <param name="x">
        ///     The cursor x-coordinate, relative to the left edge of the client area, or the amount of movement on
        ///     x-axis if this is scroll event.
        /// </param>
        /// <param name="y">
        ///     The cursor y-coordinate, relative to the left edge of the client area, or the amount of movement on
        ///     y-axis if this is scroll event.
        /// </param>
        public MouseEvent(double x, double y) {
            X = x;
            Y = y;
        }

        #endregion


        #region Properties

        /// <summary>
        ///     Gets the position of the mouse, relative to the screen.
        /// </summary>
        /// <value>
        ///     The position.
        /// </value>
        public Point Position => new Point(Convert.ToInt32(X), Convert.ToInt32(Y));

        /// <summary>
        ///     Gets the cursor x-coordinate, relative to the left edge of the client area, or the amount of movement on
        ///     x-axis if this is scroll event.
        /// </summary>
        /// <value>
        ///     The location on the x-axis.
        /// </value>
        public double X { get; }

        /// <summary>
        ///     Gets the cursor y-coordinate, relative to the left edge of the client area, or the amount of movement on
        ///     y-axis if this is scroll event.
        /// </summary>
        /// <value>
        ///     The location on the y-axis.
        /// </value>
        public double Y { get; }

        #endregion
    }


    public class MouseMoveEvent : MouseEvent {

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MouseEvent" /> class.
        /// </summary>
        /// <param name="x">
        ///     The cursor x-coordinate, relative to the left edge of the client area, or the amount of movement on
        ///     x-axis if this is scroll event.
        /// </param>
        /// <param name="y">
        ///     The cursor y-coordinate, relative to the left edge of the client area, or the amount of movement on
        ///     y-axis if this is scroll event.
        /// </param>
        public MouseMoveEvent(double x, double y) : base(x, y) { }
        #endregion
    }


    public class MouseScrollEvent : MouseEvent {

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MouseEvent" /> class.
        /// </summary>
        /// <param name="x">
        ///     The cursor x-coordinate, relative to the left edge of the client area, or the amount of movement on
        ///     x-axis if this is scroll event.
        /// </param>
        /// <param name="y">
        ///     The cursor y-coordinate, relative to the left edge of the client area, or the amount of movement on
        ///     y-axis if this is scroll event.
        /// </param>
        public MouseScrollEvent(double x, double y) : base(x, y) { }
        #endregion
    }
}