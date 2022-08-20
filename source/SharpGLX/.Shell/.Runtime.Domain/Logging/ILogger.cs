// Copyright: ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;


namespace RazorSoft.Media.Runtime.Logging {

    /// <summary>
    /// 
    /// </summary>
    public interface ILogger : IDisposable {
        #region 	properties
        /// <summary>
        /// Get logger name
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Get logger file path
        /// </summary>
        string FilePath { get; }
        /// <summary>
        /// Get or set the logger log level
        /// </summary>
        LogLevel LoggingLevel { get; set; }
        #endregion 	properties


        #region		public methods & functions
        /// <summary>
        /// Writes a message to the logger stream/output
        /// </summary>
        /// <param name="logEntry"></param>
        void Write(LogLevel loggingLevel, string logEntry);
        /// <summary>
        /// Writes a message to the logger stream/output followed by a line terminator
        /// </summary>
        /// <param name="logEntry"></param>
        void WriteLine(LogLevel loggingLevel, string logEntry);
        #endregion	public methods & functions
    }

}
