// Copyright: ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using RazorSoft.Core;

using RazorSoft.Media.Runtime.Logging;


namespace RazorSoft.Media.Runtime {

    /// <summary>
    /// 
    /// </summary>
    internal abstract class RuntimeModule<TComponent> : SingletonBase<TComponent>, IRuntimeModule where TComponent : class {
        #region		fields
        private bool isInitialized;

        #endregion	fields


        #region		properties
        internal static TComponent Component => Singleton;

        internal bool IsInitialized => isInitialized;

        public string Name { get; }
        #endregion	properties


        #region		constructors & destructors
        protected RuntimeModule() {
            Name = GetType().Name.Replace("Module", string.Empty);
        }
        #endregion	constructors & destructors


        #region		non-public methods & functions
        /// <summary>
        /// INTERNAL: called by Runtime to initialize the component
        /// </summary>
        void IRuntimeModule.Initialize() {
            InitializeComponent(ref isInitialized);
        }
        /// <summary>
        /// When overridden in a runtime component, initialize component resources and set initialization 
        /// state.
        /// </summary>
        /// <param name="isInitialized"></param>
        protected abstract void InitializeComponent(ref bool isInitialized);
        protected void Log(string logEntry, LogLevel loggingLevel = LogLevel.Info) {
            //  this is the default logger assumed to always be available
            Shell.Instance.Runtime.SystemLogger.WriteLine(loggingLevel, $"{$"<{Name}>", -10}\t{logEntry}");
        }
        #endregion	non-public methods & functions


        #region		nested classes

        #endregion	nested classes
    }
}
