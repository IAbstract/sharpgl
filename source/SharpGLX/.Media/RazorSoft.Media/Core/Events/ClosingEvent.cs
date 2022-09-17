// Copyrights
// ©2018 Eric Freed; see original GLFW-Net Lic.
// ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System.ComponentModel;

using RazorSoft.Core;


namespace RazorSoft.Media.Core {

    /// <summary>
    /// Closing message with cancel args
    /// </summary>
    public class ClosingEvent : IEventMessage {
        #region		properties
        public bool IsCancelled { get; }
        #endregion	properties


        #region		constructors & destructors
        public ClosingEvent(CancelEventArgs eventArgs) {
            IsCancelled = eventArgs.Cancel;
        }
        #endregion	constructors & destructors
    }
}