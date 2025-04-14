using CEngine.engine.data;

namespace CEngine
{
    internal class Screen
    {
        /// <summary>
        /// The size of the display-screen
        /// </summary>
        public Screen(int width, int height)
        {
            _DATA.AccurateScreenSize = new Vector2(width * 2, height);
            _DATA.wiWidth = width * 2;
            _DATA.oriWidth = width;
            _DATA.wiHeight = height;
        }

        public Screen(Vector2 size)
        {
            _DATA.AccurateScreenSize = new Vector2(size.x * 2, size.y);
            _DATA.wiWidth = size.x * 2;
            _DATA.oriWidth = size.x;
            _DATA.wiHeight = size.y;
        }
    }
}
