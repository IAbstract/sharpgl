﻿using System;
using SharpGLX.Version;


namespace SharpGLX.Windows.Renderers {

    public class NativeWindowRenderer : WindowsRendererProvider {
        /// <summary>
        /// Initializes a new instance of the <see cref="NativeWindowRenderer"/> class.
        /// </summary>
        public NativeWindowRenderer() {
            //  We cannot layer GDI drawing on top of open gl drawing.
            GDIDrawingEnabled = false;
        }

        /// <summary>
        /// Creates the render context provider. Must also create the OpenGL extensions.
        /// </summary>
        /// <param name="openGLVersion">The desired OpenGL version.</param>
        /// <param name="gl">The OpenGL context.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="bitDepth">The bit depth.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">A valid Window Handle must be provided for the NativeWindowRenderContextProvider</exception>
        public override bool Create(OpenGLVersion openGLVersion, OpenGL gl, int width, int height, int bitDepth, object parameter) {
            //  Call the base.
            base.Create(openGLVersion, gl, width, height, bitDepth, parameter);

            //  Cast the parameter to the device context.
            try {
                windowHandle = (IntPtr)parameter;
            }
            catch {
                throw new Exception("A valid Window Handle must be provided for the NativeWindowRenderContextProvider");
            }

            //	Get the window device context.
            deviceHandle = Win32.GetDC(windowHandle);

            //	Setup a pixel format.
            Win32.PIXELFORMATDESCRIPTOR pfd = new Win32.PIXELFORMATDESCRIPTOR();
            pfd.Init();
            pfd.nVersion = 1;
            pfd.dwFlags = Win32.PFD_DRAW_TO_WINDOW | Win32.PFD_SUPPORT_OPENGL | Win32.PFD_DOUBLEBUFFER;
            pfd.iPixelType = Win32.PFD_TYPE_RGBA;
            pfd.cColorBits = (byte)bitDepth;
            pfd.cDepthBits = 16;
            pfd.cStencilBits = 8;
            pfd.iLayerType = Win32.PFD_MAIN_PLANE;

            //	Match an appropriate pixel format 
            int iPixelformat;
            if ((iPixelformat = Win32.ChoosePixelFormat(deviceHandle, pfd)) == 0)
                return false;

            //	Sets the pixel format
            if (Win32.SetPixelFormat(deviceHandle, iPixelformat, pfd) == 0) {
                return false;
            }

            //	Create the render context.
            rendererHandle = Win32.wglCreateContext(deviceHandle);

            //  Make the context current.
            MakeCurrent();

            //  Update the render context if required.
            UpdateContextVersion(gl);

            //  Return success.
            return true;
        }

        /// <summary>
        /// Destroys the render context provider instance.
        /// </summary>
	    public override void Destroy() {
            //	Release the device context.
            Win32.ReleaseDC(windowHandle, deviceHandle);

            //	Call the base, which will delete the render context handle.
            base.Destroy();
        }

        /// <summary>
        /// Sets the dimensions of the render context provider.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
	    public override void SetDimensions(int width, int height) {
            //  Call the base.
            base.SetDimensions(width, height);
        }

        /// <summary>
        /// Blit the rendered data to the supplied device context.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
	    public override void Blit(IntPtr hdc) {
            if (deviceHandle != IntPtr.Zero || windowHandle != IntPtr.Zero) {
                //	Swap the buffers.
                Win32.SwapBuffers(deviceHandle);
            }
        }

        /// <summary>
        /// Makes the render context current.
        /// </summary>
	    public override void MakeCurrent() {
            if (rendererHandle != IntPtr.Zero)
                MakeCurrent(deviceHandle, rendererHandle);
        }

        /// <summary>
        /// The window handle.
        /// </summary>
        protected IntPtr windowHandle = IntPtr.Zero;
    }
}
