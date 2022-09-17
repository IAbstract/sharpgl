// Copyright: ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;
using System.IO;
using System.Collections.Generic;


namespace RazorSoft.Media.Framework.Logging {


    /// <summary>
    /// 
    /// </summary>
    internal class SystemLogger : TraceLogger {
        #region		fields
        private readonly DateTime created;
        private readonly string fileName;
        #endregion	fields


        #region		properties

        #endregion	properties


        #region		constructors & destructors
        internal SystemLogger(string name) : base(name) {
            created = DateTime.UtcNow;
            fileName = $"{created.Ticks:X}.log";
            FilePath = Path.Combine(Shell.LOG_PATH, fileName);
            LoggingLevel = LogLevel.Info;

            if (!File.Exists(FilePath)) {
                using (var file = File.Create(FilePath)) { }
            }
        }
        #endregion	constructors & destructors


        #region		public methods & functions
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="logEntry"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Write(LogLevel loggingLevel, string logEntry) {
            var current = DateTime.UtcNow;
            var date = new DateOnly(current.Year, current.Month, current.Day);
            var time = new TimeOnly(current.Hour, current.Minute, current.Second);

            //  if !loglevel
            if (loggingLevel < LoggingLevel) {
                return;
            }

            //  build log entry
            var entry = $"[{date,-10} {time,-8:HH:mm:ss}]\t[{loggingLevel,-7}]\t{logEntry}";
            var buffer = Shell.DefaultEncoder.GetBytes(entry);

            Write(buffer);
        }
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="logEntry"></param>
        public override void WriteLine(LogLevel loggingLevel, string logEntry) {
            var current = DateTime.UtcNow;
            var date = new DateOnly(current.Year, current.Month, current.Day);
            var time = new TimeOnly(current.Hour, current.Minute, current.Second);

            //  if !loglevel
            if (loggingLevel < LoggingLevel) {
                return;
            }

            //  build log entry
            var entry = $"[{date,-10} {time,-8:HH:mm:ss}]\t[{loggingLevel,-7}]\t{logEntry}\n";
            var buffer = Shell.DefaultEncoder.GetBytes(entry);

            Write(buffer);
        }
        #endregion	public methods & functions


        #region		non-public methods & functions
        private void Write(byte[] buffer) {
            using (var file = File.Open(FilePath, FileMode.Append, FileAccess.Write)) {
                file.Write(buffer);
            }
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {

            }

            base.Dispose(disposing);
        }
        #endregion	non-public methods & functions


        #region		nested classes

        #endregion	nested classes
    }
}
