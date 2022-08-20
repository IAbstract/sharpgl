// Copyright: ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System.Diagnostics;


namespace RazorSoft.Media.Runtime.Logging {

    /// <summary>
    /// 
    /// </summary>
    public abstract class Logger : ILogger {
        #region		fields
        #endregion	fields


        #region		properties
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public string FilePath { get; protected init; }
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public LogLevel LoggingLevel { get; set; } = LogLevel.Info;
        #endregion	properties


        #region		constructors & destructors
        internal Logger(string name) {
            Name = name;
        }
        #endregion	constructors & destructors


        #region		public methods & functions
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggingLevel"></param>
        /// <param name="logEntry"></param>
        public abstract void Write(LogLevel loggingLevel, string logEntry);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggingLevel"></param>
        /// <param name="logEntry"></param>
        public abstract void WriteLine(LogLevel loggingLevel, string logEntry);
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void Dispose() { }
        #endregion	public methods & functions


        #region		non-public methods & functions

        #endregion	non-public methods & functions
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class TraceLogger : TraceListener, ILogger {
        #region		fields

        #endregion	fields


        #region		properties
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public string FilePath { get; protected init; }
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public LogLevel LoggingLevel { get; set; } = LogLevel.Info;
        #endregion	properties


        #region		constructors & destructors
        protected TraceLogger(string name) {
            Name = name;
        }
        #endregion	constructors & destructors


        #region		public methods & functions
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="loggingLevel"></param>
        /// <param name="logEntry"></param>
        public abstract void Write(LogLevel loggingLevel, string logEntry);
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="logEntry"></param>
        public override void Write(string logEntry) {
            Write(LoggingLevel, logEntry);
        }
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="loggingLevel"></param>
        /// <param name="logEntry"></param>
        public abstract void WriteLine(LogLevel loggingLevel, string logEntry);
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="logEntry"></param>
        public override void WriteLine(string logEntry) {
            WriteLine(LoggingLevel, logEntry);
        }
        #endregion	public methods & functions


        #region		non-public methods & functions

        #endregion	non-public methods & functions


        #region		nested classes

        #endregion	nested classes
    }

}
