using System;

using SharpGLX.Version;


namespace SharpGLX.Renderers {

    public abstract class RendererProvider : IRenderer {

        /// <summary>
        /// The render context handle.
        /// </summary>
        protected IntPtr rendererHandle = IntPtr.Zero;

        /// <summary>
        /// The device context handle.
        /// </summary>
        protected IntPtr deviceHandle = IntPtr.Zero;

        /// <summary>
        /// The width.
        /// </summary>
        protected int width = 0;

        /// <summary>
        /// The height.
        /// </summary>
        protected int height = 0;

        /// <summary>
        /// The bit depth.
        /// </summary>
        protected int bitDepth = 0;

        /// <summary>
        /// Is gdi drawing enabled?
        /// </summary>
        protected bool gdiDrawingEnabled = true;

        /// <summary>
        /// The version of OpenGL that was requested when creating the render context.
        /// </summary>
        protected OpenGLVersion requestedOpenGLVersion;

        /// <summary>
        /// The actual version of OpenGL that is supported by the render context.
        /// </summary>
        protected OpenGLVersion createdOpenGLVersion;

        /// <summary>
        /// Gets the render context handle.
        /// </summary>
        public IntPtr RenderContextHandle {
            get { return rendererHandle; }
            protected set { rendererHandle = value; }
        }

        /// <summary>
        /// Gets the device context handle.
        /// </summary>
        public IntPtr DeviceContextHandle {
            get { return deviceHandle; }
            protected set { deviceHandle = value; }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width {
            get { return width; }
            protected set { width = value; }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height {
            get { return height; }
            protected set { height = value; }
        }

        /// <summary>
        /// Gets or sets the bit depth.
        /// </summary>
        /// <value>The bit depth.</value>
        public int BitDepth {
            get { return bitDepth; }
            protected set { bitDepth = value; }
        }

        /// <summary>
        /// Gets a value indicating whether GDI drawing is enabled for this type of render context.
        /// </summary>
        /// <value><c>true</c> if GDI drawing is enabled; otherwise, <c>false</c>.</value>
        public bool GDIDrawingEnabled {
            get { return gdiDrawingEnabled; }
            protected set { gdiDrawingEnabled = value; }
        }

        /// <summary>
        /// Gets the OpenGL version that was requested when creating the render context.
        /// </summary>
        public OpenGLVersion RequestedOpenGLVersion {
            get { return requestedOpenGLVersion; }
        }

        /// <summary>
        /// Gets the OpenGL version that is supported by the render context, compare to <see cref="RequestedOpenGLVersion"/>.
        /// </summary>
        public OpenGLVersion CreatedOpenGLVersion {
            get { return createdOpenGLVersion; }
        }

        /// <summary>
        /// Blit the rendered data to the supplied device context.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        public abstract void Blit(IntPtr hdc);
        /// <summary>
        /// 
        /// </summary>
        public void ClearContext() {
            MakeCurrent(IntPtr.Zero, IntPtr.Zero);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="openGLVersion"></param>
        /// <param name="gl"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="bitDepth"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public abstract bool Create(OpenGLVersion openGLVersion, OpenGL gl, int width, int height, int bitDepth, object parameter);
        /// <summary>
        /// 
        /// </summary>
        public abstract void Destroy();
        /// <summary>
        /// Makes the render context current.
        /// </summary>
        public abstract void MakeCurrent();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public abstract void SetDimensions(int width, int height);


        protected abstract void MakeCurrent(IntPtr zero1, IntPtr zero2);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        void IDisposable.Dispose() {
            //  Destroy the context provider.
            Destroy();
        }
    }
}