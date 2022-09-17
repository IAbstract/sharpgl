// Copyright ©2022 RazorSoft Media, DBA, Lone Star Logistics & Transport, LLC. All Rights Reserved.


using System.Runtime.InteropServices;

namespace RazorSoft.Media.Native {

    internal interface IPlatform {
        #region 	properties
        OperatingSystem OS { get; }
        string GlfwLib { get; init; }
        #endregion 	properties


        #region		public methods & functions
        public string ToString();
        #endregion	public methods & functions
    }


    public abstract class Platform : IPlatform {
        #region		fields

        #endregion	fields


        #region		properties
        protected OSPlatform OSPlatform { get; }

        public abstract OperatingSystem OS { get; }
        public string GlfwLib { get; init; }
        #endregion	properties


        #region		constructors & destructors
        public Platform(OSPlatform osPlatform) {
            OSPlatform = osPlatform;
        }

        #endregion	constructors & destructors


        #region		public methods & functions
        public override string ToString() {
            return OS.ToString();
        }
        #endregion	public methods & functions


        #region		non-public methods & functions
        internal static IPlatform GetPlatform(string glfwLib) {
#if Linux
            return new LinuxImpl() {
                GlfwLib = gflwLib
            };
#elif OSX
            return new OsxImpl() {
                GlfwLib = gflwLib
            };
#elif Windows
            return new WindowsImpl() {
                GlfwLib = glfwLib
            };
#else

#endif

        }
        #endregion	non-public methods & functions
    }


    public class WindowsImpl : Platform {
        #region		fields

        #endregion	fields


        #region		properties
        public override OperatingSystem OS => OperatingSystem.Windows;
        #endregion	properties


        #region		constructors & destructors
        public WindowsImpl() : base(OSPlatform.Windows) { }
        #endregion	constructors & destructors
    }


    public class OsxImpl : Platform {
        #region		fields

        #endregion	fields


        #region		properties
        public override OperatingSystem OS => OperatingSystem.OSX;
        #endregion	properties


        #region		constructors & destructors
        public OsxImpl() : base(OSPlatform.OSX) { }
        #endregion	constructors & destructors
    }


    public class LinuxImpl : Platform {
        #region		fields

        #endregion	fields


        #region		properties
        public override OperatingSystem OS => OperatingSystem.Linux;
        #endregion	properties


        #region		constructors & destructors
        public LinuxImpl() : base(OSPlatform.Linux) { }
        #endregion	constructors & destructors
    }

    public enum OperatingSystem {
        Windows,
        OSX,
        Linux
    }
}
