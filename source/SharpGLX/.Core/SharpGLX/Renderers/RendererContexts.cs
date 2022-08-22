namespace SharpGLX.Renderers {

    public class RendererContexts {
        public delegate IRenderer CreateRenderer();

        public CreateRenderer Create { get; protected init; }
    }
}
