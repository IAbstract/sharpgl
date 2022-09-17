/*
 * Program is an inferred class. Do not create a class called Program.
 * 
 * **/

using System.Timers;
using Timer = System.Timers.Timer;

using RazorSoft.Media.Framework;

/*
var ret = Shell.Run(OnStart);

void OnStart() {
    //  on start code here ...
}
 * **/

//  will will function identical to ... --

/*  .Net6.0 entry point code    --  */
using LaunchExecutable;

//  starts the shell runtime loop to keep the application alive
Launch prog = new();
OnShellReady onRun = prog.OnShellReady;

var ret = Shell.Run("Sample Launcher", onRun);
/*  ------------------------    --  */


namespace LaunchExecutable {

    public class Launch {

        public Launch() { }

        //  We are not supplying a context so the Runtime will give us a generic 
        //  context with which to control the runtime.
        internal void OnShellReady(RuntimeContext context) {
            MyApp app = new(context);
        }
    }

    public class MyApp {
        private TimeOnly start;

        private RuntimeContext Context { get; }
        private Timer Timer { get; }

        public MyApp(RuntimeContext context) {
            Timer = new Timer();
            Timer.Interval = 1000;
            Timer.Enabled = false;
            Timer.Elapsed += OnTimerElapsed;

            (Context = context).OnContextStarted += OnContextStarted;
        }

        private void OnContextStarted() {
            Context.OnContextStopped += OnContextStopped;

            Timer.Enabled = true;

            start = TimeOnly.FromDateTime(DateTime.UtcNow);
        }

        private void OnContextStopped() {
            Context.OnContextStarted -= OnContextStarted;
            Context.OnContextStopped -= OnContextStopped;

            TimeOnly end = TimeOnly.FromDateTime(DateTime.UtcNow);

            var runLength = end - start;

            Context.Log($"Run Length: {runLength}");
        }

        private void OnTimerElapsed(object? sender, ElapsedEventArgs arg) {
            Timer.Enabled = false;
            Context.Log("Timer Elapsed");
            Shell.Stop();
        }
    }
}