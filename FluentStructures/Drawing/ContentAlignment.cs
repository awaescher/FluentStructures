namespace FluentStructures.Drawing
{
    public enum ContentAlignment
    {
        //
        // Summary:
        //     Content is vertically aligned at the top, and horizontally aligned on the left.
        TopLeft = 1,
        //
        // Summary:
        //     Content is vertically aligned at the top, and horizontally aligned at the center.
        TopCenter = 2,
        //
        // Summary:
        //     Content is vertically aligned at the top, and horizontally aligned on the right.
        TopRight = 4,
        //
        // Summary:
        //     Content is vertically aligned in the middle, and horizontally aligned on the
        //     left.
        MiddleLeft = 0x10,
        //
        // Summary:
        //     Content is vertically aligned in the middle, and horizontally aligned at the
        //     center.
        MiddleCenter = 0x20,
        //
        // Summary:
        //     Content is vertically aligned in the middle, and horizontally aligned on the
        //     right.
        MiddleRight = 0x40,
        //
        // Summary:
        //     Content is vertically aligned at the bottom, and horizontally aligned on the
        //     left.
        BottomLeft = 0x100,
        //
        // Summary:
        //     Content is vertically aligned at the bottom, and horizontally aligned at the
        //     center.
        BottomCenter = 0x200,
        //
        // Summary:
        //     Content is vertically aligned at the bottom, and horizontally aligned on the
        //     right.
        BottomRight = 0x400
    }

    public static class ContentAlignmentExtensions
    {
        public static bool IsTop(this ContentAlignment alignment) => alignment == ContentAlignment.TopLeft || alignment == ContentAlignment.TopCenter || alignment == ContentAlignment.TopRight;

        public static bool IsMiddle(this ContentAlignment alignment) => alignment == ContentAlignment.MiddleLeft || alignment == ContentAlignment.MiddleCenter || alignment == ContentAlignment.MiddleRight;

        public static bool IsBottom(this ContentAlignment alignment) => alignment == ContentAlignment.BottomLeft || alignment == ContentAlignment.BottomCenter || alignment == ContentAlignment.BottomRight;

        public static bool IsLeft(this ContentAlignment alignment) => alignment == ContentAlignment.TopLeft || alignment == ContentAlignment.MiddleLeft || alignment == ContentAlignment.BottomLeft;

        public static bool IsCenter(this ContentAlignment alignment) => alignment == ContentAlignment.TopCenter || alignment == ContentAlignment.MiddleCenter || alignment == ContentAlignment.BottomCenter;

        public static bool IsRight(this ContentAlignment alignment) => alignment == ContentAlignment.TopRight || alignment == ContentAlignment.MiddleRight || alignment == ContentAlignment.BottomRight;
    }
}
