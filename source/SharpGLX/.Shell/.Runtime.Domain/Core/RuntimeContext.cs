// Copyright: ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;
using System.Threading;
using System.Threading.Tasks;

using RazorSoft.Media.Runtime.Logging;

namespace RazorSoft.Media.Runtime {
    public delegate void WriteLog(string logEntry, LogLevel loggingLevel = LogLevel.Info);
    public delegate void ContextReady();
    public delegate void ContextStarted();
    public delegate void ContextStopped();

    /// <summary>
    /// 
    /// </summary>
    public abstract class RuntimeContext {
        #region		fields
        private bool isRunning;
        private int exitCode;
        #endregion	fields


        #region     events
        /// <summary>
        /// 
        /// </summary>
        public event ContextReady OnContextReady;
        public event ContextStarted OnContextStarted;
        public event ContextStopped OnContextStopped;
        #endregion  events


        #region		properties
        public WriteLog Log { get; set; }
        public string Title { get; protected init; }
        public bool IsRunning => isRunning;
        #endregion	properties


        #region		constructors & destructors
        /// <summary>
        /// 
        /// </summary>
        protected RuntimeContext(string title) {
            Title = title;
        }
        #endregion	constructors & destructors


        #region		public methods & functions

        #endregion	public methods & functions


        #region		non-public methods & functions
        /// <summary>
        /// Called internally by Runtime or other mechanism capable of starting the application context
        /// </summary>
        internal async void Start() {
            StartContext(out isRunning);
            
            if (isRunning) {
                OnContextStarted?.Invoke();

                exitCode = await Loop();
            }
        }
        /// <summary>
        /// Called internally by Runtime or other mechanism capable of stopping the application context
        /// </summary>
        internal void Stop() {
            StopContext(out isRunning);

            if(!isRunning) {
                OnContextStopped?.Invoke();
                Log($"Finished with exit code: {exitCode}");
            }
        }

        protected virtual async Task<int> Loop() {
            //  while the context is running...
            while (isRunning) {
                Thread.Sleep(5);
            }

            return 0;
        }

        protected abstract void StartContext(out bool isRunning);
        protected abstract void StopContext(out bool isRunning);
        #endregion	non-public methods & functions
    }
}