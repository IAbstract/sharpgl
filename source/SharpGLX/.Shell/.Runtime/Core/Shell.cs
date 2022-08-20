// Copyright: ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Reflection;
using static System.Diagnostics.Debug;

using RazorSoft.Media.Runtime;
using RazorSoft.Media.Runtime.Logging;
using System.Collections.Generic;


/* *** general entry point      *** */
Shell.Run(args);

/* *** -----------------------  *** */


namespace RazorSoft.Media.Runtime {

    #region         delegates
    public delegate void RuntimeLaunching();
    public delegate void OnShellReady(RuntimeContext context);
    #endregion      delegates

    /// <summary>
    /// 
    /// </summary>
    public class Shell {
        #region		fields
        private const string DIRECTORY = ".\\";
        private const string MANIFEST = "manifest.json";
        private const string ENGINE = "Engine";
        private const string DEBUG_LOGGER = "DebugLogger";

        internal const string LOG_PATH = ".\\logs";
        #endregion	fields


        #region		event handlers

        #endregion	event handlers


        #region		properties
        internal static Shell Instance { get; } = new();
        internal static Encoding DefaultEncoder => Encoding.UTF8;

        internal Assembly Assembly { get; }
        internal Version Version { get; }
        internal Version DomainVersion { get; }
        internal System Runtime { get; private set; }
        #endregion	properties


        #region		constructors & destructors
        private Shell() {
            Assembly = typeof(Shell).Assembly;
            Version = Assembly.GetName().Version;

            if (!Directory.Exists(LOG_PATH)) {
                Directory.CreateDirectory(LOG_PATH);
            }

            var domainDLL = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), "RazorSoft.Media.Runtime.Domain.dll"));
            DomainVersion = domainDLL.GetName().Version;
        }
        #endregion	constructors & destructors
        #region		methods & functions
        /// <summary>
        /// Starts the Shell with a generic context
        /// </summary>
        /// <param name="onRunApp"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int Run(string title, OnShellReady onRunApp, params string[] args) {
            var ret = Run(args);

            Instance.Runtime.RegisterContext(new ShellContext(title));

            Instance.Runtime.OnLaunching += () => {
                onRunApp(Instance.Runtime.Context);
            };

            Instance.Runtime.Launch();

            return ret;
        }
        /// <summary>
        /// Starts the Shell with the supplied context
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int Run(RuntimeContext context, params string[] args) {
            var ret = Run(args);

            Instance.Runtime.RegisterContext(context);

            Instance.Runtime.Launch();

            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public static void Stop() {
            Instance.Runtime.ShutDown(() => { });
        }
        /// <summary>
        /// This is the first call an application must make. Everything necessary for the 
        /// Runtime to launch is initialized.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static int Run(params string[] args) {
            /*
             * This entry can be much more robust. For instance, after calling this method, a 
             * derived Application (App) can be found in a '*.manifest' file from which the App 
             * can be constructed.
             * 
             * By changing out a manifest, different Apps can be run without setting 
             * entry points in the code (as a Program).
             * 
             * ***/

            //  instantiate Runtime
            (Instance.Runtime = System.Instance)
                //  start Runtime Clock
                .Initialize();

            Instance.Runtime.SystemLogger.WriteLine(LogLevel.Info, $"Shell Runtime Domain v. {Instance.DomainVersion}");
            Instance.Runtime.SystemLogger.WriteLine(LogLevel.Info, "Shell Runtime Initialized");

            //  change Runtime's logging level to Warning
            Instance.Runtime.SystemLogger.LoggingLevel = LogLevel.Info;

            return 0;
        }



        #endregion	methods & functions


        #region		nested classes
        /// <summary>
        /// 
        /// </summary>
        public class System {
            #region		fields
            private static readonly Lazy<System> SINGLETON = new(() => new() {
                Assembly = Shell.Instance.Assembly,
                Version = Shell.Instance.Version
            });
            private static readonly Dictionary<Type, IRuntimeModule> COMPONENTS = new();

            // main loop flag
            private bool bail = false;
            #endregion	fields


            #region     events
            public event RuntimeLaunching OnLaunching;
            #endregion  events


            #region		properties
            internal static System Instance => SINGLETON.Value;


            internal RuntimeContext Context { get; private set; }
            internal Action OnRuntimeReady { get; set; }
            internal ILogger SystemLogger { get; private set; }

            public Assembly Assembly { get; private init; }
            public Version Version { get; private init; }
            #endregion	properties


            #region		constructors & destructors
            private System() { }
            #endregion	constructors & destructors


            #region		public methods & functions
            internal void Launch() {
                if (Context == null) {
                    //  bail out; there is no application to launch
                    return;
                }

                //  initialize runtime components
                foreach (var rc in COMPONENTS.Values) {
                    rc.Initialize();
                }

                //  runtime getting ready to launch
                OnLaunching?.Invoke();

                //  launch application
                Context.Start();
            }
            #endregion	public methods & functions


            #region		non-public methods & functions
            /// <summary>
            /// INTERNAL: Initialize fields, objects, etc. Synchronizes on Clock to exit method.
            /// Called by Bootstrap.
            /// </summary>
            internal void Initialize() {
                //  assign & init Logging component
                SystemLogger = new SystemLogger(DEBUG_LOGGER);

                Log($"Shell Runtime v. {Version}");
            }
            internal void AddComponent<TComponent>(TComponent component) where TComponent : class {
                //  TODO: error checking
                if (component is IRuntimeModule rc) {
                    COMPONENTS[typeof(TComponent)] = rc;
                }
            }

            internal TComponent GetComponent<TComponent>() where TComponent : class {
                //  TODO: error checking
                return COMPONENTS[typeof(TComponent)] as TComponent;
            }
            /// <summary>
            /// INTERNAL
            /// </summary>
            /// <param name="onClose"></param>
            internal void ShutDown(Action onClose) {
                //  change Runtime's logging level to Info for shut down
                SystemLogger.LoggingLevel = LogLevel.Info;

                //  shut down app terminals
                Log("User Closed Application");
                Context.Stop();

                //  call onClose
                onClose?.Invoke();
            }
            /// <summary>
            /// INTERNAL
            /// </summary>
            /// <param name="logEntry"></param>
            internal static void Log(string logEntry, LogLevel loggingLevel = LogLevel.Info) {
                Instance.SystemLogger.WriteLine(loggingLevel, logEntry);
            }
            internal bool RegisterContext(RuntimeContext context) {
                if (Context != null) {
                    /*  Once this property is set, cannot be changed
                     *  
                     *  Throw: Invalid Operation Exception
                     *      Crash:          TRUE
                     *      Preventable:    TRUE
                     *      Log:            Call Stack
                     *  ***/

                    //  TODO: InvalidOperationException
                }

                //  set context logging method
                (Context = context).Log = Log;

                //  raised when Runnable is ready
                Context.OnContextReady += OnContextRunEvent;

                return Context != null;
            }

            ///// <summary>
            ///// 
            ///// </summary>
            //private void OnLoopStopEvent() {
            //    ShutDown(Context.Stop);
            //}

            private void OnContextRunEvent() {
                Log("Context Run Ready");
            }
            ///// <summary>
            ///// 
            ///// </summary>
            //private void StartLoop() {
            //    Log("Runtime Entering Loop");

            //    while (Context.IsRunning && !bail) {

            //        //  take a breather
            //        Thread.Sleep(5);
            //    }
            //}
            #endregion	non-public methods & functions
        }

        /// <summary>
        /// 
        /// </summary>
        private class ShellContext : RuntimeContext {
            #region		fields

            #endregion	fields


            #region		properties

            #endregion	properties


            #region		constructors & destructors
            public ShellContext(string title) : base(title) { }
            #endregion	constructors & destructors


            #region		public methods & functions

            #endregion	public methods & functions


            #region		non-public methods & functions

            protected override void StartContext(out bool isRunning) {
                isRunning = true;
            }

            protected override void StopContext(out bool isRunning) {
                isRunning = false;
            }

            #endregion	non-public methods & functions
        }

        #endregion	nested classes
    }
}
