// Copyright: ©2021 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//
using RazorSoft.UnitTesting;


namespace Testing.RazorSoft {

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DescendentUnitTest : TestHarness {

        #region		configuration

        [ClassInitialize]
        public static void InitializeTestHarness(TestContext context) {
            SetContext(context);
            Log("Initialize.Test.Harness");
        }

        [ClassCleanup]
        public static void CleanupTestHarness() {

        }
        #endregion	configuration


        #region     tests

        #endregion  tests


        #region 	utility methods

        #endregion	utility methods


        #region     test objects

        #endregion  test objects
    }
}
