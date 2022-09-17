// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;

using RazorSoft.Core;


namespace RazorSoft.Media.Core {

    /// <summary>
    ///     Arguments supplied with file drag-drop events.
    /// </summary>
    /// <seealso cref="EventArgs" />
    public class FileDropEvent : EventArgs, IEventMessage {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileDropEvent" /> class.
        /// </summary>
        /// <param name="filenames">The dropped filenames.</param>
        public FileDropEvent(string[] filenames) { Filenames = filenames; }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the filenames of the dropped files.
        /// </summary>
        /// <value>
        ///     The filenames.
        /// </value>
        public string[] Filenames { get; }

        #endregion
    }

}