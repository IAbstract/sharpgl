// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;
using System.Text;
using System.Runtime.InteropServices;


namespace RazorSoft.Media {

    public static partial class Glfw {
        internal const float NANF = float.NaN;
        internal const float MINF = 0.0F;
        internal const float MAXF = 1.0F;

        public static Encoding Encoder { get; } = Encoding.UTF8;

        /// <summary>
        ///     Reads memory from the pointer until the first null byte is encountered and decodes the bytes from UTF-8 into a
        ///     managed <see cref="string" />.
        /// </summary>
        /// <param name="ptr">Pointer to the start of the string.</param>
        /// <returns>Managed string created from read UTF-8 bytes.</returns>
        public static string PtrToStringUTF8(IntPtr ptr) {
            if (ptr != IntPtr.Zero) {
                var length = 0;

                while (Marshal.ReadByte(ptr, length) != 0) {
                    ++length;
                }

                var buffer = new byte[length];
                Marshal.Copy(ptr, buffer, 0, length);

                return Encoding.UTF8.GetString(buffer);
            }

            return string.Empty;
        }
        public static byte[] Encode(string value) {
            return Encoder.GetBytes(value);
        }
        /// <summary>
        ///     Returns the larger of two single-precision floating-point numbers.
        /// </summary>
        /// <param name="f1">The first of two single-precision floating-point numbers to compare.</param>
        /// <param name="f2">The second of two single-precision floating-point numbers to compare.</param>
        /// <returns>
        ///     Parameter f1 or f2, whichever is larger.
        ///     <para>
        ///         If f1, f2, or both f1 and f2 are equal to <see cref="float.NaN"/>, <see cref="MAXF"/> is returned.
        ///     </para>
        /// </returns>
        public static float Max(float f1, float f2) {
            var max = Math.Max(f1, f2);

            return max == NANF ? MAXF : max;
        }
        /// <summary>
        ///     Returns the smaller of two single-precision floating-point numbers.
        /// </summary>
        /// <param name="f1">The first of two single-precision floating-point numbers to compare.</param>
        /// <param name="f2">The second of two single-precision floating-point numbers to compare.</param>
        /// <returns>
        ///     Parameter f1 or f2, whichever is smaller.
        ///     <para>
        ///         If f1, f2, or both f1 and f2 are equal to <see cref="float.NaN"/>, the <see cref="MINF"/> value is returned.
        ///     </para>
        /// </returns>
        public static float Min(float f1, float f2) {
            var min = Math.Min(f1, f2);

            return min == NANF ? MINF :  min;
        }
    }

    /// <summary>
    ///     Used internally to consolidate strongly-typed values for getting/setting window attributes.
    /// </summary>
    internal enum ContextAttributes {
        ClientApi = 0x00022001,
        ContextCreationApi = 0x0002200B,
        ContextVersionMajor = 0x00022002,
        ContextVersionMinor = 0x00022003,
        ContextVersionRevision = 0x00022004,
        OpenglForwardCompat = 0x00022006,
        OpenglDebugContext = 0x00022007,
        OpenglProfile = 0x00022008,
        ContextRobustness = 0x00022005
    }

}
