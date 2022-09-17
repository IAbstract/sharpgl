// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System.Runtime.InteropServices;


namespace RazorSoft.Media {
    /// <summary>
    ///     Represents the state of a gamepad.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GamePadState {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        private readonly InputState[] states;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        private readonly float[] axes;

        /// <summary>
        ///     Gets the state of the specified <paramref name="button" />.
        /// </summary>
        /// <param name="button">The button to retrieve the state of.</param>
        /// <returns>The button state, either <see cref="InputState.Press" /> or <see cref="InputState.Release" />.</returns>
        public InputState GetButtonState(GamePadButton button) {
            return states[(int)button];
        }
        /// <summary>
        ///     Gets the value of the specified <paramref name="axis" />.
        /// </summary>
        /// <param name="axis">The axis to retrieve the value of.</param>
        /// <returns>The axis value, in the range of <c>-1.0</c> and <c>1.0</c> inclusive.</returns>
        public float GetAxis(GamePadAxis axis) {
            return axes[(int)axis];
        }
    }

}
