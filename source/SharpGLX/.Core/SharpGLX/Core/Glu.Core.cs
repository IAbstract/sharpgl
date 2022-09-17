using System;
using System.Runtime.InteropServices;


namespace SharpGLX {

    public partial class OpenGL {
        [DllImport(GLU_LIB, SetLastError = true)]
        internal static unsafe extern sbyte* gluErrorString(uint errCode);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static unsafe extern sbyte* gluGetString(int name);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluOrtho2D(double left, double right, double bottom, double top);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluPerspective(double fovy, double aspect, double zNear, double zFar);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluPickMatrix(double x, double y, double width, double height, int[] viewport);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluLookAt(double eyex, double eyey, double eyez, double centerx, double centery, double centerz, double upx, double upy, double upz);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluProject(double objx, double objy, double objz, double[] modelMatrix, double[] projMatrix, int[] viewport, double[] winx, double[] winy, double[] winz);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluUnProject(double winx, double winy, double winz, double[] modelMatrix, double[] projMatrix, int[] viewport, ref double objx, ref double objy, ref double objz);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluScaleImage(int format, int widthin, int heightin, int typein, int[] datain, int widthout, int heightout, int typeout, int[] dataout);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluBuild1DMipmaps(uint target, uint components, int width, uint format, uint type, IntPtr data);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluBuild2DMipmaps(uint target, uint components, int width, int height, uint format, uint type, IntPtr data);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern IntPtr gluNewQuadric();

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluDeleteQuadric(IntPtr state);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluQuadricNormals(IntPtr quadObject, uint normals);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluQuadricTexture(IntPtr quadObject, int textureCoords);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluQuadricOrientation(IntPtr quadObject, int orientation);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluQuadricDrawStyle(IntPtr quadObject, uint drawStyle);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluCylinder(IntPtr qobj, double baseRadius, double topRadius, double height, int slices, int stacks);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluDisk(IntPtr qobj, double innerRadius, double outerRadius, int slices, int loops);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluPartialDisk(IntPtr qobj, double innerRadius, double outerRadius, int slices, int loops, double startAngle, double sweepAngle);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluSphere(IntPtr qobj, double radius, int slices, int stacks);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern IntPtr gluNewTess();

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluDeleteTess(IntPtr tess);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluTessBeginPolygon(IntPtr tess, IntPtr polygonData);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluTessBeginContour(IntPtr tess);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluTessVertex(IntPtr tess, double[] coords, double[] data);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluTessEndContour(IntPtr tess);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluTessEndPolygon(IntPtr tess);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluTessProperty(IntPtr tess, int which, double value);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluTessNormal(IntPtr tess, double x, double y, double z);


        ////		[DllImport(LIBRARY_GLU, SetLastError = true)]
        //internal static extern void gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.Begin callback);
        ////		[DllImport(LIBRARY_GLU, SetLastError = true)]
        //internal static extern void gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.BeginData callback);
        ////		[DllImport(LIBRARY_GLU, SetLastError = true)]
        //internal static extern void gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.Combine callback);
        ////		[DllImport(LIBRARY_GLU, SetLastError = true)]
        //internal static extern void gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.CombineData callback);
        ////		[DllImport(LIBRARY_GLU, SetLastError = true)]
        //internal static extern void gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.EdgeFlag callback);
        ////		[DllImport(LIBRARY_GLU, SetLastError = true)]
        //internal static extern void gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.EdgeFlagData callback);
        ////		[DllImport(LIBRARY_GLU, SetLastError = true)]
        //internal static extern void gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.End callback);
        ////		[DllImport(LIBRARY_GLU, SetLastError = true)]
        //internal static extern void gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.EndData callback);
        ////		[DllImport(LIBRARY_GLU, SetLastError = true)]
        //internal static extern void gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.Error callback);
        ////		[DllImport(LIBRARY_GLU, SetLastError = true)]
        //internal static extern void gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.ErrorData callback);
        ////		[DllImport(LIBRARY_GLU, SetLastError = true)]
        //internal static extern void gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.Vertex callback);
        ////		[DllImport(LIBRARY_GLU, SetLastError = true)]
        //internal static extern void gluTessCallback(IntPtr tess, int which, SharpGL.Delegates.Tesselators.VertexData callback);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluGetTessProperty(IntPtr tess, int which, double value);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern IntPtr gluNewNurbsRenderer();

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluDeleteNurbsRenderer(IntPtr nobj);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluBeginSurface(IntPtr nobj);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluBeginCurve(IntPtr nobj);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluEndCurve(IntPtr nobj);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluEndSurface(IntPtr nobj);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluBeginTrim(IntPtr nobj);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluEndTrim(IntPtr nobj);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluPwlCurve(IntPtr nobj, int count, float array, int stride, uint type);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluNurbsCurve(IntPtr nobj, int nknots, float[] knot, int stride, float[] ctlarray, int order, uint type);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluNurbsSurface(IntPtr nobj, int sknot_count, float[] sknot, int tknot_count, float[] tknot, int s_stride, int t_stride, float[] ctlarray, int sorder, int torder, uint type);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluLoadSamplingMatrices(IntPtr nobj, float[] modelMatrix, float[] projMatrix, int[] viewport);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluNurbsProperty(IntPtr nobj, int property, float value);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void gluGetNurbsProperty(IntPtr nobj, int property, float value);

        [DllImport(GLU_LIB, SetLastError = true)]
        internal static extern void IntPtrCallback(IntPtr nobj, int which, IntPtr Callback);
    }
}
