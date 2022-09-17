// Copyright: ©2021,2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RazorSoft.UnitTesting;

using RazorSoft.Media;
using OperatingSystem = RazorSoft.Media.Native.OperatingSystem;


namespace Testing.RazorSoft {

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class NativePlatformTests : TestHarness {
        //  this causes the Glfw static state to initialize
        private static readonly DateTime glfwStartTime = Glfw.Started;

        #region		configuration
        [ClassInitialize]
        public static void InitializeTestHarness(TestContext context) {
            SetContext(context);
            Log("Initialize.Test.Harness");
        }

        [ClassCleanup]
        public static void CleanupTestHarness() {
            Glfw.Terminate();
        }
        #endregion	configuration


        #region     tests
        [TestMethod]
        [TestCategory("Glfw")]
        public void GlfwInitialization() {
            IsTrue(Glfw.IsInitialized, "Glfw initialized");
        }

        [TestMethod]
        [TestCategory("Glfw.Windows")]
        public void WindowsPlatform() {
            var expOS = OperatingSystem.Windows;
            var expGLFW_LIB = "glfw3";
            
            var platform = Glfw.Platform;

            AreEqual(expOS, platform.OS, "operating system", platform.ToString());
            AreEqual(expGLFW_LIB, platform.GlfwLib, "Glfw lib");
        }
        #endregion  tests


        #region 	utility methods

        #endregion	utility methods


        #region     test objects

        #endregion  test objects
    }
}
