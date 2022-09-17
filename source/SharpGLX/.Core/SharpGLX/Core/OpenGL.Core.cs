using System;
using System.Runtime.InteropServices;


namespace SharpGLX {

    public partial class OpenGL {
        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glAccum(uint op, float value);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glAlphaFunc(uint func, float ref_notkeword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern byte glAreTexturesResident(int n, uint[] textures, byte[] residences);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glArrayElement(int i);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glBegin(uint mode);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glBindTexture(uint target, uint texture);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glBitmap(int width, int height, float xorig, float yorig, float xmove, float ymove, byte[] bitmap);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glBlendFunc(uint sfactor, uint dfactor);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glCallList(uint list);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glCallLists(int n, uint type, IntPtr lists);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glCallLists(int n, uint type, uint[] lists);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glCallLists(int n, uint type, byte[] lists);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glClear(uint mask);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glClearAccum(float red, float green, float blue, float alpha);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glClearColor(float red, float green, float blue, float alpha);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glClearDepth(double depth);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glClearIndex(float c);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glClearStencil(int s);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glClipPlane(uint plane, double[] equation);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor3b(byte red, byte green, byte blue);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor3bv(byte[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor3d(double red, double green, double blue);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor3dv(double[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor3f(float red, float green, float blue);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor3fv(float[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor3i(int red, int green, int blue);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor3iv(int[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor3s(short red, short green, short blue);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor3sv(short[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor3ub(byte red, byte green, byte blue);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor3ubv(byte[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor3ui(uint red, uint green, uint blue);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor3uiv(uint[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor3us(ushort red, ushort green, ushort blue);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor3usv(ushort[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor4b(byte red, byte green, byte blue, byte alpha);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor4bv(byte[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor4d(double red, double green, double blue, double alpha);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor4dv(double[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor4f(float red, float green, float blue, float alpha);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor4fv(float[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor4i(int red, int green, int blue, int alpha);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor4iv(int[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor4s(short red, short green, short blue, short alpha);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor4sv(short[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor4ub(byte red, byte green, byte blue, byte alpha);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor4ubv(byte[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor4ui(uint red, uint green, uint blue, uint alpha);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor4uiv(uint[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor4us(ushort red, ushort green, ushort blue, ushort alpha);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColor4usv(ushort[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColorMask(byte red, byte green, byte blue, byte alpha);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColorMaterial(uint face, uint mode);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColorPointer(int size, uint type, int stride, IntPtr pointer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColorPointer(int size, uint type, int stride, byte[] pointer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glColorPointer(int size, uint type, int stride, float[] pointer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glCopyPixels(int x, int y, int width, int height, uint type);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glCopyTexImage1D(uint target, int level, uint internalFormat, int x, int y, int width, int border);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glCopyTexImage2D(uint target, int level, uint internalFormat, int x, int y, int width, int height, int border);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glCopyTexSubImage1D(uint target, int level, int xoffset, int x, int y, int width);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glCopyTexSubImage2D(uint target, int level, int xoffset, int yoffset, int x, int y, int width, int height);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glCullFace(uint mode);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glDeleteLists(uint list, int range);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glDeleteTextures(int n, uint[] textures);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glDepthFunc(uint func);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glDepthMask(byte flag);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glDepthRange(double zNear, double zFar);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glDisable(uint cap);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glDisableClientState(uint array);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glDrawArrays(uint mode, int first, int count);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glDrawBuffer(uint mode);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glDrawElements(uint mode, int count, uint type, IntPtr indices);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glDrawElements(uint mode, int count, uint type, uint[] indices);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glDrawPixels(int width, int height, uint format, uint type, float[] pixels);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glDrawPixels(int width, int height, uint format, uint type, uint[] pixels);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glDrawPixels(int width, int height, uint format, uint type, ushort[] pixels);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glDrawPixels(int width, int height, uint format, uint type, byte[] pixels);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glDrawPixels(int width, int height, uint format, uint type, IntPtr pixels);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEdgeFlag(byte flag);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEdgeFlagPointer(int stride, int[] pointer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEdgeFlagv(byte[] flag);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEnable(uint cap);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEnableClientState(uint array);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEnd();

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEndList();

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEvalCoord1d(double u);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEvalCoord1dv(double[] u);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEvalCoord1f(float u);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEvalCoord1fv(float[] u);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEvalCoord2d(double u, double v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEvalCoord2dv(double[] u);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEvalCoord2f(float u, float v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEvalCoord2fv(float[] u);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEvalMesh1(uint mode, int i1, int i2);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEvalMesh2(uint mode, int i1, int i2, int j1, int j2);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEvalPoint1(int i);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glEvalPoint2(int i, int j);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glFeedbackBuffer(int size, uint type, float[] buffer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glFinish();

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glFlush();

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glFogf(uint pname, float param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glFogfv(uint pname, float[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glFogi(uint pname, int param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glFogiv(uint pname, int[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glFrontFace(uint mode);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glFrustum(double left, double right, double bottom, double top, double zNear, double zFar);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern uint glGenLists(int range);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGenTextures(int n, uint[] textures);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetBooleanv(uint pname, byte[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetClipPlane(uint plane, double[] equation);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetDoublev(uint pname, double[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern uint glGetError();

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetFloatv(uint pname, float[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetIntegerv(uint pname, int[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetLightfv(uint light, uint pname, float[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetLightiv(uint light, uint pname, int[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetMapdv(uint target, uint query, double[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetMapfv(uint target, uint query, float[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetMapiv(uint target, uint query, int[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetMaterialfv(uint face, uint pname, float[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetMaterialiv(uint face, uint pname, int[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetPixelMapfv(uint map, float[] values);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetPixelMapuiv(uint map, uint[] values);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetPixelMapusv(uint map, ushort[] values);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetPointerv(uint pname, int[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetPolygonStipple(byte[] mask);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private unsafe static extern sbyte* glGetString(uint name);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetTexEnvfv(uint target, uint pname, float[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetTexEnviv(uint target, uint pname, int[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetTexGendv(uint coord, uint pname, double[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetTexGenfv(uint coord, uint pname, float[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetTexGeniv(uint coord, uint pname, int[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetTexImage(uint target, int level, uint format, uint type, int[] pixels);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetTexLevelParameterfv(uint target, int level, uint pname, float[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetTexLevelParameteriv(uint target, int level, uint pname, int[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetTexParameterfv(uint target, uint pname, float[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glGetTexParameteriv(uint target, uint pname, int[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glHint(uint target, uint mode);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glIndexMask(uint mask);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glIndexPointer(uint type, int stride, int[] pointer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glIndexd(double c);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glIndexdv(double[] c);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glIndexf(float c);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glIndexfv(float[] c);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glIndexi(int c);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glIndexiv(int[] c);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glIndexs(short c);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glIndexsv(short[] c);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glIndexub(byte c);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glIndexubv(byte[] c);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glInitNames();

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glInterleavedArrays(uint format, int stride, int[] pointer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern byte glIsEnabled(uint cap);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern byte glIsList(uint list);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern byte glIsTexture(uint texture);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glLightModelf(uint pname, float param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glLightModelfv(uint pname, float[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glLightModeli(uint pname, int param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glLightModeliv(uint pname, int[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glLightf(uint light, uint pname, float param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glLightfv(uint light, uint pname, float[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glLighti(uint light, uint pname, int param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glLightiv(uint light, uint pname, int[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glLineStipple(int factor, ushort pattern);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glLineWidth(float width);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glListBase(uint base_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glLoadIdentity();

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glLoadMatrixd(double[] m);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glLoadMatrixf(float[] m);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glLoadName(uint name);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glLogicOp(uint opcode);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glMap1d(uint target, double u1, double u2, int stride, int order, double[] points);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glMap1f(uint target, float u1, float u2, int stride, int order, float[] points);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glMap2d(uint target, double u1, double u2, int ustride, int uorder, double v1, double v2, int vstride, int vorder, double[] points);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glMap2f(uint target, float u1, float u2, int ustride, int uorder, float v1, float v2, int vstride, int vorder, float[] points);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glMapGrid1d(int un, double u1, double u2);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glMapGrid1f(int un, float u1, float u2);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glMapGrid2d(int un, double u1, double u2, int vn, double v1, double v2);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glMapGrid2f(int un, float u1, float u2, int vn, float v1, float v2);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glMaterialf(uint face, uint pname, float param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glMaterialfv(uint face, uint pname, float[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glMateriali(uint face, uint pname, int param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glMaterialiv(uint face, uint pname, int[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glMatrixMode(uint mode);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glMultMatrixd(double[] m);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glMultMatrixf(float[] m);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glNewList(uint list, uint mode);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glNormal3b(byte nx, byte ny, byte nz);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glNormal3bv(byte[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glNormal3d(double nx, double ny, double nz);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glNormal3dv(double[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glNormal3f(float nx, float ny, float nz);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glNormal3fv(float[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glNormal3i(int nx, int ny, int nz);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glNormal3iv(int[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glNormal3s(short nx, short ny, short nz);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glNormal3sv(short[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glNormalPointer(uint type, int stride, IntPtr pointer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glNormalPointer(uint type, int stride, float[] pointer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glOrtho(double left, double right, double bottom, double top, double zNear, double zFar);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPassThrough(float token);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPixelMapfv(uint map, int mapsize, float[] values);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPixelMapuiv(uint map, int mapsize, uint[] values);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPixelMapusv(uint map, int mapsize, ushort[] values);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPixelStoref(uint pname, float param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPixelStorei(uint pname, int param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPixelTransferf(uint pname, float param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPixelTransferi(uint pname, int param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPixelZoom(float xfactor, float yfactor);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPointSize(float size);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPolygonMode(uint face, uint mode);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPolygonOffset(float factor, float units);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPolygonStipple(byte[] mask);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPopAttrib();

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPopClientAttrib();

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPopMatrix();

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPopName();

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPrioritizeTextures(int n, uint[] textures, float[] priorities);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPushAttrib(uint mask);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPushClientAttrib(uint mask);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPushMatrix();

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glPushName(uint name);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos2d(double x, double y);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos2dv(double[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos2f(float x, float y);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos2fv(float[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos2i(int x, int y);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos2iv(int[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos2s(short x, short y);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos2sv(short[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos3d(double x, double y, double z);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos3dv(double[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos3f(float x, float y, float z);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos3fv(float[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos3i(int x, int y, int z);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos3iv(int[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos3s(short x, short y, short z);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos3sv(short[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos4d(double x, double y, double z, double w);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos4dv(double[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos4f(float x, float y, float z, float w);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos4fv(float[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos4i(int x, int y, int z, int w);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos4iv(int[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos4s(short x, short y, short z, short w);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRasterPos4sv(short[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glReadBuffer(uint mode);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glReadPixels(int x, int y, int width, int height, uint format, uint type, byte[] pixels);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glReadPixels(int x, int y, int width, int height, uint format, uint type, IntPtr pixels);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRectd(double x1, double y1, double x2, double y2);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRectdv(double[] v1, double[] v2);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRectf(float x1, float y1, float x2, float y2);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRectfv(float[] v1, float[] v2);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRecti(int x1, int y1, int x2, int y2);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRectiv(int[] v1, int[] v2);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRects(short x1, short y1, short x2, short y2);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRectsv(short[] v1, short[] v2);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern int glRenderMode(uint mode);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRotated(double angle, double x, double y, double z);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glRotatef(float angle, float x, float y, float z);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glScaled(double x, double y, double z);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glScalef(float x, float y, float z);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glScissor(int x, int y, int width, int height);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glSelectBuffer(int size, uint[] buffer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glShadeModel(uint mode);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glStencilFunc(uint func, int ref_notkeword, uint mask);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glStencilMask(uint mask);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glStencilOp(uint fail, uint zfail, uint zpass);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord1d(double s);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord1dv(double[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord1f(float s);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord1fv(float[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord1i(int s);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord1iv(int[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord1s(short s);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord1sv(short[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord2d(double s, double t);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord2dv(double[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord2f(float s, float t);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord2fv(float[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord2i(int s, int t);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord2iv(int[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord2s(short s, short t);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord2sv(short[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord3d(double s, double t, double r);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord3dv(double[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord3f(float s, float t, float r);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord3fv(float[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord3i(int s, int t, int r);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord3iv(int[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord3s(short s, short t, short r);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord3sv(short[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord4d(double s, double t, double r, double q);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord4dv(double[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord4f(float s, float t, float r, float q);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord4fv(float[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord4i(int s, int t, int r, int q);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord4iv(int[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord4s(short s, short t, short r, short q);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoord4sv(short[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoordPointer(int size, uint type, int stride, IntPtr pointer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexCoordPointer(int size, uint type, int stride, float[] pointer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexEnvf(uint target, uint pname, float param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexEnvfv(uint target, uint pname, float[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexEnvi(uint target, uint pname, int param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexEnviv(uint target, uint pname, int[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexGend(uint coord, uint pname, double param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexGendv(uint coord, uint pname, double[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexGenf(uint coord, uint pname, float param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexGenfv(uint coord, uint pname, float[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexGeni(uint coord, uint pname, int param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexGeniv(uint coord, uint pname, int[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexImage1D(uint target, int level, uint internalformat, int width, int border, uint format, uint type, byte[] pixels);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexImage1D(uint target, int level, uint internalformat, int width, int border, uint format, uint type, sbyte[] pixels); //format=GL_BYTE

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexImage1D(uint target, int level, uint internalformat, int width, int border, uint format, uint type, ushort[] pixels); //format=GL_UNSIGNED_SHORT
        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexImage1D(uint target, int level, uint internalformat, int width, int border, uint format, uint type, short[] pixels);//format=GL_SHORT
        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexImage1D(uint target, int level, uint internalformat, int width, int border, uint format, uint type, uint[] pixels); //format=GL_UNSIGNED_INT
        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexImage1D(uint target, int level, uint internalformat, int width, int border, uint format, uint type, int[] pixels); //format=GL_INT
        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexImage1D(uint target, int level, uint internalformat, int width, int border, uint format, uint type, float[] pixels); //format=GL_FLOAT
        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexImage1D(uint target, int level, uint internalformat, int width, int border, uint format, uint type, IntPtr pixels);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, uint format, uint type, byte[] pixels);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, uint format, uint type, sbyte[] pixels); //format=GL_BYTE
        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, uint format, uint type, ushort[] pixels); //format=GL_UNSIGNED_SHORT
        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, uint format, uint type, short[] pixels); //format=GL_SHORT
        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, uint format, uint type, uint[] pixels); //format=GL_UNSIGNED_INT
        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, uint format, uint type, int[] pixels); //format=GL_INT
        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, uint format, uint type, float[] pixels); //format=GL_FLOAT
        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, uint format, uint type, IntPtr pixels);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexParameterf(uint target, uint pname, float param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexParameterfv(uint target, uint pname, float[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexParameteri(uint target, uint pname, int param);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexParameteriv(uint target, uint pname, int[] params_notkeyword);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexSubImage1D(uint target, int level, int xoffset, int width, uint format, uint type, int[] pixels);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, int[] pixels);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTranslated(double x, double y, double z);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glTranslatef(float x, float y, float z);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex2d(double x, double y);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex2dv(double[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex2f(float x, float y);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex2fv(float[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex2i(int x, int y);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex2iv(int[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex2s(short x, short y);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex2sv(short[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex3d(double x, double y, double z);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex3dv(double[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex3f(float x, float y, float z);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex3fv(float[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex3i(int x, int y, int z);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex3iv(int[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex3s(short x, short y, short z);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex3sv(short[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex4d(double x, double y, double z, double w);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex4dv(double[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex4f(float x, float y, float z, float w);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex4fv(float[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex4i(int x, int y, int z, int w);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex4iv(int[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex4s(short x, short y, short z, short w);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertex4sv(short[] v);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertexPointer(int size, uint type, int stride, IntPtr pointer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertexPointer(int size, uint type, int stride, short[] pointer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertexPointer(int size, uint type, int stride, int[] pointer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertexPointer(int size, uint type, int stride, float[] pointer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glVertexPointer(int size, uint type, int stride, double[] pointer);

        [DllImport(OPENGL_LIB, SetLastError = true)]
        private static extern void glViewport(int x, int y, int width, int height);
    }
}
