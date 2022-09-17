// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;
using System.Runtime.InteropServices;


namespace RazorSoft.Media {

    /// <summary>
    ///     Wrapper around a GLFW window pointer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeWindow : IEquatable<NativeWindow> {
        #region		fields
        private readonly IntPtr handle;
        #endregion	fields


        #region		configurations
        public static NativeWindow Null { get; }
        #endregion	configurations


        #region		properties
        /// <summary>
        ///     Internal pointer.
        /// </summary>
        public IntPtr Handle => handle;

        #endregion	properties


        #region		constructors & destructors
        /// <summary>
        /// Creates a new instance of the <see cref="NativeWindow"/> struct.
        /// </summary>
        /// <param name="nativeHandle">A pointer representing the window handle.</param>
        public NativeWindow(IntPtr nativeHandle) {
            handle = nativeHandle;
        }
        #endregion	constructors & destructors


        #region		public methods & functions
        /// <summary>
        ///     Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator ==(NativeWindow left, NativeWindow right) {
            return left.Equals(right);
        }
        /// <summary>
        ///     Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator !=(NativeWindow left, NativeWindow right) {
            return !left.Equals(right);
        }
        /// <summary>
        ///     Performs an implicit conversion from <see cref="NativeWindow" /> to <see cref="IntPtr" />.
        /// </summary>
        /// <param name="window">The native window.</param>
        /// <returns>
        ///     The result of the conversion.
        /// </returns>
        public static implicit operator IntPtr(NativeWindow window) {
            return window.handle;
        }
        /// <summary>
        ///     Performs an explicit conversion from <see cref="IntPtr"/> to <see cref="NativeWindow"/>.
        /// </summary>
        /// <param name="handle">A pointer representing the window handle.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator NativeWindow(IntPtr handle) {
            //  shouldn't we have validation that this is a NativeWindow handle according to GLFW?
            return new(handle);
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
        ///     Determines whether the specified <see cref="NativeWindow" />, is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="NativeWindow" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="NativeWindow" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(NativeWindow other) {
            return handle.Equals(other.handle);
        }
        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) {
            return (obj is NativeWindow window) ? Equals(window) : false;
        }
        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() {
            return handle.GetHashCode();
        }
        #endregion	public methods & functions


        #region		non-public methods & functions

        #endregion	non-public methods & functions
    }
}
