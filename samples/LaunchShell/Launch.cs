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
var ret = Shell.Run(new MyAppContext());
/*  ------------------------    --  */


namespace LaunchExecutable {

    public class MyAppContext : RuntimeContext {
        private TimeOnly start;

        private RuntimeContext Context { get; }
        private Timer Timer { get; }

        public MyAppContext() : base("MyApplication") {
            Timer = new Timer();
            Timer.Interval = 1000;
            Timer.Enabled = false;
            Timer.Elapsed += OnTimerElapsed;

            //OnContextStarted += OnContextStarted;
        }

        protected override void StartContext(out bool isRunning) {
            isRunning = Timer.Enabled = true;
            start = TimeOnly.FromDateTime(DateTime.UtcNow);
        }

        protected override void StopContext(out bool isRunning) {
            isRunning = Timer.Enabled = false;
            TimeOnly end = TimeOnly.FromDateTime(DateTime.UtcNow);

            var runLength = end - start;
            Context.Log($"Run Length: {runLength}");
        }

        private void OnTimerElapsed(object? sender, ElapsedEventArgs arg) {
            Context.Log("Timer Elapsed");
            Shell.Stop();
        }
    }
}