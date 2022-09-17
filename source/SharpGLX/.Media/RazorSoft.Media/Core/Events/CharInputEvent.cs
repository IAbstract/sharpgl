// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;

using RazorSoft.Core;


namespace RazorSoft.Media.Core {

    /// <summary>
    ///     Arguments supplied with char input events.
    /// </summary>
    /// <seealso cref="EventArgs" />
    public class CharInputEvent : EventArgs, IEventMessage {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="CharInputEvent" /> class.
        /// </summary>
        /// <param name="codePoint">A UTF-32 code point.</param>
        /// <param name="mods">The modifier keys present.</param>
        public CharInputEvent(uint codePoint, ModifierKeys mods) {
            CodePoint = codePoint;
            ModifierKeys = mods;
        }

        #endregion


        #region Properties

        /// <summary>
        ///     Gets the Unicode character for the code point.
        /// </summary>
        /// <value>
        ///     The character.
        /// </value>
        public string Char => char.ConvertFromUtf32(unchecked((int)CodePoint));

        /// <summary>
        ///     Gets the platform independent code point.
        ///     <para>This value can be treated as a UTF-32 code point.</para>
        /// </summary>
        /// <value>
        ///     The code point.
        /// </value>
        public uint CodePoint { get; }

        /// <summary>
        ///     Gets the modifier keys.
        /// </summary>
        /// <value>
        ///     The modifier keys.
        /// </value>
        public ModifierKeys ModifierKeys { get; }

        #endregion
    }
}