

using System;
using System.Linq;
using System.Collections.Generic;

using SharpGLX.Fonts;


namespace SharpGLX.Windows.Fonts {

    /// <summary>
    /// This class wraps the functionality of the wglUseFontOutlines function to
    /// allow straightforward rendering of text.
    /// </summary>
    public class WinFontOutlines : FontOutlines {
        #region		properties

        #endregion	properties


        #region		constructors & destructors
        public WinFontOutlines() {

        }
        #endregion	constructors & destructors


        #region		public methods & functions
        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="gl">The gl.</param>
        /// <param name="faceName">Name of the face.</param>
        /// <param name="deviation">The deviation.</param>
        /// <param name="extrusion">The extrusion.</param>
        /// <param name="text">The text.</param>
        /// <returns>True if the text was rendered, false if the underlying font could not be created.</returns>
        public override bool DrawText(OpenGL gl, string faceName, float deviation, float extrusion, string text) {
            return DrawText(gl, faceName, deviation, extrusion, text, out _);
        }
        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="gl">The gl.</param>
        /// <param name="faceName">Name of the face.</param>
        /// <param name="deviation">The deviation.</param>
        /// <param name="extrusion">The extrusion.</param>
        /// <param name="text">The text.</param>
        /// <param name="glyphMetrics"> </param>
        /// <returns>True if the text was rendered, false if the underlying font could not be created.</returns>
        public override bool DrawText(OpenGL gl, string faceName, float deviation, float extrusion, string text, out GLYPHMETRICSFLOAT[] glyphMetrics) {
            //  Do we have a font bitmap entry for this OpenGL instance and face name?
            //  If not, create one.
            const float tolerance = 0.01f;
            var fontOutlineEntry = (from fbe in fontOutlineEntries
                                    where fbe.HDC == gl.RenderContextProvider.DeviceContextHandle
                                             && fbe.HRC == gl.RenderContextProvider.RenderContextHandle
                                             && string.Compare(fbe.FaceName, faceName, StringComparison.OrdinalIgnoreCase) == 0
                                             && Math.Abs(fbe.Deviation - deviation) < tolerance
                                             && Math.Abs(fbe.Extrusion - extrusion) < tolerance
                                    select fbe).FirstOrDefault()
                                   ?? CreateFontOutlineEntry(gl, faceName, deviation, extrusion,
                                       FontOutlineFormat.Polygons);

            //  If we failed to create the outline entry we'll need to bail.
            if (fontOutlineEntry == null) {
                glyphMetrics = null;
                return false;
            }

            //  Set the list base.
            gl.ListBase(fontOutlineEntry.ListBase);

            //  Create an array of lists for the glyphs.
            var lists = text.Select(c => (byte) c).ToArray();

            //  Call the lists for the string.
            gl.CallLists(lists.Length, lists);
            gl.Flush();

            //  Return the glyph metrics used.
            glyphMetrics = fontOutlineEntry.GlyphMetrics;
            return true;
        }
        #endregion	public methods & functions


        #region		non-public methods & functions
        protected override FontOutlineEntry CreateFontOutlineEntry(OpenGL gl, string faceName, float deviation, float extrusion, FontOutlineFormat fontOutlineFormat) {
            //  Make the OpenGL instance current.
            gl.MakeCurrent();

            //  Create the font based on the face name.
            var hFont = Win32.CreateFont(12, 0, 0, 0, Win32.FW_DONTCARE, 0, 0, 0, Win32.DEFAULT_CHARSET,
                Win32.OUT_OUTLINE_PRECIS, Win32.CLIP_DEFAULT_PRECIS, Win32.CLEARTYPE_QUALITY, Win32.VARIABLE_PITCH, faceName);

            //  Select the font handle.
            var hOldObject = Win32.SelectObject(gl.RenderContextProvider.DeviceContextHandle, hFont);

            //  Create the list base.
            var listBase = gl.GenLists(1);

            //  Create space for the glyph metrics.
            var glyphMetrics = new GLYPHMETRICSFLOAT[255];

            //  Create the font bitmaps.
            bool result = Win32.wglUseFontOutlines(gl.RenderContextProvider.DeviceContextHandle, 0, 255, listBase,
                deviation, extrusion, (int)fontOutlineFormat, glyphMetrics);

            //  Reselect the old font.
            Win32.SelectObject(gl.RenderContextProvider.DeviceContextHandle, hOldObject);

            //  Free the font.
            Win32.DeleteObject(hFont);

            //  If we failed to create the font outlines, bail out now.
            if (result == false) return null;

            //  Create the font outline entry.
            var foe = new FontOutlineEntry() {
                HDC = gl.RenderContextProvider.DeviceContextHandle,
                HRC = gl.RenderContextProvider.RenderContextHandle,
                FaceName = faceName,
                ListBase = listBase,
                ListCount = 255,
                Deviation = deviation,
                Extrusion = extrusion,
                FontOutlineFormat = fontOutlineFormat,
                GlyphMetrics = glyphMetrics
            };

            //  Add the font bitmap entry to the internal list.
            return Add(foe);
        }
        #endregion	non-public methods & functions
    }
}
