using SharpGLX.Renderers;

namespace SharpGLX.Windows.Renderers {
    public class WindowsRendererContexts : RendererContexts {

        public static RendererContexts DIBSection = new WindowsRendererContexts() { Create = () => new DIBSectionRenderer() };
        public static RendererContexts NativeWindow = new WindowsRendererContexts() { Create = () => new NativeWindowRenderer() };
        public static RendererContexts HiddenWindow = new WindowsRendererContexts() { Create = () => new HiddenWindowRenderer() };
        public static RendererContexts FBO = new WindowsRendererContexts() { Create = () => new FBORenderer() };

    }
}
