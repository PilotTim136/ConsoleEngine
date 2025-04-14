namespace CEngine.engine.data
{
    internal class _DATA
    {
        ///////////////////////////////////////////////////
        ///                                             ///
        ///                  SETTINGS                   ///
        ///                                             ///
        ///////////////////////////////////////////////////

        //recommended screen size: 10, 10             (10, 10) MAX RECOMMENDED: (40, 20)
        public static Vector2 ScreenSize = new Vector2(10, 10); //screen size
        //recommended FPS: 60        (60)                      MAX RECOMMENDED: (999999)
        public static int TargetFPS = 60; //the FPS the game should run on


        //do NOT change stuff below!

        public static Vector2 AccurateScreenSize; //this will update automatically on runtime

        //screenData
        public static int wiHeight = 1, wiWidth = 1, oriWidth = 1;

        //gameObject data
        public static List<GameObject> objects = new List<GameObject>();

        //CEngine values
        public static List<CEngineBehaviour> behaviours = new List<CEngineBehaviour>();
    }
}
