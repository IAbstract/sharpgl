// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;

using RazorSoft.Core;


namespace RazorSoft.Media.Core {

    /// <summary>
    ///     Arguments supplied with keyboard events.
    /// </summary>
    /// <seealso cref="EventArgs" />
    public class KeyEvent : EventArgs, IEventMessage {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="KeyEvent" /> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="scanCode">The platform scan code of the key.</param>
        /// <param name="state">The state of the key.</param>
        /// <param name="mods">The modifier keys.</param>
        public KeyEvent(Keys key, int scanCode, InputState state, ModifierKeys mods) {
            Key = key;
            ScanCode = scanCode;
            State = state;
            Modifiers = mods;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the key whose state change raised the event.
        /// </summary>
        /// <value>
        ///     The key.
        /// </value>
        public Keys Key { get; }

        /// <summary>
        ///     Gets the modifier keys at the time of the event.
        /// </summary>
        /// <value>
        ///     The modifiers.
        /// </value>
        public ModifierKeys Modifiers { get; }

        /// <summary>
        ///     Gets the platform scan code for the key.
        /// </summary>
        /// <value>
        ///     The scan code.
        /// </value>
        public int ScanCode { get; }

        /// <summary>
        ///     Gets the state of the key.
        /// </summary>
        /// <value>
        ///     The state.
        /// </value>
        public InputState State { get; }

        #endregion
    }

}