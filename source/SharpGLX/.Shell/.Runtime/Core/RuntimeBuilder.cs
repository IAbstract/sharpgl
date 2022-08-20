// Copyright: ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using RazorSoft.Media.Framework.Core;


namespace RazorSoft.Media.Framework.Utility {

    public static class RuntimeBuilder {

        public static ConfigureRuntime WithSubsystems(this ConfigureRuntime configurator, Subsystems subsystems) {
            var runtime = configurator();

            runtime.AddSubsystems((uint)subsystems);

            return () => runtime;
        }

        public static void Execute(this ConfigureRuntime configurator) {
            var runtime = configurator();

            runtime.OnRuntimeReady();
        }
    }


    internal static class RuntimeExtensions {

        internal static Runtime.Graphics GetGraphics(this ISystem runtime) {
            return (Runtime.Graphics)runtime.Graphics;
        }
    }
}
