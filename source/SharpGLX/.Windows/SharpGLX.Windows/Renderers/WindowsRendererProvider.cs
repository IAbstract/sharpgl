using System;

using SharpGLX.Version;
using SharpGLX.Renderers;


namespace SharpGLX.Windows.Renderers {

    public abstract class WindowsRendererProvider : RendererProvider {
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
            //  Set the width, height and bit depth.
            Width = width;
            Height = height;
            BitDepth = bitDepth;

            //  For now, assume we're going to be able to create the requested OpenGL version.
            requestedOpenGLVersion = openGLVersion;
            createdOpenGLVersion = openGLVersion;

            return true;
        }

        /// <summary>
        /// Destroys the render context provider instance.
        /// </summary>
        public override void Destroy() {
            //  If we have a render context, destroy it.
            if (rendererHandle != IntPtr.Zero) {
                Win32.wglDeleteContext(rendererHandle);
                rendererHandle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Sets the dimensions of the render context provider.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public override void SetDimensions(int width, int height) {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Only valid to be called after the renderer context is created, this function attempts to
        /// move the renderer context to the OpenGL version originally requested. If this is &gt; 2.1, this
        /// means building a new context. If this fails, we'll have to make do with 2.1.
        /// </summary>
        /// <param name="gl">The OpenGL instance.</param>
        protected void UpdateContextVersion(OpenGL gl) {
            //  If the request version number is anything up to and including 2.1, standard render contexts
            //  will provide what we need (as long as the graphics card drivers are up to date).
            var requestedVersionNumber = VersionAttribute.GetVersionAttribute(requestedOpenGLVersion);
            if (requestedVersionNumber.IsAtLeastVersion(3, 0) == false) {
                createdOpenGLVersion = requestedOpenGLVersion;
                return;
            }

            //  Now the none-trivial case. We must use the WGL_ARB_create_context extension to 
            //  attempt to create a 3.0+ context.
            try {
                int[] attributes =
                {
                    OpenGL.WGL_CONTEXT_MAJOR_VERSION_ARB, requestedVersionNumber.Major,
                    OpenGL.WGL_CONTEXT_MINOR_VERSION_ARB, requestedVersionNumber.Minor,
                    OpenGL.WGL_CONTEXT_FLAGS_ARB, OpenGL.WGL_CONTEXT_FORWARD_COMPATIBLE_BIT_ARB,
                    0
                };
                var hrc = gl.CreateContextAttribsARB(IntPtr.Zero, attributes);
                Win32.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
                Win32.wglDeleteContext(rendererHandle);
                Win32.wglMakeCurrent(deviceHandle, hrc);
                rendererHandle = hrc;
            }
            catch (Exception) {
                //  TODO: can we actually get the real version?
                createdOpenGLVersion = OpenGLVersion.OpenGL2_1;
            }
        }

        protected override void MakeCurrent(IntPtr device, IntPtr renderer) {
            Win32.wglMakeCurrent(device, renderer);
        }
    }
}
