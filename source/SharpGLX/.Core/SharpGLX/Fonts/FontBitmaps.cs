using System;
using System.Collections.Generic;


namespace SharpGLX.Fonts {

    /// <summary>
    /// A FontBitmap entry contains the details of a font face.
    /// </summary>
    public class FontBitmapEntry {
        public IntPtr HDC {
            get;
            set;
        }

        public IntPtr HRC {
            get;
            set;
        }

        public string FaceName {
            get;
            set;
        }

        public int Height {
            get;
            set;
        }

        public uint ListBase {
            get;
            set;
        }

        public uint ListCount {
            get;
            set;
        }
    }

    public abstract class FontBitmaps {
        /// <summary>
        /// Cache of font bitmap enties.
        /// </summary>
        protected readonly List<FontBitmapEntry> fontBitmapEntries = new List<FontBitmapEntry>();

        public abstract void DrawText(OpenGL gl, int x, int y, float r, float g, float b, string faceName, float fontSize, string text, double resWidth, double resHeight);

        protected abstract FontBitmapEntry CreateFontBitmapEntry(OpenGL gl, string faceName, int height);
        internal FontBitmapEntry Add(FontBitmapEntry fbe) {
            fontBitmapEntries.Add(fbe);

            return fbe;
        }
    }

}
