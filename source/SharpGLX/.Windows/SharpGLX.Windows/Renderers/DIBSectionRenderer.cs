using System;

using SharpGLX.Version;

namespace SharpGLX.Windows.Renderers {

    public class DIBSectionRenderer : WindowsRendererProvider {
        /// <summary>
        /// Initializes a new instance of the <see cref="DIBSectionRenderer"/> class.
        /// </summary>
        public DIBSectionRenderer() {
            //  We can layer GDI drawing on top of open gl drawing.
            GDIDrawingEnabled = true;
        }

        /// <summary>
        /// Creates the render context provider. Must also create the OpenGL extensions.
        /// </summary>
        /// <param name="openGLVersion">The desired OpenGL version.</param>
        /// <param name="gl">The OpenGL context.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="bitDepth">The bit depth.</param>
        /// <param name="parameter">The extra parameter.</param>
        /// <returns></returns>
        public override bool Create(OpenGLVersion openGLVersion, OpenGL gl, int width, int height, int bitDepth, object parameter) {
            //  Call the base.
            base.Create(openGLVersion, gl, width, height, bitDepth, parameter);

            //  Get the desktop DC.
            IntPtr desktopDC = Win32.GetDC(IntPtr.Zero);

            //  Create our DC as a compatible DC for the desktop.
            deviceHandle = Win32.CreateCompatibleDC(desktopDC);

            //  Release the desktop DC.
            Win32.ReleaseDC(IntPtr.Zero, desktopDC);

            //  Create our dib section.
            dibSection.Create(deviceHandle, width, height, bitDepth);

            //  Create the render context.
            Win32.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
            rendererHandle = Win32.wglCreateContext(deviceHandle);

            //  Make current.
            MakeCurrent();

            //  Update the context if required.
            UpdateContextVersion(gl);

            //  Return success.
            return true;
        }

        /// <summary>
        /// Destroys the render context provider instance.
        /// </summary>
	    public override void Destroy() {
            //  Destroy the bitmap.
            dibSection.Destroy();

            //	Release the device context.
            Win32.ReleaseDC(IntPtr.Zero, deviceHandle);

            //	Call the base, which will delete the render context handle.
            base.Destroy();
        }

        public override void SetDimensions(int width, int height) {
            //  Call the base.
            base.SetDimensions(width, height);

            //	Resize.
            dibSection.Resize(width, height, BitDepth);
        }

        public override void Blit(IntPtr hdc) {
            //  We must have a device context.
            // [RS] Why can the deviceContextHandle be zero?
            if (deviceHandle == IntPtr.Zero)
                return;

            //	Swap the buffers.
            Win32.SwapBuffers(deviceHandle);

            //  Blit to the device context.
            Win32.BitBlt(hdc, 0, 0, Width, Height, deviceHandle, 0, 0, Win32.SRCCOPY);
        }

        public override void MakeCurrent() {
            //  If we have a render context and DC make current.
            if (rendererHandle != IntPtr.Zero && deviceHandle != IntPtr.Zero)
                MakeCurrent(deviceHandle, rendererHandle);
        }

        /// <summary>
        /// The DIB Section object.
        /// </summary>
        protected DIBSection dibSection = new DIBSection();

        /// <summary>
        /// Gets the DIB section.
        /// </summary>
        /// <value>The DIB section.</value>
        public DIBSection DIBSection {
            get { return dibSection; }
        }
    }
}
