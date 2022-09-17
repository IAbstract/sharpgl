// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;
using System.Drawing;
using System.Runtime.InteropServices;


namespace RazorSoft.Media {

    /// <summary>
    ///     Wrapper around a pointer to monitor.
    /// </summary>
    /// <seealso cref="NativeScreen" />
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeScreen : IEquatable<NativeScreen> {
        /// <summary>
        ///     Represents a <c>null</c> value for a <see cref="NativeScreen" /> object.
        /// </summary>
        public static readonly NativeScreen Null;

        /// <summary>
        ///     Internal pointer.
        /// </summary>
        private readonly IntPtr handle;

        /// <summary>
        ///     Determines whether the specified <see cref="NativeScreen" />, is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="NativeScreen" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(NativeScreen other) { return handle.Equals(other.handle); }

        /// <summary>
        ///     Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) {
            if (obj is NativeScreen monitor)
                return Equals(monitor);
            return false;
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() { return handle.GetHashCode(); }

        /// <summary>
        ///     Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator ==(NativeScreen left, NativeScreen right) {
            return left.Equals(right);
        }
        /// <summary>
        ///     Implements the operator !=.
        /// </summary>
        /// <param name="m1">The left.</param>
        /// <param name="m2">The right.</param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator !=(NativeScreen m1, NativeScreen m2) {
            return !m1.Equals(m2);
        }
        /// <summary>
        ///     Performs an implicit conversion from <see cref="NativeWindow" /> to <see cref="IntPtr" />.
        /// </summary>
        /// <param name="monitor">The window.</param>
        /// <returns>
        ///     The result of the conversion.
        /// </returns>
        public static implicit operator IntPtr(NativeScreen monitor) {
            return monitor.handle;
        }

        /// <summary>
        ///     Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() {
            return handle.ToString();
        }

        /// <summary>
        ///     Gets the position, in screen coordinates, of the valid work are for the monitor.
        /// </summary>
        /// <seealso cref="Glfw.GetWorkArea" />
        public Rectangle WorkArea => this.GetWorkArea();

        /// <summary>
        ///     Gets the content scale of this monitor.
        ///     <para>The content scale is the ratio between the current DPI and the platform's default DPI.</para>
        /// </summary>
        /// <seealso cref="Glfw.GetContentScale" />

        public PointF ContentScale {
            get {
                return this.GetContentScale();
            }
        }

        /// <summary>
        ///     Gets or sets a user-defined pointer to associate with the window.
        /// </summary>
        /// <seealso cref="Glfw.GetUserHandle" />
        /// <seealso cref="Glfw.SetUserHandle" />
        public IntPtr UserPointer {
            get => this.GetUserHandle();
            set => this.SetUserHandle(value);
        }
    }
}
