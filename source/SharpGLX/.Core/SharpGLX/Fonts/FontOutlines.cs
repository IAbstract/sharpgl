using System;
using System.Collections.Generic;


namespace SharpGLX.Fonts {

/// <summary>
/// A FontOutline entry contains the details of a font face.
/// </summary>
    public class FontOutlineEntry {
        /// <summary>
        /// Gets or sets the HDC.
        /// </summary>
        /// <value>
        /// The HDC.
        /// </value>
        public IntPtr HDC {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the HRC.
        /// </summary>
        /// <value>
        /// The HRC.
        /// </value>
        public IntPtr HRC {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the face.
        /// </summary>
        /// <value>
        /// The name of the face.
        /// </value>
        public string FaceName {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the list base.
        /// </summary>
        /// <value>
        /// The list base.
        /// </value>
        public uint ListBase {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the list count.
        /// </summary>
        /// <value>
        /// The list count.
        /// </value>
        public uint ListCount {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the deviation.
        /// </summary>
        /// <value>
        /// The deviation.
        /// </value>
        public float Deviation {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the extrusion.
        /// </summary>
        /// <value>
        /// The extrusion.
        /// </value>
        public float Extrusion {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the font outline format.
        /// </summary>
        /// <value>
        /// The font outline format.
        /// </value>
        public FontOutlineFormat FontOutlineFormat {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the glyph metrics.
        /// </summary>
        /// <value>
        /// The glyph metrics.
        /// </value>
        public GLYPHMETRICSFLOAT[] GlyphMetrics {
            get; set;
        }
    }

    /// <summary>
    /// The font outline format.
    /// </summary>
    public enum FontOutlineFormat {
        /// <summary>
        /// Render using lines.
        /// </summary>
        Lines = 0,

        /// <summary>
        /// Render using polygons.
        /// </summary>
        Polygons = 1
    }

    /// <summary>
    /// The GLYPHMETRICSFLOAT structure contains information about the placement and orientation of a glyph in a character cell.
    /// </summary>
    public struct GLYPHMETRICSFLOAT {
        /// <summary>
        /// Specifies the width of the smallest rectangle (the glyph's black box) that completely encloses the glyph..
        /// </summary>
        public float gmfBlackBoxX;
        /// <summary>
        /// Specifies the height of the smallest rectangle (the glyph's black box) that completely encloses the glyph.
        /// </summary>
        public float gmfBlackBoxY;
        /// <summary>
        /// Specifies the x and y coordinates of the upper-left corner of the smallest rectangle that completely encloses the glyph.
        /// </summary>
        public POINTFLOAT gmfptGlyphOrigin;
        /// <summary>
        /// Specifies the horizontal distance from the origin of the current character cell to the origin of the next character cell.
        /// </summary>
        public float gmfCellIncX;
        /// <summary>
        /// Specifies the vertical distance from the origin of the current character cell to the origin of the next character cell.
        /// </summary>
        public float gmfCellIncY;
    }

    /// <summary>
    /// Point structure used in Win32 interop.
    /// </summary>
    public struct POINTFLOAT {
        /// <summary>
        /// The x coord value.
        /// </summary>
        public float x;

        /// <summary>
        /// The y coord value.
        /// </summary>
        public float y;

    }

    public abstract class FontOutlines {
        #region		fields
        /// <summary>
        /// The cache of font outline entries.
        /// </summary>
        protected readonly List<FontOutlineEntry> fontOutlineEntries = new List<FontOutlineEntry>();
        #endregion	fields


        public abstract bool DrawText(OpenGL gl, string faceName, float deviation, float extrusion, string text);
        public abstract bool DrawText(OpenGL gl, string faceName, float deviation, float extrusion, string text, out GLYPHMETRICSFLOAT[] glyphMetrics);
        protected abstract FontOutlineEntry CreateFontOutlineEntry(OpenGL gl, string faceName, float deviation, float extrusion, FontOutlineFormat fontOutlineFormat);

        protected FontOutlineEntry Add(FontOutlineEntry foe) {
            fontOutlineEntries.Add(foe);

            return foe;
        }
    }

}
